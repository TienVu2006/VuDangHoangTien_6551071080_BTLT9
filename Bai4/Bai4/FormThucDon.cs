using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Bai4.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai4
{
    public partial class FormThucDon : Form
    {
        private QL_TraSuaContext _db = new QL_TraSuaContext();

        public FormThucDon()
        {
            InitializeComponent();
            LoadDanhMuc();
            HienThiDanhSach();
        }

        private void LoadDanhMuc()
        {
            cboDanhMuc.DisplayMember = "TenDm";
            cboDanhMuc.ValueMember = "MaDm";
            cboDanhMuc.DataSource = _db.DanhMucMons.ToList();
        }

        private void HienThiDanhSach()
        {
            var query = _db.MonUongs.Include(m => m.MaDmNavigation).AsQueryable();

            if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                query = query.Where(m => m.TenMon.Contains(txtTimKiem.Text.Trim()));
            }

            dgvMonUong.DataSource = query.Select(m => new
            {
                m.MaMon,
                m.TenMon,
                m.GiaBan,
                m.DangBan,
                TenDanhMuc = m.MaDmNavigation.TenDm
            }).ToList();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var mon = new MonUong
            {
                TenMon = txtTenMon.Text.Trim(),
                GiaBan = numGiaBan.Value,
                DangBan = chkDangBan.Checked,
                MaDm = (int)cboDanhMuc.SelectedValue
            };
            _db.MonUongs.Add(mon);
            _db.SaveChanges();
            HienThiDanhSach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvMonUong.CurrentRow != null)
            {
                int maMon = (int)dgvMonUong.CurrentRow.Cells["MaMon"].Value;
                var mon = _db.MonUongs.Find(maMon);
                if (mon != null)
                {
                    mon.TenMon = txtTenMon.Text.Trim();
                    mon.GiaBan = numGiaBan.Value;
                    mon.DangBan = chkDangBan.Checked;
                    mon.MaDm = (int)cboDanhMuc.SelectedValue;
                    _db.SaveChanges();
                    HienThiDanhSach();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvMonUong.CurrentRow != null)
            {
                int maMon = (int)dgvMonUong.CurrentRow.Cells["MaMon"].Value;
                var mon = _db.MonUongs.Find(maMon);
                if (mon != null)
                {
                    _db.MonUongs.Remove(mon);
                    _db.SaveChanges();
                    HienThiDanhSach();
                }
            }
        }

        private void dgvMonUong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMonUong.CurrentRow != null)
            {
                txtTenMon.Text = dgvMonUong.CurrentRow.Cells["TenMon"].Value?.ToString();
                numGiaBan.Value = Convert.ToDecimal(dgvMonUong.CurrentRow.Cells["GiaBan"].Value);
                chkDangBan.Checked = Convert.ToBoolean(dgvMonUong.CurrentRow.Cells["DangBan"].Value);
            }
        }
    }
}