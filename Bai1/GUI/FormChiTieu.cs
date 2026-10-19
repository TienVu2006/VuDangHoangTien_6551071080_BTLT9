using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLChiTieu.BLL;
using QLChiTieu.DTO;
using Serilog;

namespace QLChiTieu.GUI;

public partial class FormChiTieu : Form
{
    private readonly ChiTieuBLL _bll = new();
    private List<ChiTieuDto> _currentList = new();
    private int _selectedMaCt = 0;

    public FormChiTieu()
    {
        InitializeComponent();
        DangKySuKien();
    }

    private void DangKySuKien()
    {
        this.Load += async (s, e) => await FormChiTieu_LoadAsync();

        // Sự kiện thao tác CRUD
        this.btnThem.Click += async (s, e) => await ThemKhoanChiAsync();
        this.btnSua.Click += async (s, e) => await SuaKhoanChiAsync();
        this.btnXoa.Click += async (s, e) => await XoaKhoanChiAsync();
        this.btnLamMoi.Click += async (s, e) => await LamMoiToanBoAsync();

        // Sự kiện tìm kiếm / lọc
        this.btnTim.Click += async (s, e) => await TimKiemAsync();
        this.txtTimNoiDung.KeyDown += async (s, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await TimKiemAsync();
            }
        };

        // Lọc nhanh khi chọn lại ComboBox loại chi ở nhóm Tìm kiếm
        this.cboTimLoaiChi.SelectedIndexChanged += async (s, e) => await TimKiemAsync();

