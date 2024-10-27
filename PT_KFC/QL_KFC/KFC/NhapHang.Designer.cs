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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbMaNCC = new System.Windows.Forms.ComboBox();
            this.lbMNCC = new System.Windows.Forms.Label();
            this.lbMLH = new System.Windows.Forms.Label();
            this.pnBET = new System.Windows.Forms.Panel();
            this.btnXuat = new CustomButton.VBButton();
            this.btnTimKiem = new CustomButton.VBButton();
            this.btnThem = new CustomButton.VBButton();
            this.btnCapNhat = new CustomButton.VBButton();
            this.btnXoa = new CustomButton.VBButton();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMaLH = new System.Windows.Forms.ComboBox();
            this.dtpNN = new System.Windows.Forms.DateTimePicker();
            this.cbMaSP = new System.Windows.Forms.ComboBox();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.txtMaNH = new System.Windows.Forms.TextBox();
            this.lbNN = new System.Windows.Forms.Label();
            this.lbDVT = new System.Windows.Forms.Label();
            this.lbSL = new System.Windows.Forms.Label();
            this.lbMSP = new System.Windows.Forms.Label();
            this.lbMNH = new System.Windows.Forms.Label();
            this.lblNH = new System.Windows.Forms.Label();
            this.pnTop = new System.Windows.Forms.Panel();
            this.dtGVNH = new System.Windows.Forms.DataGridView();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.btnDonGia = new System.Windows.Forms.Label();
            this.pnBET.SuspendLayout();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVNH)).BeginInit();
            this.SuspendLayout();
            // 
            // cbMaNCC
            // 
            this.cbMaNCC.FormattingEnabled = true;
            this.cbMaNCC.Location = new System.Drawing.Point(798, 283);
            this.cbMaNCC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaNCC.Name = "cbMaNCC";
            this.cbMaNCC.Size = new System.Drawing.Size(291, 28);
            this.cbMaNCC.TabIndex = 23;
            // 
            // lbMNCC
            // 
            this.lbMNCC.AutoSize = true;
            this.lbMNCC.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMNCC.Location = new System.Drawing.Point(552, 283);
            this.lbMNCC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMNCC.Name = "lbMNCC";
            this.lbMNCC.Size = new System.Drawing.Size(238, 34);
            this.lbMNCC.TabIndex = 22;
            this.lbMNCC.Text = "Mã nhà cung cấp :";
            // 
            // lbMLH
            // 
            this.lbMLH.AutoSize = true;
            this.lbMLH.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMLH.Location = new System.Drawing.Point(595, 212);
            this.lbMLH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMLH.Name = "lbMLH";
            this.lbMLH.Size = new System.Drawing.Size(191, 34);
            this.lbMLH.TabIndex = 20;
            this.lbMLH.Text = "Mã loại hàng :";
            // 
            // pnBET
            // 
            this.pnBET.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnBET.Controls.Add(this.txtDonGia);
            this.pnBET.Controls.Add(this.btnDonGia);
            this.pnBET.Controls.Add(this.btnXuat);
            this.pnBET.Controls.Add(this.btnTimKiem);
            this.pnBET.Controls.Add(this.btnThem);
            this.pnBET.Controls.Add(this.btnCapNhat);
            this.pnBET.Controls.Add(this.btnXoa);
            this.pnBET.Controls.Add(this.txtTenSP);
            this.pnBET.Controls.Add(this.label1);
            this.pnBET.Controls.Add(this.cbMaNCC);
            this.pnBET.Controls.Add(this.lbMNCC);
            this.pnBET.Controls.Add(this.cbMaLH);
            this.pnBET.Controls.Add(this.lbMLH);
            this.pnBET.Controls.Add(this.dtpNN);
            this.pnBET.Controls.Add(this.cbMaSP);
            this.pnBET.Controls.Add(this.txtDVT);
            this.pnBET.Controls.Add(this.txtSL);
            this.pnBET.Controls.Add(this.txtMaNH);
            this.pnBET.Controls.Add(this.lbNN);
            this.pnBET.Controls.Add(this.lbDVT);
            this.pnBET.Controls.Add(this.lbSL);
            this.pnBET.Controls.Add(this.lbMSP);
            this.pnBET.Controls.Add(this.lbMNH);
            this.pnBET.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBET.Location = new System.Drawing.Point(0, 562);
            this.pnBET.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnBET.Name = "pnBET";
            this.pnBET.Size = new System.Drawing.Size(1300, 455);
            this.pnBET.TabIndex = 9;
            // 
            // btnXuat
            // 
            this.btnXuat.BackColor = System.Drawing.Color.Firebrick;
            this.btnXuat.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnXuat.BorderColor = System.Drawing.Color.Crimson;
            this.btnXuat.BorderRadius = 10;
            this.btnXuat.BorderSize = 0;
            this.btnXuat.FlatAppearance.BorderSize = 0;
            this.btnXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuat.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.ForeColor = System.Drawing.Color.White;
            this.btnXuat.Location = new System.Drawing.Point(1123, 329);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(170, 55);
            this.btnXuat.TabIndex = 30;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.TextColor = System.Drawing.Color.White;
            this.btnXuat.UseVisualStyleBackColor = false;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Firebrick;
            this.btnTimKiem.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnTimKiem.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnTimKiem.BorderRadius = 10;
            this.btnTimKiem.BorderSize = 0;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(1123, 255);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(170, 55);
            this.btnTimKiem.TabIndex = 29;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextColor = System.Drawing.Color.White;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Firebrick;
            this.btnThem.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnThem.BorderColor = System.Drawing.Color.Crimson;
            this.btnThem.BorderRadius = 10;
            this.btnThem.BorderSize = 0;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(1123, 36);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(170, 55);
            this.btnThem.TabIndex = 28;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextColor = System.Drawing.Color.White;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.Firebrick;
            this.btnCapNhat.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnCapNhat.BorderColor = System.Drawing.Color.Crimson;
            this.btnCapNhat.BorderRadius = 10;
            this.btnCapNhat.BorderSize = 0;
            this.btnCapNhat.FlatAppearance.BorderSize = 0;
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Location = new System.Drawing.Point(1123, 105);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(170, 55);
            this.btnCapNhat.TabIndex = 27;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.TextColor = System.Drawing.Color.White;
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Firebrick;
            this.btnXoa.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnXoa.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnXoa.BorderRadius = 10;
            this.btnXoa.BorderSize = 0;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(1123, 180);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(170, 55);
            this.btnXoa.TabIndex = 26;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextColor = System.Drawing.Color.White;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(242, 208);
            this.txtTenSP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(291, 26);
            this.txtTenSP.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 205);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 34);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tên sản phẩm : ";
            // 
            // cbMaLH
            // 
            this.cbMaLH.FormattingEnabled = true;
            this.cbMaLH.Location = new System.Drawing.Point(798, 212);
            this.cbMaLH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaLH.Name = "cbMaLH";
            this.cbMaLH.Size = new System.Drawing.Size(291, 28);
            this.cbMaLH.TabIndex = 21;
            // 
            // dtpNN
            // 
            this.dtpNN.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNN.Location = new System.Drawing.Point(791, 123);
            this.dtpNN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpNN.Name = "dtpNN";
            this.dtpNN.Size = new System.Drawing.Size(298, 26);
            this.dtpNN.TabIndex = 19;
            // 
            // cbMaSP
            // 
            this.cbMaSP.FormattingEnabled = true;
            this.cbMaSP.Location = new System.Drawing.Point(242, 125);
            this.cbMaSP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMaSP.Name = "cbMaSP";
            this.cbMaSP.Size = new System.Drawing.Size(291, 28);
            this.cbMaSP.TabIndex = 18;
            this.cbMaSP.SelectedIndexChanged += new System.EventHandler(this.cbMaSP_SelectedIndexChanged);
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(798, 36);
            this.txtDVT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(291, 26);
            this.txtDVT.TabIndex = 10;
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(242, 285);
            this.txtSL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(291, 26);
            this.txtSL.TabIndex = 9;
            // 
            // txtMaNH
            // 
            this.txtMaNH.Enabled = false;
            this.txtMaNH.Location = new System.Drawing.Point(242, 36);
            this.txtMaNH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaNH.Name = "txtMaNH";
            this.txtMaNH.Size = new System.Drawing.Size(291, 26);
            this.txtMaNH.TabIndex = 7;
            // 
            // lbNN
            // 
            this.lbNN.AutoSize = true;
            this.lbNN.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNN.Location = new System.Drawing.Point(618, 116);
            this.lbNN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNN.Name = "lbNN";
            this.lbNN.Size = new System.Drawing.Size(161, 34);
            this.lbNN.TabIndex = 4;
            this.lbNN.Text = "Ngày nhập :";
            // 
            // lbDVT
            // 
            this.lbDVT.AutoSize = true;
            this.lbDVT.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDVT.Location = new System.Drawing.Point(618, 36);
            this.lbDVT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDVT.Name = "lbDVT";
            this.lbDVT.Size = new System.Drawing.Size(164, 34);
            this.lbDVT.TabIndex = 3;
            this.lbDVT.Text = "Đơn vị tính :";
            // 
            // lbSL
            // 
            this.lbSL.AutoSize = true;
            this.lbSL.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSL.Location = new System.Drawing.Point(76, 276);
            this.lbSL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSL.Name = "lbSL";
            this.lbSL.Size = new System.Drawing.Size(138, 34);
            this.lbSL.TabIndex = 2;
            this.lbSL.Text = "Số lượng :\r\n";
            // 
            // lbMSP
            // 
            this.lbMSP.AutoSize = true;
            this.lbMSP.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMSP.Location = new System.Drawing.Point(28, 125);
            this.lbMSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMSP.Name = "lbMSP";
            this.lbMSP.Size = new System.Drawing.Size(192, 34);
            this.lbMSP.TabIndex = 1;
            this.lbMSP.Text = "Mã sản phẩm :";
            // 
            // lbMNH
            // 
            this.lbMNH.AutoSize = true;
            this.lbMNH.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMNH.Location = new System.Drawing.Point(17, 36);
            this.lbMNH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMNH.Name = "lbMNH";
            this.lbMNH.Size = new System.Drawing.Size(205, 34);
            this.lbMNH.TabIndex = 0;
            this.lbMNH.Text = "Mã nhập hàng :";
            // 
            // lblNH
            // 
            this.lblNH.AutoSize = true;
            this.lblNH.BackColor = System.Drawing.Color.DarkRed;
            this.lblNH.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNH.ForeColor = System.Drawing.Color.White;
            this.lblNH.Location = new System.Drawing.Point(526, 29);
            this.lblNH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNH.Name = "lblNH";
            this.lblNH.Size = new System.Drawing.Size(259, 55);
            this.lblNH.TabIndex = 1;
            this.lblNH.Text = "Nhập Hàng";
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.DarkRed;
            this.pnTop.Controls.Add(this.lblNH);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1300, 114);
            this.pnTop.TabIndex = 8;
            // 
            // dtGVNH
            // 
            this.dtGVNH.AllowUserToAddRows = false;
            this.dtGVNH.AllowUserToDeleteRows = false;
            this.dtGVNH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGVNH.BackgroundColor = System.Drawing.Color.White;
            this.dtGVNH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtGVNH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVNH.GridColor = System.Drawing.Color.Firebrick;
            this.dtGVNH.Location = new System.Drawing.Point(0, 113);
            this.dtGVNH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtGVNH.Name = "dtGVNH";
            this.dtGVNH.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGVNH.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtGVNH.RowHeadersWidth = 51;
            this.dtGVNH.Size = new System.Drawing.Size(1300, 448);
            this.dtGVNH.TabIndex = 7;
            this.dtGVNH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVNH_CellClick);
            this.dtGVNH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVNH_CellContentClick);
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(242, 357);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(291, 26);
            this.txtDonGia.TabIndex = 32;
            // 
            // btnDonGia
            // 
            this.btnDonGia.AutoSize = true;
            this.btnDonGia.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonGia.Location = new System.Drawing.Point(76, 348);
            this.btnDonGia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnDonGia.Name = "btnDonGia";
            this.btnDonGia.Size = new System.Drawing.Size(121, 34);
            this.btnDonGia.TabIndex = 31;
            this.btnDonGia.Text = "Đơn giá:\r\n";
            // 
            // NhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 1017);
            this.Controls.Add(this.pnBET);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.dtGVNH);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NhapHang";
            this.Text = "NhapHang";
            this.pnBET.ResumeLayout(false);
            this.pnBET.PerformLayout();
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVNH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMaNCC;
        private System.Windows.Forms.Label lbMNCC;
        private System.Windows.Forms.Label lbMLH;
        private System.Windows.Forms.Panel pnBET;
        private System.Windows.Forms.ComboBox cbMaLH;
        private System.Windows.Forms.DateTimePicker dtpNN;
        private System.Windows.Forms.ComboBox cbMaSP;
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
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label1;
        private CustomButton.VBButton btnTimKiem;
        private CustomButton.VBButton btnThem;
        private CustomButton.VBButton btnCapNhat;
        private CustomButton.VBButton btnXoa;
        private CustomButton.VBButton btnXuat;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label btnDonGia;
    }
}