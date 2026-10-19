using System;
using System.Globalization;
using QLChiTieu.Models;

namespace QLChiTieu.DTO;

/// <summary>
/// Data Transfer Object cho ChiTieu - truyền giữa DAL, BLL và GUI
/// </summary>
public class ChiTieuDto
{
    public int MaCt { get; set; }
    public string MaHienThi => MaCt.ToString("D3");
    public DateOnly NgayChi { get; set; }
    public string NgayChiHienThi => NgayChi.ToString("dd/MM/yyyy");
    public string NoiDung { get; set; } = string.Empty;
    public string LoaiChi { get; set; } = string.Empty;
    public decimal SoTien { get; set; }
    public string SoTienHienThi => SoTien.ToString("N0", new CultureInfo("vi-VN"));
    public string? GhiChu { get; set; }

    public static ChiTieuDto FromEntity(ChiTieu entity)
    {
        return new ChiTieuDto
        {
            MaCt = entity.MaCt,
            NgayChi = entity.NgayChi,
            NoiDung = entity.NoiDung,
            LoaiChi = entity.LoaiChi,
            SoTien = entity.SoTien,
            GhiChu = entity.GhiChu
        };
    }

    public ChiTieu ToEntity()
    {
        return new ChiTieu
        {
            MaCt = this.MaCt,
            NgayChi = this.NgayChi,
            NoiDung = this.NoiDung,
            LoaiChi = this.LoaiChi,
            SoTien = this.SoTien,
            GhiChu = this.GhiChu
        };
    }
}
