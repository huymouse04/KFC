namespace KFC
{
    partial class CapNhatNhaCungCap
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
            this.pnFILL = new System.Windows.Forms.Panel();
            this.lbGC = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnHuy = new CustomButton.VBButton();
            this.BtnSave = new CustomButton.VBButton();
            this.btnBrowse = new CustomButton.VBButton();
            this.lbSDT = new System.Windows.Forms.Label();
            this.lbDC = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lbTNCC = new System.Windows.Forms.Label();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.lbMNCC = new System.Windows.Forms.Label();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.pbAnhNCC = new System.Windows.Forms.PictureBox();
            this.mtbSDT = new System.Windows.Forms.MaskedTextBox();
            this.pnFILL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnhNCC)).BeginInit();
            this.SuspendLayout();
            // 
            // pnFILL
            // 
            this.pnFILL.Controls.Add(this.mtbSDT);
            this.pnFILL.Controls.Add(this.lbGC);
            this.pnFILL.Controls.Add(this.txtGhiChu);
            this.pnFILL.Controls.Add(this.btnHuy);
            this.pnFILL.Controls.Add(this.BtnSave);
            this.pnFILL.Controls.Add(this.btnBrowse);
            this.pnFILL.Controls.Add(this.lbSDT);
            this.pnFILL.Controls.Add(this.lbDC);
            this.pnFILL.Controls.Add(this.txtDiaChi);
            this.pnFILL.Controls.Add(this.lbTNCC);
            this.pnFILL.Controls.Add(this.txtTenNCC);
            this.pnFILL.Controls.Add(this.lbMNCC);
            this.pnFILL.Controls.Add(this.txtMaNCC);
            this.pnFILL.Controls.Add(this.txtPath);
            this.pnFILL.Controls.Add(this.pbAnhNCC);
            this.pnFILL.Location = new System.Drawing.Point(11, 25);
            this.pnFILL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnFILL.Name = "pnFILL";
            this.pnFILL.Size = new System.Drawing.Size(499, 474);
            this.pnFILL.TabIndex = 4;
            // 
            // lbGC
            // 
            this.lbGC.AutoSize = true;
            this.lbGC.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbGC.Location = new System.Drawing.Point(311, 271);
            this.lbGC.Name = "lbGC";
            this.lbGC.Size = new System.Drawing.Size(67, 17);
            this.lbGC.TabIndex = 64;
            this.lbGC.Text = "Ghi chú :";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(312, 290);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(159, 20);
            this.txtGhiChu.TabIndex = 5;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Firebrick;
            this.btnHuy.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnHuy.BorderColor = System.Drawing.Color.White;
            this.btnHuy.BorderRadius = 10;
            this.btnHuy.BorderSize = 0;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(312, 412);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(78, 34);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextColor = System.Drawing.Color.White;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.Firebrick;
            this.BtnSave.BackgroundColor = System.Drawing.Color.Firebrick;
            this.BtnSave.BorderColor = System.Drawing.Color.White;
            this.BtnSave.BorderRadius = 10;
            this.BtnSave.BorderSize = 0;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(155, 412);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(73, 34);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "Lưu";
            this.BtnSave.TextColor = System.Drawing.Color.White;
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.Firebrick;
            this.btnBrowse.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnBrowse.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnBrowse.BorderRadius = 10;
            this.btnBrowse.BorderSize = 0;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(359, 120);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(78, 35);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Chọn Ảnh";
            this.btnBrowse.TextColor = System.Drawing.Color.White;
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lbSDT
            // 
            this.lbSDT.AutoSize = true;
            this.lbSDT.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbSDT.Location = new System.Drawing.Point(311, 201);
            this.lbSDT.Name = "lbSDT";
            this.lbSDT.Size = new System.Drawing.Size(44, 17);
            this.lbSDT.TabIndex = 57;
            this.lbSDT.Text = "SĐT :";
            // 
            // lbDC
            // 
            this.lbDC.AutoSize = true;
            this.lbDC.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbDC.Location = new System.Drawing.Point(68, 335);
            this.lbDC.Name = "lbDC";
            this.lbDC.Size = new System.Drawing.Size(63, 17);
            this.lbDC.TabIndex = 55;
            this.lbDC.Text = "Địa chỉ :";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(69, 354);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(159, 20);
            this.txtDiaChi.TabIndex = 3;
            // 
            // lbTNCC
            // 
            this.lbTNCC.AutoSize = true;
            this.lbTNCC.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTNCC.Location = new System.Drawing.Point(68, 271);
            this.lbTNCC.Name = "lbTNCC";
            this.lbTNCC.Size = new System.Drawing.Size(130, 17);
            this.lbTNCC.TabIndex = 53;
            this.lbTNCC.Text = "Tên nhà cung cấp :";
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(69, 290);
            this.txtTenNCC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(159, 20);
            this.txtTenNCC.TabIndex = 2;
            // 
            // lbMNCC
            // 
            this.lbMNCC.AutoSize = true;
            this.lbMNCC.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbMNCC.Location = new System.Drawing.Point(68, 201);
            this.lbMNCC.Name = "lbMNCC";
            this.lbMNCC.Size = new System.Drawing.Size(128, 17);
            this.lbMNCC.TabIndex = 51;
            this.lbMNCC.Text = "Mã nhà cung cấp :";
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Location = new System.Drawing.Point(69, 220);
            this.txtMaNCC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(159, 20);
            this.txtMaNCC.TabIndex = 1;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(346, 84);
            this.txtPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(101, 20);
            this.txtPath.TabIndex = 25;
            this.txtPath.Visible = false;
            // 
            // pbAnhNCC
            // 
            this.pbAnhNCC.Location = new System.Drawing.Point(186, 26);
            this.pbAnhNCC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbAnhNCC.Name = "pbAnhNCC";
            this.pbAnhNCC.Size = new System.Drawing.Size(132, 129);
            this.pbAnhNCC.TabIndex = 11;
            this.pbAnhNCC.TabStop = false;
            // 
            // mtbSDT
            // 
            this.mtbSDT.Location = new System.Drawing.Point(312, 220);
            this.mtbSDT.Margin = new System.Windows.Forms.Padding(2);
            this.mtbSDT.Mask = "0000000000";
            this.mtbSDT.Name = "mtbSDT";
            this.mtbSDT.Size = new System.Drawing.Size(159, 20);
            this.mtbSDT.TabIndex = 4;
            // 
            // CapNhatNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 523);
            this.Controls.Add(this.pnFILL);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CapNhatNhaCungCap";
            this.Text = "CapNhatNhaCungCap";
            this.pnFILL.ResumeLayout(false);
            this.pnFILL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnhNCC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnFILL;
        private System.Windows.Forms.Label lbGC;
        private System.Windows.Forms.TextBox txtGhiChu;
        private CustomButton.VBButton btnHuy;
        private CustomButton.VBButton BtnSave;
        private CustomButton.VBButton btnBrowse;
        private System.Windows.Forms.Label lbSDT;
        private System.Windows.Forms.Label lbDC;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lbTNCC;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.Label lbMNCC;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.PictureBox pbAnhNCC;
        private System.Windows.Forms.MaskedTextBox mtbSDT;
    }
}