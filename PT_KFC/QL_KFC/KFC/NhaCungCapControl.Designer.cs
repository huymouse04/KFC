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
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.lblTenNCC = new System.Windows.Forms.Label();
            this.pbNhaCungCap = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbNhaCungCap)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDienThoai.Location = new System.Drawing.Point(172, 94);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(180, 29);
            this.lblSoDienThoai.TabIndex = 5;
            this.lblSoDienThoai.Text = "Số Điện Thoại";
            // 
            // lblTenNCC
            // 
            this.lblTenNCC.AutoSize = true;
            this.lblTenNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNCC.Location = new System.Drawing.Point(170, 31);
            this.lblTenNCC.Name = "lblTenNCC";
            this.lblTenNCC.Size = new System.Drawing.Size(311, 37);
            this.lblTenNCC.TabIndex = 4;
            this.lblTenNCC.Text = "Tên Nhà Cung Cấp";
            // 
            // pbNhaCungCap
            // 
            this.pbNhaCungCap.ErrorImage = global::KFC.Properties.Resources.logo;
            this.pbNhaCungCap.Image = global::KFC.Properties.Resources.logo;
            this.pbNhaCungCap.Location = new System.Drawing.Point(30, 15);
            this.pbNhaCungCap.Name = "pbNhaCungCap";
            this.pbNhaCungCap.Size = new System.Drawing.Size(120, 120);
            this.pbNhaCungCap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNhaCungCap.TabIndex = 3;
            this.pbNhaCungCap.TabStop = false;
            // 
            // NhaCungCapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSoDienThoai);
            this.Controls.Add(this.lblTenNCC);
            this.Controls.Add(this.pbNhaCungCap);
            this.Name = "NhaCungCapControl";
            this.Size = new System.Drawing.Size(921, 146);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NhaCungCapControl_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pbNhaCungCap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.Label lblTenNCC;
        private System.Windows.Forms.PictureBox pbNhaCungCap;
    }
}
