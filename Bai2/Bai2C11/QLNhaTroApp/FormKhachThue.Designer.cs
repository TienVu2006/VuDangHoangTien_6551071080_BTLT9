namespace QLNhaTroApp;

partial class FormKhachThue
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
        grpThongTin = new GroupBox();
        txtHoTen = new TextBox();
        lblHoTen = new Label();
        pnlGioiTinh = new Panel();
        rbNu = new RadioButton();
        rbNam = new RadioButton();
        lblGioiTinh = new Label();
        dtpNgaySinh = new DateTimePicker();
        lblNgaySinh = new Label();
        txtSoDienThoai = new TextBox();
        lblSoDienThoai = new Label();
        cboPhong = new ComboBox();
        lblPhong = new Label();
        cboTinhThanh = new ComboBox();
        lblTinhThanh = new Label();
        cboPhuongXa = new ComboBox();
        lblPhuongXa = new Label();
        chkTamTru = new CheckBox();
        btnThem = new Button();
        btnSua = new Button();
        btnXoa = new Button();
        btnLamMoi = new Button();
        btnGayLoiThu = new Button();
        pnlTopSearch = new Panel();
        txtTimKiem = new TextBox();
        lblLocPhong = new Label();
        cboLocPhong = new ComboBox();
        lblLocTinh = new Label();
        cboLocTinh = new ComboBox();
        btnTim = new Button();
        btnBoLoc = new Button();
        dgvKhachThue = new DataGridView();
        colMaKhach = new DataGridViewTextBoxColumn();
        colHoTen = new DataGridViewTextBoxColumn();
        colSDT = new DataGridViewTextBoxColumn();
        colPhong = new DataGridViewTextBoxColumn();
        colGiaThue = new DataGridViewTextBoxColumn();
        colQueQuan = new DataGridViewTextBoxColumn();
        colTamTru = new DataGridViewCheckBoxColumn();
        statusStrip = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();
        grpThongTin.SuspendLayout();
        pnlGioiTinh.SuspendLayout();
        pnlTopSearch.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvKhachThue).BeginInit();
        statusStrip.SuspendLayout();
        SuspendLayout();
        // 
        // grpThongTin
        // 
        grpThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        grpThongTin.Controls.Add(btnGayLoiThu);
        grpThongTin.Controls.Add(btnLamMoi);
        grpThongTin.Controls.Add(btnXoa);
        grpThongTin.Controls.Add(btnSua);
        grpThongTin.Controls.Add(btnThem);
        grpThongTin.Controls.Add(chkTamTru);
        grpThongTin.Controls.Add(cboPhuongXa);
        grpThongTin.Controls.Add(lblPhuongXa);
        grpThongTin.Controls.Add(cboTinhThanh);
        grpThongTin.Controls.Add(lblTinhThanh);
        grpThongTin.Controls.Add(cboPhong);
        grpThongTin.Controls.Add(lblPhong);
        grpThongTin.Controls.Add(txtSoDienThoai);
        grpThongTin.Controls.Add(lblSoDienThoai);
        grpThongTin.Controls.Add(dtpNgaySinh);
        grpThongTin.Controls.Add(lblNgaySinh);
        grpThongTin.Controls.Add(pnlGioiTinh);
        grpThongTin.Controls.Add(lblGioiTinh);
        grpThongTin.Controls.Add(txtHoTen);
        grpThongTin.Controls.Add(lblHoTen);
        grpThongTin.Font = new Font("Segoe UI", 9.5F);
        grpThongTin.Location = new Point(12, 12);
        grpThongTin.Name = "grpThongTin";
        grpThongTin.Size = new Size(360, 520);
        grpThongTin.TabIndex = 0;
        grpThongTin.TabStop = false;
        grpThongTin.Text = "Thông tin khách thuê";
        // 
        // lblHoTen
        // 
        lblHoTen.AutoSize = true;
        lblHoTen.Location = new Point(15, 30);
        lblHoTen.Name = "lblHoTen";
        lblHoTen.Size = new Size(50, 17);
        lblHoTen.TabIndex = 0;
        lblHoTen.Text = "Họ tên:";
        // 
        // txtHoTen
        // 
        txtHoTen.Location = new Point(110, 27);
        txtHoTen.Name = "txtHoTen";
        txtHoTen.Size = new Size(230, 24);
        txtHoTen.TabIndex = 1;
        // 
        // lblGioiTinh
        // 
        lblGioiTinh.AutoSize = true;
        lblGioiTinh.Location = new Point(15, 65);
        lblGioiTinh.Name = "lblGioiTinh";
        lblGioiTinh.Size = new Size(59, 17);
        lblGioiTinh.TabIndex = 2;
        lblGioiTinh.Text = "Giới tính:";
        // 
        // pnlGioiTinh
        // 
        pnlGioiTinh.Controls.Add(rbNu);
        pnlGioiTinh.Controls.Add(rbNam);
        pnlGioiTinh.Location = new Point(110, 58);
        pnlGioiTinh.Name = "pnlGioiTinh";
        pnlGioiTinh.Size = new Size(230, 30);
        pnlGioiTinh.TabIndex = 3;
        // 
        // rbNam
        // 
        rbNam.AutoSize = true;
        rbNam.Checked = true;
        rbNam.Location = new Point(5, 5);
        rbNam.Name = "rbNam";
        rbNam.Size = new Size(54, 21);
        rbNam.TabIndex = 0;
        rbNam.TabStop = true;
        rbNam.Text = "Nam";
        rbNam.UseVisualStyleBackColor = true;
        // 
        // rbNu
        // 
        rbNu.AutoSize = true;
        rbNu.Location = new Point(90, 5);
        rbNu.Name = "rbNu";
        rbNu.Size = new Size(44, 21);
        rbNu.TabIndex = 1;
        rbNu.Text = "Nữ";
        rbNu.UseVisualStyleBackColor = true;
        // 
        // lblNgaySinh
        // 
        lblNgaySinh.AutoSize = true;
        lblNgaySinh.Location = new Point(15, 100);
        lblNgaySinh.Name = "lblNgaySinh";
        lblNgaySinh.Size = new Size(69, 17);
        lblNgaySinh.TabIndex = 4;
        lblNgaySinh.Text = "Ngày sinh:";
        // 
        // dtpNgaySinh
        // 
        dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
        dtpNgaySinh.Format = DateTimePickerFormat.Custom;
        dtpNgaySinh.Location = new Point(110, 95);
        dtpNgaySinh.Name = "dtpNgaySinh";
        dtpNgaySinh.Size = new Size(230, 24);
        dtpNgaySinh.TabIndex = 5;
        // 
        // lblSoDienThoai
        // 
        lblSoDienThoai.AutoSize = true;
        lblSoDienThoai.Location = new Point(15, 135);
        lblSoDienThoai.Name = "lblSoDienThoai";
        lblSoDienThoai.Size = new Size(88, 17);
        lblSoDienThoai.TabIndex = 6;
        lblSoDienThoai.Text = "Số điện thoại:";
        // 
        // txtSoDienThoai
        // 
        txtSoDienThoai.Location = new Point(110, 132);
        txtSoDienThoai.Name = "txtSoDienThoai";
        txtSoDienThoai.Size = new Size(230, 24);
        txtSoDienThoai.TabIndex = 7;
        // 
        // lblPhong
        // 
        lblPhong.AutoSize = true;
        lblPhong.Location = new Point(15, 170);
        lblPhong.Name = "lblPhong";
        lblPhong.Size = new Size(48, 17);
        lblPhong.TabIndex = 8;
        lblPhong.Text = "Phòng:";
        // 
        // cboPhong
        // 
        cboPhong.DropDownStyle = ComboBoxStyle.DropDownList;
        cboPhong.FormattingEnabled = true;
        cboPhong.Location = new Point(110, 167);
        cboPhong.Name = "cboPhong";
        cboPhong.Size = new Size(230, 25);
        cboPhong.TabIndex = 9;
        // 
        // lblTinhThanh
        // 
        lblTinhThanh.AutoSize = true;
        lblTinhThanh.Location = new Point(15, 207);
        lblTinhThanh.Name = "lblTinhThanh";
        lblTinhThanh.Size = new Size(74, 17);
        lblTinhThanh.TabIndex = 10;
        lblTinhThanh.Text = "Tỉnh/Thành:";
        // 
        // cboTinhThanh
        // 
        cboTinhThanh.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTinhThanh.FormattingEnabled = true;
        cboTinhThanh.Location = new Point(110, 204);
        cboTinhThanh.Name = "cboTinhThanh";
        cboTinhThanh.Size = new Size(230, 25);
        cboTinhThanh.TabIndex = 11;
        cboTinhThanh.SelectedIndexChanged += cboTinhThanh_SelectedIndexChanged;
        // 
        // lblPhuongXa
        // 
        lblPhuongXa.AutoSize = true;
        lblPhuongXa.Location = new Point(15, 244);
        lblPhuongXa.Name = "lblPhuongXa";
        lblPhuongXa.Size = new Size(76, 17);
        lblPhuongXa.TabIndex = 12;
        lblPhuongXa.Text = "Phường/Xã:";
        // 
        // cboPhuongXa
        // 
        cboPhuongXa.FormattingEnabled = true;
        cboPhuongXa.Location = new Point(110, 241);
        cboPhuongXa.Name = "cboPhuongXa";
        cboPhuongXa.Size = new Size(230, 25);
        cboPhuongXa.TabIndex = 13;
        // 
        // chkTamTru
        // 
        chkTamTru.AutoSize = true;
        chkTamTru.Location = new Point(110, 280);
        chkTamTru.Name = "chkTamTru";
        chkTamTru.Size = new Size(137, 21);
        chkTamTru.TabIndex = 14;
        chkTamTru.Text = "Đã đăng ký tạm trú";
        chkTamTru.UseVisualStyleBackColor = true;
        // 
        // btnThem
        // 
        btnThem.Location = new Point(15, 320);
        btnThem.Name = "btnThem";
        btnThem.Size = new Size(75, 32);
        btnThem.TabIndex = 15;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;
        btnThem.Click += btnThem_Click;
        // 
        // btnSua
        // 
        btnSua.Location = new Point(100, 320);
        btnSua.Name = "btnSua";
        btnSua.Size = new Size(75, 32);
        btnSua.TabIndex = 16;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = true;
        btnSua.Click += btnSua_Click;
        // 
        // btnXoa
        // 
        btnXoa.Location = new Point(185, 320);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(75, 32);
        btnXoa.TabIndex = 17;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;
        // 
        // btnLamMoi
        // 
        btnLamMoi.Location = new Point(270, 320);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new Size(75, 32);
        btnLamMoi.TabIndex = 18;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;
        btnLamMoi.Click += btnLamMoi_Click;
        // 
        // btnGayLoiThu
        // 
        btnGayLoiThu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnGayLoiThu.Font = new Font("Segoe UI", 8F);
        btnGayLoiThu.ForeColor = Color.DarkRed;
        btnGayLoiThu.Location = new Point(15, 475);
        btnGayLoiThu.Name = "btnGayLoiThu";
        btnGayLoiThu.Size = new Size(110, 28);
        btnGayLoiThu.TabIndex = 19;
        btnGayLoiThu.Text = "⚠ Gây lỗi thử";
        btnGayLoiThu.UseVisualStyleBackColor = true;
        btnGayLoiThu.Click += btnGayLoiThu_Click;
        // 
        // pnlTopSearch
        // 
        pnlTopSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        pnlTopSearch.Controls.Add(btnBoLoc);
        pnlTopSearch.Controls.Add(btnTim);
        pnlTopSearch.Controls.Add(cboLocTinh);
        pnlTopSearch.Controls.Add(lblLocTinh);
        pnlTopSearch.Controls.Add(cboLocPhong);
        pnlTopSearch.Controls.Add(lblLocPhong);
        pnlTopSearch.Controls.Add(txtTimKiem);
        pnlTopSearch.Font = new Font("Segoe UI", 9.5F);
        pnlTopSearch.Location = new Point(380, 12);
        pnlTopSearch.Name = "pnlTopSearch";
        pnlTopSearch.Size = new Size(650, 45);
        pnlTopSearch.TabIndex = 1;
        // 
        // txtTimKiem
        // 
        txtTimKiem.Location = new Point(5, 10);
        txtTimKiem.Name = "txtTimKiem";
        txtTimKiem.PlaceholderText = "Tìm theo tên hoặc SĐT...";
        txtTimKiem.Size = new Size(160, 24);
        txtTimKiem.TabIndex = 0;
        // 
        // lblLocPhong
        // 
        lblLocPhong.AutoSize = true;
        lblLocPhong.Location = new Point(175, 13);
        lblLocPhong.Name = "lblLocPhong";
        lblLocPhong.Size = new Size(48, 17);
        lblLocPhong.TabIndex = 1;
        lblLocPhong.Text = "Phòng:";
        // 
        // cboLocPhong
        // 
        cboLocPhong.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLocPhong.FormattingEnabled = true;
        cboLocPhong.Location = new Point(228, 10);
        cboLocPhong.Name = "cboLocPhong";
        cboLocPhong.Size = new Size(100, 25);
        cboLocPhong.TabIndex = 2;
        // 
        // lblLocTinh
        // 
        lblLocTinh.AutoSize = true;
        lblLocTinh.Location = new Point(335, 13);
        lblLocTinh.Name = "lblLocTinh";
        lblLocTinh.Size = new Size(35, 17);
        lblLocTinh.TabIndex = 3;
        lblLocTinh.Text = "Tỉnh:";
        // 
        // cboLocTinh
        // 
        cboLocTinh.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLocTinh.FormattingEnabled = true;
        cboLocTinh.Location = new Point(375, 10);
        cboLocTinh.Name = "cboLocTinh";
        cboLocTinh.Size = new Size(135, 25);
        cboLocTinh.TabIndex = 4;
        // 
        // btnTim
        // 
        btnTim.Location = new Point(520, 7);
        btnTim.Name = "btnTim";
        btnTim.Size = new Size(55, 30);
        btnTim.TabIndex = 5;
        btnTim.Text = "Tìm";
        btnTim.UseVisualStyleBackColor = true;
        btnTim.Click += btnTim_Click;
        // 
        // btnBoLoc
        // 
        btnBoLoc.Location = new Point(580, 7);
        btnBoLoc.Name = "btnBoLoc";
        btnBoLoc.Size = new Size(65, 30);
        btnBoLoc.TabIndex = 6;
        btnBoLoc.Text = "Bỏ lọc";
        btnBoLoc.UseVisualStyleBackColor = true;
        btnBoLoc.Click += btnBoLoc_Click;
        // 
        // dgvKhachThue
        // 
        dgvKhachThue.AllowUserToAddRows = false;
        dgvKhachThue.AllowUserToDeleteRows = false;
        dgvKhachThue.AutoGenerateColumns = false;
        dgvKhachThue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvKhachThue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvKhachThue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvKhachThue.Columns.AddRange(new DataGridViewColumn[] {
            colMaKhach,
            colHoTen,
            colSDT,
            colPhong,
            colGiaThue,
            colQueQuan,
            colTamTru
        });
        dgvKhachThue.Location = new Point(380, 65);
        dgvKhachThue.MultiSelect = false;
        dgvKhachThue.Name = "dgvKhachThue";
        dgvKhachThue.ReadOnly = true;
        dgvKhachThue.RowHeadersVisible = false;
        dgvKhachThue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvKhachThue.Size = new Size(650, 467);
        dgvKhachThue.TabIndex = 2;
        dgvKhachThue.CellClick += dgvKhachThue_CellClick;
        // 
        // colMaKhach
        // 
        colMaKhach.DataPropertyName = "MaKhach";
        colMaKhach.HeaderText = "Mã";
        colMaKhach.Name = "colMaKhach";
        colMaKhach.ReadOnly = true;
        colMaKhach.Visible = false;
        // 
        // colHoTen
        // 
        colHoTen.DataPropertyName = "HoTen";
        colHoTen.FillWeight = 110F;
        colHoTen.HeaderText = "Họ tên";
        colHoTen.Name = "colHoTen";
        colHoTen.ReadOnly = true;
        // 
        // colSDT
        // 
        colSDT.DataPropertyName = "SoDienThoai";
        colSDT.FillWeight = 90F;
        colSDT.HeaderText = "SĐT";
        colSDT.Name = "colSDT";
        colSDT.ReadOnly = true;
        // 
        // colPhong
        // 
        colPhong.DataPropertyName = "TenPhong";
        colPhong.FillWeight = 60F;
        colPhong.HeaderText = "Phòng";
        colPhong.Name = "colPhong";
        colPhong.ReadOnly = true;
        // 
        // colGiaThue
        // 
        colGiaThue.DataPropertyName = "GiaThueFormat";
        colGiaThue.FillWeight = 95F;
        colGiaThue.HeaderText = "Giá thuê";
        colGiaThue.Name = "colGiaThue";
        colGiaThue.ReadOnly = true;
        // 
        // colQueQuan
        // 
        colQueQuan.DataPropertyName = "QueQuan";
        colQueQuan.FillWeight = 160F;
        colQueQuan.HeaderText = "Quê quán";
        colQueQuan.Name = "colQueQuan";
        colQueQuan.ReadOnly = true;
        // 
        // colTamTru
        // 
        colTamTru.DataPropertyName = "DaDangKyTamTru";
        colTamTru.FillWeight = 60F;
        colTamTru.HeaderText = "Tạm trú";
        colTamTru.Name = "colTamTru";
        colTamTru.ReadOnly = true;
        colTamTru.Resizable = DataGridViewTriState.True;
        colTamTru.SortMode = DataGridViewColumnSortMode.Automatic;
        // 
        // statusStrip
        // 
        statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus });
        statusStrip.Location = new Point(0, 542);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(1042, 22);
        statusStrip.TabIndex = 3;
        // 
        // lblStatus
        // 
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(59, 17);
        lblStatus.Text = "Sẵn sàng.";
        // 
        // FormKhachThue
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1042, 564);
        Controls.Add(statusStrip);
        Controls.Add(dgvKhachThue);
        Controls.Add(pnlTopSearch);
        Controls.Add(grpThongTin);
        Font = new Font("Segoe UI", 9.5F);
        MinimumSize = new Size(950, 550);
        Name = "FormKhachThue";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Quản lý nhà trọ - Khách thuê";
        Load += FormKhachThue_Load;
        grpThongTin.ResumeLayout(false);
        grpThongTin.PerformLayout();
        pnlGioiTinh.ResumeLayout(false);
        pnlGioiTinh.PerformLayout();
        pnlTopSearch.ResumeLayout(false);
        pnlTopSearch.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvKhachThue).EndInit();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private GroupBox grpThongTin;
    private Label lblHoTen;
    private TextBox txtHoTen;
    private Label lblGioiTinh;
    private Panel pnlGioiTinh;
    private RadioButton rbNam;
    private RadioButton rbNu;
    private Label lblNgaySinh;
    private DateTimePicker dtpNgaySinh;
    private Label lblSoDienThoai;
    private TextBox txtSoDienThoai;
    private Label lblPhong;
    private ComboBox cboPhong;
    private Label lblTinhThanh;
    private ComboBox cboTinhThanh;
    private Label lblPhuongXa;
    private ComboBox cboPhuongXa;
    private CheckBox chkTamTru;
    private Button btnThem;
    private Button btnSua;
    private Button btnXoa;
    private Button btnLamMoi;
    private Button btnGayLoiThu;
    private Panel pnlTopSearch;
    private TextBox txtTimKiem;
    private Label lblLocPhong;
    private ComboBox cboLocPhong;
    private Label lblLocTinh;
    private ComboBox cboLocTinh;
    private Button btnTim;
    private Button btnBoLoc;
    private DataGridView dgvKhachThue;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel lblStatus;
    private DataGridViewTextBoxColumn colMaKhach;
    private DataGridViewTextBoxColumn colHoTen;
    private DataGridViewTextBoxColumn colSDT;
    private DataGridViewTextBoxColumn colPhong;
    private DataGridViewTextBoxColumn colGiaThue;
    private DataGridViewTextBoxColumn colQueQuan;
    private DataGridViewCheckBoxColumn colTamTru;
}
