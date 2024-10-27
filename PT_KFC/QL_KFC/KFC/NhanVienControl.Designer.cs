namespace KFC
{
    partial class NhanVienControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.pbNhanVien = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblChucVu);
            this.panel1.Controls.Add(this.lblTenNV);
            this.panel1.Controls.Add(this.pbNhanVien);
            this.panel1.Location = new System.Drawing.Point(7, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 232);
            this.panel1.TabIndex = 7;
            // 
            // lblChucVu
            // 
            this.lblChucVu.AutoEllipsis = true;
            this.lblChucVu.Location = new System.Drawing.Point(64, 192);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(107, 16);
            this.lblChucVu.TabIndex = 8;
            this.lblChucVu.Text = "Chức Vụ";
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoEllipsis = true;
            this.lblTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNV.Location = new System.Drawing.Point(33, 148);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(171, 33);
            this.lblTenNV.TabIndex = 7;
            this.lblTenNV.Text = "Tên Nhân Viên";
            // 
            // pbNhanVien
            // 
            this.pbNhanVien.Image = global::KFC.Properties.Resources.logo;
            this.pbNhanVien.Location = new System.Drawing.Point(38, 16);
            this.pbNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbNhanVien.Name = "pbNhanVien";
            this.pbNhanVien.Size = new System.Drawing.Size(133, 120);
            this.pbNhanVien.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNhanVien.TabIndex = 6;
            this.pbNhanVien.TabStop = false;
            // 
            // NhanVienControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "NhanVienControl";
            this.Size = new System.Drawing.Size(223, 249);
//            this.Click += new System.EventHandler(this.NhanVienControl_Click);
            this.DoubleClick += new System.EventHandler(this.NhanVienControl_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NhanVienControl_MouseDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.PictureBox pbNhanVien;
    }
}
