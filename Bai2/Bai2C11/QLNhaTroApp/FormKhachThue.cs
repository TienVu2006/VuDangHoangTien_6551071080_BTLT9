using System.Data;
using Microsoft.EntityFrameworkCore;
using QLNhaTroApp.Data;
using QLNhaTroApp.Models;
using QLNhaTroApp.Services;
using Serilog;

namespace QLNhaTroApp;

public partial class FormKhachThue : Form
{
    private int _selectedMaKhach = 0;
    private bool _isLoadingAddress = false;
    private List<ProvinceDto> _provinceList = new();

    public class KhachThueViewModel
    {
        public int MaKhach { get; set; }
        public string HoTen { get; set; } = string.Empty;
        public string GioiTinh { get; set; } = "Nam";
        public DateOnly NgaySinh { get; set; }
        public string SoDienThoai { get; set; } = string.Empty;
        public int MaPhong { get; set; }
        public string TenPhong { get; set; } = string.Empty;
        public decimal GiaThue { get; set; }
        public string GiaThueFormat => GiaThue.ToString("#,##0") + " đ";
        public int MaTinh { get; set; }
        public string TenTinh { get; set; } = string.Empty;
        public int MaPhuongXa { get; set; }
        public string TenPhuongXa { get; set; } = string.Empty;
        public string QueQuan => $"{TenPhuongXa} – {TenTinh}";
        public bool DaDangKyTamTru { get; set; }
    }

    public class RoomItem
    {
        public int MaPhong { get; set; }
        public string DisplayText { get; set; } = string.Empty;
        public override string ToString() => DisplayText;
    }

    public FormKhachThue()
    {
        InitializeComponent();
    }

