namespace KFC
{
    partial class ThucDonControl
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.pbMon = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTenMon
            // 
            this.lblTenMon.AutoEllipsis = true;
            this.lblTenMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenMon.Location = new System.Drawing.Point(49, 124);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(193, 33);
            this.lblTenMon.TabIndex = 7;
            this.lblTenMon.Text = "Tên Món";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDonGia);
            this.panel1.Controls.Add(this.lblTenMon);
            this.panel1.Controls.Add(this.pbMon);
            this.panel1.Location = new System.Drawing.Point(8, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 224);
            this.panel1.TabIndex = 8;
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(78, 181);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(55, 16);
            this.lblDonGia.TabIndex = 9;
            this.lblDonGia.Text = "Đơn Giá";
            // 
            // pbMon
            // 
            this.pbMon.Image = global::KFC.Properties.Resources.logo;
            this.pbMon.Location = new System.Drawing.Point(54, 20);
            this.pbMon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbMon.Name = "pbMon";
            this.pbMon.Size = new System.Drawing.Size(108, 86);
            this.pbMon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMon.TabIndex = 6;
            this.pbMon.TabStop = false;
            // 
            // ThucDonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ThucDonControl";
            this.Size = new System.Drawing.Size(228, 237);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.PictureBox pbMon;
    }
}
