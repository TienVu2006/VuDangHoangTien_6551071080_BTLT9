namespace Bai4
{
    partial class FormBanHang
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
            grpChonMon = new GroupBox();
            btnThem = new Button();
            numSoLy = new NumericUpDown();
            lblSoLy = new Label();
            lstMonUong = new ListBox();
            cboDanhMuc = new ComboBox();
            lblDanhMuc = new Label();
            grpDonHang = new GroupBox();
            lblTongTien = new Label();
            btnXoaDong = new Button();
            dgvGioHang = new DataGridView();
            colTenMon = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            colThanhTien = new DataGridViewTextBoxColumn();
            grpThanhToan = new GroupBox();
            lblNoiDungChuyen = new Label();
            lblSoTienChuyen = new Label();
            lblThongTinCk = new Label();
            btnDaNhanTien = new Button();
            picQRCode = new PictureBox();
            btnTienMat = new Button();
            btnThanhToanCK = new Button();
            grpChonMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLy).BeginInit();
            grpDonHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).BeginInit();
            grpThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picQRCode).BeginInit();
            SuspendLayout();
            // 
            // grpChonMon
            // 
            grpChonMon.Controls.Add(btnThem);
            grpChonMon.Controls.Add(numSoLy);
            grpChonMon.Controls.Add(lblSoLy);
            grpChonMon.Controls.Add(lstMonUong);
            grpChonMon.Controls.Add(cboDanhMuc);
            grpChonMon.Controls.Add(lblDanhMuc);
            grpChonMon.Location = new Point(24, 24);
            grpChonMon.Name = "grpChonMon";
            grpChonMon.Size = new Size(300, 520);
            grpChonMon.TabIndex = 0;
            grpChonMon.TabStop = false;
            grpChonMon.Text = "Chọn món";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(18, 464);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(264, 40);
            btnThem.TabIndex = 5;
            btnThem.Text = "Thêm vào đơn";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // numSoLy
            // 
            numSoLy.Location = new Point(82, 418);
            numSoLy.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoLy.Name = "numSoLy";
            numSoLy.Size = new Size(200, 30);
            numSoLy.TabIndex = 4;
            numSoLy.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSoLy
            // 
            lblSoLy.AutoSize = true;
            lblSoLy.Location = new Point(18, 422);
            lblSoLy.Name = "lblSoLy";
            lblSoLy.Size = new Size(36, 15);
            lblSoLy.TabIndex = 3;
            lblSoLy.Text = "Số ly:";
            // 
            // lstMonUong
            // 
            lstMonUong.FormattingEnabled = true;
            lstMonUong.ItemHeight = 15;
            lstMonUong.Location = new Point(18, 100);
            lstMonUong.Name = "lstMonUong";
            lstMonUong.Size = new Size(264, 300);
            lstMonUong.TabIndex = 2;
            // 
            // cboDanhMuc
            // 
            cboDanhMuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDanhMuc.FormattingEnabled = true;
            cboDanhMuc.Location = new Point(18, 50);
            cboDanhMuc.Name = "cboDanhMuc";
            cboDanhMuc.Size = new Size(264, 30);
            cboDanhMuc.TabIndex = 1;
            cboDanhMuc.SelectedIndexChanged += cboDanhMuc_SelectedIndexChanged;
            // 
            // lblDanhMuc
            // 
            lblDanhMuc.AutoSize = true;
            lblDanhMuc.Location = new Point(18, 26);
            lblDanhMuc.Name = "lblDanhMuc";
            lblDanhMuc.Size = new Size(65, 15);
            lblDanhMuc.TabIndex = 0;
            lblDanhMuc.Text = "Danh mục:";
            // 
            // grpDonHang
            // 
            grpDonHang.Controls.Add(lblTongTien);
            grpDonHang.Controls.Add(btnXoaDong);
            grpDonHang.Controls.Add(dgvGioHang);
            grpDonHang.Location = new Point(348, 24);
            grpDonHang.Name = "grpDonHang";
            grpDonHang.Size = new Size(400, 520);
            grpDonHang.TabIndex = 1;
            grpDonHang.TabStop = false;
            grpDonHang.Text = "Đơn hiện tại";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongTien.Location = new Point(18, 478);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(130, 21);
            lblTongTien.TabIndex = 2;
            lblTongTien.Text = "Tổng tiền: 0 đ";
            // 
            // btnXoaDong
            // 
            btnXoaDong.Location = new Point(18, 418);
            btnXoaDong.Name = "btnXoaDong";
            btnXoaDong.Size = new Size(364, 40);
            btnXoaDong.TabIndex = 1;
            btnXoaDong.Text = "Xóa dòng";
            btnXoaDong.UseVisualStyleBackColor = true;
            btnXoaDong.Click += btnXoaDong_Click;
            // 
            // dgvGioHang
            // 
            dgvGioHang.AllowUserToAddRows = false;
            dgvGioHang.AutoGenerateColumns = false;
            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGioHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGioHang.Columns.AddRange(new DataGridViewColumn[] { colTenMon, colSoLuong, colDonGia, colThanhTien });
            dgvGioHang.Location = new Point(18, 28);
            dgvGioHang.MultiSelect = false;
            dgvGioHang.Name = "dgvGioHang";
            dgvGioHang.ReadOnly = true;
            dgvGioHang.RowHeadersVisible = false;
            dgvGioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGioHang.Size = new Size(364, 370);
            dgvGioHang.TabIndex = 0;
            // 
            // colTenMon
            // 
            colTenMon.DataPropertyName = "TenMon";
            colTenMon.FillWeight = 40F;
            colTenMon.HeaderText = "Tên món";
            colTenMon.MinimumWidth = 60;
            colTenMon.Name = "colTenMon";
            // 
            // colSoLuong
            // 
            colSoLuong.DataPropertyName = "SoLuong";
            colSoLuong.FillWeight = 15F;
            colSoLuong.HeaderText = "SL";
            colSoLuong.MinimumWidth = 40;
            colSoLuong.Name = "colSoLuong";
            // 
            // colDonGia
            // 
            colDonGia.DataPropertyName = "DonGia";
            colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDonGia.DefaultCellStyle.Format = "N0";
            colDonGia.FillWeight = 22F;
            colDonGia.HeaderText = "Đơn giá";
            colDonGia.MinimumWidth = 60;
            colDonGia.Name = "colDonGia";
            // 
            // colThanhTien
            // 
            colThanhTien.DataPropertyName = "ThanhTien";
            colThanhTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colThanhTien.DefaultCellStyle.Format = "N0";
            colThanhTien.FillWeight = 23F;
            colThanhTien.HeaderText = "Thành tiền";
            colThanhTien.MinimumWidth = 70;
            colThanhTien.Name = "colThanhTien";
            // 
            // grpThanhToan
            // 
            grpThanhToan.Controls.Add(lblNoiDungChuyen);
            grpThanhToan.Controls.Add(lblSoTienChuyen);
            grpThanhToan.Controls.Add(lblThongTinCk);
            grpThanhToan.Controls.Add(btnDaNhanTien);
            grpThanhToan.Controls.Add(picQRCode);
            grpThanhToan.Controls.Add(btnTienMat);
            grpThanhToan.Controls.Add(btnThanhToanCK);
            grpThanhToan.Location = new Point(772, 24);
            grpThanhToan.Name = "grpThanhToan";
            grpThanhToan.Size = new Size(260, 520);
            grpThanhToan.TabIndex = 2;
            grpThanhToan.TabStop = false;
            grpThanhToan.Text = "Thanh toán";
            // 
            // lblNoiDungChuyen
            // 
            lblNoiDungChuyen.AutoSize = true;
            lblNoiDungChuyen.Location = new Point(18, 400);
            lblNoiDungChuyen.Name = "lblNoiDungChuyen";
            lblNoiDungChuyen.Size = new Size(60, 15);
            lblNoiDungChuyen.TabIndex = 5;
            lblNoiDungChuyen.Text = "Nội dung:";
            // 
            // lblSoTienChuyen
            // 
            lblSoTienChuyen.AutoSize = true;
            lblSoTienChuyen.Location = new Point(18, 376);
            lblSoTienChuyen.Name = "lblSoTienChuyen";
            lblSoTienChuyen.Size = new Size(46, 15);
            lblSoTienChuyen.TabIndex = 4;
            lblSoTienChuyen.Text = "Số tiền:";
            // 
            // lblThongTinCk
            // 
            lblThongTinCk.AutoEllipsis = true;
            lblThongTinCk.Font = new Font("Segoe UI", 8.25F);
            lblThongTinCk.Location = new Point(18, 120);
            lblThongTinCk.Name = "lblThongTinCk";
            lblThongTinCk.Size = new Size(224, 16);
            lblThongTinCk.TabIndex = 6;
            lblThongTinCk.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnDaNhanTien
            // 
            btnDaNhanTien.BackColor = Color.ForestGreen;
            btnDaNhanTien.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDaNhanTien.ForeColor = Color.White;
            btnDaNhanTien.Location = new Point(18, 436);
            btnDaNhanTien.Name = "btnDaNhanTien";
            btnDaNhanTien.Size = new Size(224, 44);
            btnDaNhanTien.TabIndex = 3;
            btnDaNhanTien.Text = "Đã nhận tiền";
            btnDaNhanTien.UseVisualStyleBackColor = false;
            btnDaNhanTien.Click += btnDaNhanTien_Click;
            // 
            // picQRCode
            // 
            picQRCode.BorderStyle = BorderStyle.FixedSingle;
            picQRCode.Location = new Point(18, 136);
            picQRCode.Name = "picQRCode";
            picQRCode.Size = new Size(224, 224);
            picQRCode.SizeMode = PictureBoxSizeMode.Zoom;
            picQRCode.TabIndex = 2;
            picQRCode.TabStop = false;
            // 
            // btnTienMat
            // 
            btnTienMat.Location = new Point(18, 80);
            btnTienMat.Name = "btnTienMat";
            btnTienMat.Size = new Size(224, 36);
            btnTienMat.TabIndex = 1;
            btnTienMat.Text = "Tiền mặt";
            btnTienMat.UseVisualStyleBackColor = true;
            btnTienMat.Click += btnTienMat_Click;
            // 
            // btnThanhToanCK
            // 
            btnThanhToanCK.Location = new Point(18, 26);
            btnThanhToanCK.Name = "btnThanhToanCK";
            btnThanhToanCK.Size = new Size(224, 40);
            btnThanhToanCK.TabIndex = 0;
            btnThanhToanCK.Text = "Thanh toán chuyển khoản";
            btnThanhToanCK.UseVisualStyleBackColor = true;
            btnThanhToanCK.Click += btnThanhToanCK_Click;
            // 
            // FormBanHang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 568);
            Controls.Add(grpThanhToan);
            Controls.Add(grpDonHang);
            Controls.Add(grpChonMon);
            Name = "FormBanHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bán hàng - Quán trà sữa";
            grpChonMon.ResumeLayout(false);
            grpChonMon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLy).EndInit();
            grpDonHang.ResumeLayout(false);
            grpDonHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).EndInit();
            grpThanhToan.ResumeLayout(false);
            grpThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picQRCode).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpChonMon;
        private Label lblDanhMuc;
        private ComboBox cboDanhMuc;
        private ListBox lstMonUong;
        private Label lblSoLy;
        private NumericUpDown numSoLy;
        private Button btnThem;
        private GroupBox grpDonHang;
        private DataGridView dgvGioHang;
        private DataGridViewTextBoxColumn colTenMon;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colThanhTien;
        private Button btnXoaDong;
        private Label lblTongTien;
        private GroupBox grpThanhToan;
        private Button btnThanhToanCK;
        private Button btnTienMat;
        private PictureBox picQRCode;
        private Label lblSoTienChuyen;
        private Label lblNoiDungChuyen;
        private Label lblThongTinCk;
        private Button btnDaNhanTien;
    }
}