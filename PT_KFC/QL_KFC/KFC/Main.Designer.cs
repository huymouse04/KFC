namespace KFC
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Body = new System.Windows.Forms.Panel();
            this.btnNhanVien = new CustomButton.VBButton();
            this.btnKho = new CustomButton.VBButton();
            this.btnThucDon = new CustomButton.VBButton();
            this.btnComBo = new CustomButton.VBButton();
            this.btnKhuyenMai = new CustomButton.VBButton();
            this.btnBan = new CustomButton.VBButton();
            this.btnDonDat = new CustomButton.VBButton();
            this.btnHoaDon = new CustomButton.VBButton();
            this.btnKhachHang = new CustomButton.VBButton();
            this.btnDoanhThu = new CustomButton.VBButton();
            this.btnThoat = new CustomButton.VBButton();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel_Body.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.DarkRed;
            this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel1.Controls.Add(this.btnNhanVien);
            this.flowLayoutPanel1.Controls.Add(this.btnKho);
            this.flowLayoutPanel1.Controls.Add(this.btnThucDon);
            this.flowLayoutPanel1.Controls.Add(this.btnComBo);
            this.flowLayoutPanel1.Controls.Add(this.btnKhuyenMai);
            this.flowLayoutPanel1.Controls.Add(this.btnBan);
            this.flowLayoutPanel1.Controls.Add(this.btnDonDat);
            this.flowLayoutPanel1.Controls.Add(this.btnHoaDon);
            this.flowLayoutPanel1.Controls.Add(this.btnKhachHang);
            this.flowLayoutPanel1.Controls.Add(this.btnDoanhThu);
            this.flowLayoutPanel1.Controls.Add(this.btnThoat);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(150, 1236);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = global::KFC.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(145, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1208, 129);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(500, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "KFC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_Body
            // 
            this.panel_Body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Body.BackgroundImage = global::KFC.Properties.Resources.banner5;
            this.panel_Body.Controls.Add(this.panel1);
            this.panel_Body.Controls.Add(this.flowLayoutPanel1);
            this.panel_Body.Location = new System.Drawing.Point(0, 0);
            this.panel_Body.Margin = new System.Windows.Forms.Padding(1);
            this.panel_Body.Name = "panel_Body";
            this.panel_Body.Size = new System.Drawing.Size(1353, 1236);
            this.panel_Body.TabIndex = 17;
            this.panel_Body.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNhanVien.BackColor = System.Drawing.Color.Firebrick;
            this.btnNhanVien.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnNhanVien.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnNhanVien.BorderRadius = 10;
            this.btnNhanVien.BorderSize = 0;
            this.btnNhanVien.FlatAppearance.BorderSize = 0;
            this.btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanVien.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnNhanVien.Location = new System.Drawing.Point(3, 132);
            this.btnNhanVien.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(143, 65);
            this.btnNhanVien.TabIndex = 38;
            this.btnNhanVien.Text = "Nhân Viên";
            this.btnNhanVien.TextColor = System.Drawing.Color.White;
            this.btnNhanVien.UseVisualStyleBackColor = false;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnKho
            // 
            this.btnKho.BackColor = System.Drawing.Color.Firebrick;
            this.btnKho.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnKho.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnKho.BorderRadius = 10;
            this.btnKho.BorderSize = 0;
            this.btnKho.FlatAppearance.BorderSize = 0;
            this.btnKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKho.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKho.ForeColor = System.Drawing.Color.White;
            this.btnKho.Location = new System.Drawing.Point(3, 199);
            this.btnKho.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnKho.Name = "btnKho";
            this.btnKho.Size = new System.Drawing.Size(143, 65);
            this.btnKho.TabIndex = 39;
            this.btnKho.Text = "Kho";
            this.btnKho.TextColor = System.Drawing.Color.White;
            this.btnKho.UseVisualStyleBackColor = false;
            this.btnKho.Click += new System.EventHandler(this.btnKho_Click);
            // 
            // btnThucDon
            // 
            this.btnThucDon.BackColor = System.Drawing.Color.Firebrick;
            this.btnThucDon.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnThucDon.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnThucDon.BorderRadius = 10;
            this.btnThucDon.BorderSize = 0;
            this.btnThucDon.FlatAppearance.BorderSize = 0;
            this.btnThucDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThucDon.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThucDon.ForeColor = System.Drawing.Color.White;
            this.btnThucDon.Location = new System.Drawing.Point(3, 266);
            this.btnThucDon.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnThucDon.Name = "btnThucDon";
            this.btnThucDon.Size = new System.Drawing.Size(143, 65);
            this.btnThucDon.TabIndex = 40;
            this.btnThucDon.Text = "Thực Đơn";
            this.btnThucDon.TextColor = System.Drawing.Color.White;
            this.btnThucDon.UseVisualStyleBackColor = false;
            this.btnThucDon.Click += new System.EventHandler(this.btnThucDon_Click);
            // 
            // btnComBo
            // 
            this.btnComBo.BackColor = System.Drawing.Color.Firebrick;
            this.btnComBo.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnComBo.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnComBo.BorderRadius = 10;
            this.btnComBo.BorderSize = 0;
            this.btnComBo.FlatAppearance.BorderSize = 0;
            this.btnComBo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComBo.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComBo.ForeColor = System.Drawing.Color.White;
            this.btnComBo.Location = new System.Drawing.Point(3, 333);
            this.btnComBo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnComBo.Name = "btnComBo";
            this.btnComBo.Size = new System.Drawing.Size(143, 65);
            this.btnComBo.TabIndex = 41;
            this.btnComBo.Text = "Combo";
            this.btnComBo.TextColor = System.Drawing.Color.White;
            this.btnComBo.UseVisualStyleBackColor = false;
            //this.btnComBo.Click += new System.EventHandler(this.btnComBo_Click);
            // 
            // btnKhuyenMai
            // 
            this.btnKhuyenMai.BackColor = System.Drawing.Color.Firebrick;
            this.btnKhuyenMai.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnKhuyenMai.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnKhuyenMai.BorderRadius = 10;
            this.btnKhuyenMai.BorderSize = 0;
            this.btnKhuyenMai.FlatAppearance.BorderSize = 0;
            this.btnKhuyenMai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhuyenMai.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhuyenMai.ForeColor = System.Drawing.Color.White;
            this.btnKhuyenMai.Location = new System.Drawing.Point(3, 400);
            this.btnKhuyenMai.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnKhuyenMai.Name = "btnKhuyenMai";
            this.btnKhuyenMai.Size = new System.Drawing.Size(143, 65);
            this.btnKhuyenMai.TabIndex = 42;
            this.btnKhuyenMai.Text = "Khuyến mãi";
            this.btnKhuyenMai.TextColor = System.Drawing.Color.White;
            this.btnKhuyenMai.UseVisualStyleBackColor = false;
            this.btnKhuyenMai.Click += new System.EventHandler(this.btnKhuyenMai_Click_1);
            // 
            // btnBan
            // 
            this.btnBan.BackColor = System.Drawing.Color.Firebrick;
            this.btnBan.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnBan.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnBan.BorderRadius = 10;
            this.btnBan.BorderSize = 0;
            this.btnBan.FlatAppearance.BorderSize = 0;
            this.btnBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBan.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBan.ForeColor = System.Drawing.Color.White;
            this.btnBan.Location = new System.Drawing.Point(3, 467);
            this.btnBan.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnBan.Name = "btnBan";
            this.btnBan.Size = new System.Drawing.Size(143, 65);
            this.btnBan.TabIndex = 43;
            this.btnBan.Text = "Bàn";
            this.btnBan.TextColor = System.Drawing.Color.White;
            this.btnBan.UseVisualStyleBackColor = false;
            // 
            // btnDonDat
            // 
            this.btnDonDat.BackColor = System.Drawing.Color.Firebrick;
            this.btnDonDat.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnDonDat.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnDonDat.BorderRadius = 10;
            this.btnDonDat.BorderSize = 0;
            this.btnDonDat.FlatAppearance.BorderSize = 0;
            this.btnDonDat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonDat.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonDat.ForeColor = System.Drawing.Color.White;
            this.btnDonDat.Location = new System.Drawing.Point(3, 534);
            this.btnDonDat.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnDonDat.Name = "btnDonDat";
            this.btnDonDat.Size = new System.Drawing.Size(143, 65);
            this.btnDonDat.TabIndex = 44;
            this.btnDonDat.Text = "Đơn Đặt";
            this.btnDonDat.TextColor = System.Drawing.Color.White;
            this.btnDonDat.UseVisualStyleBackColor = false;
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.BackColor = System.Drawing.Color.Firebrick;
            this.btnHoaDon.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnHoaDon.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnHoaDon.BorderRadius = 10;
            this.btnHoaDon.BorderSize = 0;
            this.btnHoaDon.FlatAppearance.BorderSize = 0;
            this.btnHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoaDon.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnHoaDon.Location = new System.Drawing.Point(3, 601);
            this.btnHoaDon.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(143, 65);
            this.btnHoaDon.TabIndex = 45;
            this.btnHoaDon.Text = "Hóa đơn";
            this.btnHoaDon.TextColor = System.Drawing.Color.White;
            this.btnHoaDon.UseVisualStyleBackColor = false;
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.BackColor = System.Drawing.Color.Firebrick;
            this.btnKhachHang.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnKhachHang.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnKhachHang.BorderRadius = 10;
            this.btnKhachHang.BorderSize = 0;
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.Location = new System.Drawing.Point(3, 668);
            this.btnKhachHang.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(143, 65);
            this.btnKhachHang.TabIndex = 46;
            this.btnKhachHang.Text = "Khách Hàng";
            this.btnKhachHang.TextColor = System.Drawing.Color.White;
            this.btnKhachHang.UseVisualStyleBackColor = false;
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.BackColor = System.Drawing.Color.Firebrick;
            this.btnDoanhThu.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnDoanhThu.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnDoanhThu.BorderRadius = 10;
            this.btnDoanhThu.BorderSize = 0;
            this.btnDoanhThu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDoanhThu.FlatAppearance.BorderSize = 0;
            this.btnDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoanhThu.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoanhThu.ForeColor = System.Drawing.Color.White;
            this.btnDoanhThu.Location = new System.Drawing.Point(3, 735);
            this.btnDoanhThu.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Size = new System.Drawing.Size(135, 65);
            this.btnDoanhThu.TabIndex = 47;
            this.btnDoanhThu.Text = "Doanh Thu";
            this.btnDoanhThu.TextColor = System.Drawing.Color.White;
            this.btnDoanhThu.UseVisualStyleBackColor = false;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Firebrick;
            this.btnThoat.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnThoat.BorderColor = System.Drawing.Color.LavenderBlush;
            this.btnThoat.BorderRadius = 10;
            this.btnThoat.BorderSize = 0;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(3, 802);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(135, 65);
            this.btnThoat.TabIndex = 48;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextColor = System.Drawing.Color.White;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 920);
            this.Controls.Add(this.panel_Body);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_Body.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomButton.VBButton btnNhanVien;
        private CustomButton.VBButton btnKho;
        private CustomButton.VBButton btnThucDon;
        private CustomButton.VBButton btnComBo;
        private CustomButton.VBButton btnKhuyenMai;
        private CustomButton.VBButton btnBan;
        private CustomButton.VBButton btnDonDat;
        private CustomButton.VBButton btnHoaDon;
        private CustomButton.VBButton btnKhachHang;
        private CustomButton.VBButton btnDoanhThu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Body;
        private CustomButton.VBButton btnThoat;

        private System.Windows.Forms.Button r;

    }
}

