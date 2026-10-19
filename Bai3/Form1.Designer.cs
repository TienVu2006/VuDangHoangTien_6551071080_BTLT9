namespace Bai3
{
    partial class FormChuyenDi
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblNgonNgu = new Label();
            cboNgonNgu = new ComboBox();
            gbThongTin = new GroupBox();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            chkDaHoanThanh = new CheckBox();
            cboPhuongTien = new ComboBox();
            nudSoNguoi = new NumericUpDown();
            dtpNgayDi = new DateTimePicker();
            txtNganSach = new TextBox();
            txtDiaDiem = new TextBox();
            lblPhuongTien = new Label();
            lblNganSach = new Label();
            lblSoNguoi = new Label();
            lblNgayDi = new Label();
            lblDiaDiem = new Label();
            txtTenChuyen = new TextBox();
            lblTenChuyen = new Label();
            pnlThoiTiet = new Panel();
            pnlLoiKhuyen = new Panel();
            lblLoiKhuyen = new Label();
            lblKhaNangMua = new Label();
            lblNhietDo = new Label();
            lblMoTaThoiTiet = new Label();
            picThoiTiet = new PictureBox();
            lblDuBaoTieuDe = new Label();
            btnXemThoiTiet = new Button();
            prgThoiTiet = new ProgressBar();
            txtTimKiem = new TextBox();
            chkChuaHoanThanh = new CheckBox();
            btnTim = new Button();
            dgvChuyenDi = new DataGridView();
            colMaChuyen = new DataGridViewTextBoxColumn();
            colTenChuyen = new DataGridViewTextBoxColumn();
            colDiaDiem = new DataGridViewTextBoxColumn();
            colNgayDi = new DataGridViewTextBoxColumn();
            colSoNguoi = new DataGridViewTextBoxColumn();
            colNganSach = new DataGridViewTextBoxColumn();
            colPhuongTien = new DataGridViewTextBoxColumn();
            colDaHoanThanh = new DataGridViewTextBoxColumn();
            gbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoNguoi).BeginInit();
            pnlThoiTiet.SuspendLayout();
            pnlLoiKhuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picThoiTiet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenDi).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.Location = new Point(75, 23);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(390, 38);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Kế hoạch dã ngoại cuối tuần";
            // 
            // lblNgonNgu
            // 
            lblNgonNgu.AutoSize = true;
            lblNgonNgu.Location = new Point(575, 37);
            lblNgonNgu.Name = "lblNgonNgu";
            lblNgonNgu.Size = new Size(76, 20);
            lblNgonNgu.TabIndex = 1;
            lblNgonNgu.Text = "Ngôn ngữ";
            // 
            // cboNgonNgu
            // 
            cboNgonNgu.FormattingEnabled = true;
            cboNgonNgu.Items.AddRange(new object[] { "Tiếng Việt", "English" });
            cboNgonNgu.Location = new Point(657, 34);
            cboNgonNgu.Name = "cboNgonNgu";
            cboNgonNgu.Size = new Size(131, 28);
            cboNgonNgu.TabIndex = 2;
            cboNgonNgu.SelectedIndexChanged += cboNgonNgu_SelectedIndexChanged;
            // 
            // gbThongTin
            // 
            gbThongTin.Controls.Add(btnLamMoi);
            gbThongTin.Controls.Add(btnXoa);
            gbThongTin.Controls.Add(btnSua);
            gbThongTin.Controls.Add(btnThem);
            gbThongTin.Controls.Add(chkDaHoanThanh);
            gbThongTin.Controls.Add(cboPhuongTien);
            gbThongTin.Controls.Add(nudSoNguoi);
            gbThongTin.Controls.Add(dtpNgayDi);
            gbThongTin.Controls.Add(txtNganSach);
            gbThongTin.Controls.Add(txtDiaDiem);
            gbThongTin.Controls.Add(lblPhuongTien);
            gbThongTin.Controls.Add(lblNganSach);
            gbThongTin.Controls.Add(lblSoNguoi);
            gbThongTin.Controls.Add(lblNgayDi);
            gbThongTin.Controls.Add(lblDiaDiem);
            gbThongTin.Controls.Add(txtTenChuyen);
            gbThongTin.Controls.Add(lblTenChuyen);
            gbThongTin.Location = new Point(12, 74);
            gbThongTin.Name = "gbThongTin";
            gbThongTin.Size = new Size(437, 348);
            gbThongTin.TabIndex = 3;
            gbThongTin.TabStop = false;
            gbThongTin.Text = "Thông tin chuyến đi";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(337, 305);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 29);
            btnLamMoi.TabIndex = 9;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(222, 305);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 29);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(116, 305);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 29);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(10, 305);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 29);
            btnThem.TabIndex = 9;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // chkDaHoanThanh
            // 
            chkDaHoanThanh.AutoSize = true;
            chkDaHoanThanh.Location = new Point(29, 275);
            chkDaHoanThanh.Name = "chkDaHoanThanh";
            chkDaHoanThanh.Size = new Size(128, 24);
            chkDaHoanThanh.TabIndex = 8;
            chkDaHoanThanh.Text = "Đã hoàn thành";
            chkDaHoanThanh.UseVisualStyleBackColor = true;
            // 
            // cboPhuongTien
            // 
            cboPhuongTien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhuongTien.FormattingEnabled = true;
            cboPhuongTien.Items.AddRange(new object[] { "Ô tô", "Xe máy", "Xe khách", "Tàu hỏa", "Máy bay" });
            cboPhuongTien.Location = new Point(146, 241);
            cboPhuongTien.Name = "cboPhuongTien";
            cboPhuongTien.Size = new Size(186, 28);
            cboPhuongTien.TabIndex = 7;
            // 
            // nudSoNguoi
            // 
            nudSoNguoi.Location = new Point(146, 161);
            nudSoNguoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoNguoi.Name = "nudSoNguoi";
            nudSoNguoi.Size = new Size(190, 27);
            nudSoNguoi.TabIndex = 6;
            nudSoNguoi.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dtpNgayDi
            // 
            dtpNgayDi.CustomFormat = "dd/MM/yyyy";
            dtpNgayDi.Format = DateTimePickerFormat.Custom;
            dtpNgayDi.Location = new Point(146, 119);
            dtpNgayDi.Name = "dtpNgayDi";
            dtpNgayDi.Size = new Size(190, 27);
            dtpNgayDi.TabIndex = 5;
            // 
            // txtNganSach
            // 
            txtNganSach.Location = new Point(146, 198);
            txtNganSach.Name = "txtNganSach";
            txtNganSach.Size = new Size(185, 27);
            txtNganSach.TabIndex = 4;
            txtNganSach.Text = "0";
            // 
            // txtDiaDiem
            // 
            txtDiaDiem.Location = new Point(145, 77);
            txtDiaDiem.Name = "txtDiaDiem";
            txtDiaDiem.Size = new Size(185, 27);
            txtDiaDiem.TabIndex = 4;
            // 
            // lblPhuongTien
            // 
            lblPhuongTien.AutoSize = true;
            lblPhuongTien.Location = new Point(28, 241);
            lblPhuongTien.Name = "lblPhuongTien";
            lblPhuongTien.Size = new Size(89, 20);
            lblPhuongTien.TabIndex = 3;
            lblPhuongTien.Text = "Phương tiện";
            // 
            // lblNganSach
            // 
            lblNganSach.AutoSize = true;
            lblNganSach.Location = new Point(28, 198);
            lblNganSach.Name = "lblNganSach";
            lblNganSach.Size = new Size(78, 20);
            lblNganSach.TabIndex = 3;
            lblNganSach.Text = "Ngân sách";
            // 
            // lblSoNguoi
            // 
            lblSoNguoi.AutoSize = true;
            lblSoNguoi.Location = new Point(28, 161);
            lblSoNguoi.Name = "lblSoNguoi";
            lblSoNguoi.Size = new Size(69, 20);
            lblSoNguoi.TabIndex = 3;
            lblSoNguoi.Text = "Số người";
            // 
            // lblNgayDi
            // 
            lblNgayDi.AutoSize = true;
            lblNgayDi.Location = new Point(28, 119);
            lblNgayDi.Name = "lblNgayDi";
            lblNgayDi.Size = new Size(61, 20);
            lblNgayDi.TabIndex = 3;
            lblNgayDi.Text = "Ngày đi";
            // 
            // lblDiaDiem
            // 
            lblDiaDiem.AutoSize = true;
            lblDiaDiem.Location = new Point(29, 77);
            lblDiaDiem.Name = "lblDiaDiem";
            lblDiaDiem.Size = new Size(70, 20);
            lblDiaDiem.TabIndex = 2;
            lblDiaDiem.Text = "Địa điểm";
            // 
            // txtTenChuyen
            // 
            txtTenChuyen.Location = new Point(146, 36);
            txtTenChuyen.Name = "txtTenChuyen";
            txtTenChuyen.Size = new Size(185, 27);
            txtTenChuyen.TabIndex = 1;
            // 
            // lblTenChuyen
            // 
            lblTenChuyen.AutoSize = true;
            lblTenChuyen.Location = new Point(28, 36);
            lblTenChuyen.Name = "lblTenChuyen";
            lblTenChuyen.Size = new Size(82, 20);
            lblTenChuyen.TabIndex = 0;
            lblTenChuyen.Text = "Tên chuyến";
            // 
            // pnlThoiTiet
            // 
            pnlThoiTiet.BorderStyle = BorderStyle.FixedSingle;
            pnlThoiTiet.Controls.Add(pnlLoiKhuyen);
            pnlThoiTiet.Controls.Add(lblKhaNangMua);
            pnlThoiTiet.Controls.Add(lblNhietDo);
            pnlThoiTiet.Controls.Add(lblMoTaThoiTiet);
            pnlThoiTiet.Controls.Add(picThoiTiet);
            pnlThoiTiet.Controls.Add(lblDuBaoTieuDe);
            pnlThoiTiet.Location = new Point(471, 109);
            pnlThoiTiet.Name = "pnlThoiTiet";
            pnlThoiTiet.Size = new Size(317, 313);
            pnlThoiTiet.TabIndex = 4;
            // 
            // pnlLoiKhuyen
            // 
            pnlLoiKhuyen.BackColor = Color.FromArgb(255, 128, 0);
            pnlLoiKhuyen.Controls.Add(lblLoiKhuyen);
            pnlLoiKhuyen.Location = new Point(15, 218);
            pnlLoiKhuyen.Name = "pnlLoiKhuyen";
            pnlLoiKhuyen.Size = new Size(297, 80);
            pnlLoiKhuyen.TabIndex = 3;
            // 
            // lblLoiKhuyen
            // 
            lblLoiKhuyen.Location = new Point(3, 11);
            lblLoiKhuyen.Name = "lblLoiKhuyen";
            lblLoiKhuyen.Size = new Size(291, 34);
            lblLoiKhuyen.TabIndex = 0;
            lblLoiKhuyen.Text = "Nên mang áo mưa hoặc cân nhắc dời lịch";
            // 
            // lblKhaNangMua
            // 
            lblKhaNangMua.AutoSize = true;
            lblKhaNangMua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKhaNangMua.Location = new Point(171, 98);
            lblKhaNangMua.Name = "lblKhaNangMua";
            lblKhaNangMua.Size = new Size(144, 20);
            lblKhaNangMua.TabIndex = 2;
            lblKhaNangMua.Text = "Khả năng mưa: --%";
            // 
            // lblNhietDo
            // 
            lblNhietDo.AutoSize = true;
            lblNhietDo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNhietDo.Location = new Point(171, 62);
            lblNhietDo.Name = "lblNhietDo";
            lblNhietDo.Size = new Size(105, 20);
            lblNhietDo.TabIndex = 2;
            lblNhietDo.Text = "Nhiệt độ: --°C";
            // 
            // lblMoTaThoiTiet
            // 
            lblMoTaThoiTiet.AutoSize = true;
            lblMoTaThoiTiet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMoTaThoiTiet.Location = new Point(171, 27);
            lblMoTaThoiTiet.Name = "lblMoTaThoiTiet";
            lblMoTaThoiTiet.Size = new Size(98, 20);
            lblMoTaThoiTiet.TabIndex = 2;
            lblMoTaThoiTiet.Text = "Mưa rào nhẹ";
            // 
            // picThoiTiet
            // 
            picThoiTiet.Location = new Point(15, 27);
            picThoiTiet.Name = "picThoiTiet";
            picThoiTiet.Size = new Size(136, 185);
            picThoiTiet.SizeMode = PictureBoxSizeMode.Zoom;
            picThoiTiet.TabIndex = 1;
            picThoiTiet.TabStop = false;
            // 
            // lblDuBaoTieuDe
            // 
            lblDuBaoTieuDe.AutoSize = true;
            lblDuBaoTieuDe.Location = new Point(3, 0);
            lblDuBaoTieuDe.Name = "lblDuBaoTieuDe";
            lblDuBaoTieuDe.Size = new Size(124, 20);
            lblDuBaoTieuDe.TabIndex = 0;
            lblDuBaoTieuDe.Text = "Dự báo thời tiết...";
            // 
            // btnXemThoiTiet
            // 
            btnXemThoiTiet.Location = new Point(471, 74);
            btnXemThoiTiet.Name = "btnXemThoiTiet";
            btnXemThoiTiet.Size = new Size(108, 29);
            btnXemThoiTiet.TabIndex = 5;
            btnXemThoiTiet.Text = "Xem thời tiết";
            btnXemThoiTiet.UseVisualStyleBackColor = true;
            btnXemThoiTiet.Click += btnXemThoiTiet_Click;
            // 
            // prgThoiTiet
            // 
            prgThoiTiet.Location = new Point(585, 78);
            prgThoiTiet.Name = "prgThoiTiet";
            prgThoiTiet.Size = new Size(203, 25);
            prgThoiTiet.Style = ProgressBarStyle.Marquee;
            prgThoiTiet.TabIndex = 6;
            prgThoiTiet.Visible = false;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(12, 428);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm địa điểm...";
            txtTimKiem.Size = new Size(157, 27);
            txtTimKiem.TabIndex = 7;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // chkChuaHoanThanh
            // 
            chkChuaHoanThanh.AutoSize = true;
            chkChuaHoanThanh.Location = new Point(180, 431);
            chkChuaHoanThanh.Name = "chkChuaHoanThanh";
            chkChuaHoanThanh.Size = new Size(248, 24);
            chkChuaHoanThanh.TabIndex = 8;
            chkChuaHoanThanh.Text = "Chỉ hiện chuyến chưa hoàn thành";
            chkChuaHoanThanh.UseVisualStyleBackColor = true;
            chkChuaHoanThanh.CheckedChanged += chkChuaHoanThanh_CheckedChanged;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(434, 428);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(100, 29);
            btnTim.TabIndex = 9;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // dgvChuyenDi
            // 
            dgvChuyenDi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChuyenDi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChuyenDi.Columns.AddRange(new DataGridViewColumn[] { colMaChuyen, colTenChuyen, colDiaDiem, colNgayDi, colSoNguoi, colNganSach, colPhuongTien, colDaHoanThanh });
            dgvChuyenDi.Location = new Point(-1, 484);
            dgvChuyenDi.Name = "dgvChuyenDi";
            dgvChuyenDi.RowHeadersWidth = 51;
            dgvChuyenDi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChuyenDi.Size = new Size(802, 188);
            dgvChuyenDi.TabIndex = 10;
            dgvChuyenDi.CellClick += dgvChuyenDi_CellClick;
            dgvChuyenDi.CellContentClick += dgvChuyenDi_CellClick;
            // 
            // colMaChuyen
            // 
            colMaChuyen.DataPropertyName = "MaChuyen";
            colMaChuyen.HeaderText = "Mã";
            colMaChuyen.MinimumWidth = 6;
            colMaChuyen.Name = "colMaChuyen";
            // 
            // colTenChuyen
            // 
            colTenChuyen.DataPropertyName = "TenChuyen";
            colTenChuyen.HeaderText = "Tên chuyến";
            colTenChuyen.MinimumWidth = 6;
            colTenChuyen.Name = "colTenChuyen";
            // 
            // colDiaDiem
            // 
            colDiaDiem.DataPropertyName = "DiaDiem";
            colDiaDiem.HeaderText = "Địa điểm";
            colDiaDiem.MinimumWidth = 6;
            colDiaDiem.Name = "colDiaDiem";
            // 
            // colNgayDi
            // 
            colNgayDi.DataPropertyName = "NgayDi";
            colNgayDi.HeaderText = "Ngày đi";
            colNgayDi.MinimumWidth = 6;
            colNgayDi.Name = "colNgayDi";
            // 
            // colSoNguoi
            // 
            colSoNguoi.DataPropertyName = "SoNguoi";
            colSoNguoi.HeaderText = "Số người";
            colSoNguoi.MinimumWidth = 6;
            colSoNguoi.Name = "colSoNguoi";
            // 
            // colNganSach
            // 
            colNganSach.DataPropertyName = "NganSach";
            colNganSach.HeaderText = "Ngân sách";
            colNganSach.MinimumWidth = 6;
            colNganSach.Name = "colNganSach";
            // 
            // colPhuongTien
            // 
            colPhuongTien.DataPropertyName = "PhuongTien";
            colPhuongTien.HeaderText = "Phương tiện";
            colPhuongTien.MinimumWidth = 6;
            colPhuongTien.Name = "colPhuongTien";
            // 
            // colDaHoanThanh
            // 
            colDaHoanThanh.DataPropertyName = "DaHoanThanh";
            colDaHoanThanh.HeaderText = "Hoàn thành";
            colDaHoanThanh.MinimumWidth = 6;
            colDaHoanThanh.Name = "colDaHoanThanh";
            // 
            // FormChuyenDi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 671);
            Controls.Add(dgvChuyenDi);
            Controls.Add(txtTimKiem);
            Controls.Add(prgThoiTiet);
            Controls.Add(btnXemThoiTiet);
            Controls.Add(btnTim);
            Controls.Add(pnlThoiTiet);
            Controls.Add(chkChuaHoanThanh);
            Controls.Add(gbThongTin);
            Controls.Add(cboNgonNgu);
            Controls.Add(lblNgonNgu);
            Controls.Add(lblTieuDe);
            Name = "FormChuyenDi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kế hoạch dã ngoại cuối tuần";
            gbThongTin.ResumeLayout(false);
            gbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoNguoi).EndInit();
            pnlThoiTiet.ResumeLayout(false);
            pnlThoiTiet.PerformLayout();
            pnlLoiKhuyen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picThoiTiet).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenDi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblNgonNgu;
        private ComboBox cboNgonNgu;
        private GroupBox gbThongTin;
        private TextBox txtDiaDiem;
        private Label lblNgayDi;
        private Label lblDiaDiem;
        private TextBox txtTenChuyen;
        private Label lblTenChuyen;
        private NumericUpDown nudSoNguoi;
        private DateTimePicker dtpNgayDi;
        private TextBox txtNganSach;
        private Label lblPhuongTien;
        private Label lblNganSach;
        private Label lblSoNguoi;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private CheckBox chkDaHoanThanh;
        private ComboBox cboPhuongTien;
        private Panel pnlThoiTiet;
        private Button btnXemThoiTiet;
        private ProgressBar prgThoiTiet;
        private Label lblMoTaThoiTiet;
        private PictureBox picThoiTiet;
        private Label lblDuBaoTieuDe;
        private Panel pnlLoiKhuyen;
        private Label lblLoiKhuyen;
        private Label lblKhaNangMua;
        private Label lblNhietDo;
        private TextBox txtTimKiem;
        private CheckBox chkChuaHoanThanh;
        private Button btnTim;
        private DataGridView dgvChuyenDi;
        private DataGridViewTextBoxColumn colMaChuyen;
        private DataGridViewTextBoxColumn colTenChuyen;
        private DataGridViewTextBoxColumn colDiaDiem;
        private DataGridViewTextBoxColumn colNgayDi;
        private DataGridViewTextBoxColumn colSoNguoi;
        private DataGridViewTextBoxColumn colNganSach;
        private DataGridViewTextBoxColumn colPhuongTien;
        private DataGridViewTextBoxColumn colDaHoanThanh;
    }
}