        // Sự kiện DataGridView
        this.dgvChiTieu.CellClick += DgvChiTieu_CellClick;
    }

    private async Task FormChiTieu_LoadAsync()
    {
        try
        {
            // Thiết lập giá trị mặc định cho control
            dtpNgayChi.Value = DateTime.Today;
            dtpNgayChi.MaxDate = DateTime.Today;

            if (cboLoaiChi.Items.Count > 0)
                cboLoaiChi.SelectedIndex = 0;

            if (cboTimLoaiChi.Items.Count > 0)
                cboTimLoaiChi.SelectedIndex = 0;

            // Mặc định khoảng ngày tìm kiếm: từ đầu tháng hiện tại đến hôm nay
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDenNgay.Value = DateTime.Today;

            await TaiDuLieuAsync();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi xảy ra khi nạp FormChiTieu_Load");
            MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu ban đầu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Nạp toàn bộ danh sách chi tiêu bất đồng bộ (Non-blocking UI)
    /// </summary>
    private async Task TaiDuLieuAsync()
    {
        try
        {
            SetLoadingState(true);
            _currentList = await _bll.LayDanhSachAsync();
            CapNhatBangVaTongTien(_currentList);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi gọi TaiDuLieuAsync");
            MessageBox.Show("Không thể tải danh sách chi tiêu từ cơ sở dữ liệu: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            SetLoadingState(false);
        }
    }

    /// <summary>
    /// Cập nhật hiển thị DataGridView và Label Tổng chi
    /// </summary>
    private void CapNhatBangVaTongTien(List<ChiTieuDto> danhSach)
    {
        dgvChiTieu.DataSource = null;
        dgvChiTieu.DataSource = danhSach;

        decimal tongTien = _bll.TinhTongTien(danhSach);
        lblTongChi.Text = $"Tổng chi: {tongTien.ToString("N0", new CultureInfo("vi-VN"))} đ";
    }

    /// <summary>
    /// Xử lý click chọn một dòng trong DataGridView (Task 3)
    /// </summary>
    private void DgvChiTieu_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        // Chống lỗi khi click vào Header
        if (e.RowIndex < 0 || e.RowIndex >= _currentList.Count)
            return;

        errorProvider1.Clear();
        var item = _currentList[e.RowIndex];
        _selectedMaCt = item.MaCt;

        // Điền dữ liệu lên các input control
        dtpNgayChi.Value = new DateTime(item.NgayChi.Year, item.NgayChi.Month, item.NgayChi.Day);
        txtNoiDung.Text = item.NoiDung;

        var loaiIndex = cboLoaiChi.FindStringExact(item.LoaiChi);
        if (loaiIndex >= 0)
            cboLoaiChi.SelectedIndex = loaiIndex;
        else
            cboLoaiChi.Text = item.LoaiChi;

        nudSoTien.Value = item.SoTien;
        txtGhiChu.Text = item.GhiChu ?? string.Empty;
    }

    /// <summary>
    /// Kiểm tra tính hợp lệ dữ liệu nhập (Validation với ErrorProvider)
    /// </summary>
    private bool ValidateInput(out ChiTieuDto dto)
    {
        dto = new ChiTieuDto();
        errorProvider1.Clear();
        bool isValid = true;

        var noiDung = txtNoiDung.Text.Trim();
        if (string.IsNullOrWhiteSpace(noiDung))
        {
            errorProvider1.SetError(txtNoiDung, "Nội dung chi tiêu không được để trống!");
            isValid = false;
        }

        if (nudSoTien.Value <= 0)
        {
            errorProvider1.SetError(nudSoTien, "Số tiền chi tiêu phải lớn hơn 0!");
            isValid = false;
        }

        if (dtpNgayChi.Value.Date > DateTime.Today)
        {
            errorProvider1.SetError(dtpNgayChi, "Ngày chi không được lớn hơn ngày hôm nay!");
            isValid = false;
        }

        if (cboLoaiChi.SelectedIndex < 0 || string.IsNullOrWhiteSpace(cboLoaiChi.Text))
        {
            errorProvider1.SetError(cboLoaiChi, "Vui lòng chọn loại chi!");
            isValid = false;
        }

        if (!isValid)
            return false;

        dto.MaCt = _selectedMaCt;
        dto.NgayChi = DateOnly.FromDateTime(dtpNgayChi.Value.Date);
        dto.NoiDung = noiDung;
        dto.LoaiChi = cboLoaiChi.Text.Trim();
        dto.SoTien = nudSoTien.Value;
        dto.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();

        return true;
    }

    /// <summary>
    /// Thêm khoản chi mới (Task 3)
    /// </summary>
    private async Task ThemKhoanChiAsync()
    {
        if (!ValidateInput(out var dto))
            return;

        try
        {
            SetLoadingState(true);
            dto.MaCt = 0; // Thêm mới để identity tự sinh
            var kq = await _bll.ThemKhoanChiAsync(dto);

            MessageBox.Show($"Thêm mới khoản chi thành công! (Mã: {kq.MaHienThi})", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LamMoiControlNhap();
            await TaiDuLieuAsync();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi thực hiện Thêm khoản chi");
            MessageBox.Show("Có lỗi xảy ra khi thêm khoản chi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            SetLoadingState(false);
        }
    }

    /// <summary>
    /// Sửa khoản chi đã chọn (Task 3)
    /// </summary>
    private async Task SuaKhoanChiAsync()
    {
        if (_selectedMaCt <= 0)
        {
            MessageBox.Show("Vui lòng chọn một dòng khoản chi trên danh sách để sửa!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateInput(out var dto))
            return;

        try
        {
            SetLoadingState(true);
            dto.MaCt = _selectedMaCt;
            var success = await _bll.SuaKhoanChiAsync(dto);

            if (success)
            {
                MessageBox.Show($"Cập nhật khoản chi mã {dto.MaHienThi} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiControlNhap();
                await TaiDuLieuAsync();
            }
            else
            {
                MessageBox.Show("Không tìm thấy khoản chi cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi thực hiện Sửa khoản chi MaCT={MaCT}", _selectedMaCt);
            MessageBox.Show("Có lỗi xảy ra khi sửa khoản chi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            SetLoadingState(false);
        }
    }

    /// <summary>
    /// Xóa khoản chi có xác nhận (Task 3)
    /// </summary>
    private async Task XoaKhoanChiAsync()
    {
        if (_selectedMaCt <= 0)
        {
            MessageBox.Show("Vui lòng chọn một khoản chi trên danh sách để xóa!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var xacNhan = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa khoản chi '{txtNoiDung.Text}' (Mã: {_selectedMaCt.ToString("D3")}) không?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2
        );

        if (xacNhan != DialogResult.Yes)
            return;

        try
        {
            SetLoadingState(true);
            var success = await _bll.XoaKhoanChiAsync(_selectedMaCt);

            if (success)
            {
                MessageBox.Show("Đã xóa khoản chi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiControlNhap();
                await TaiDuLieuAsync();
            }
            else
            {
                MessageBox.Show("Không tìm thấy khoản chi để xóa trong CSDL!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi xóa khoản chi MaCT={MaCT}", _selectedMaCt);
            MessageBox.Show("Có lỗi xảy ra khi xóa khoản chi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            SetLoadingState(false);
        }
    }

    /// <summary>
    /// Tìm kiếm và lọc theo nội dung, loại chi, khoảng thời gian (Task 4)
    /// </summary>
    private async Task TimKiemAsync()
    {
        try
        {
            SetLoadingState(true);

            string? noiDung = string.IsNullOrWhiteSpace(txtTimNoiDung.Text) ? null : txtTimNoiDung.Text.Trim();
            string? loaiChi = cboTimLoaiChi.Text;
            DateOnly tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value.Date);
            DateOnly denNgay = DateOnly.FromDateTime(dtpDenNgay.Value.Date);

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Giá trị 'Từ ngày' không được lớn hơn 'Đến ngày'!", "Lỗi bộ lọc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _currentList = await _bll.TraCuuAsync(noiDung, loaiChi, tuNgay, denNgay);
            CapNhatBangVaTongTien(_currentList);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi lọc dữ liệu");
            MessageBox.Show("Có lỗi xảy ra khi tìm kiếm/lọc: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            SetLoadingState(false);
        }
    }

    /// <summary>
    /// Làm mới các ô nhập liệu bên trái
    /// </summary>
    private void LamMoiControlNhap()
    {
        _selectedMaCt = 0;
        dtpNgayChi.Value = DateTime.Today;
        txtNoiDung.Clear();
        if (cboLoaiChi.Items.Count > 0)
            cboLoaiChi.SelectedIndex = 0;
        nudSoTien.Value = 0;
        txtGhiChu.Clear();
        errorProvider1.Clear();
        dgvChiTieu.ClearSelection();
    }

    /// <summary>
    /// Làm mới toàn bộ (Làm mới ô nhập + bộ lọc và nạp lại danh sách gốc)
    /// </summary>
    private async Task LamMoiToanBoAsync()
    {
        LamMoiControlNhap();

        txtTimNoiDung.Clear();
        if (cboTimLoaiChi.Items.Count > 0)
            cboTimLoaiChi.SelectedIndex = 0;

        dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        dtpDenNgay.Value = DateTime.Today;

        await TaiDuLieuAsync();
    }

    private void SetLoadingState(bool isLoading)
    {
        this.Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;
        btnThem.Enabled = !isLoading;
        btnSua.Enabled = !isLoading;
        btnXoa.Enabled = !isLoading;
        btnLamMoi.Enabled = !isLoading;
        btnTim.Enabled = !isLoading;
    }
}
