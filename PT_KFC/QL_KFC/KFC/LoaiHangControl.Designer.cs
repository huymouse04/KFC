namespace KFC
{
    partial class LoaiHangControl
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
            this.lblMaLoaiHang = new System.Windows.Forms.Label();
            this.lblTenLoaiHang = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMaLoaiHang
            // 
            this.lblMaLoaiHang.AutoSize = true;
            this.lblMaLoaiHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaLoaiHang.Location = new System.Drawing.Point(44, 50);
            this.lblMaLoaiHang.Name = "lblMaLoaiHang";
            this.lblMaLoaiHang.Size = new System.Drawing.Size(134, 25);
            this.lblMaLoaiHang.TabIndex = 3;
            this.lblMaLoaiHang.Text = "Mã Loại Hàng";
            // 
            // lblTenLoaiHang
            // 
            this.lblTenLoaiHang.AutoSize = true;
            this.lblTenLoaiHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLoaiHang.Location = new System.Drawing.Point(42, 100);
            this.lblTenLoaiHang.Name = "lblTenLoaiHang";
            this.lblTenLoaiHang.Size = new System.Drawing.Size(241, 37);
            this.lblTenLoaiHang.TabIndex = 2;
            this.lblTenLoaiHang.Text = "Tên Loại Hàng";
            // 
            // LoaiHangControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMaLoaiHang);
            this.Controls.Add(this.lblTenLoaiHang);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoaiHangControl";
            this.Size = new System.Drawing.Size(404, 188);
            //this.DoubleClick += new System.EventHandler(this.LoaiHangControl_DoubleClick_1);
            //this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoaiHangControl_MouseDown_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaLoaiHang;
        private System.Windows.Forms.Label lblTenLoaiHang;
    }
}
