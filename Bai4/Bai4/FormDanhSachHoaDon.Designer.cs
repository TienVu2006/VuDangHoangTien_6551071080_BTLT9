namespace Bai4
{
    partial class FormDanhSachHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblChonNgay = new Label();
            dtpNgay = new DateTimePicker();
            lblDoanhThu = new Label();
            dgvHoaDon = new DataGridView();
            dgvChiTiet = new DataGridView();
            lblDanhSachHD = new Label();
            lblChiTietHD = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // 
            // lblChonNgay
            // 
            lblChonNgay.AutoSize = true;
            lblChonNgay.Location = new Point(20, 20);
            lblChonNgay.Name = "lblChonNgay";
            lblChonNgay.Size = new Size(68, 15);
            lblChonNgay.TabIndex = 0;
            lblChonNgay.Text = "Chọn ngày:";
            // 
            // dtpNgay
            // 
            dtpNgay.Format = DateTimePickerFormat.Short;
            dtpNgay.Location = new Point(95, 16);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(150, 23);
            dtpNgay.TabIndex = 1;
            dtpNgay.ValueChanged += dtpNgay_ValueChanged;
            // 
            // lblDoanhThu
            // 
            lblDoanhThu.AutoSize = true;
            lblDoanhThu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDoanhThu.ForeColor = Color.DarkGreen;
            lblDoanhThu.Location = new Point(300, 18);
            lblDoanhThu.Name = "lblDoanhThu";
            lblDoanhThu.Size = new Size(160, 20);
            lblDoanhThu.TabIndex = 2;
            lblDoanhThu.Text = "Doanh thu ngày: 0 đ";
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(20, 80);
            dgvHoaDon.MultiSelect = false;
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.Size = new Size(350, 320);
            dgvHoaDon.TabIndex = 3;
            dgvHoaDon.SelectionChanged += dgvHoaDon_SelectionChanged;
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Location = new Point(390, 80);
            dgvChiTiet.MultiSelect = false;
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.Size = new Size(320, 320);
            dgvChiTiet.TabIndex = 4;
            // 
            // lblDanhSachHD
            // 
            lblDanhSachHD.AutoSize = true;
            lblDanhSachHD.Location = new Point(20, 58);
            lblDanhSachHD.Name = "lblDanhSachHD";
            lblDanhSachHD.Size = new Size(113, 15);
            lblDanhSachHD.TabIndex = 5;
            lblDanhSachHD.Text = "Danh sách hóa đơn:";
            // 
            // lblChiTietHD
            // 
            lblChiTietHD.AutoSize = true;
            lblChiTietHD.Location = new Point(390, 58);
            lblChiTietHD.Name = "lblChiTietHD";
            lblChiTietHD.Size = new Size(94, 15);
            lblChiTietHD.TabIndex = 6;
            lblChiTietHD.Text = "Chi tiết hóa đơn:";
            // 
            // FormDanhSachHoaDon
            // 
            ClientSize = new Size(730, 420);
            Controls.Add(lblChiTietHD);
            Controls.Add(lblDanhSachHD);
            Controls.Add(dgvChiTiet);
            Controls.Add(dgvHoaDon);
            Controls.Add(lblDoanhThu);
            Controls.Add(dtpNgay);
            Controls.Add(lblChonNgay);
            Name = "FormDanhSachHoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê hóa đơn";
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblChonNgay;
        private DateTimePicker dtpNgay;
        private Label lblDoanhThu;
        private DataGridView dgvHoaDon;
        private DataGridView dgvChiTiet;
        private Label lblDanhSachHD;
        private Label lblChiTietHD;
    }
}