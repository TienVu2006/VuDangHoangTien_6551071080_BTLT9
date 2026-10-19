using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Bai4.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai4
{
    public partial class FormDanhSachHoaDon : Form
    {
        private QL_TraSuaContext _db = new QL_TraSuaContext();

        public FormDanhSachHoaDon()
        {
            InitializeComponent();
            dtpNgay.Value = DateTime.Now;
            LoadHoaDon();
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadHoaDon();
        }

        private void LoadHoaDon()
        {
            DateTime ngayChon = dtpNgay.Value.Date;

            var dsHoaDon = _db.HoaDons
                .Where(h => h.NgayLap.Date == ngayChon && h.DaThanhToan)
                .Select(h => new
                {
                    h.MaHd,
                    GioLap = h.NgayLap.ToString("HH:mm:ss"),
                    h.HinhThucTt,
                    h.TongTien
                })
                .ToList();

            dgvHoaDon.DataSource = dsHoaDon;

            decimal doanhThuNgay = dsHoaDon.Sum(h => h.TongTien);
            lblDoanhThu.Text = $"Doanh thu ngày: {doanhThuNgay:N0} đ";
        }

        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                int maHD = (int)dgvHoaDon.CurrentRow.Cells["MaHd"].Value;

                var chiTiet = _db.ChiTietHoaDons
                    .Where(ct => ct.MaHd == maHD)
                    .Include(ct => ct.MaMonNavigation)
                    .Select(ct => new
                    {
                        TenMon = ct.MaMonNavigation.TenMon,
                        ct.SoLy,
                        ct.DonGia,
                        ThanhTien = ct.SoLy * ct.DonGia
                    })
                    .ToList();

                dgvChiTiet.DataSource = chiTiet;
            }
        }
    }
}