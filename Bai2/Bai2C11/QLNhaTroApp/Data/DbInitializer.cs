using Microsoft.EntityFrameworkCore;
using QLNhaTroApp.Models;
using Serilog;

namespace QLNhaTroApp.Data;

public static class DbInitializer
{
    public static void Initialize(QLNhaTroContext context)
    {
        try
        {
            // Kiểm tra và khởi tạo dữ liệu chuẩn tiếng Việt có dấu
            // Cập nhật lại danh sách phòng trọ
            var existingRooms = context.PhongTros.ToList();
            if (existingRooms.Count == 0)
            {
                var rooms = new List<PhongTro>
                {
                    new PhongTro { TenPhong = "P01", GiaThue = 1500000, TinhTrang = "Đang thuê" },
                    new PhongTro { TenPhong = "P02", GiaThue = 1600000, TinhTrang = "Đang thuê" },
                    new PhongTro { TenPhong = "P03", GiaThue = 1800000, TinhTrang = "Đang thuê" },
                    new PhongTro { TenPhong = "P04", GiaThue = 2000000, TinhTrang = "Đang thuê" },
                    new PhongTro { TenPhong = "P05", GiaThue = 1700000, TinhTrang = "Đang thuê" },
                    new PhongTro { TenPhong = "P06", GiaThue = 2200000, TinhTrang = "Trống" }
                };
                context.PhongTros.AddRange(rooms);
                context.SaveChanges();
            }
            else
            {
                // Chuẩn hóa tên và trạng thái phòng nếu trước đó bị lỗi font
                foreach (var r in existingRooms)
                {
                    if (r.TinhTrang.Contains("?") || r.TinhTrang.Contains("Ä") || r.TinhTrang.Contains("ang"))
                    {
                        r.TinhTrang = r.TinhTrang.Contains("Tr") ? "Trống" : "Đang thuê";
                    }
                }
                context.SaveChanges();
            }

            // Cập nhật lại danh sách khách thuê với tiếng Việt chuẩn và mã API khớp chính xác
            var existingGuests = context.KhachThues.ToList();
            // Nếu phát hiện font bị lỗi (chứa ký tự lạ) hoặc khởi tạo lần đầu
            bool needUpdate = existingGuests.Any(g => g.HoTen.Contains("?") || g.HoTen.Contains("Ã") || g.HoTen.Contains("Trá"));
            if (existingGuests.Count == 0 || needUpdate)
            {
                context.KhachThues.RemoveRange(existingGuests);
                context.SaveChanges();

                // Lấy ID phòng thực tế từ DB
                var rooms = context.PhongTros.OrderBy(p => p.MaPhong).ToList();
                int p01 = rooms.FirstOrDefault(r => r.TenPhong == "P01")?.MaPhong ?? 1;
                int p02 = rooms.FirstOrDefault(r => r.TenPhong == "P02")?.MaPhong ?? 2;
                int p03 = rooms.FirstOrDefault(r => r.TenPhong == "P03")?.MaPhong ?? 3;
                int p04 = rooms.FirstOrDefault(r => r.TenPhong == "P04")?.MaPhong ?? 4;
                int p05 = rooms.FirstOrDefault(r => r.TenPhong == "P05")?.MaPhong ?? 5;

                var guests = new List<KhachThue>
                {
                    new KhachThue
                    {
                        HoTen = "Nguyễn Văn",
                        GioiTinh = "Nam",
                        NgaySinh = new DateOnly(2000, 1, 15),
                        SoDienThoai = "0912345678",
                        MaTinh = 1,
                        TenTinh = "Thành phố Hà Nội",
                        MaPhuongXa = 4,
                        TenPhuongXa = "Phường Ba Đình",
                        DaDangKyTamTru = false,
                        MaPhong = p03
                    },
                    new KhachThue
                    {
                        HoTen = "Nguyễn Văn An",
                        GioiTinh = "Nam",
                        NgaySinh = new DateOnly(2004, 5, 12),
                        SoDienThoai = "0912345678",
                        MaTinh = 1,
                        TenTinh = "Thành phố Hà Nội",
                        MaPhuongXa = 4,
                        TenPhuongXa = "Phường Ba Đình",
                        DaDangKyTamTru = true,
                        MaPhong = p03
                    },
                    new KhachThue
                    {
                        HoTen = "Trần Thị Bình",
                        GioiTinh = "Nữ",
                        NgaySinh = new DateOnly(2002, 8, 20),
                        SoDienThoai = "0876543210",
                        MaTinh = 37,
                        TenTinh = "Tỉnh Ninh Bình",
                        MaPhuongXa = 14494, // Mã chuẩn của Xã Gia Trấn trên API open-api.vn
                        TenPhuongXa = "Xã Gia Trấn",
                        DaDangKyTamTru = false,
                        MaPhong = p01
                    },
                    new KhachThue
                    {
                        HoTen = "Lê Văn Cường",
                        GioiTinh = "Nam",
                        NgaySinh = new DateOnly(1999, 11, 3),
                        SoDienThoai = "0901234567",
                        MaTinh = 38,
                        TenTinh = "Tỉnh Thanh Hóa",
                        MaPhuongXa = 16171, // Mã chuẩn Xã Ba Đình, Thanh Hóa
                        TenPhuongXa = "Xã Ba Đình",
                        DaDangKyTamTru = false,
                        MaPhong = p02
                    },
                    new KhachThue
                    {
                        HoTen = "Phạm Minh Đức",
                        GioiTinh = "Nam",
                        NgaySinh = new DateOnly(2001, 3, 25),
                        SoDienThoai = "0987654321",
                        MaTinh = 38,
                        TenTinh = "Tỉnh Thanh Hóa",
                        MaPhuongXa = 14758, // Mã chuẩn Phường Hàm Rồng, Thanh Hóa
                        TenPhuongXa = "Phường Hàm Rồng",
                        DaDangKyTamTru = false,
                        MaPhong = p04
                    },
                    new KhachThue
                    {
                        HoTen = "Hoàng Thị Dung",
                        GioiTinh = "Nữ",
                        NgaySinh = new DateOnly(2003, 7, 14),
                        SoDienThoai = "0765432109",
                        MaTinh = 24,
                        TenTinh = "Thành phố Bắc Ninh",
                        MaPhuongXa = 9187, // Mã chuẩn Phường Kinh Bắc, Bắc Ninh
                        TenPhuongXa = "Phường Kinh Bắc",
                        DaDangKyTamTru = false,
                        MaPhong = p05
                    }
                };

                context.KhachThues.AddRange(guests);
                context.SaveChanges();
                Log.Information("Đã khởi tạo và chuẩn hóa dữ liệu mẫu tiếng Việt chuẩn.");
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi trong quá trình khởi tạo/chuẩn hóa dữ liệu DbInitializer.");
        }
    }
}
