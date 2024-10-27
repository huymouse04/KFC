namespace KFC
{
    partial class KhuyenMai
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSUA = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.khuyenMaiControl1 = new KFC.KhuyenMaiControl();
            this.khuyenMaiControl2 = new KFC.KhuyenMaiControl();
            this.khuyenMaiControl3 = new KFC.KhuyenMaiControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnSUA);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 480);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 70);
            this.panel1.TabIndex = 7;
            // 
            // btnSUA
            // 
            this.btnSUA.BackColor = System.Drawing.Color.Firebrick;
            this.btnSUA.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSUA.Location = new System.Drawing.Point(132, 4);
            this.btnSUA.Margin = new System.Windows.Forms.Padding(4);
            this.btnSUA.Name = "btnSUA";
            this.btnSUA.Size = new System.Drawing.Size(112, 63);
            this.btnSUA.TabIndex = 2;
            this.btnSUA.Text = "Cập nhật";
            this.btnSUA.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Firebrick;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa.Location = new System.Drawing.Point(252, 4);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(112, 63);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "XÓA";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Firebrick;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.Location = new System.Drawing.Point(12, 4);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(112, 63);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "THÊM";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.khuyenMaiControl1);
            this.flowLayoutPanel1.Controls.Add(this.khuyenMaiControl2);
            this.flowLayoutPanel1.Controls.Add(this.khuyenMaiControl3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(897, 480);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // khuyenMaiControl1
            // 
            this.khuyenMaiControl1.GiaTri = "Giá Trị";
            this.khuyenMaiControl1.Location = new System.Drawing.Point(3, 3);
            this.khuyenMaiControl1.MaKM = "Mã Khuyến Mãi";
            this.khuyenMaiControl1.Name = "khuyenMaiControl1";
            this.khuyenMaiControl1.Size = new System.Drawing.Size(790, 120);
            this.khuyenMaiControl1.SoLuong = "Số Lượng";
            this.khuyenMaiControl1.TabIndex = 0;
            // 
            // khuyenMaiControl2
            // 
            this.khuyenMaiControl2.GiaTri = "Giá Trị";
            this.khuyenMaiControl2.Location = new System.Drawing.Point(3, 129);
            this.khuyenMaiControl2.MaKM = "Mã Khuyến Mãi";
            this.khuyenMaiControl2.Name = "khuyenMaiControl2";
            this.khuyenMaiControl2.Size = new System.Drawing.Size(790, 120);
            this.khuyenMaiControl2.SoLuong = "Số Lượng";
            this.khuyenMaiControl2.TabIndex = 1;
            // 
            // khuyenMaiControl3
            // 
            this.khuyenMaiControl3.GiaTri = "Giá Trị";
            this.khuyenMaiControl3.Location = new System.Drawing.Point(3, 255);
            this.khuyenMaiControl3.MaKM = "Mã Khuyến Mãi";
            this.khuyenMaiControl3.Name = "khuyenMaiControl3";
            this.khuyenMaiControl3.Size = new System.Drawing.Size(790, 120);
            this.khuyenMaiControl3.SoLuong = "Số Lượng";
            this.khuyenMaiControl3.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(515, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(197, 22);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.Location = new System.Drawing.Point(737, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 63);
            this.button1.TabIndex = 4;
            this.button1.Text = "Tìm kiếm";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // KhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 550);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "KhuyenMai";
            this.Text = "KhuyenMai";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSUA;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private KhuyenMaiControl khuyenMaiControl1;
        private KhuyenMaiControl khuyenMaiControl2;
        private KhuyenMaiControl khuyenMaiControl3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}