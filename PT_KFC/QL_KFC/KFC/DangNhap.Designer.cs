namespace KFC
{
    partial class DangNhap
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
            this.components = new System.ComponentModel.Container();
            this.labelMJS3 = new LabelMJS();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.labelMJS2 = new LabelMJS();
            this.labelMJS1 = new LabelMJS();
            this.rdoNhanVien = new customRadio.VBRadioButton();
            this.rdoQuanLy = new customRadio.VBRadioButton();
            this.btnDangNhap = new CustomButton.VBButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMJS3
            // 
            this.labelMJS3.AutoSize = true;
            this.labelMJS3.DrawingDirection = LabelMJS.Angles.LeftToRight;
            this.labelMJS3.EnableGradient = true;
            this.labelMJS3.EnableShadow = false;
            this.labelMJS3.EndColor = System.Drawing.Color.DarkRed;
            this.labelMJS3.EndColorAlpha = 255;
            this.labelMJS3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMJS3.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.labelMJS3.Location = new System.Drawing.Point(635, 169);
            this.labelMJS3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMJS3.Name = "labelMJS3";
            this.labelMJS3.ShadowColor = System.Drawing.Color.DarkRed;
            this.labelMJS3.ShadowOffset = 1;
            this.labelMJS3.Size = new System.Drawing.Size(268, 54);
            this.labelMJS3.StartColor = System.Drawing.Color.Red;
            this.labelMJS3.StartColorAlpha = 255;
            this.labelMJS3.TabIndex = 16;
            this.labelMJS3.Text = "Đăng Nhập";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::KFC.Properties.Resources.DangNhap;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 605);
            this.panel1.TabIndex = 15;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(732, 342);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(188, 33);
            this.txtMatKhau.TabIndex = 12;
            this.txtMatKhau.TextChanged += new System.EventHandler(this.txtMatKhau_TextChanged);
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaiKhoan.Location = new System.Drawing.Point(732, 294);
            this.txtTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(188, 33);
            this.txtTaiKhoan.TabIndex = 11;
            this.txtTaiKhoan.TextChanged += new System.EventHandler(this.txtTaiKhoan_TextChanged);
            // 
            // labelMJS2
            // 
            this.labelMJS2.AutoSize = true;
            this.labelMJS2.DrawingDirection = LabelMJS.Angles.LeftToRight;
            this.labelMJS2.EnableGradient = true;
            this.labelMJS2.EnableShadow = false;
            this.labelMJS2.EndColor = System.Drawing.Color.Firebrick;
            this.labelMJS2.EndColorAlpha = 255;
            this.labelMJS2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMJS2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.labelMJS2.Location = new System.Drawing.Point(604, 342);
            this.labelMJS2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMJS2.Name = "labelMJS2";
            this.labelMJS2.ShadowColor = System.Drawing.Color.DarkRed;
            this.labelMJS2.ShadowOffset = 1;
            this.labelMJS2.Size = new System.Drawing.Size(112, 25);
            this.labelMJS2.StartColor = System.Drawing.Color.IndianRed;
            this.labelMJS2.StartColorAlpha = 255;
            this.labelMJS2.TabIndex = 10;
            this.labelMJS2.Text = "Mật Khẩu:";
            // 
            // labelMJS1
            // 
            this.labelMJS1.AutoSize = true;
            this.labelMJS1.DrawingDirection = LabelMJS.Angles.LeftToRight;
            this.labelMJS1.EnableGradient = true;
            this.labelMJS1.EnableShadow = false;
            this.labelMJS1.EndColor = System.Drawing.Color.Firebrick;
            this.labelMJS1.EndColorAlpha = 255;
            this.labelMJS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMJS1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.labelMJS1.Location = new System.Drawing.Point(599, 294);
            this.labelMJS1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMJS1.Name = "labelMJS1";
            this.labelMJS1.ShadowColor = System.Drawing.Color.DarkRed;
            this.labelMJS1.ShadowOffset = 1;
            this.labelMJS1.Size = new System.Drawing.Size(119, 25);
            this.labelMJS1.StartColor = System.Drawing.Color.IndianRed;
            this.labelMJS1.StartColorAlpha = 255;
            this.labelMJS1.TabIndex = 9;
            this.labelMJS1.Text = "Tài Khoản:";
            // 
            // rdoNhanVien
            // 
            this.rdoNhanVien.AutoSize = true;
            this.rdoNhanVien.CheckedColor = System.Drawing.Color.DarkRed;
            this.rdoNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoNhanVien.Location = new System.Drawing.Point(804, 247);
            this.rdoNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.rdoNhanVien.MinimumSize = new System.Drawing.Size(0, 26);
            this.rdoNhanVien.Name = "rdoNhanVien";
            this.rdoNhanVien.Size = new System.Drawing.Size(99, 26);
            this.rdoNhanVien.TabIndex = 14;
            this.rdoNhanVien.TabStop = true;
            this.rdoNhanVien.Text = "Nhân Viên";
            this.rdoNhanVien.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdoNhanVien.UseVisualStyleBackColor = true;
            // 
            // rdoQuanLy
            // 
            this.rdoQuanLy.AutoSize = true;
            this.rdoQuanLy.CheckedColor = System.Drawing.Color.DarkRed;
            this.rdoQuanLy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoQuanLy.Location = new System.Drawing.Point(644, 247);
            this.rdoQuanLy.Margin = new System.Windows.Forms.Padding(4);
            this.rdoQuanLy.MinimumSize = new System.Drawing.Size(0, 26);
            this.rdoQuanLy.Name = "rdoQuanLy";
            this.rdoQuanLy.Size = new System.Drawing.Size(82, 26);
            this.rdoQuanLy.TabIndex = 13;
            this.rdoQuanLy.TabStop = true;
            this.rdoQuanLy.Text = "Quản Lí";
            this.rdoQuanLy.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdoQuanLy.UseVisualStyleBackColor = true;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.Firebrick;
            this.btnDangNhap.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnDangNhap.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDangNhap.BorderRadius = 20;
            this.btnDangNhap.BorderSize = 0;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(684, 404);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(180, 48);
            this.btnDangNhap.TabIndex = 17;
            this.btnDangNhap.Text = "Đăng Nhập";
            this.btnDangNhap.TextColor = System.Drawing.Color.White;
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 605);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.labelMJS3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rdoNhanVien);
            this.Controls.Add(this.rdoQuanLy);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.labelMJS2);
            this.Controls.Add(this.labelMJS1);
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DangNhap";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelMJS labelMJS3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private LabelMJS labelMJS2;
        private LabelMJS labelMJS1;
        private customRadio.VBRadioButton rdoNhanVien;
        private customRadio.VBRadioButton rdoQuanLy;
        private CustomButton.VBButton btnDangNhap;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}