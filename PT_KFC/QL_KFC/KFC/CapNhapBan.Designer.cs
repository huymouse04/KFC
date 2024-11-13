namespace KFC
{
    partial class CapNhapBan
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
            this.btnHuy = new CustomButton.VBButton();
            this.BtnSave = new CustomButton.VBButton();
            this.txtTenBan = new System.Windows.Forms.TextBox();
            this.txtMaBan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radKhongTrong = new System.Windows.Forms.RadioButton();
            this.radBanTrong = new System.Windows.Forms.RadioButton();
            this.dtpkThoiGianDen = new System.Windows.Forms.DateTimePicker();
            this.dtpkThoiGianRoi = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
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
            this.btnHuy.Location = new System.Drawing.Point(138, 243);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(63, 24);
            this.btnHuy.TabIndex = 8;
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
            this.BtnSave.Location = new System.Drawing.Point(54, 243);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(63, 24);
            this.BtnSave.TabIndex = 7;
            this.BtnSave.Text = "Lưu";
            this.BtnSave.TextColor = System.Drawing.Color.White;
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtTenBan
            // 
            this.txtTenBan.Location = new System.Drawing.Point(42, 83);
            this.txtTenBan.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenBan.Name = "txtTenBan";
            this.txtTenBan.Size = new System.Drawing.Size(102, 20);
            this.txtTenBan.TabIndex = 2;
            // 
            // txtMaBan
            // 
            this.txtMaBan.Location = new System.Drawing.Point(42, 29);
            this.txtMaBan.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaBan.Name = "txtMaBan";
            this.txtMaBan.Size = new System.Drawing.Size(159, 20);
            this.txtMaBan.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Tên Bàn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Mã bàn";
            // 
            // radKhongTrong
            // 
            this.radKhongTrong.AutoSize = true;
            this.radKhongTrong.BackColor = System.Drawing.Color.Firebrick;
            this.radKhongTrong.ForeColor = System.Drawing.Color.White;
            this.radKhongTrong.Location = new System.Drawing.Point(145, 198);
            this.radKhongTrong.Margin = new System.Windows.Forms.Padding(2);
            this.radKhongTrong.Name = "radKhongTrong";
            this.radKhongTrong.Size = new System.Drawing.Size(87, 17);
            this.radKhongTrong.TabIndex = 6;
            this.radKhongTrong.TabStop = true;
            this.radKhongTrong.Text = "Không Trống";
            this.radKhongTrong.UseVisualStyleBackColor = false;
            // 
            // radBanTrong
            // 
            this.radBanTrong.AutoSize = true;
            this.radBanTrong.BackColor = System.Drawing.Color.Firebrick;
            this.radBanTrong.ForeColor = System.Drawing.Color.White;
            this.radBanTrong.Location = new System.Drawing.Point(37, 198);
            this.radBanTrong.Margin = new System.Windows.Forms.Padding(2);
            this.radBanTrong.Name = "radBanTrong";
            this.radBanTrong.Size = new System.Drawing.Size(53, 17);
            this.radBanTrong.TabIndex = 5;
            this.radBanTrong.TabStop = true;
            this.radBanTrong.Text = "Trống";
            this.radBanTrong.UseVisualStyleBackColor = false;
            // 
            // dtpkThoiGianDen
            // 
            this.dtpkThoiGianDen.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpkThoiGianDen.Location = new System.Drawing.Point(43, 121);
            this.dtpkThoiGianDen.Name = "dtpkThoiGianDen";
            this.dtpkThoiGianDen.Size = new System.Drawing.Size(101, 20);
            this.dtpkThoiGianDen.TabIndex = 3;
            // 
            // dtpkThoiGianRoi
            // 
            this.dtpkThoiGianRoi.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpkThoiGianRoi.Location = new System.Drawing.Point(43, 159);
            this.dtpkThoiGianRoi.Name = "dtpkThoiGianRoi";
            this.dtpkThoiGianRoi.Size = new System.Drawing.Size(101, 20);
            this.dtpkThoiGianRoi.TabIndex = 4;
            // 
            // CapNhapBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 274);
            this.Controls.Add(this.dtpkThoiGianRoi);
            this.Controls.Add(this.dtpkThoiGianDen);
            this.Controls.Add(this.radKhongTrong);
            this.Controls.Add(this.radBanTrong);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.txtTenBan);
            this.Controls.Add(this.txtMaBan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CapNhapBan";
            this.Text = "CapNhapBan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomButton.VBButton btnHuy;
        private CustomButton.VBButton BtnSave;
        private System.Windows.Forms.TextBox txtTenBan;
        private System.Windows.Forms.TextBox txtMaBan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radKhongTrong;
        private System.Windows.Forms.RadioButton radBanTrong;
        private System.Windows.Forms.DateTimePicker dtpkThoiGianDen;
        private System.Windows.Forms.DateTimePicker dtpkThoiGianRoi;
    }
}