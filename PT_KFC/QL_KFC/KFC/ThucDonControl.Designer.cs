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
            this.lblTenMon = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.pbMon = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pbMon)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTenMon
            // 
            this.lblTenMon.AutoEllipsis = true;
            this.lblTenMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenMon.Location = new System.Drawing.Point(3, 140);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(243, 88);
            this.lblTenMon.TabIndex = 7;
            this.lblTenMon.Text = "Tên Món";
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDonGia.Location = new System.Drawing.Point(3, 228);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(243, 55);
            this.lblDonGia.TabIndex = 9;
            this.lblDonGia.Text = "Đơn Giá";
            // 
            // pbMon
            // 
            this.pbMon.Image = global::KFC.Properties.Resources.logo;
            this.pbMon.Location = new System.Drawing.Point(3, 2);
            this.pbMon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbMon.Name = "pbMon";
            this.pbMon.Size = new System.Drawing.Size(243, 117);
            this.pbMon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMon.TabIndex = 6;
            this.pbMon.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblTenMon, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblDonGia, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.pbMon, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 10);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.16505F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.83495F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(249, 283);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ThucDonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ThucDonControl";
            this.Size = new System.Drawing.Size(256, 296);
            ((System.ComponentModel.ISupportInitialize)(this.pbMon)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.PictureBox pbMon;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
