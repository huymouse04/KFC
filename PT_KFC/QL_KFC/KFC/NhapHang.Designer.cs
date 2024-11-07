namespace KFC
{
    partial class NhapHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNH = new System.Windows.Forms.Label();
            this.pnTop = new System.Windows.Forms.Panel();
            this.dtGVNH = new System.Windows.Forms.DataGridView();
            this.customPanel1 = new CustomPanel();
            this.vbButton1 = new CustomButton.VBButton();
            this.btnLamMoi = new CustomButton.VBButton();
            this.dtpNgayHH = new System.Windows.Forms.DateTimePicker();
            this.dtpNgaySX = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lbMNCC = new System.Windows.Forms.Label();
            this.btnDonGia = new System.Windows.Forms.Label();
            this.lbMNH = new System.Windows.Forms.Label();
            this.btnXuat = new CustomButton.VBButton();
            this.lbMSP = new System.Windows.Forms.Label();
            this.btnTimKiem = new CustomButton.VBButton();
            this.lbSL = new System.Windows.Forms.Label();
            this.btnThem = new CustomButton.VBButton();
            this.lbDVT = new System.Windows.Forms.Label();
            this.btnCapNhat = new CustomButton.VBButton();
            this.lbNN = new System.Windows.Forms.Label();
            this.btnXoa = new CustomButton.VBButton();
            this.txtMaNH = new System.Windows.Forms.TextBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.cbMaNCC = new System.Windows.Forms.ComboBox();
            this.cbTenSP = new System.Windows.Forms.ComboBox();
            this.dtpNN = new System.Windows.Forms.DateTimePicker();
            this.cbMaLH = new System.Windows.Forms.ComboBox();
            this.lbMLH = new System.Windows.Forms.Label();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVNH)).BeginInit();
            this.customPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNH
            // 
            this.lblNH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNH.AutoSize = true;
            this.lblNH.BackColor = System.Drawing.Color.DarkRed;
            this.lblNH.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNH.ForeColor = System.Drawing.Color.White;
            this.lblNH.Location = new System.Drawing.Point(588, 7);
            this.lblNH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNH.Name = "lblNH";
            this.lblNH.Size = new System.Drawing.Size(214, 45);
            this.lblNH.TabIndex = 1;
            this.lblNH.Text = "Nhập Hàng";
            this.lblNH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.DarkRed;
            this.pnTop.Controls.Add(this.lblNH);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1298, 59);
            this.pnTop.TabIndex = 8;
            // 
            // dtGVNH
            // 
            this.dtGVNH.AllowUserToAddRows = false;
            this.dtGVNH.AllowUserToDeleteRows = false;
            this.dtGVNH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGVNH.BackgroundColor = System.Drawing.Color.White;
            this.dtGVNH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtGVNH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVNH.GridColor = System.Drawing.Color.Firebrick;
            this.dtGVNH.Location = new System.Drawing.Point(0, 58);
            this.dtGVNH.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtGVNH.Name = "dtGVNH";
            this.dtGVNH.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVNH.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGVNH.RowHeadersWidth = 51;
            this.dtGVNH.Size = new System.Drawing.Size(1298, 319);
            this.dtGVNH.TabIndex = 7;
            this.dtGVNH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVNH_CellClick);
            // 
            // customPanel1
            // 
            this.customPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel1.BorderColor = System.Drawing.Color.DarkRed;
            this.customPanel1.BorderRadius = 30F;
            this.customPanel1.Controls.Add(this.vbButton1);
            this.customPanel1.Controls.Add(this.btnLamMoi);
            this.customPanel1.Controls.Add(this.dtpNgayHH);
            this.customPanel1.Controls.Add(this.dtpNgaySX);
            this.customPanel1.Controls.Add(this.label3);
            this.customPanel1.Controls.Add(this.label2);
            this.customPanel1.Controls.Add(this.txtDonGia);
            this.customPanel1.Controls.Add(this.lbMNCC);
            this.customPanel1.Controls.Add(this.btnDonGia);
            this.customPanel1.Controls.Add(this.lbMNH);
            this.customPanel1.Controls.Add(this.btnXuat);
            this.customPanel1.Controls.Add(this.lbMSP);
            this.customPanel1.Controls.Add(this.btnTimKiem);
            this.customPanel1.Controls.Add(this.lbSL);
            this.customPanel1.Controls.Add(this.btnThem);
            this.customPanel1.Controls.Add(this.lbDVT);
            this.customPanel1.Controls.Add(this.btnCapNhat);
            this.customPanel1.Controls.Add(this.lbNN);
            this.customPanel1.Controls.Add(this.btnXoa);
            this.customPanel1.Controls.Add(this.txtMaNH);
            this.customPanel1.Controls.Add(this.txtMaSP);
            this.customPanel1.Controls.Add(this.txtSL);
            this.customPanel1.Controls.Add(this.label1);
            this.customPanel1.Controls.Add(this.txtDVT);
            this.customPanel1.Controls.Add(this.cbMaNCC);
            this.customPanel1.Controls.Add(this.cbTenSP);
            this.customPanel1.Controls.Add(this.dtpNN);
            this.customPanel1.Controls.Add(this.cbMaLH);
            this.customPanel1.Controls.Add(this.lbMLH);
            this.customPanel1.Location = new System.Drawing.Point(61, 398);
            this.customPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.PanelColor = System.Drawing.Color.LightGray;
            this.customPanel1.Size = new System.Drawing.Size(1179, 310);
            this.customPanel1.TabIndex = 10;
            // 
            // vbButton1
            // 
            this.vbButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.vbButton1.BackColor = System.Drawing.Color.Firebrick;
            this.vbButton1.BackgroundColor = System.Drawing.Color.Firebrick;
            this.vbButton1.BorderColor = System.Drawing.Color.Crimson;
            this.vbButton1.BorderRadius = 10;
            this.vbButton1.BorderSize = 0;
            this.vbButton1.FlatAppearance.BorderSize = 0;
            this.vbButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vbButton1.ForeColor = System.Drawing.Color.White;
            this.vbButton1.Location = new System.Drawing.Point(1030, 240);
            this.vbButton1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.vbButton1.Name = "vbButton1";
            this.vbButton1.Size = new System.Drawing.Size(132, 54);
            this.vbButton1.TabIndex = 38;
            this.vbButton1.Text = "Đến Hạn";
            this.vbButton1.TextColor = System.Drawing.Color.White;
            this.vbButton1.UseVisualStyleBackColor = false;
            this.vbButton1.Click += new System.EventHandler(this.vbButton1_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.BackColor = System.Drawing.Color.Firebrick;
            this.btnLamMoi.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnLamMoi.BorderColor = System.Drawing.Color.Crimson;
            this.btnLamMoi.BorderRadius = 10;
            this.btnLamMoi.BorderSize = 0;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(886, 174);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(132, 54);
            this.btnLamMoi.TabIndex = 37;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.TextColor = System.Drawing.Color.White;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // dtpNgayHH
            // 
            this.dtpNgayHH.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dtpNgayHH.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayHH.Location = new System.Drawing.Point(875, 238);
            this.dtpNgayHH.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpNgayHH.Name = "dtpNgayHH";
            this.dtpNgayHH.Size = new System.Drawing.Size(121, 22);
            this.dtpNgayHH.TabIndex = 36;
            this.dtpNgayHH.Value = new System.DateTime(2024, 11, 7, 0, 0, 0, 0);
            // 
            // dtpNgaySX
            // 
            this.dtpNgaySX.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dtpNgaySX.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySX.Location = new System.Drawing.Point(577, 239);
            this.dtpNgaySX.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpNgaySX.Name = "dtpNgaySX";
            this.dtpNgaySX.Size = new System.Drawing.Size(122, 22);
            this.dtpNgaySX.TabIndex = 35;
            this.dtpNgaySX.Value = new System.DateTime(2024, 11, 7, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkRed;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(712, 235);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 27);
            this.label3.TabIndex = 34;
            this.label3.Text = "Ngày hết hạn :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkRed;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(392, 235);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 27);
            this.label2.TabIndex = 33;
            this.label2.Text = "Ngày sản xuất :";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDonGia.Enabled = false;
            this.txtDonGia.ForeColor = System.Drawing.Color.Firebrick;
            this.txtDonGia.Location = new System.Drawing.Point(207, 241);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(174, 22);
            this.txtDonGia.TabIndex = 32;
            // 
            // lbMNCC
            // 
            this.lbMNCC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbMNCC.AutoSize = true;
            this.lbMNCC.BackColor = System.Drawing.Color.DarkRed;
            this.lbMNCC.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMNCC.ForeColor = System.Drawing.Color.White;
            this.lbMNCC.Location = new System.Drawing.Point(392, 190);
            this.lbMNCC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMNCC.Name = "lbMNCC";
            this.lbMNCC.Size = new System.Drawing.Size(160, 27);
            this.lbMNCC.TabIndex = 22;
            this.lbMNCC.Text = "Nhà cung cấp :";
            // 
            // btnDonGia
            // 
            this.btnDonGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDonGia.AutoSize = true;
            this.btnDonGia.BackColor = System.Drawing.Color.DarkRed;
            this.btnDonGia.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonGia.ForeColor = System.Drawing.Color.White;
            this.btnDonGia.Location = new System.Drawing.Point(80, 235);
            this.btnDonGia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnDonGia.Name = "btnDonGia";
            this.btnDonGia.Size = new System.Drawing.Size(105, 27);
            this.btnDonGia.TabIndex = 31;
            this.btnDonGia.Text = "Đơn giá :\r\n";
            // 
            // lbMNH
            // 
            this.lbMNH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMNH.AutoSize = true;
            this.lbMNH.BackColor = System.Drawing.Color.DarkRed;
            this.lbMNH.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMNH.ForeColor = System.Drawing.Color.White;
            this.lbMNH.Location = new System.Drawing.Point(12, 54);
            this.lbMNH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMNH.Name = "lbMNH";
            this.lbMNH.Size = new System.Drawing.Size(166, 27);
            this.lbMNH.TabIndex = 0;
            this.lbMNH.Text = "Mã nhập hàng :";
            // 
            // btnXuat
            // 
            this.btnXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuat.BackColor = System.Drawing.Color.Firebrick;
            this.btnXuat.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnXuat.BorderColor = System.Drawing.Color.Crimson;
            this.btnXuat.BorderRadius = 10;
            this.btnXuat.BorderSize = 0;
            this.btnXuat.FlatAppearance.BorderSize = 0;
            this.btnXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuat.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.ForeColor = System.Drawing.Color.White;
            this.btnXuat.Location = new System.Drawing.Point(1030, 176);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(132, 54);
            this.btnXuat.TabIndex = 30;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.TextColor = System.Drawing.Color.White;
            this.btnXuat.UseVisualStyleBackColor = false;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // lbMSP
            // 
            this.lbMSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMSP.AutoSize = true;
            this.lbMSP.BackColor = System.Drawing.Color.DarkRed;
            this.lbMSP.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMSP.ForeColor = System.Drawing.Color.White;
            this.lbMSP.Location = new System.Drawing.Point(23, 147);
            this.lbMSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMSP.Name = "lbMSP";
            this.lbMSP.Size = new System.Drawing.Size(156, 27);
            this.lbMSP.TabIndex = 1;
            this.lbMSP.Text = "Mã sản phẩm :";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.BackColor = System.Drawing.Color.Firebrick;
            this.btnTimKiem.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnTimKiem.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnTimKiem.BorderRadius = 10;
            this.btnTimKiem.BorderSize = 0;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(1030, 101);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(132, 54);
            this.btnTimKiem.TabIndex = 29;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextColor = System.Drawing.Color.White;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lbSL
            // 
            this.lbSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSL.AutoSize = true;
            this.lbSL.BackColor = System.Drawing.Color.DarkRed;
            this.lbSL.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSL.ForeColor = System.Drawing.Color.White;
            this.lbSL.Location = new System.Drawing.Point(71, 190);
            this.lbSL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSL.Name = "lbSL";
            this.lbSL.Size = new System.Drawing.Size(113, 27);
            this.lbSL.TabIndex = 2;
            this.lbSL.Text = "Số lượng :\r\n";
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.BackColor = System.Drawing.Color.Firebrick;
            this.btnThem.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnThem.BorderColor = System.Drawing.Color.Crimson;
            this.btnThem.BorderRadius = 10;
            this.btnThem.BorderSize = 0;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(886, 26);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(132, 54);
            this.btnThem.TabIndex = 28;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextColor = System.Drawing.Color.White;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // lbDVT
            // 
            this.lbDVT.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbDVT.AutoSize = true;
            this.lbDVT.BackColor = System.Drawing.Color.DarkRed;
            this.lbDVT.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDVT.ForeColor = System.Drawing.Color.White;
            this.lbDVT.Location = new System.Drawing.Point(421, 54);
            this.lbDVT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDVT.Name = "lbDVT";
            this.lbDVT.Size = new System.Drawing.Size(136, 27);
            this.lbDVT.TabIndex = 3;
            this.lbDVT.Text = "Đơn vị tính :";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapNhat.BackColor = System.Drawing.Color.Firebrick;
            this.btnCapNhat.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnCapNhat.BorderColor = System.Drawing.Color.Crimson;
            this.btnCapNhat.BorderRadius = 10;
            this.btnCapNhat.BorderSize = 0;
            this.btnCapNhat.FlatAppearance.BorderSize = 0;
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Location = new System.Drawing.Point(1030, 26);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(132, 54);
            this.btnCapNhat.TabIndex = 27;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.TextColor = System.Drawing.Color.White;
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // lbNN
            // 
            this.lbNN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbNN.AutoSize = true;
            this.lbNN.BackColor = System.Drawing.Color.DarkRed;
            this.lbNN.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNN.ForeColor = System.Drawing.Color.White;
            this.lbNN.Location = new System.Drawing.Point(424, 103);
            this.lbNN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNN.Name = "lbNN";
            this.lbNN.Size = new System.Drawing.Size(131, 27);
            this.lbNN.TabIndex = 4;
            this.lbNN.Text = "Ngày nhập :";
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.BackColor = System.Drawing.Color.Firebrick;
            this.btnXoa.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnXoa.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnXoa.BorderRadius = 10;
            this.btnXoa.BorderSize = 0;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(886, 101);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(132, 54);
            this.btnXoa.TabIndex = 26;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextColor = System.Drawing.Color.White;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtMaNH
            // 
            this.txtMaNH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMaNH.Enabled = false;
            this.txtMaNH.ForeColor = System.Drawing.Color.Firebrick;
            this.txtMaNH.Location = new System.Drawing.Point(207, 60);
            this.txtMaNH.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMaNH.Name = "txtMaNH";
            this.txtMaNH.Size = new System.Drawing.Size(174, 22);
            this.txtMaNH.TabIndex = 7;
            // 
            // txtMaSP
            // 
            this.txtMaSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMaSP.ForeColor = System.Drawing.Color.Firebrick;
            this.txtMaSP.Location = new System.Drawing.Point(207, 154);
            this.txtMaSP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(174, 22);
            this.txtMaSP.TabIndex = 25;
            // 
            // txtSL
            // 
            this.txtSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSL.ForeColor = System.Drawing.Color.Firebrick;
            this.txtSL.Location = new System.Drawing.Point(207, 196);
            this.txtSL.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(174, 22);
            this.txtSL.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 27);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tên sản phẩm : ";
            // 
            // txtDVT
            // 
            this.txtDVT.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDVT.Enabled = false;
            this.txtDVT.ForeColor = System.Drawing.Color.Firebrick;
            this.txtDVT.Location = new System.Drawing.Point(591, 60);
            this.txtDVT.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(168, 22);
            this.txtDVT.TabIndex = 10;
            // 
            // cbMaNCC
            // 
            this.cbMaNCC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbMaNCC.BackColor = System.Drawing.Color.DarkRed;
            this.cbMaNCC.ForeColor = System.Drawing.Color.White;
            this.cbMaNCC.FormattingEnabled = true;
            this.cbMaNCC.Location = new System.Drawing.Point(591, 195);
            this.cbMaNCC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbMaNCC.Name = "cbMaNCC";
            this.cbMaNCC.Size = new System.Drawing.Size(168, 24);
            this.cbMaNCC.TabIndex = 23;
            // 
            // cbTenSP
            // 
            this.cbTenSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbTenSP.BackColor = System.Drawing.Color.DarkRed;
            this.cbTenSP.ForeColor = System.Drawing.Color.White;
            this.cbTenSP.FormattingEnabled = true;
            this.cbTenSP.Location = new System.Drawing.Point(207, 108);
            this.cbTenSP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbTenSP.Name = "cbTenSP";
            this.cbTenSP.Size = new System.Drawing.Size(174, 24);
            this.cbTenSP.TabIndex = 18;
            this.cbTenSP.SelectedIndexChanged += new System.EventHandler(this.cbMaSP_SelectedIndexChanged);
            // 
            // dtpNN
            // 
            this.dtpNN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dtpNN.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNN.Location = new System.Drawing.Point(591, 110);
            this.dtpNN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpNN.Name = "dtpNN";
            this.dtpNN.Size = new System.Drawing.Size(168, 22);
            this.dtpNN.TabIndex = 19;
            this.dtpNN.Value = new System.DateTime(2024, 11, 7, 0, 0, 0, 0);
            // 
            // cbMaLH
            // 
            this.cbMaLH.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbMaLH.BackColor = System.Drawing.Color.DarkRed;
            this.cbMaLH.ForeColor = System.Drawing.Color.White;
            this.cbMaLH.FormattingEnabled = true;
            this.cbMaLH.Location = new System.Drawing.Point(591, 152);
            this.cbMaLH.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbMaLH.Name = "cbMaLH";
            this.cbMaLH.Size = new System.Drawing.Size(168, 24);
            this.cbMaLH.TabIndex = 21;
            // 
            // lbMLH
            // 
            this.lbMLH.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbMLH.AutoSize = true;
            this.lbMLH.BackColor = System.Drawing.Color.DarkRed;
            this.lbMLH.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMLH.ForeColor = System.Drawing.Color.White;
            this.lbMLH.Location = new System.Drawing.Point(392, 147);
            this.lbMLH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMLH.Name = "lbMLH";
            this.lbMLH.Size = new System.Drawing.Size(160, 27);
            this.lbMLH.TabIndex = 20;
            this.lbMLH.Text = "Tên loại hàng :";
            // 
            // NhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1298, 743);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.dtGVNH);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NhapHang";
            this.Text = "NhapHang";
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVNH)).EndInit();
            this.customPanel1.ResumeLayout(false);
            this.customPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMaNCC;
        private System.Windows.Forms.Label lbMNCC;
        private System.Windows.Forms.Label lbMLH;
        private System.Windows.Forms.ComboBox cbMaLH;
        private System.Windows.Forms.DateTimePicker dtpNN;
        private System.Windows.Forms.ComboBox cbTenSP;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.TextBox txtMaNH;
        private System.Windows.Forms.Label lbNN;
        private System.Windows.Forms.Label lbDVT;
        private System.Windows.Forms.Label lbSL;
        private System.Windows.Forms.Label lbMSP;
        private System.Windows.Forms.Label lbMNH;
        private System.Windows.Forms.Label lblNH;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.DataGridView dtGVNH;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label1;
        private CustomButton.VBButton btnTimKiem;
        private CustomButton.VBButton btnThem;
        private CustomButton.VBButton btnCapNhat;
        private CustomButton.VBButton btnXoa;
        private CustomButton.VBButton btnXuat;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label btnDonGia;
        private CustomButton.VBButton btnClear;
        private CustomPanel customPanel1;
        private CustomButton.VBButton btnLamMoi;
        private System.Windows.Forms.DateTimePicker dtpNgayHH;
        private System.Windows.Forms.DateTimePicker dtpNgaySX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private CustomButton.VBButton vbButton1;
    }
}