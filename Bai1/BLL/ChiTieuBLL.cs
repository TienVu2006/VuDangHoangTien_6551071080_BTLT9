using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLChiTieu.DAL;
using QLChiTieu.DTO;
using Serilog;

namespace QLChiTieu.BLL;

/// <summary>
/// Business Logic Layer cho nghiệp vụ quản lý chi tiêu
/// </summary>
public class ChiTieuBLL
{
    private readonly ChiTieuDAL _dal = new();

    public async Task<List<ChiTieuDto>> LayDanhSachAsync()
    {
        var entities = await _dal.GetAllAsync();
        return entities.Select(ChiTieuDto.FromEntity).ToList();
    }

    public async Task<List<ChiTieuDto>> TraCuuAsync(string? noiDung, string? loaiChi, DateOnly? tuNgay, DateOnly? denNgay)
    {
        var entities = await _dal.FilterAsync(noiDung, loaiChi, tuNgay, denNgay);
        return entities.Select(ChiTieuDto.FromEntity).ToList();
    }

    public void KiemTraHopLe(ChiTieuDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.NoiDung))
        {
            throw new ArgumentException("Nội dung chi tiêu không được để trống!");
        }

        if (dto.SoTien <= 0)
        {
            throw new ArgumentException("Số tiền chi tiêu phải lớn hơn 0!");
        }

        var today = DateOnly.FromDateTime(DateTime.Today);
        if (dto.NgayChi > today)
        {
            throw new ArgumentException("Ngày chi không được lớn hơn ngày hiện tại (hôm nay)!");
        }

        if (string.IsNullOrWhiteSpace(dto.LoaiChi))
        {
            throw new ArgumentException("Vui lòng chọn loại chi hợp lệ!");
        }
    }

    public async Task<ChiTieuDto> ThemKhoanChiAsync(ChiTieuDto dto)
    {
        KiemTraHopLe(dto);

        var entity = dto.ToEntity();
        var result = await _dal.AddAsync(entity);

        Log.Information("Thêm khoản chi thành công: MaCT={MaCT}, NgàyChi={NgayChi}, Nội dung='{NoiDung}', Loại={LoaiChi}, Số tiền={SoTien}",
            result.MaCt, result.NgayChi, result.NoiDung, result.LoaiChi, result.SoTien);

        return ChiTieuDto.FromEntity(result);
    }

    public async Task<bool> SuaKhoanChiAsync(ChiTieuDto dto)
    {
        if (dto.MaCt <= 0)
        {
            throw new ArgumentException("Mã khoản chi không hợp lệ!");
        }

        KiemTraHopLe(dto);

        var entity = dto.ToEntity();
        var success = await _dal.UpdateAsync(entity);

        if (success)
        {
            Log.Information("Cập nhật khoản chi thành công: MaCT={MaCT}, NgàyChi={NgayChi}, Nội dung='{NoiDung}', Loại={LoaiChi}, Số tiền={SoTien}",
                dto.MaCt, dto.NgayChi, dto.NoiDung, dto.LoaiChi, dto.SoTien);
        }

        return success;
    }

    public async Task<bool> XoaKhoanChiAsync(int maCt)
    {
        if (maCt <= 0)
        {
            throw new ArgumentException("Mã khoản chi cần xóa không hợp lệ!");
        }

        var success = await _dal.DeleteAsync(maCt);
        if (success)
        {
            Log.Information("Xóa khoản chi thành công: MaCT={MaCT}", maCt);
        }

        return success;
    }

    public decimal TinhTongTien(IEnumerable<ChiTieuDto> danhSach)
    {
        return danhSach.Sum(c => c.SoTien);
    }
}
