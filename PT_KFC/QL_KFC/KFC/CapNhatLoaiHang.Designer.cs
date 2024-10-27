namespace KFC
{
    partial class CapNhatLoaiHang
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
            this.lblTLH = new System.Windows.Forms.Label();
            this.lbMLH = new System.Windows.Forms.Label();
            this.txtMLH = new System.Windows.Forms.TextBox();
            this.btnHuy = new CustomButton.VBButton();
            this.btnLuu = new CustomButton.VBButton();
            this.txtTLH = new System.Windows.Forms.TextBox();
            this.pnFILL.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnFILL
            // 
            this.pnFILL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnFILL.Controls.Add(this.lblTLH);
            this.pnFILL.Controls.Add(this.lbMLH);
            this.pnFILL.Controls.Add(this.txtMLH);
            this.pnFILL.Controls.Add(this.btnHuy);
            this.pnFILL.Controls.Add(this.btnLuu);
            this.pnFILL.Controls.Add(this.txtTLH);
            this.pnFILL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnFILL.Location = new System.Drawing.Point(0, 0);
            this.pnFILL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnFILL.Name = "pnFILL";
            this.pnFILL.Size = new System.Drawing.Size(351, 416);
            this.pnFILL.TabIndex = 1;
            // 
            // lblTLH
            // 
            this.lblTLH.AutoSize = true;
            this.lblTLH.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTLH.Location = new System.Drawing.Point(51, 166);
            this.lblTLH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTLH.Name = "lblTLH";
            this.lblTLH.Size = new System.Drawing.Size(158, 26);
            this.lblTLH.TabIndex = 50;
            this.lblTLH.Text = "Tên loại hàng :";
            // 
            // lbMLH
            // 
            this.lbMLH.AutoSize = true;
            this.lbMLH.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbMLH.Location = new System.Drawing.Point(50, 85);
            this.lbMLH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMLH.Name = "lbMLH";
            this.lbMLH.Size = new System.Drawing.Size(154, 26);
            this.lbMLH.TabIndex = 49;
            this.lbMLH.Text = "Mã loại hàng :";
            // 
            // txtMLH
            // 
            this.txtMLH.Location = new System.Drawing.Point(51, 114);
            this.txtMLH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMLH.Name = "txtMLH";
            this.txtMLH.Size = new System.Drawing.Size(237, 26);
            this.txtMLH.TabIndex = 48;
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
            this.btnHuy.Location = new System.Drawing.Point(199, 271);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(117, 52);
            this.btnHuy.TabIndex = 45;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextColor = System.Drawing.Color.White;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Firebrick;
            this.btnLuu.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnLuu.BorderColor = System.Drawing.Color.White;
            this.btnLuu.BorderRadius = 10;
            this.btnLuu.BorderSize = 0;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(33, 271);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(109, 52);
            this.btnLuu.TabIndex = 44;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextColor = System.Drawing.Color.White;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtTLH
            // 
            this.txtTLH.Location = new System.Drawing.Point(53, 195);
            this.txtTLH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTLH.Name = "txtTLH";
            this.txtTLH.Size = new System.Drawing.Size(237, 26);
            this.txtTLH.TabIndex = 39;
            // 
            // CapNhatLoaiHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 416);
            this.Controls.Add(this.pnFILL);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CapNhatLoaiHang";
            this.Text = "CapNhatLoaiHang";
            this.pnFILL.ResumeLayout(false);
            this.pnFILL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnFILL;
        private System.Windows.Forms.Label lblTLH;
        private System.Windows.Forms.Label lbMLH;
        private System.Windows.Forms.TextBox txtMLH;
        private CustomButton.VBButton btnHuy;
        private CustomButton.VBButton btnLuu;
        private System.Windows.Forms.TextBox txtTLH;
    }
}