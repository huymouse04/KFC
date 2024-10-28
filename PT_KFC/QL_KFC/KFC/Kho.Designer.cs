namespace KFC
{
    partial class Kho
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
            this.dtGVKHO = new System.Windows.Forms.DataGridView();
            this.lbKHO = new System.Windows.Forms.Label();
            this.cbLH = new System.Windows.Forms.ComboBox();
            this.lbLH = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.lbDG = new System.Windows.Forms.Label();
            this.lbDVT = new System.Windows.Forms.Label();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.lbSL = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lbTSP = new System.Windows.Forms.Label();
            this.lbMSP = new System.Windows.Forms.Label();
            this.panel_Body = new System.Windows.Forms.Panel();
            this.pnBET = new System.Windows.Forms.Panel();
            this.btnLamMoi = new CustomButton.VBButton();
            this.btnXuat = new CustomButton.VBButton();
            this.btnThem = new CustomButton.VBButton();
            this.btnCapNhat = new CustomButton.VBButton();
            this.btnDelete = new CustomButton.VBButton();
            this.btnTimKiem = new CustomButton.VBButton();
            this.btnLoaiHang = new CustomButton.VBButton();
            this.btnNCC = new CustomButton.VBButton();
            this.btnNhapHang = new CustomButton.VBButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVKHO)).BeginInit();
            this.panel_Body.SuspendLayout();
            this.pnBET.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGVKHO
            // 
            this.dtGVKHO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVKHO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtGVKHO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVKHO.Dock = System.Windows.Forms.DockStyle.Bottom;

            this.dtGVKHO.Location = new System.Drawing.Point(0, 277);

            this.dtGVKHO.Name = "dtGVKHO";
            this.dtGVKHO.RowHeadersWidth = 51;
            this.dtGVKHO.Size = new System.Drawing.Size(950, 332);
            this.dtGVKHO.TabIndex = 16;
            this.dtGVKHO.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVKHO_CellDoubleClick_1);
            // 
            // lbKHO
            // 
            this.lbKHO.AutoSize = true;
            this.lbKHO.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKHO.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbKHO.Location = new System.Drawing.Point(395, 7);
            this.lbKHO.Name = "lbKHO";
            this.lbKHO.Size = new System.Drawing.Size(91, 36);
            this.lbKHO.TabIndex = 78;
            this.lbKHO.Text = "KHO";
            // 
            // cbLH
            // 
            this.cbLH.FormattingEnabled = true;
            this.cbLH.Location = new System.Drawing.Point(532, 199);
            this.cbLH.Name = "cbLH";
            this.cbLH.Size = new System.Drawing.Size(186, 21);
            this.cbLH.TabIndex = 5;
            // 
            // lbLH
            // 
            this.lbLH.AutoSize = true;
            this.lbLH.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLH.Location = new System.Drawing.Point(406, 197);
            this.lbLH.Name = "lbLH";
            this.lbLH.Size = new System.Drawing.Size(106, 21);
            this.lbLH.TabIndex = 72;
            this.lbLH.Text = "Loại hàng : ";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(532, 145);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(186, 20);
            this.txtDonGia.TabIndex = 4;
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(532, 95);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(186, 20);
            this.txtDVT.TabIndex = 3;
            // 
            // lbDG
            // 
            this.lbDG.AutoSize = true;
            this.lbDG.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDG.Location = new System.Drawing.Point(420, 141);
            this.lbDG.Name = "lbDG";
            this.lbDG.Size = new System.Drawing.Size(90, 21);
            this.lbDG.TabIndex = 69;
            this.lbDG.Text = "Đơn giá : ";
            // 
            // lbDVT
            // 
            this.lbDVT.AutoSize = true;
            this.lbDVT.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDVT.Location = new System.Drawing.Point(397, 95);
            this.lbDVT.Name = "lbDVT";
            this.lbDVT.Size = new System.Drawing.Size(113, 21);
            this.lbDVT.TabIndex = 68;
            this.lbDVT.Text = "Đơn vị tính : ";
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(161, 197);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(186, 20);
            this.txtSL.TabIndex = 2;
            // 
            // lbSL
            // 
            this.lbSL.AutoSize = true;
            this.lbSL.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSL.Location = new System.Drawing.Point(27, 197);
            this.lbSL.Name = "lbSL";
            this.lbSL.Size = new System.Drawing.Size(95, 21);
            this.lbSL.TabIndex = 62;
            this.lbSL.Text = "Số lượng : ";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(161, 145);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(186, 20);
            this.txtTenSP.TabIndex = 1;
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(161, 95);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(186, 20);
            this.txtMaSP.TabIndex = 0;
            // 
            // lbTSP
            // 
            this.lbTSP.AutoSize = true;
            this.lbTSP.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTSP.Location = new System.Drawing.Point(27, 145);
            this.lbTSP.Name = "lbTSP";
            this.lbTSP.Size = new System.Drawing.Size(131, 21);
            this.lbTSP.TabIndex = 59;
            this.lbTSP.Text = "Tên sản phẩm :";
            // 
            // lbMSP
            // 
            this.lbMSP.AutoSize = true;
            this.lbMSP.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMSP.Location = new System.Drawing.Point(27, 95);
            this.lbMSP.Name = "lbMSP";
            this.lbMSP.Size = new System.Drawing.Size(128, 21);
            this.lbMSP.TabIndex = 58;
            this.lbMSP.Text = "Mã sản phẩm :";
            // 
            // panel_Body
            // 
            this.panel_Body.Controls.Add(this.pnBET);
            this.panel_Body.Controls.Add(this.dtGVKHO);
            this.panel_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Body.Location = new System.Drawing.Point(0, 0);
            this.panel_Body.Name = "panel_Body";

            this.panel_Body.Size = new System.Drawing.Size(950, 661);

            this.panel_Body.TabIndex = 1;
            // 
            // pnBET
            // 
            this.pnBET.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnBET.Controls.Add(this.btnLamMoi);
            this.pnBET.Controls.Add(this.lbKHO);
            this.pnBET.Controls.Add(this.cbLH);
            this.pnBET.Controls.Add(this.btnXuat);
            this.pnBET.Controls.Add(this.btnThem);
            this.pnBET.Controls.Add(this.btnCapNhat);
            this.pnBET.Controls.Add(this.btnDelete);
            this.pnBET.Controls.Add(this.lbLH);
            this.pnBET.Controls.Add(this.txtDonGia);
            this.pnBET.Controls.Add(this.txtDVT);
            this.pnBET.Controls.Add(this.lbDG);
            this.pnBET.Controls.Add(this.lbDVT);
            this.pnBET.Controls.Add(this.btnTimKiem);
            this.pnBET.Controls.Add(this.btnLoaiHang);
            this.pnBET.Controls.Add(this.btnNCC);
            this.pnBET.Controls.Add(this.btnNhapHang);
            this.pnBET.Controls.Add(this.txtSL);
            this.pnBET.Controls.Add(this.lbSL);
            this.pnBET.Controls.Add(this.txtTenSP);
            this.pnBET.Controls.Add(this.txtMaSP);
            this.pnBET.Controls.Add(this.lbTSP);
            this.pnBET.Controls.Add(this.lbMSP);
            this.pnBET.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnBET.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBET.Location = new System.Drawing.Point(0, 0);
            this.pnBET.Name = "pnBET";
            this.pnBET.Size = new System.Drawing.Size(950, 333);
            this.pnBET.TabIndex = 17;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Firebrick;
            this.btnLamMoi.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnLamMoi.BorderColor = System.Drawing.Color.Crimson;
            this.btnLamMoi.BorderRadius = 10;
            this.btnLamMoi.BorderSize = 0;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(791, 253);

            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);

            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(142, 48);
            this.btnLamMoi.TabIndex = 14;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.TextColor = System.Drawing.Color.White;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
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
            this.btnXuat.Location = new System.Drawing.Point(630, 253);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(2);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(142, 48);
            this.btnXuat.TabIndex = 10;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.TextColor = System.Drawing.Color.White;
            this.btnXuat.UseVisualStyleBackColor = false;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);

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
            this.btnThem.Location = new System.Drawing.Point(12, 253);

            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);

            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(142, 48);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextColor = System.Drawing.Color.White;
            this.btnThem.UseVisualStyleBackColor = false;
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
            this.btnCapNhat.Location = new System.Drawing.Point(168, 253);

            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);

            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(142, 48);
            this.btnCapNhat.TabIndex = 7;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.TextColor = System.Drawing.Color.White;
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnDelete.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnDelete.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnDelete.BorderRadius = 10;
            this.btnDelete.BorderSize = 0;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(322, 253);

            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);

            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(142, 48);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Firebrick;
            this.btnTimKiem.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnTimKiem.BorderColor = System.Drawing.Color.Crimson;
            this.btnTimKiem.BorderRadius = 10;
            this.btnTimKiem.BorderSize = 0;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(477, 254);

            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);

            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(142, 48);
            this.btnTimKiem.TabIndex = 9;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextColor = System.Drawing.Color.White;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // btnLoaiHang
            // 
            this.btnLoaiHang.BackColor = System.Drawing.Color.Firebrick;
            this.btnLoaiHang.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnLoaiHang.BorderColor = System.Drawing.Color.Crimson;
            this.btnLoaiHang.BorderRadius = 10;
            this.btnLoaiHang.BorderSize = 0;
            this.btnLoaiHang.FlatAppearance.BorderSize = 0;
            this.btnLoaiHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoaiHang.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoaiHang.ForeColor = System.Drawing.Color.White;
            this.btnLoaiHang.Location = new System.Drawing.Point(791, 67);

            this.btnLoaiHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);

            this.btnLoaiHang.Name = "btnLoaiHang";
            this.btnLoaiHang.Size = new System.Drawing.Size(142, 48);
            this.btnLoaiHang.TabIndex = 11;
            this.btnLoaiHang.Text = "Loại hàng hóa";
            this.btnLoaiHang.TextColor = System.Drawing.Color.White;
            this.btnLoaiHang.UseVisualStyleBackColor = false;
            this.btnLoaiHang.Click += new System.EventHandler(this.btnLoaiHang_Click_1);
            // 
            // btnNCC
            // 
            this.btnNCC.BackColor = System.Drawing.Color.Firebrick;
            this.btnNCC.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnNCC.BorderColor = System.Drawing.Color.Crimson;
            this.btnNCC.BorderRadius = 10;
            this.btnNCC.BorderSize = 0;
            this.btnNCC.FlatAppearance.BorderSize = 0;
            this.btnNCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNCC.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNCC.ForeColor = System.Drawing.Color.White;
            this.btnNCC.Location = new System.Drawing.Point(791, 132);

            this.btnNCC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);

            this.btnNCC.Name = "btnNCC";
            this.btnNCC.Size = new System.Drawing.Size(142, 48);
            this.btnNCC.TabIndex = 12;
            this.btnNCC.Text = "Nhà cung cấp";
            this.btnNCC.TextColor = System.Drawing.Color.White;
            this.btnNCC.UseVisualStyleBackColor = false;
            this.btnNCC.Click += new System.EventHandler(this.btnNCC_Click_1);
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.BackColor = System.Drawing.Color.Firebrick;
            this.btnNhapHang.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnNhapHang.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnNhapHang.BorderRadius = 10;
            this.btnNhapHang.BorderSize = 0;
            this.btnNhapHang.FlatAppearance.BorderSize = 0;
            this.btnNhapHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapHang.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapHang.ForeColor = System.Drawing.Color.White;
            this.btnNhapHang.Location = new System.Drawing.Point(791, 197);

            this.btnNhapHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);

            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(142, 48);
            this.btnNhapHang.TabIndex = 13;
            this.btnNhapHang.Text = "Nhập hàng";
            this.btnNhapHang.TextColor = System.Drawing.Color.White;
            this.btnNhapHang.UseVisualStyleBackColor = false;
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click_1);
            // 
            // Kho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(950, 661);
            this.Controls.Add(this.panel_Body);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);

            this.Name = "Kho";
            this.Text = "Kho";
            ((System.ComponentModel.ISupportInitialize)(this.dtGVKHO)).EndInit();
            this.panel_Body.ResumeLayout(false);
            this.pnBET.ResumeLayout(false);
            this.pnBET.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGVKHO;
        private CustomButton.VBButton btnLamMoi;
        private System.Windows.Forms.Label lbKHO;
        private System.Windows.Forms.ComboBox cbLH;
        private CustomButton.VBButton btnXuat;
        private CustomButton.VBButton btnThem;
        private CustomButton.VBButton btnCapNhat;
        private CustomButton.VBButton btnDelete;
        private System.Windows.Forms.Label lbLH;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label lbDG;
        private System.Windows.Forms.Label lbDVT;
        private CustomButton.VBButton btnTimKiem;
        private CustomButton.VBButton btnLoaiHang;
        private CustomButton.VBButton btnNCC;
        private CustomButton.VBButton btnNhapHang;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Label lbSL;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lbTSP;
        private System.Windows.Forms.Label lbMSP;
        private System.Windows.Forms.Panel panel_Body;
        private System.Windows.Forms.Panel pnBET;
    }
}