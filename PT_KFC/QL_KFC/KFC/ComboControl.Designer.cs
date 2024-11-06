namespace KFC
{
    partial class ComboControl
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
            this.lblCombo = new System.Windows.Forms.Label();
            this.lblTenCombo = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.pbTrangThai = new System.Windows.Forms.PictureBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrangThai)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCombo
            // 
            this.lblCombo.AutoSize = true;
            this.lblCombo.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCombo.Location = new System.Drawing.Point(6, 5);
            this.lblCombo.Name = "lblCombo";
            this.lblCombo.Size = new System.Drawing.Size(85, 19);
            this.lblCombo.TabIndex = 0;
            this.lblCombo.Text = "Mã Combo";
            this.lblCombo.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblTenCombo
            // 
            this.lblTenCombo.AutoSize = true;
            this.lblTenCombo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenCombo.Location = new System.Drawing.Point(21, 28);
            this.lblTenCombo.Name = "lblTenCombo";
            this.lblTenCombo.Size = new System.Drawing.Size(105, 22);
            this.lblTenCombo.TabIndex = 1;
            this.lblTenCombo.Text = "Tên ComBo";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGia.Location = new System.Drawing.Point(38, 55);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(87, 19);
            this.lblGia.TabIndex = 2;
            this.lblGia.Text = "Giá Combo";
            // 
            // pbTrangThai
            // 
            this.pbTrangThai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbTrangThai.Location = new System.Drawing.Point(181, 3);
            this.pbTrangThai.Name = "pbTrangThai";
            this.pbTrangThai.Size = new System.Drawing.Size(40, 35);
            this.pbTrangThai.TabIndex = 3;
            this.pbTrangThai.TabStop = false;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong.Location = new System.Drawing.Point(188, 44);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(28, 19);
            this.lblSoLuong.TabIndex = 4;
            this.lblSoLuong.Text = "SL";
            // 
            // ComboControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.pbTrangThai);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.lblTenCombo);
            this.Controls.Add(this.lblCombo);
            this.Name = "ComboControl";
            this.Size = new System.Drawing.Size(233, 78);
            this.Click += new System.EventHandler(this.ComboControl_Click);
            this.DoubleClick += new System.EventHandler(this.ComboControl_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pbTrangThai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCombo;
        private System.Windows.Forms.Label lblTenCombo;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.PictureBox pbTrangThai;
        private System.Windows.Forms.Label lblSoLuong;
    }
}
