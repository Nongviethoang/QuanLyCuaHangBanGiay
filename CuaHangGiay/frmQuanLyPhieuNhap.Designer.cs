namespace CuaHangGiay
{
    partial class frmQuanLyPhieuNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label13 = new System.Windows.Forms.Label();
            this.cbTenNCC = new System.Windows.Forms.ComboBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNgayLap = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLapPhieuNhap = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewPhieuNhap = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSP = new System.Windows.Forms.ComboBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInPN = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSDTNCC = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhieuNhap)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(351, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 51;
            this.label13.Text = "Phiếu nhập";
            // 
            // cbTenNCC
            // 
            this.cbTenNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTenNCC.FormattingEnabled = true;
            this.cbTenNCC.Location = new System.Drawing.Point(144, 138);
            this.cbTenNCC.Name = "cbTenNCC";
            this.cbTenNCC.Size = new System.Drawing.Size(190, 21);
            this.cbTenNCC.TabIndex = 49;
            this.cbTenNCC.SelectedIndexChanged += new System.EventHandler(this.cbTenNCC_SelectedIndexChanged);
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(144, 111);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.ReadOnly = true;
            this.txtTenNV.Size = new System.Drawing.Size(190, 20);
            this.txtTenNV.TabIndex = 48;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Tên nhà cung cấp";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Thành tiền";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(108, 146);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(87, 20);
            this.txtThanhTien.TabIndex = 44;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(108, 106);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.ReadOnly = true;
            this.txtGiaNhap.Size = new System.Drawing.Size(87, 20);
            this.txtGiaNhap.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Giá nhập";
            // 
            // txtNgayLap
            // 
            this.txtNgayLap.Location = new System.Drawing.Point(144, 43);
            this.txtNgayLap.Name = "txtNgayLap";
            this.txtNgayLap.ReadOnly = true;
            this.txtNgayLap.Size = new System.Drawing.Size(190, 20);
            this.txtNgayLap.TabIndex = 41;
            this.txtNgayLap.TextChanged += new System.EventHandler(this.txtNgayLap_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "Ngày lập";
            // 
            // btnLapPhieuNhap
            // 
            this.btnLapPhieuNhap.Location = new System.Drawing.Point(548, 309);
            this.btnLapPhieuNhap.Name = "btnLapPhieuNhap";
            this.btnLapPhieuNhap.Size = new System.Drawing.Size(162, 51);
            this.btnLapPhieuNhap.TabIndex = 39;
            this.btnLapPhieuNhap.Text = "Lập phiếu nhập";
            this.btnLapPhieuNhap.UseVisualStyleBackColor = true;
            this.btnLapPhieuNhap.Click += new System.EventHandler(this.btnLapPhieuNhap_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(548, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 51);
            this.button1.TabIndex = 37;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewPhieuNhap
            // 
            this.dataGridViewPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column7,
            this.Column5});
            this.dataGridViewPhieuNhap.Location = new System.Drawing.Point(351, 95);
            this.dataGridViewPhieuNhap.Name = "dataGridViewPhieuNhap";
            this.dataGridViewPhieuNhap.Size = new System.Drawing.Size(595, 154);
            this.dataGridViewPhieuNhap.TabIndex = 36;
            this.dataGridViewPhieuNhap.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPhieuNhap_CellContentClick);
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Mã sản phẩm";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Tên sản phẩm";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Số lượng";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Giá nhập";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Thành tiền";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Xóa";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbSP);
            this.groupBox1.Controls.Add(this.txtSoLuong);
            this.groupBox1.Controls.Add(this.txtTongTien);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGiaNhap);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtThanhTien);
            this.groupBox1.Location = new System.Drawing.Point(30, 206);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 236);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sản phẩm";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(10, 207);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số lượng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên sản phẩm";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cbSP
            // 
            this.cbSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSP.FormattingEnabled = true;
            this.cbSP.Location = new System.Drawing.Point(108, 68);
            this.cbSP.Name = "cbSP";
            this.cbSP.Size = new System.Drawing.Size(190, 21);
            this.cbSP.TabIndex = 1;
            this.cbSP.SelectedIndexChanged += new System.EventHandler(this.cbSP_SelectedIndexChanged);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(108, 23);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(87, 20);
            this.txtSoLuong.TabIndex = 0;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(108, 175);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(87, 20);
            this.txtTongTien.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "Tổng tiền";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Số điện thoại";
            // 
            // btnInPN
            // 
            this.btnInPN.Location = new System.Drawing.Point(354, 391);
            this.btnInPN.Name = "btnInPN";
            this.btnInPN.Size = new System.Drawing.Size(162, 51);
            this.btnInPN.TabIndex = 53;
            this.btnInPN.Text = "In Phiếu Nhập";
            this.btnInPN.UseVisualStyleBackColor = true;
            this.btnInPN.Click += new System.EventHandler(this.btnInPN_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Tên nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Mã nhân viên";
            // 
            // txtSDTNCC
            // 
            this.txtSDTNCC.Location = new System.Drawing.Point(144, 168);
            this.txtSDTNCC.Name = "txtSDTNCC";
            this.txtSDTNCC.ReadOnly = true;
            this.txtSDTNCC.Size = new System.Drawing.Size(190, 20);
            this.txtSDTNCC.TabIndex = 57;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(354, 309);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 51);
            this.button2.TabIndex = 60;
            this.button2.Text = "Lọc";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(391, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 24);
            this.label6.TabIndex = 61;
            this.label6.Text = "Quản lý phiếu nhập";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(144, 76);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(190, 20);
            this.txtMaNV.TabIndex = 62;
            // 
            // frmQuanLyPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 525);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtSDTNCC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnInPN);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbTenNCC);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtNgayLap);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLapPhieuNhap);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewPhieuNhap);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmQuanLyPhieuNhap";
            this.Text = "Quản lý phiếu nhập";
            this.Load += new System.EventHandler(this.frmQuanLyPhieuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhieuNhap)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbTenNCC;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNgayLap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLapPhieuNhap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewPhieuNhap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSP;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInPN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSDTNCC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewLinkColumn Column5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaNV;
    }
}