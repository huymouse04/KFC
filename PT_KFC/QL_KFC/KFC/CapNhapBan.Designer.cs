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
            this.TxtImagePath = new System.Windows.Forms.TextBox();
            this.TxtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radMaNV = new System.Windows.Forms.RadioButton();
            this.radTenNV = new System.Windows.Forms.RadioButton();
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
            this.btnHuy.Location = new System.Drawing.Point(180, 245);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(84, 29);
            this.btnHuy.TabIndex = 45;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextColor = System.Drawing.Color.White;
            this.btnHuy.UseVisualStyleBackColor = false;
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
            this.BtnSave.Location = new System.Drawing.Point(68, 245);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(84, 29);
            this.BtnSave.TabIndex = 44;
            this.BtnSave.Text = "Lưu";
            this.BtnSave.TextColor = System.Drawing.Color.White;
            this.BtnSave.UseVisualStyleBackColor = false;
            // 
            // TxtImagePath
            // 
            this.TxtImagePath.Location = new System.Drawing.Point(65, 134);
            this.TxtImagePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtImagePath.Name = "TxtImagePath";
            this.TxtImagePath.Size = new System.Drawing.Size(134, 22);
            this.TxtImagePath.TabIndex = 42;
            // 
            // TxtTitle
            // 
            this.TxtTitle.Location = new System.Drawing.Point(65, 68);
            this.TxtTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtTitle.Name = "TxtTitle";
            this.TxtTitle.Size = new System.Drawing.Size(211, 22);
            this.TxtTitle.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 39;
            this.label2.Text = "Tên Bàn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "Mã bàn";
            // 
            // radMaNV
            // 
            this.radMaNV.AutoSize = true;
            this.radMaNV.BackColor = System.Drawing.Color.Firebrick;
            this.radMaNV.ForeColor = System.Drawing.Color.White;
            this.radMaNV.Location = new System.Drawing.Point(190, 190);
            this.radMaNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radMaNV.Name = "radMaNV";
            this.radMaNV.Size = new System.Drawing.Size(105, 20);
            this.radMaNV.TabIndex = 54;
            this.radMaNV.TabStop = true;
            this.radMaNV.Text = "Không Trống";
            this.radMaNV.UseVisualStyleBackColor = false;
            // 
            // radTenNV
            // 
            this.radTenNV.AutoSize = true;
            this.radTenNV.BackColor = System.Drawing.Color.Firebrick;
            this.radTenNV.ForeColor = System.Drawing.Color.White;
            this.radTenNV.Location = new System.Drawing.Point(45, 190);
            this.radTenNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radTenNV.Name = "radTenNV";
            this.radTenNV.Size = new System.Drawing.Size(64, 20);
            this.radTenNV.TabIndex = 53;
            this.radTenNV.TabStop = true;
            this.radTenNV.Text = "Trống";
            this.radTenNV.UseVisualStyleBackColor = false;
            // 
            // CapNhapBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 337);
            this.Controls.Add(this.radMaNV);
            this.Controls.Add(this.radTenNV);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtImagePath);
            this.Controls.Add(this.TxtTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CapNhapBan";
            this.Text = "CapNhapBan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomButton.VBButton btnHuy;
        private CustomButton.VBButton BtnSave;
        private System.Windows.Forms.TextBox TxtImagePath;
        private System.Windows.Forms.TextBox TxtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radMaNV;
        private System.Windows.Forms.RadioButton radTenNV;
    }
}