namespace KFC
{
    partial class KhachHang
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
            this.flpKhachHang = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbbLoc = new System.Windows.Forms.ComboBox();
            this.tbtTiemKiem = new System.Windows.Forms.TextBox();
            this.btnXuat = new CustomButton.VBButton();
            this.btnLoc = new CustomButton.VBButton();
            this.btnTimKiem = new CustomButton.VBButton();
            this.btnLamMoi = new CustomButton.VBButton();
            this.btnXoa = new CustomButton.VBButton();
            this.BtnAdd = new CustomButton.VBButton();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpKhachHang
            // 
            this.flpKhachHang.AutoScroll = true;
            this.flpKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpKhachHang.Location = new System.Drawing.Point(0, 0);
            this.flpKhachHang.Margin = new System.Windows.Forms.Padding(2);
            this.flpKhachHang.Name = "flpKhachHang";
            this.flpKhachHang.Size = new System.Drawing.Size(893, 291);
            this.flpKhachHang.TabIndex = 22;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkRed;
            this.panel3.Controls.Add(this.btnXuat);
            this.panel3.Controls.Add(this.cbbLoc);
            this.panel3.Controls.Add(this.btnLoc);
            this.panel3.Controls.Add(this.tbtTiemKiem);
            this.panel3.Controls.Add(this.btnTimKiem);
            this.panel3.Controls.Add(this.btnLamMoi);
            this.panel3.Controls.Add(this.btnXoa);
            this.panel3.Controls.Add(this.BtnAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Location = new System.Drawing.Point(0, 226);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(893, 65);
            this.panel3.TabIndex = 24;
            // 
            // cbbLoc
            // 
            this.cbbLoc.FormattingEnabled = true;
            this.cbbLoc.Location = new System.Drawing.Point(640, 24);
            this.cbbLoc.Name = "cbbLoc";
            this.cbbLoc.Size = new System.Drawing.Size(141, 21);
            this.cbbLoc.TabIndex = 15;
            // 
            // tbtTiemKiem
            // 
            this.tbtTiemKiem.Location = new System.Drawing.Point(381, 24);
            this.tbtTiemKiem.Name = "tbtTiemKiem";
            this.tbtTiemKiem.Size = new System.Drawing.Size(153, 20);
            this.tbtTiemKiem.TabIndex = 13;
            // 
            // btnXuat
            // 
            this.btnXuat.BackColor = System.Drawing.Color.Firebrick;
            this.btnXuat.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnXuat.BorderColor = System.Drawing.Color.Crimson;
            this.btnXuat.BorderRadius = 10;
            this.btnXuat.BorderSize = 0;
            this.btnXuat.FlatAppearance.BorderSize = 0;
            this.btnXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuat.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold);
            this.btnXuat.ForeColor = System.Drawing.Color.White;
            this.btnXuat.Location = new System.Drawing.Point(787, 0);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(94, 62);
            this.btnXuat.TabIndex = 16;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.TextColor = System.Drawing.Color.White;
            this.btnXuat.UseVisualStyleBackColor = false;
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(853, 30);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 24);
            this.comboBox1.TabIndex = 15;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.Firebrick;
            this.btnLoc.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnLoc.BorderColor = System.Drawing.Color.Crimson;
            this.btnLoc.BorderRadius = 10;
            this.btnLoc.BorderSize = 0;
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(720, 0);
            this.btnLoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(125, 76);
            this.btnLoc.TabIndex = 14;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.TextColor = System.Drawing.Color.White;
            this.btnLoc.UseVisualStyleBackColor = false;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Firebrick;
            this.btnTimKiem.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnTimKiem.BorderColor = System.Drawing.Color.Crimson;
            this.btnTimKiem.BorderRadius = 10;
            this.btnTimKiem.BorderSize = 0;
            this.btnTimKiem.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(282, 0);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(94, 65);
            this.btnTimKiem.TabIndex = 12;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.TextColor = System.Drawing.Color.White;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click_1);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Firebrick;
            this.btnLamMoi.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnLamMoi.BorderColor = System.Drawing.Color.Crimson;
            this.btnLamMoi.BorderRadius = 10;
            this.btnLamMoi.BorderSize = 0;
            this.btnLamMoi.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(188, 0);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(94, 65);
            this.btnLamMoi.TabIndex = 10;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.TextColor = System.Drawing.Color.White;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click_1);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Firebrick;
            this.btnXoa.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnXoa.BorderColor = System.Drawing.Color.Crimson;
            this.btnXoa.BorderRadius = 10;
            this.btnXoa.BorderSize = 0;
            this.btnXoa.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(94, 0);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(94, 65);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextColor = System.Drawing.Color.White;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.Firebrick;
            this.BtnAdd.BackgroundColor = System.Drawing.Color.Firebrick;
            this.BtnAdd.BorderColor = System.Drawing.Color.LavenderBlush;
            this.BtnAdd.BorderRadius = 10;
            this.BtnAdd.BorderSize = 0;
            this.BtnAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(0, 0);
            this.BtnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(94, 65);
            this.BtnAdd.TabIndex = 6;
            this.BtnAdd.Text = "Thêm";
            this.BtnAdd.TextColor = System.Drawing.Color.White;
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 343);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flpKhachHang);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "KhachHang";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 52);
            this.Text = "KhachHang";
            this.Load += new System.EventHandler(this.KhachHang_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flpKhachHang;
        private System.Windows.Forms.Panel panel3;
        private CustomButton.VBButton btnXuat;
        private System.Windows.Forms.ComboBox cbbLoc;
        private CustomButton.VBButton btnLoc;
        private System.Windows.Forms.TextBox tbtTiemKiem;
        private CustomButton.VBButton btnTimKiem;
        private CustomButton.VBButton btnLamMoi;
        private CustomButton.VBButton btnXoa;
        private CustomButton.VBButton BtnAdd;
    }
}