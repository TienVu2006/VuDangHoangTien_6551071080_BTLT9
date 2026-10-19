using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai3.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai3
{
    public partial class FormChuyenDi : Form
    {
        private QL_DaNgoaiContext _context;
        private int _selectedMaChuyen = -1;

        // 1. HttpClient dùng chung với Timeout 8 giây
        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(8)
        };

        // Đường dẫn file lưu cấu hình ngôn ngữ trong %LocalAppData%
        private readonly string _settingsFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Bai3App",
            "usersettings.json"
        );

        private string _currentLang = "vi-VN"; // Mặc định Tiếng Việt

        public FormChuyenDi()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<QL_DaNgoaiContext>();
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=QL_DaNgoai;Integrated Security=True;TrustServerCertificate=True;");
            _context = new QL_DaNgoaiContext(optionsBuilder.Options);
        }

        private void FormChuyenDi_Load(object sender, EventArgs e)
        {
            // Tải ngôn ngữ đã lưu từ file JSON
            LoadUserSettings();

            // Cấu hình ComboBox Ngôn ngữ
            cboNgonNgu.Items.Clear();
            cboNgonNgu.Items.Add("Tiếng Việt");
            cboNgonNgu.Items.Add("English");
            cboNgonNgu.SelectedIndex = _currentLang == "en-US" ? 1 : 0;

            // Đăng ký sự kiện đổi ngôn ngữ
            cboNgonNgu.SelectedIndexChanged += cboNgonNgu_SelectedIndexChanged;

            if (cboPhuongTien.Items.Count > 0)
                cboPhuongTien.SelectedIndex = 0;

            dtpNgayDi.Value = DateTime.Today;

            // Áp dụng ngôn ngữ lên giao diện
            ApplyLanguage(_currentLang);
        }

        // ==========================================
        // TẢI VÀ LƯU CẤU HÌNH USER SETTINGS (%LocalAppData%)
        // ==========================================
        private class UserSettings
        {
            public string Language { get; set; } = "vi-VN";
        }

        private void LoadUserSettings()
        {
            try
            {
                if (File.Exists(_settingsFilePath))
                {
                    string json = File.ReadAllText(_settingsFilePath);
                    var settings = JsonSerializer.Deserialize<UserSettings>(json);
                    if (settings != null && !string.IsNullOrEmpty(settings.Language))
                    {
                        _currentLang = settings.Language;
                    }
                }
            }
            catch { /* Mặc định giữ vi-VN nếu file lỗi */ }
        }

        private void SaveUserSettings()
        {
            try
            {
                string dir = Path.GetDirectoryName(_settingsFilePath);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                var settings = new UserSettings { Language = _currentLang };
                string json = JsonSerializer.Serialize(settings);
                File.ReadAllText(_settingsFilePath);
                File.WriteAllText(_settingsFilePath, json);
            }
            catch { }
        }

        // ==========================================
        // ĐA NGÔN NGỮ (MULTI-LANGUAGE & CULTUREINFO)
        // ==========================================
        private void cboNgonNgu_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentLang = cboNgonNgu.SelectedIndex == 1 ? "en-US" : "vi-VN";
            SaveUserSettings();
            ApplyLanguage(_currentLang);
        }

        private void ApplyLanguage(string cultureCode)
        {
            CultureInfo culture = new CultureInfo(cultureCode);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            bool isEn = cultureCode == "en-US";

            // 1. Tiêu đề và Khung
            this.Text = isEn ? "Weekend Outing Plan" : "Kế hoạch dã ngoại cuối tuần";
            if (lblTieuDe != null) lblTieuDe.Text = isEn ? "Weekend Outing Plan" : "Kế hoạch dã ngoại cuối tuần";
            if (lblNgonNgu != null) lblNgonNgu.Text = isEn ? "Language" : "Ngôn ngữ";
            if (gbThongTin != null) gbThongTin.Text = isEn ? "Trip Information" : "Thông tin chuyến đi";

            // 2. Các Label nhập liệu
            if (lblTenChuyen != null) lblTenChuyen.Text = isEn ? "Trip Name" : "Tên chuyến";
            if (lblDiaDiem != null) lblDiaDiem.Text = isEn ? "Destination" : "Địa điểm";
            if (lblNgayDi != null) lblNgayDi.Text = isEn ? "Departure Date" : "Ngày đi";
            if (lblSoNguoi != null) lblSoNguoi.Text = isEn ? "Participants" : "Số người";
            if (lblNganSach != null) lblNganSach.Text = isEn ? "Budget" : "Ngân sách";
            if (lblPhuongTien != null) lblPhuongTien.Text = isEn ? "Transport" : "Phương tiện";
            if (chkDaHoanThanh != null) chkDaHoanThanh.Text = isEn ? "Completed" : "Đã hoàn thành";

            // 3. Các Button
            if (btnThem != null) btnThem.Text = isEn ? "Add" : "Thêm";
            if (btnSua != null) btnSua.Text = isEn ? "Edit" : "Sửa";
            if (btnXoa != null) btnXoa.Text = isEn ? "Delete" : "Xóa";
            if (btnLamMoi != null) btnLamMoi.Text = isEn ? "Reset" : "Làm mới";
            if (btnXemThoiTiet != null) btnXemThoiTiet.Text = isEn ? "Check Weather" : "Xem thời tiết";
            if (btnTim != null) btnTim.Text = isEn ? "Search" : "Tìm";
            if (chkChuaHoanThanh != null) chkChuaHoanThanh.Text = isEn ? "Unfinished trips only" : "Chỉ hiện chuyến chưa hoàn thành";

            // 4. Đổi ngôn ngữ cho ComboBox Phương tiện
            int selIdx = cboPhuongTien.SelectedIndex;
            cboPhuongTien.Items.Clear();
            if (isEn)
                cboPhuongTien.Items.AddRange(new object[] { "Car", "Motorbike", "Bus", "Train", "Airplane" });
            else
                cboPhuongTien.Items.AddRange(new object[] { "Ô tô", "Xe máy", "Xe khách", "Tàu hỏa", "Máy bay" });
            cboPhuongTien.SelectedIndex = selIdx >= 0 ? selIdx : 0;

            // 5. Cập nhật Tiêu đề các Cột trong DataGridView
            UpdateGridHeaderNames(isEn);

            // 6. Load lại danh sách dữ liệu để định dạng tiền/ngày chuẩn theo CultureInfo
            LoadData();
        }

        private void UpdateGridHeaderNames(bool isEn)
        {
            SetColumnHeader("MaChuyen", isEn ? "ID" : "Mã");
            SetColumnHeader("TenChuyen", isEn ? "Trip Name" : "Tên chuyến");
            SetColumnHeader("DiaDiem", isEn ? "Destination" : "Địa điểm");
            SetColumnHeader("NgayDi", isEn ? "Departure Date" : "Ngày đi");
            SetColumnHeader("SoNguoi", isEn ? "Participants" : "Số người");
            SetColumnHeader("NganSach", isEn ? "Budget" : "Ngân sách");
            SetColumnHeader("PhuongTien", isEn ? "Transport" : "Phương tiện");
            SetColumnHeader("DaHoanThanh", isEn ? "Completed" : "Hoàn thành");
        }

        private void SetColumnHeader(string colName, string headerText)
        {
            if (dgvChuyenDi.Columns.Contains(colName))
                dgvChuyenDi.Columns[colName].HeaderText = headerText;
            else if (dgvChuyenDi.Columns.Contains("col" + colName))
                dgvChuyenDi.Columns["col" + colName].HeaderText = headerText;
        }

        // ==========================================
        // TẢI VÀ TÌM KIẾM DỮ LIỆU (SEARCH & FILTER)
        // ==========================================
        private void LoadData()
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim().ToLower();
                bool chiChuaHoanThanh = chkChuaHoanThanh.Checked;

                var query = _context.ChuyenDis.AsQueryable();

                if (chiChuaHoanThanh)
                    query = query.Where(c => !c.DaHoanThanh);

                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    query = query.Where(c => c.TenChuyen.ToLower().Contains(tuKhoa)
                                          || c.DiaDiem.ToLower().Contains(tuKhoa));
                }

                var list = query.Select(c => new
                {
                    c.MaChuyen,
                    c.TenChuyen,
                    c.DiaDiem,
                    c.NgayDi,
                    c.SoNguoi,
                    c.NganSach,
                    c.PhuongTien,
                    c.DaHoanThanh
                }).ToList();

                dgvChuyenDi.DataSource = list;
            }
            catch (Exception ex)
            {
                string msg = _currentLang == "en-US" ? "Data load error: " : "Lỗi tải dữ liệu: ";
                MessageBox.Show(msg + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e) => LoadData();
        private void txtTimKiem_TextChanged(object sender, EventArgs e) => LoadData();
        private void chkChuaHoanThanh_CheckedChanged(object sender, EventArgs e) => LoadData();

        // ==========================================
        // CHỌN DÒNG TRÊN DATAGRIDVIEW
        // ==========================================
        private void dgvChuyenDi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvChuyenDi.Rows.Count)
            {
                DataGridViewRow row = dgvChuyenDi.Rows[e.RowIndex];

                object GetValue(string colName, int defaultIndex)
                {
                    if (dgvChuyenDi.Columns.Contains(colName)) return row.Cells[colName].Value;
                    if (dgvChuyenDi.Columns.Contains("col" + colName)) return row.Cells["col" + colName].Value;
                    if (defaultIndex < row.Cells.Count) return row.Cells[defaultIndex].Value;
                    return null;
                }

                var valMa = GetValue("MaChuyen", 0);
                if (valMa != null && int.TryParse(valMa.ToString(), out int ma)) _selectedMaChuyen = ma;

                txtTenChuyen.Text = GetValue("TenChuyen", 1)?.ToString();
                txtDiaDiem.Text = GetValue("DiaDiem", 2)?.ToString();

                var valNgay = GetValue("NgayDi", 3);
                if (valNgay is DateOnly dateOnly)
                    dtpNgayDi.Value = dateOnly.ToDateTime(TimeOnly.MinValue);
                else if (DateTime.TryParse(valNgay?.ToString(), out DateTime dt))
                    dtpNgayDi.Value = dt;

                if (decimal.TryParse(GetValue("SoNguoi", 4)?.ToString(), out decimal soNguoi))
                    nudSoNguoi.Value = soNguoi;

                txtNganSach.Text = GetValue("NganSach", 5)?.ToString();
                cboPhuongTien.Text = GetValue("PhuongTien", 6)?.ToString();

                if (bool.TryParse(GetValue("DaHoanThanh", 7)?.ToString(), out bool daHT))
                    chkDaHoanThanh.Checked = daHT;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _selectedMaChuyen = -1;
            txtTenChuyen.Clear();
            txtDiaDiem.Clear();
            dtpNgayDi.Value = DateTime.Today;
            nudSoNguoi.Value = 1;
            txtNganSach.Text = "0";
            if (cboPhuongTien.Items.Count > 0) cboPhuongTien.SelectedIndex = 0;
            chkDaHoanThanh.Checked = false;
            dgvChuyenDi.ClearSelection();
        }

        private bool KiemTraHopLe(bool isThemMoi)
        {
            bool isEn = _currentLang == "en-US";

            if (string.IsNullOrWhiteSpace(txtTenChuyen.Text))
            {
                MessageBox.Show(isEn ? "Please enter trip name!" : "Vui lòng nhập tên chuyến đi!", isEn ? "Warning" : "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenChuyen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaDiem.Text))
            {
                MessageBox.Show(isEn ? "Please enter destination!" : "Vui lòng nhập địa điểm!", isEn ? "Warning" : "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaDiem.Focus();
                return false;
            }

            if (isThemMoi && dtpNgayDi.Value.Date < DateTime.Today)
            {
                MessageBox.Show(isEn ? "Departure date cannot be earlier than today!" : "Ngày đi không được nhỏ hơn ngày hôm nay!", isEn ? "Warning" : "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayDi.Focus();
                return false;
            }

            if (nudSoNguoi.Value < 1)
            {
                MessageBox.Show(isEn ? "Participants must be at least 1!" : "Số người tham gia phải từ 1 người trở lên!", isEn ? "Warning" : "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudSoNguoi.Focus();
                return false;
            }

            if (!decimal.TryParse(txtNganSach.Text.Trim(), out decimal nganSach) || nganSach < 0)
            {
                MessageBox.Show(isEn ? "Budget must be a non-negative number!" : "Ngân sách phải là một số không âm!", isEn ? "Warning" : "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNganSach.Focus();
                return false;
            }

            return true;
        }

        // ==========================================
        // CHỨC NĂNG THÊM - SỬA - XÓA (CRUD)
        // ==========================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe(isThemMoi: true)) return;
            bool isEn = _currentLang == "en-US";

            try
            {
                var chuyenDi = new ChuyenDi
                {
                    TenChuyen = txtTenChuyen.Text.Trim(),
                    DiaDiem = txtDiaDiem.Text.Trim(),
                    NgayDi = DateOnly.FromDateTime(dtpNgayDi.Value),
                    SoNguoi = (int)nudSoNguoi.Value,
                    NganSach = decimal.Parse(txtNganSach.Text.Trim()),
                    PhuongTien = cboPhuongTien.Text,
                    DaHoanThanh = chkDaHoanThanh.Checked
                };

                _context.ChuyenDis.Add(chuyenDi);
                _context.SaveChanges();

                MessageBox.Show(isEn ? "Trip added successfully!" : "Thêm chuyến đi thành công!", isEn ? "Info" : "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnLamMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show((isEn ? "Error adding: " : "Lỗi khi thêm: ") + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bool isEn = _currentLang == "en-US";

            if (_selectedMaChuyen == -1)
            {
                MessageBox.Show(isEn ? "Please select a trip to edit!" : "Vui lòng chọn chuyến đi cần sửa!", isEn ? "Warning" : "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraHopLe(isThemMoi: false)) return;

            try
            {
                var chuyenDi = _context.ChuyenDis.Find(_selectedMaChuyen);
                if (chuyenDi != null)
                {
                    chuyenDi.TenChuyen = txtTenChuyen.Text.Trim();
                    chuyenDi.DiaDiem = txtDiaDiem.Text.Trim();
                    chuyenDi.NgayDi = DateOnly.FromDateTime(dtpNgayDi.Value);
                    chuyenDi.SoNguoi = (int)nudSoNguoi.Value;
                    chuyenDi.NganSach = decimal.Parse(txtNganSach.Text.Trim());
                    chuyenDi.PhuongTien = cboPhuongTien.Text;
                    chuyenDi.DaHoanThanh = chkDaHoanThanh.Checked;

                    _context.SaveChanges();

                    MessageBox.Show(isEn ? "Trip updated successfully!" : "Cập nhật chuyến đi thành công!", isEn ? "Info" : "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btnLamMoi_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show((isEn ? "Error editing: " : "Lỗi khi sửa: ") + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool isEn = _currentLang == "en-US";

            if (_selectedMaChuyen == -1)
            {
                MessageBox.Show(isEn ? "Please select a trip to delete!" : "Vui lòng chọn chuyến đi cần xóa!", isEn ? "Warning" : "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string confirmMsg = isEn ? "Are you sure you want to delete this trip?" : "Bạn có chắc chắn muốn xóa chuyến đi này không?";
            var dialog = MessageBox.Show(confirmMsg, isEn ? "Confirm Delete" : "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    var chuyenDi = _context.ChuyenDis.Find(_selectedMaChuyen);
                    if (chuyenDi != null)
                    {
                        _context.ChuyenDis.Remove(chuyenDi);
                        _context.SaveChanges();

                        MessageBox.Show(isEn ? "Trip deleted successfully!" : "Xóa chuyến đi thành công!", isEn ? "Info" : "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        btnLamMoi_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show((isEn ? "Error deleting: " : "Lỗi khi xóa: ") + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // GỌI API THỜI TIẾT TỐI ƯU (ASYNC, MARQUEE, TIMEOUT 8S & BẮT LỖI MẠNG)
        // ==========================================
        private async void btnXemThoiTiet_Click(object sender, EventArgs e)
        {
            bool isEn = _currentLang == "en-US";
            string diaDiem = txtDiaDiem.Text.Trim();
            DateTime ngayDi = dtpNgayDi.Value.Date;

            if (string.IsNullOrEmpty(diaDiem))
            {
                MessageBox.Show(isEn ? "Please enter/select a destination!" : "Vui lòng chọn hoặc nhập địa điểm cần xem thời tiết!", isEn ? "Warning" : "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Khóa nút và bật ProgressBar kiểu Marquee lúc đang tải
                if (prgThoiTiet != null)
                {
                    prgThoiTiet.Visible = true;
                    prgThoiTiet.Style = ProgressBarStyle.Marquee;
                }
                btnXemThoiTiet.Enabled = false;

                // Bước 1: Gọi Geocoding API lấy tọa độ
                string geoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(diaDiem)}&count=1&language={(isEn ? "en" : "vi")}";
                string geoResponse = await _httpClient.GetStringAsync(geoUrl);
                using var geoDoc = JsonDocument.Parse(geoResponse);

                if (!geoDoc.RootElement.TryGetProperty("results", out var results) || results.GetArrayLength() == 0)
                {
                    string notFoundMsg = isEn
                        ? $"Location '{diaDiem}' not found. Try searching without accents (e.g., 'Da Lat')!"
                        : $"Không tìm thấy địa danh '{diaDiem}'. Gợi ý thử tìm tên không dấu (VD: 'Da Lat')!";

                    MessageBox.Show(notFoundMsg, isEn ? "Notice" : "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                double lat = results[0].GetProperty("latitude").GetDouble();
                double lon = results[0].GetProperty("longitude").GetDouble();

                // Bước 2: Gọi Forecast API (16 ngày)
                string weatherUrl = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max&timezone=auto&forecast_days=16";
                string weatherResponse = await _httpClient.GetStringAsync(weatherUrl);
                using var weatherDoc = JsonDocument.Parse(weatherResponse);

                var daily = weatherDoc.RootElement.GetProperty("daily");
                var timeArray = daily.GetProperty("time").EnumerateArray().Select(x => x.GetString()).ToList();

                string ngayDiStr = ngayDi.ToString("yyyy-MM-dd");
                int index = timeArray.IndexOf(ngayDiStr);

                // Nếu ngày đi vượt quá 16 ngày dự báo
                if (index == -1)
                {
                    if (lblDuBaoTieuDe != null) lblDuBaoTieuDe.Text = isEn ? $"Forecast for {ngayDi:MM/dd/yyyy} - {diaDiem}" : $"Dự báo thời tiết ngày {ngayDi:dd/MM/yyyy} - {diaDiem}";
                    if (lblMoTaThoiTiet != null) lblMoTaThoiTiet.Text = isEn ? "No forecast data available" : "Chưa có dữ liệu dự báo";
                    if (lblNhietDo != null) lblNhietDo.Text = isEn ? "Temperature: --°C" : "Nhiệt độ: --°C";
                    if (lblKhaNangMua != null) lblKhaNangMua.Text = isEn ? "Rain probability: --%" : "Khả năng mưa: --%";
                    if (pnlLoiKhuyen != null) pnlLoiKhuyen.Visible = false;
                    return;
                }

                int weatherCode = daily.GetProperty("weather_code")[index].GetInt32();
                double tempMin = daily.GetProperty("temperature_2m_min")[index].GetDouble();
                double tempMax = daily.GetProperty("temperature_2m_max")[index].GetDouble();
                int rainProb = daily.GetProperty("precipitation_probability_max")[index].GetInt32();

                string weatherText = ConvertWeatherCode(weatherCode, isEn);

                // Hiển thị kết quả lên UI
                if (lblDuBaoTieuDe != null) lblDuBaoTieuDe.Text = isEn ? $"Forecast for {ngayDi:MM/dd/yyyy} - {diaDiem}" : $"Dự báo thời tiết ngày {ngayDi:dd/MM/yyyy} - {diaDiem}";
                if (lblMoTaThoiTiet != null) lblMoTaThoiTiet.Text = weatherText;
                if (lblNhietDo != null) lblNhietDo.Text = isEn ? $"Temperature: {tempMin:0.#}°C - {tempMax:0.#}°C" : $"Nhiệt độ: {tempMin:0.#}°C - {tempMax:0.#}°C";
                if (lblKhaNangMua != null) lblKhaNangMua.Text = isEn ? $"Rain probability: {rainProb}%" : $"Khả năng mưa: {rainProb}%";

                // Cảnh báo nếu khả năng mưa >= 60%
                if (rainProb >= 60)
                {
                    if (pnlLoiKhuyen != null)
                    {
                        pnlLoiKhuyen.Visible = true;
                        pnlLoiKhuyen.BackColor = Color.Orange;
                    }
                    if (lblLoiKhuyen != null)
                        lblLoiKhuyen.Text = isEn ? "⚠ Bring a raincoat or consider rescheduling" : "⚠ Nên mang áo mưa hoặc cân nhắc dời lịch";
                }
                else
                {
                    if (pnlLoiKhuyen != null)
                    {
                        pnlLoiKhuyen.Visible = true;
                        pnlLoiKhuyen.BackColor = Color.LightGreen;
                    }
                    if (lblLoiKhuyen != null)
                        lblLoiKhuyen.Text = isEn ? "Good weather for traveling!" : "Thời tiết thuận lợi cho chuyến đi!";
                }
            }
            catch (HttpRequestException)
            {
                // Bắt lỗi rút dây mạng / mất kết nối
                string errNet = isEn ? "Network connection error! Please check your internet." : "Lỗi kết nối mạng! Vui lòng kiểm tra lại đường truyền internet.";
                MessageBox.Show(errNet, isEn ? "Network Error" : "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (TaskCanceledException)
            {
                // Bắt lỗi Hết thời gian kết nối (Timeout 8 giây)
                string errTime = isEn ? "Request timed out (8s Timeout)." : "Kết nối quá thời hạn cho phép (Timeout 8 giây).";
                MessageBox.Show(errTime, isEn ? "Timeout Error" : "Lỗi Quá Giờ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show((isEn ? "API Error: " : "Lỗi API: ") + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Trả lại trạng thái cho ProgressBar và Button
                if (prgThoiTiet != null) prgThoiTiet.Visible = false;
                btnXemThoiTiet.Enabled = true;
            }
        }

        private string ConvertWeatherCode(int code, bool isEn)
        {
            if (isEn)
            {
                return code switch
                {
                    0 => "Clear sky",
                    1 or 2 or 3 => "Partly cloudy",
                    45 or 48 => "Foggy",
                    >= 51 and <= 67 => "Rain",
                    >= 80 and <= 82 => "Rain showers",
                    >= 95 and <= 99 => "Thunderstorm",
                    _ => "Light rain"
                };
            }
            else
            {
                return code switch
                {
                    0 => "Trời quang",
                    1 or 2 or 3 => "Có mây",
                    45 or 48 => "Sương mù",
                    >= 51 and <= 67 => "Mưa",
                    >= 80 and <= 82 => "Mưa rào",
                    >= 95 and <= 99 => "Dông",
                    _ => "Có mưa nhẹ"
                };
            }
        }
    }
}