namespace Bai4
{
    partial class FormThucDon
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
            lblTenMon = new Label();
            txtTenMon = new TextBox();
            lblDanhMuc = new Label();
            cboDanhMuc = new ComboBox();
            lblGiaBan = new Label();
            numGiaBan = new NumericUpDown();
            chkDangBan = new CheckBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            dgvMonUong = new DataGridView();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            ((System.ComponentModel.ISupportInitialize)numGiaBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonUong).BeginInit();
            SuspendLayout();
            // 
            // lblTenMon
            // 
            lblTenMon.AutoSize = true;
            lblTenMon.Location = new Point(20, 20);
            lblTenMon.Name = "lblTenMon";
            lblTenMon.Size = new Size(56, 15);
            lblTenMon.TabIndex = 0;
            lblTenMon.Text = "Tên món:";
            // 
            // txtTenMon
            // 
            txtTenMon.Location = new Point(90, 17);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.Size = new Size(180, 23);
            txtTenMon.TabIndex = 1;
            // 
            // lblDanhMuc
            // 
            lblDanhMuc.AutoSize = true;
            lblDanhMuc.Location = new Point(20, 55);
            lblDanhMuc.Name = "lblDanhMuc";
            lblDanhMuc.Size = new Size(65, 15);
            lblDanhMuc.TabIndex = 2;
            lblDanhMuc.Text = "Danh mục:";
            // 
            // cboDanhMuc
            // 
            cboDanhMuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDanhMuc.FormattingEnabled = true;
            cboDanhMuc.Location = new Point(90, 52);
            cboDanhMuc.Name = "cboDanhMuc";
            cboDanhMuc.Size = new Size(180, 23);
            cboDanhMuc.TabIndex = 3;
            // 
            // lblGiaBan
            // 
            lblGiaBan.AutoSize = true;
            lblGiaBan.Location = new Point(300, 20);
            lblGiaBan.Name = "lblGiaBan";
            lblGiaBan.Size = new Size(50, 15);
            lblGiaBan.TabIndex = 4;
            lblGiaBan.Text = "Giá bán:";
            // 
            // numGiaBan
            // 
            numGiaBan.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numGiaBan.Location = new Point(360, 17);
            numGiaBan.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numGiaBan.Name = "numGiaBan";
            numGiaBan.Size = new Size(120, 23);
            numGiaBan.TabIndex = 5;
            // 
            // chkDangBan
            // 
            chkDangBan.AutoSize = true;
            chkDangBan.Checked = true;
            chkDangBan.CheckState = CheckState.Checked;
            chkDangBan.Location = new Point(360, 54);
            chkDangBan.Name = "chkDangBan";
            chkDangBan.Size = new Size(77, 19);
            chkDangBan.TabIndex = 6;
            chkDangBan.Text = "Đang bán";
            chkDangBan.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(510, 16);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 25);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(510, 50);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 25);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(595, 50);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 25);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // dgvMonUong
            // 
            dgvMonUong.AllowUserToAddRows = false;
            dgvMonUong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonUong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonUong.Location = new Point(20, 130);
            dgvMonUong.MultiSelect = false;
            dgvMonUong.Name = "dgvMonUong";
            dgvMonUong.ReadOnly = true;
            dgvMonUong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonUong.Size = new Size(650, 290);
            dgvMonUong.TabIndex = 10;
            dgvMonUong.SelectionChanged += dgvMonUong_SelectionChanged;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(90, 95);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(180, 23);
            txtTimKiem.TabIndex = 11;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(20, 98);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(59, 15);
            lblTimKiem.TabIndex = 12;
            lblTimKiem.Text = "Tìm kiếm:";
            // 
            // FormThucDon
            // 
            ClientSize = new Size(690, 440);
            Controls.Add(lblTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(dgvMonUong);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(chkDangBan);
            Controls.Add(numGiaBan);
            Controls.Add(lblGiaBan);
            Controls.Add(cboDanhMuc);
            Controls.Add(lblDanhMuc);
            Controls.Add(txtTenMon);
            Controls.Add(lblTenMon);
            Name = "FormThucDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý thực đơn";
            ((System.ComponentModel.ISupportInitialize)numGiaBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonUong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTenMon;
        private TextBox txtTenMon;
        private Label lblDanhMuc;
        private ComboBox cboDanhMuc;
        private Label lblGiaBan;
        private NumericUpDown numGiaBan;
        private CheckBox chkDangBan;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private DataGridView dgvMonUong;
        private TextBox txtTimKiem;
        private Label lblTimKiem;
    }
}