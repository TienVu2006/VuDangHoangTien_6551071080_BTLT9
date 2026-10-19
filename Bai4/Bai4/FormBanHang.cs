using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using Bai4.Models;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Bai4
{
    public partial class FormBanHang : Form
    {
        private QL_TraSuaContext _db = new QL_TraSuaContext();
        private PaymentSettings _paymentConfig = new PaymentSettings();
        private List<CartItem> _gioHang = new List<CartItem>();
        private static readonly HttpClient _httpClient = new HttpClient();

        public FormBanHang()
        {
            InitializeComponent();
            LoadConfig();
            LoadDanhMuc();
        }

        private void LoadConfig()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _paymentConfig = config.GetSection("Payment").Get<PaymentSettings>() ?? new PaymentSettings();
        }

        private void LoadDanhMuc()
        {
            cboDanhMuc.DisplayMember = "TenDm";
            cboDanhMuc.ValueMember = "MaDm";
            cboDanhMuc.DataSource = _db.DanhMucMons.ToList();
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDanhMuc.SelectedValue is int maDM)
            {
                var dsMon = _db.MonUongs
                    .Where(m => m.MaDm == maDM && m.DangBan)
                    .Select(m => new { m.MaMon, HienThi = $"{m.TenMon} - {m.GiaBan:N0} đ", m.TenMon, m.GiaBan })
                    .ToList();

                lstMonUong.DataSource = dsMon;
                lstMonUong.DisplayMember = "HienThi";
                lstMonUong.ValueMember = "MaMon";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (lstMonUong.SelectedItem == null) return;

            dynamic selectedMon = lstMonUong.SelectedItem;
            int maMon = selectedMon.MaMon;
            string tenMon = selectedMon.TenMon;
            decimal donGia = selectedMon.GiaBan;
            int soLuong = (int)numSoLy.Value;

            var item = _gioHang.FirstOrDefault(g => g.MaMon == maMon);
            if (item != null)
            {
                item.SoLuong += soLuong;
            }
            else
            {
                _gioHang.Add(new CartItem
                {
                    MaMon = maMon,
                    TenMon = tenMon,
                    SoLuong = soLuong,
                    DonGia = donGia
                });
            }

            CapNhatGioHang();
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow?.DataBoundItem is CartItem item)
            {
                _gioHang.Remove(item);
                CapNhatGioHang();
            }
        }

        private void CapNhatGioHang()
        {
            dgvGioHang.DataSource = null;
            dgvGioHang.DataSource = _gioHang;
            decimal tongTien = _gioHang.Sum(x => x.ThanhTien);
            lblTongTien.Text = $"Tổng tiền: {tongTien:N0} đ";
        }

        private async void btnThanhToanCK_Click(object sender, EventArgs e)
        {
            decimal tongTien = _gioHang.Sum(x => x.ThanhTien);
            if (tongTien <= 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!");
                return;
            }

            int maHDTam = (_db.HoaDons.Max(h => (int?)h.MaHd) ?? 0) + 1;
            string noiDungCK = $"TRASUA HD{maHDTam}";

            picQRCode.Image?.Dispose();
            picQRCode.Image = null;
            lblSoTienChuyen.Text = $"Số tiền: {tongTien:N0} đ";
            lblNoiDungChuyen.Text = $"Nội dung: {noiDungCK}";
            lblThongTinCk.Text = $"STK: {_paymentConfig.AccountNo} - {_paymentConfig.BankId}";

            string bankId = Uri.EscapeDataString(_paymentConfig.BankId);
            string accountNo = Uri.EscapeDataString(_paymentConfig.AccountNo);
            string template = Uri.EscapeDataString(_paymentConfig.Template);
            string accountName = Uri.EscapeDataString(_paymentConfig.AccountName);
            string addInfo = Uri.EscapeDataString(noiDungCK);

            string qrUrl = $"https://img.vietqr.io/image/{bankId}-{accountNo}-{template}.png?amount={tongTien}&addInfo={addInfo}&accountName={accountName}";

            try
            {
                byte[] imageBytes = await _httpClient.GetByteArrayAsync(qrUrl);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                using (Image img = Image.FromStream(ms))
                {
                    picQRCode.Image = new Bitmap(img);
                }

                string maskedAccount = _paymentConfig.AccountNo.Length > 4
                    ? "***" + _paymentConfig.AccountNo.Substring(_paymentConfig.AccountNo.Length - 4)
                    : "***";
                Log.Information("Đã tạo VietQR cho HoaDon Temp {MaHD}, SoTien: {TongTien}, STK: {MaskedSTK}", maHDTam, tongTien, maskedAccount);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi tải ảnh QR VietQR cho HoaDon Temp {MaHD}", maHDTam);
                picQRCode.Image?.Dispose();
                picQRCode.Image = null;
                lblThongTinCk.Text = $"STK: {_paymentConfig.AccountNo} - {_paymentConfig.BankId}";
                MessageBox.Show(
                    "Không thể tải mã QR do mất mạng. Vui lòng chuyển khoản thủ công:\n\n" +
                    $"STK: {_paymentConfig.AccountNo} ({_paymentConfig.BankId})\n" +
                    $"Chủ TK: {_paymentConfig.AccountName}\n" +
                    $"Số tiền: {tongTien:N0} đ\n" +
                    $"Nội dung: {noiDungCK}");
            }
        }

        private void btnDaNhanTien_Click(object sender, EventArgs e)
        {
            LuuHoaDon("Chuyển khoản");
        }

        private void btnTienMat_Click(object sender, EventArgs e)
        {
            LuuHoaDon("Tiền mặt");
        }

        private void LuuHoaDon(string hinhThucTT)
        {
            decimal tongTien = _gioHang.Sum(x => x.ThanhTien);
            if (tongTien <= 0) return;

            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var hoaDon = new HoaDon
                    {
                        NgayLap = DateTime.Now,
                        TongTien = tongTien,
                        HinhThucTt = hinhThucTT,
                        DaThanhToan = true
                    };

                    foreach (var item in _gioHang)
                    {
                        hoaDon.ChiTietHoaDons.Add(new ChiTietHoaDon
                        {
                            MaMon = item.MaMon,
                            SoLy = item.SoLuong,
                            DonGia = item.DonGia
                        });
                    }

                    _db.HoaDons.Add(hoaDon);
                    _db.SaveChanges();
                    transaction.Commit();
                    Log.Information("Đã lưu hóa đơn {MaHD}: {HinhThucTt}, {TongTien} đ, {SoMon} món",
                        hoaDon.MaHd, hinhThucTT, tongTien, _gioHang.Count);

                    MessageBox.Show($"Thanh toán thành công! Mã HD: {hoaDon.MaHd}");
                    _gioHang.Clear();
                    CapNhatGioHang();
                    picQRCode.Image?.Dispose();
                    picQRCode.Image = null;
                    lblThongTinCk.Text = string.Empty;
                    lblSoTienChuyen.Text = "Số tiền:";
                    lblNoiDungChuyen.Text = "Nội dung:";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Log.Error(ex, "Lỗi lưu hóa đơn");
                    MessageBox.Show("Lỗi trong quá trình lưu hóa đơn!");
                }
            }
        }

        private void picQRCode_Click(object sender, EventArgs e)
        {

        }
    }

    public class PaymentSettings
    {
        public string BankId { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string Template { get; set; } = string.Empty;
        public string TenQuan { get; set; } = string.Empty;
    }

    public class CartItem
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien => SoLuong * DonGia;
    }
}