    private async void FormKhachThue_Load(object sender, EventArgs e)
    {
        try
        {
            using (var ctx = new QLNhaTroContext())
            {
                DbInitializer.Initialize(ctx);
            }

            await LoadProvincesAsync();
            LoadRoomsToComboBox();
            LoadDataGridKhachThue();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi nạp dữ liệu ban đầu cho form.");
            MessageBox.Show("Có lỗi xảy ra khi nạp dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    #region Task 3 & Task 8: Tích hợp API và Chịu lỗi mạng
    private async Task LoadProvincesAsync()
    {
        _isLoadingAddress = true;
        cboTinhThanh.Enabled = false;
        cboPhuongXa.Enabled = false;
        cboTinhThanh.Text = "Đang tải…";
        cboPhuongXa.Text = "Đang tải…";

        try
        {
            var provinces = await AddressApiService.GetProvincesAsync();
            if (provinces != null && provinces.Count > 0)
            {
                _provinceList = provinces;
                cboTinhThanh.DropDownStyle = ComboBoxStyle.DropDownList;
                cboTinhThanh.DataSource = _provinceList;
                cboTinhThanh.DisplayMember = "Name";
                cboTinhThanh.ValueMember = "Code";
                cboTinhThanh.Enabled = true;

                // Nạp cho combobox lọc tỉnh
                var locTinhList = new List<ProvinceDto>
                {
                    new ProvinceDto { Code = 0, Name = "Tất cả tỉnh" }
                };
                locTinhList.AddRange(_provinceList);
                cboLocTinh.DataSource = locTinhList;
                cboLocTinh.DisplayMember = "Name";
                cboLocTinh.ValueMember = "Code";
                cboLocTinh.SelectedIndex = 0;

                lblStatus.Text = $"Đã tải {_provinceList.Count} tỉnh/thành từ provinces.open-api.vn";

                // Nạp phường/xã của tỉnh đầu tiên
                if (cboTinhThanh.SelectedValue is int firstCode)
                {
                    await LoadWardsAsync(firstCode);
                }
            }
        }
        catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException)
        {
            // Task 8: Chịu lỗi mạng
            lblStatus.Text = "Lỗi kết nối API tỉnh/thành - Cho phép nhập tay địa chỉ.";
            MessageBox.Show("Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng.\nBạn vẫn có thể gõ trực tiếp tên Tỉnh và Phường/Xã.",
                "Cảnh báo kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Cho phép người dùng gõ tay
            cboTinhThanh.DropDownStyle = ComboBoxStyle.DropDown;
            cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;
            cboTinhThanh.Enabled = true;
            cboPhuongXa.Enabled = true;
            cboTinhThanh.Text = "";
            cboPhuongXa.Text = "";
        }
        finally
        {
            _isLoadingAddress = false;
        }
    }

    private async Task LoadWardsAsync(int provinceCode, int selectWardCode = 0, string fallbackWardName = "")
    {
        _isLoadingAddress = true;
        cboPhuongXa.Enabled = false;
        cboPhuongXa.DataSource = null;
        cboPhuongXa.Text = "Đang tải…";

        try
        {
            var wards = await AddressApiService.GetWardsAsync(provinceCode);
            if (wards != null && wards.Count > 0)
            {
                cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDownList;
                cboPhuongXa.DataSource = wards;
                cboPhuongXa.DisplayMember = "Name";
                cboPhuongXa.ValueMember = "Code";
                cboPhuongXa.Enabled = true;

                if (selectWardCode > 0)
                {
                    cboPhuongXa.SelectedValue = selectWardCode;
                }

                // Nếu không match được bằng code, thử tìm theo tên
                if (cboPhuongXa.SelectedIndex == -1 && !string.IsNullOrWhiteSpace(fallbackWardName))
                {
                    var match = wards.FirstOrDefault(w => w.Name.Equals(fallbackWardName, StringComparison.OrdinalIgnoreCase));
                    if (match != null)
                    {
                        cboPhuongXa.SelectedValue = match.Code;
                    }
                    else
                    {
                        cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;
                        cboPhuongXa.Text = fallbackWardName;
                    }
                }
            }
            else
            {
                cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;
                cboPhuongXa.Enabled = true;
                cboPhuongXa.Text = fallbackWardName;
            }
        }
        catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException)
        {
            // Task 8: Bắt lỗi mạng khi lấy phường/xã
            lblStatus.Text = "Lỗi kết nối API phường/xã - Cho phép gõ tay.";
            MessageBox.Show("Không tải được danh sách phường/xã, vui lòng kiểm tra mạng.\nBạn có thể gõ trực tiếp tên Phường/Xã.",
                "Cảnh báo kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDown;
            cboPhuongXa.Enabled = true;
            cboPhuongXa.Text = fallbackWardName;
        }
        finally
        {
            _isLoadingAddress = false;
        }
    }

    private async void cboTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_isLoadingAddress) return;

        if (cboTinhThanh.SelectedValue is int code && code > 0)
        {
            await LoadWardsAsync(code);
        }
    }
    #endregion

    #region Task 1, 4 & 5: Load dữ liệu, Quản lý phòng & Hiển thị DataGridView
    private void LoadRoomsToComboBox()
    {
        using var context = new QLNhaTroContext();
        var rooms = context.PhongTros.AsNoTracking().ToList();

        // 1. Cbo phòng thông tin nhập liệu
        var roomItems = rooms.Select(r => new RoomItem
        {
            MaPhong = r.MaPhong,
            DisplayText = $"{r.TenPhong} - {r.GiaThue:#,##0} đ ({r.TinhTrang})"
        }).ToList();

        cboPhong.DataSource = roomItems;
        cboPhong.DisplayMember = "DisplayText";
        cboPhong.ValueMember = "MaPhong";

        // 2. Cbo lọc phòng
        var locRooms = new List<RoomItem>
        {
            new RoomItem { MaPhong = 0, DisplayText = "Tất cả" }
        };
        locRooms.AddRange(rooms.Select(r => new RoomItem
        {
            MaPhong = r.MaPhong,
            DisplayText = r.TenPhong
        }));

        cboLocPhong.DataSource = locRooms;
        cboLocPhong.DisplayMember = "DisplayText";
        cboLocPhong.ValueMember = "MaPhong";
        cboLocPhong.SelectedIndex = 0;
    }

    private void LoadDataGridKhachThue(string? keyword = null, int filterMaPhong = 0, int filterMaTinh = 0)
    {
        try
        {
            using var context = new QLNhaTroContext();

            var query = from k in context.KhachThues.AsNoTracking()
                        join p in context.PhongTros.AsNoTracking() on k.MaPhong equals p.MaPhong
                        select new KhachThueViewModel
                        {
                            MaKhach = k.MaKhach,
                            HoTen = k.HoTen,
                            GioiTinh = k.GioiTinh,
                            NgaySinh = k.NgaySinh,
                            SoDienThoai = k.SoDienThoai,
                            MaPhong = k.MaPhong,
                            TenPhong = p.TenPhong,
                            GiaThue = p.GiaThue,
                            MaTinh = k.MaTinh,
                            TenTinh = k.TenTinh,
                            MaPhuongXa = k.MaPhuongXa,
                            TenPhuongXa = k.TenPhuongXa,
                            DaDangKyTamTru = k.DaDangKyTamTru
                        };

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim().ToLower();
                query = query.Where(k => k.HoTen.ToLower().Contains(keyword) || k.SoDienThoai.Contains(keyword));
            }

            if (filterMaPhong > 0)
            {
                query = query.Where(k => k.MaPhong == filterMaPhong);
            }

            if (filterMaTinh > 0)
            {
                query = query.Where(k => k.MaTinh == filterMaTinh);
            }

            var list = query.OrderByDescending(k => k.MaKhach).ToList();
            dgvKhachThue.DataSource = list;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi truy vấn danh sách khách thuê từ CSDL.");
            MessageBox.Show("Lỗi truy vấn CSDL: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void dgvKhachThue_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= dgvKhachThue.Rows.Count) return;

        if (dgvKhachThue.Rows[e.RowIndex].DataBoundItem is KhachThueViewModel item)
        {
            _selectedMaKhach = item.MaKhach;
            txtHoTen.Text = item.HoTen;
            if (item.GioiTinh.Equals("Nữ", StringComparison.OrdinalIgnoreCase))
                rbNu.Checked = true;
            else
                rbNam.Checked = true;

            dtpNgaySinh.Value = item.NgaySinh.ToDateTime(TimeOnly.MinValue);
            txtSoDienThoai.Text = item.SoDienThoai;
            chkTamTru.Checked = item.DaDangKyTamTru;

            cboPhong.SelectedValue = item.MaPhong;

            // Xử lý nạp Tỉnh và Xã
            if (cboTinhThanh.DataSource != null)
            {
                _isLoadingAddress = true;
                cboTinhThanh.SelectedValue = item.MaTinh;
                _isLoadingAddress = false;

                await LoadWardsAsync(item.MaTinh, item.MaPhuongXa, item.TenPhuongXa);
            }
            else
            {
                cboTinhThanh.Text = item.TenTinh;
                cboPhuongXa.Text = item.TenPhuongXa;
            }
        }
    }
    #endregion

    #region Task 4: CRUD & Tự động đổi trạng thái phòng
    private async void btnThem_Click(object sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        try
        {
            using var context = new QLNhaTroContext();

            int maPhong = (int)cboPhong.SelectedValue!;
            int maTinh = 0;
            string tenTinh = "";
            int maPhuongXa = 0;
            string tenPhuongXa = "";

            GetAddressValues(out maTinh, out tenTinh, out maPhuongXa, out tenPhuongXa);

            var khach = new KhachThue
            {
                HoTen = txtHoTen.Text.Trim(),
                GioiTinh = rbNam.Checked ? "Nam" : "Nữ",
                NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value),
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                MaPhong = maPhong,
                MaTinh = maTinh,
                TenTinh = tenTinh,
                MaPhuongXa = maPhuongXa,
                TenPhuongXa = tenPhuongXa,
                DaDangKyTamTru = chkTamTru.Checked
            };

            context.KhachThues.Add(khach);

            // Cập nhật trạng thái phòng thành "Đang thuê"
            var phong = context.PhongTros.Find(maPhong);
            if (phong != null)
            {
                phong.TinhTrang = "Đang thuê";
            }

            await context.SaveChangesAsync();

            Log.Information("Đã thêm khách thuê: {HoTen}, SĐT: {SDT}, Phòng: {MaPhong}", khach.HoTen, khach.SoDienThoai, maPhong);
            MessageBox.Show("Thêm khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetForm();
            LoadRoomsToComboBox();
            LoadDataGridKhachThue();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi thêm khách thuê vào CSDL.");
            MessageBox.Show("Có lỗi xảy ra khi thêm khách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnSua_Click(object sender, EventArgs e)
    {
        if (_selectedMaKhach <= 0)
        {
            MessageBox.Show("Vui lòng chọn một khách thuê trong danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateInput()) return;

        try
        {
            using var context = new QLNhaTroContext();
            var khach = await context.KhachThues.FindAsync(_selectedMaKhach);
            if (khach == null)
            {
                MessageBox.Show("Không tìm thấy khách thuê cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int oldMaPhong = khach.MaPhong;
            int newMaPhong = (int)cboPhong.SelectedValue!;

            int maTinh = 0;
            string tenTinh = "";
            int maPhuongXa = 0;
            string tenPhuongXa = "";
            GetAddressValues(out maTinh, out tenTinh, out maPhuongXa, out tenPhuongXa);

            khach.HoTen = txtHoTen.Text.Trim();
            khach.GioiTinh = rbNam.Checked ? "Nam" : "Nữ";
            khach.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);
            khach.SoDienThoai = txtSoDienThoai.Text.Trim();
            khach.MaPhong = newMaPhong;
            khach.MaTinh = maTinh;
            khach.TenTinh = tenTinh;
            khach.MaPhuongXa = maPhuongXa;
            khach.TenPhuongXa = tenPhuongXa;
            khach.DaDangKyTamTru = chkTamTru.Checked;

            // Xử lý chuyển phòng
            if (oldMaPhong != newMaPhong)
            {
                // Phòng mới chuyển sang "Đang thuê"
                var phongMoi = await context.PhongTros.FindAsync(newMaPhong);
                if (phongMoi != null) phongMoi.TinhTrang = "Đang thuê";

                // Kiểm tra phòng cũ: nếu không còn ai thì chuyển về "Trống"
                int remainingInOld = await context.KhachThues.CountAsync(k => k.MaPhong == oldMaPhong && k.MaKhach != _selectedMaKhach);
                if (remainingInOld == 0)
                {
                    var phongCu = await context.PhongTros.FindAsync(oldMaPhong);
                    if (phongCu != null) phongCu.TinhTrang = "Trống";
                }
            }

            await context.SaveChangesAsync();

            Log.Information("Cập nhật khách thuê mã {MaKhach} thành công.", _selectedMaKhach);
            MessageBox.Show("Cập nhật thông tin khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetForm();
            LoadRoomsToComboBox();
            LoadDataGridKhachThue();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi cập nhật khách thuê mã {MaKhach}.", _selectedMaKhach);
            MessageBox.Show("Có lỗi xảy ra khi sửa khách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnXoa_Click(object sender, EventArgs e)
    {
        if (_selectedMaKhach <= 0)
        {
            MessageBox.Show("Vui lòng chọn một khách thuê trong danh sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa khách '{txtHoTen.Text}' khỏi hệ thống?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirm != DialogResult.Yes) return;

        try
        {
            using var context = new QLNhaTroContext();
            var khach = await context.KhachThues.FindAsync(_selectedMaKhach);
            if (khach == null)
            {
                MessageBox.Show("Không tìm thấy khách thuê cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maPhong = khach.MaPhong;
            context.KhachThues.Remove(khach);

            // Kiểm tra: nếu đây là người cuối cùng của phòng -> phòng trở lại "Trống"
            int remainingInRoom = await context.KhachThues.CountAsync(k => k.MaPhong == maPhong && k.MaKhach != _selectedMaKhach);
            if (remainingInRoom == 0)
            {
                var phong = await context.PhongTros.FindAsync(maPhong);
                if (phong != null)
                {
                    phong.TinhTrang = "Trống";
                }
            }

            await context.SaveChangesAsync();

            Log.Information("Đã xóa khách thuê mã {MaKhach}, phòng {MaPhong}", _selectedMaKhach, maPhong);
            MessageBox.Show("Xóa khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetForm();
            LoadRoomsToComboBox();
            LoadDataGridKhachThue();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi xóa khách thuê mã {MaKhach}.", _selectedMaKhach);
            MessageBox.Show("Có lỗi xảy ra khi xóa khách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        ResetForm();
    }

    private void ResetForm()
    {
        _selectedMaKhach = 0;
        txtHoTen.Clear();
        rbNam.Checked = true;
        dtpNgaySinh.Value = new DateTime(2000, 1, 1);
        txtSoDienThoai.Clear();
        chkTamTru.Checked = false;

        if (cboPhong.Items.Count > 0)
            cboPhong.SelectedIndex = 0;

        if (cboTinhThanh.Items.Count > 0)
            cboTinhThanh.SelectedIndex = 0;

        txtHoTen.Focus();
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        {
            MessageBox.Show("Họ tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtHoTen.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
        {
            MessageBox.Show("Số điện thoại không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSoDienThoai.Focus();
            return false;
        }

        if (cboPhong.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn phòng trọ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboPhong.Focus();
            return false;
        }

        string tenTinh = cboTinhThanh.Text.Trim();
        string tenPhuong = cboPhuongXa.Text.Trim();

        if (string.IsNullOrWhiteSpace(tenTinh) || tenTinh == "Đang tải…")
        {
            MessageBox.Show("Vui lòng chọn hoặc nhập Tỉnh/Thành!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboTinhThanh.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(tenPhuong) || tenPhuong == "Đang tải…")
        {
            MessageBox.Show("Vui lòng chọn hoặc nhập Phường/Xã!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboPhuongXa.Focus();
            return false;
        }

        return true;
    }

    private void GetAddressValues(out int maTinh, out string tenTinh, out int maPhuongXa, out string tenPhuongXa)
    {
        if (cboTinhThanh.SelectedItem is ProvinceDto p)
        {
            maTinh = p.Code;
            tenTinh = p.Name;
        }
        else
        {
            maTinh = cboTinhThanh.SelectedValue is int c ? c : 0;
            tenTinh = cboTinhThanh.Text.Trim();
        }

        if (cboPhuongXa.SelectedItem is WardDto w)
        {
            maPhuongXa = w.Code;
            tenPhuongXa = w.Name;
        }
        else
        {
            maPhuongXa = cboPhuongXa.SelectedValue is int wc ? wc : 0;
            tenPhuongXa = cboPhuongXa.Text.Trim();
        }
    }
    #endregion

    #region Task 6: Tìm kiếm & Lọc
    private void btnTim_Click(object sender, EventArgs e)
    {
        string keyword = txtTimKiem.Text.Trim();
        int maPhong = cboLocPhong.SelectedValue is int p ? p : 0;
        int maTinh = cboLocTinh.SelectedValue is int t ? t : 0;

        LoadDataGridKhachThue(keyword, maPhong, maTinh);
    }

    private void btnBoLoc_Click(object sender, EventArgs e)
    {
        txtTimKiem.Clear();
        cboLocPhong.SelectedIndex = 0;
        if (cboLocTinh.Items.Count > 0)
            cboLocTinh.SelectedIndex = 0;

        LoadDataGridKhachThue();
    }
    #endregion

    #region Task 7: Thử nghiệm bắt lỗi toàn cục
    private void btnGayLoiThu_Click(object sender, EventArgs e)
    {
        // Cố tình ném lỗi chưa được bắt để kiểm tra Global Exception Handler và Serilog
        throw new InvalidOperationException("Thử nghiệm lỗi ngoại lệ chưa được xử lý (Global Unhandled Exception) để kiểm tra Serilog và cơ chế bảo vệ ứng dụng không bị văng.");
    }
    #endregion
}
