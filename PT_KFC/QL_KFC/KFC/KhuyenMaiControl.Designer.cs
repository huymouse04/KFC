namespace KFC
{
    partial class KhuyenMaiControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMaKM = new System.Windows.Forms.Label();
            this.lblGiaTri = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMaKM
            // 
            this.lblMaKM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMaKM.AutoSize = true;
            this.lblMaKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKM.Location = new System.Drawing.Point(31, 10);
            this.lblMaKM.Name = "lblMaKM";
            this.lblMaKM.Size = new System.Drawing.Size(235, 36);
            this.lblMaKM.TabIndex = 4;
            this.lblMaKM.Text = "Mã Khuyến Mãi";
            // 
            // lblGiaTri
            // 
            this.lblGiaTri.AutoSize = true;
            this.lblGiaTri.Location = new System.Drawing.Point(50, 67);
            this.lblGiaTri.Name = "lblGiaTri";
            this.lblGiaTri.Size = new System.Drawing.Size(47, 16);
            this.lblGiaTri.TabIndex = 7;
            this.lblGiaTri.Text = "Giá Trị";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(150, 67);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(64, 16);
            this.lblSoLuong.TabIndex = 5;
            this.lblSoLuong.Text = "Số Lượng";
            // 
            // KhuyenMaiControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMaKM);
            this.Controls.Add(this.lblGiaTri);
            this.Controls.Add(this.lblSoLuong);
            this.Name = "KhuyenMaiControl";
            this.Size = new System.Drawing.Size(790, 120);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaKM;
        private System.Windows.Forms.Label lblGiaTri;
        private System.Windows.Forms.Label lblSoLuong;
    }
}
