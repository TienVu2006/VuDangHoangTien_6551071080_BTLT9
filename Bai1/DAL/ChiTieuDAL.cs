using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLChiTieu.Models;
using Serilog;

namespace QLChiTieu.DAL;

/// <summary>
/// Data Access Layer cho bảng ChiTieu sử dụng EF Core Database First
/// </summary>
public class ChiTieuDAL
{
    public async Task<List<ChiTieu>> GetAllAsync()
    {
        try
        {
            using var context = new QLChiTieuContext();
            return await context.ChiTieus
                .AsNoTracking()
                .OrderByDescending(c => c.NgayChi)
                .ThenByDescending(c => c.MaCt)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi truy cập CSDL tại ChiTieuDAL.GetAllAsync");
            throw;
        }
    }

    public async Task<ChiTieu?> GetByIdAsync(int maCt)
    {
        try
        {
            using var context = new QLChiTieuContext();
            return await context.ChiTieus
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.MaCt == maCt);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi truy cập CSDL tại ChiTieuDAL.GetByIdAsync với MaCT={MaCT}", maCt);
            throw;
        }
    }

    public async Task<List<ChiTieu>> FilterAsync(string? noiDung, string? loaiChi, DateOnly? tuNgay, DateOnly? denNgay)
    {
        try
        {
            using var context = new QLChiTieuContext();
            var query = context.ChiTieus.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(noiDung))
            {
                var keyword = noiDung.Trim().ToLower();
                query = query.Where(c => c.NoiDung.ToLower().Contains(keyword));
            }

            if (!string.IsNullOrWhiteSpace(loaiChi) && loaiChi != "Tất cả")
            {
                query = query.Where(c => c.LoaiChi == loaiChi);
            }

            if (tuNgay.HasValue)
            {
                query = query.Where(c => c.NgayChi >= tuNgay.Value);
            }

            if (denNgay.HasValue)
            {
                query = query.Where(c => c.NgayChi <= denNgay.Value);
            }

            return await query
                .OrderByDescending(c => c.NgayChi)
                .ThenByDescending(c => c.MaCt)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi truy cập CSDL tại ChiTieuDAL.FilterAsync");
            throw;
        }
    }

    public async Task<ChiTieu> AddAsync(ChiTieu entity)
    {
        try
        {
            using var context = new QLChiTieuContext();
            context.ChiTieus.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi truy cập CSDL tại ChiTieuDAL.AddAsync với Nội dung='{NoiDung}'", entity.NoiDung);
            throw;
        }
    }

    public async Task<bool> UpdateAsync(ChiTieu entity)
    {
        try
        {
            using var context = new QLChiTieuContext();
            var existing = await context.ChiTieus.FirstOrDefaultAsync(c => c.MaCt == entity.MaCt);
            if (existing == null)
            {
                return false;
            }

            existing.NgayChi = entity.NgayChi;
            existing.NoiDung = entity.NoiDung;
            existing.LoaiChi = entity.LoaiChi;
            existing.SoTien = entity.SoTien;
            existing.GhiChu = entity.GhiChu;

            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi truy cập CSDL tại ChiTieuDAL.UpdateAsync với MaCT={MaCT}", entity.MaCt);
            throw;
        }
    }

    public async Task<bool> DeleteAsync(int maCt)
    {
        try
        {
            using var context = new QLChiTieuContext();
            var existing = await context.ChiTieus.FirstOrDefaultAsync(c => c.MaCt == maCt);
            if (existing == null)
            {
                return false;
            }

            context.ChiTieus.Remove(existing);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi truy cập CSDL tại ChiTieuDAL.DeleteAsync với MaCT={MaCT}", maCt);
            throw;
        }
    }
}
