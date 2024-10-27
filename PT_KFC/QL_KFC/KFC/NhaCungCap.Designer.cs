namespace KFC
{
    partial class NhaCungCap
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
            this.flpNhaCungCap = new System.Windows.Forms.FlowLayoutPanel();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTimKiem = new CustomButton.VBButton();
            this.btnXuat = new CustomButton.VBButton();
            this.btnLamMoi = new CustomButton.VBButton();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnXoa = new CustomButton.VBButton();
            this.BtnAdd = new CustomButton.VBButton();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpNhaCungCap
            // 
            this.flpNhaCungCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpNhaCungCap.Location = new System.Drawing.Point(0, 0);
            this.flpNhaCungCap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpNhaCungCap.Name = "flpNhaCungCap";
            this.flpNhaCungCap.Size = new System.Drawing.Size(943, 579);
            this.flpNhaCungCap.TabIndex = 16;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkRed;
            this.panel3.Controls.Add(this.btnTimKiem);
            this.panel3.Controls.Add(this.btnXuat);
            this.panel3.Controls.Add(this.btnLamMoi);
            this.panel3.Controls.Add(this.txtTimKiem);
            this.panel3.Controls.Add(this.btnXoa);
            this.panel3.Controls.Add(this.BtnAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Location = new System.Drawing.Point(0, 579);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(943, 76);
            this.panel3.TabIndex = 17;
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
            this.btnTimKiem.Location = new System.Drawing.Point(500, 0);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(125, 76);
            this.btnTimKiem.TabIndex = 12;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.TextColor = System.Drawing.Color.White;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXuat
            // 
            this.btnXuat.BackColor = System.Drawing.Color.Firebrick;
            this.btnXuat.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnXuat.BorderColor = System.Drawing.Color.Crimson;
            this.btnXuat.BorderRadius = 10;
            this.btnXuat.BorderSize = 0;
            this.btnXuat.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnXuat.FlatAppearance.BorderSize = 0;
            this.btnXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuat.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.ForeColor = System.Drawing.Color.White;
            this.btnXuat.Location = new System.Drawing.Point(375, 0);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(125, 76);
            this.btnXuat.TabIndex = 11;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.TextColor = System.Drawing.Color.White;
            this.btnXuat.UseVisualStyleBackColor = false;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
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
            this.btnLamMoi.Location = new System.Drawing.Point(250, 0);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(125, 76);
            this.btnLamMoi.TabIndex = 10;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.TextColor = System.Drawing.Color.White;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(632, 30);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(263, 22);
            this.txtTimKiem.TabIndex = 9;
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
            this.btnXoa.Location = new System.Drawing.Point(125, 0);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(125, 76);
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
            this.BtnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(125, 76);
            this.BtnAdd.TabIndex = 6;
            this.BtnAdd.Text = "Thêm";
            this.BtnAdd.TextColor = System.Drawing.Color.White;
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // NhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 655);
            this.Controls.Add(this.flpNhaCungCap);
            this.Controls.Add(this.panel3);
            this.Name = "NhaCungCap";
            this.Text = "NhaCungCap";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpNhaCungCap;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel panel3;
        private CustomButton.VBButton btnTimKiem;
        private CustomButton.VBButton btnXuat;
        private CustomButton.VBButton btnLamMoi;
        private System.Windows.Forms.TextBox txtTimKiem;
        private CustomButton.VBButton btnXoa;
        private CustomButton.VBButton BtnAdd;
    }
}