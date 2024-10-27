namespace KFC
{
    partial class NhaCungCapControl
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
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblTenNCC = new System.Windows.Forms.Label();
            this.pbNCC = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbNCC)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(153, 75);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(150, 25);
            this.lblSDT.TabIndex = 5;
            this.lblSDT.Text = "Số Điện Thoại";
            // 
            // lblTenNCC
            // 
            this.lblTenNCC.AutoSize = true;
            this.lblTenNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNCC.Location = new System.Drawing.Point(151, 25);
            this.lblTenNCC.Name = "lblTenNCC";
            this.lblTenNCC.Size = new System.Drawing.Size(263, 31);
            this.lblTenNCC.TabIndex = 4;
            this.lblTenNCC.Text = "Tên Nhà Cung Cấp";
            // 
            // pbNCC
            // 
            this.pbNCC.ErrorImage = global::KFC.Properties.Resources.logo;
            this.pbNCC.Image = global::KFC.Properties.Resources.logo;
            this.pbNCC.Location = new System.Drawing.Point(26, 12);
            this.pbNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbNCC.Name = "pbNCC";
            this.pbNCC.Size = new System.Drawing.Size(107, 96);
            this.pbNCC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNCC.TabIndex = 3;
            this.pbNCC.TabStop = false;
            // 
            // NhaCungCapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.lblTenNCC);
            this.Controls.Add(this.pbNCC);
            this.Name = "NhaCungCapControl";
            this.Size = new System.Drawing.Size(818, 117);
            ((System.ComponentModel.ISupportInitialize)(this.pbNCC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblTenNCC;
        private System.Windows.Forms.PictureBox pbNCC;
    }
}
