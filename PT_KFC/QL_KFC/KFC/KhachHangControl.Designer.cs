﻿namespace KFC
{
    partial class KhachHangControl
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
            this.lblMaKH = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblDiemTL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKH.Location = new System.Drawing.Point(23, 20);
            this.lblMaKH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(97, 13);
            this.lblMaKH.TabIndex = 0;
            this.lblMaKH.Text = "Mã khách Hàng";
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen.Location = new System.Drawing.Point(46, 52);
            this.lblTen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(206, 29);
            this.lblTen.TabIndex = 1;
            this.lblTen.Text = "Tên Khách Hàng";
            // 
            // lblDiemTL
            // 
            this.lblDiemTL.AutoSize = true;
            this.lblDiemTL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiemTL.Location = new System.Drawing.Point(49, 97);
            this.lblDiemTL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiemTL.Name = "lblDiemTL";
            this.lblDiemTL.Size = new System.Drawing.Size(90, 13);
            this.lblDiemTL.TabIndex = 2;
            this.lblDiemTL.Text = "Điểm Tích Lũy";
            // 
            // KhachHangControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDiemTL);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.lblMaKH);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "KhachHangControl";
            this.Size = new System.Drawing.Size(401, 145);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.KhachHangControl_Paint_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblDiemTL;
    }
}
