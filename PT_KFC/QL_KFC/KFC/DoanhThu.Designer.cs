namespace KFC
{
    partial class DoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dtgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.pnDoanhThu = new System.Windows.Forms.Panel();
            this.gbCongCu = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXuat = new System.Windows.Forms.Button();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.cbbLoc = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.gbTongChiTieu = new System.Windows.Forms.GroupBox();
            this.tbTongChiTieu = new System.Windows.Forms.TextBox();
            this.gbTongDoanhThu = new System.Windows.Forms.GroupBox();
            this.tbTongDoanhThu = new System.Windows.Forms.TextBox();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDoanhThu)).BeginInit();
            this.pnDoanhThu.SuspendLayout();
            this.gbCongCu.SuspendLayout();
            this.gbTongChiTieu.SuspendLayout();
            this.gbTongDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvDoanhThu
            // 
            this.dtgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDoanhThu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgvDoanhThu.Location = new System.Drawing.Point(0, 651);
            this.dtgvDoanhThu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgvDoanhThu.Name = "dtgvDoanhThu";
            this.dtgvDoanhThu.RowHeadersWidth = 51;
            this.dtgvDoanhThu.Size = new System.Drawing.Size(1205, 266);
            this.dtgvDoanhThu.TabIndex = 26;
            // 
            // pnDoanhThu
            // 
            this.pnDoanhThu.BackColor = System.Drawing.Color.RosyBrown;
            this.pnDoanhThu.Controls.Add(this.gbCongCu);
            this.pnDoanhThu.Controls.Add(this.gbTongChiTieu);
            this.pnDoanhThu.Controls.Add(this.gbTongDoanhThu);
            this.pnDoanhThu.Controls.Add(this.chartDoanhThu);
            this.pnDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.pnDoanhThu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnDoanhThu.Name = "pnDoanhThu";
            this.pnDoanhThu.Size = new System.Drawing.Size(1205, 651);
            this.pnDoanhThu.TabIndex = 27;
            // 
            // gbCongCu
            // 
            this.gbCongCu.Controls.Add(this.btnLamMoi);
            this.gbCongCu.Controls.Add(this.btnXuat);
            this.gbCongCu.Controls.Add(this.txtLoc);
            this.gbCongCu.Controls.Add(this.cbbLoc);
            this.gbCongCu.Controls.Add(this.btnLoc);
            this.gbCongCu.Controls.Add(this.dateTimePicker2);
            this.gbCongCu.Controls.Add(this.dateTimePicker1);
            this.gbCongCu.Controls.Add(this.btnTimKiem);
            this.gbCongCu.Location = new System.Drawing.Point(239, 457);
            this.gbCongCu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbCongCu.Name = "gbCongCu";
            this.gbCongCu.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbCongCu.Size = new System.Drawing.Size(861, 160);
            this.gbCongCu.TabIndex = 4;
            this.gbCongCu.TabStop = false;
            this.gbCongCu.Text = "Công Cụ";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.IndianRed;
            this.btnLamMoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(647, 97);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(125, 39);
            this.btnLamMoi.TabIndex = 8;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXuat
            // 
            this.btnXuat.BackColor = System.Drawing.Color.IndianRed;
            this.btnXuat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnXuat.ForeColor = System.Drawing.Color.White;
            this.btnXuat.Location = new System.Drawing.Point(647, 37);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(125, 39);
            this.btnXuat.TabIndex = 7;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.UseVisualStyleBackColor = false;
            // 
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(473, 103);
            this.txtLoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(140, 22);
            this.txtLoc.TabIndex = 5;
            // 
            // cbbLoc
            // 
            this.cbbLoc.FormattingEnabled = true;
            this.cbbLoc.Location = new System.Drawing.Point(473, 42);
            this.cbbLoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbLoc.Name = "cbbLoc";
            this.cbbLoc.Size = new System.Drawing.Size(140, 24);
            this.cbbLoc.TabIndex = 4;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.IndianRed;
            this.btnLoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(340, 64);
            this.btnLoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(125, 39);
            this.btnLoc.TabIndex = 6;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(209, 103);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(101, 22);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(209, 43);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(101, 22);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.IndianRed;
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(76, 64);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(125, 39);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // gbTongChiTieu
            // 
            this.gbTongChiTieu.Controls.Add(this.tbTongChiTieu);
            this.gbTongChiTieu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gbTongChiTieu.Location = new System.Drawing.Point(755, 326);
            this.gbTongChiTieu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbTongChiTieu.Name = "gbTongChiTieu";
            this.gbTongChiTieu.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbTongChiTieu.Size = new System.Drawing.Size(345, 123);
            this.gbTongChiTieu.TabIndex = 3;
            this.gbTongChiTieu.TabStop = false;
            this.gbTongChiTieu.Text = "TỔNG CHI TIÊU";
            // 
            // tbTongChiTieu
            // 
            this.tbTongChiTieu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbTongChiTieu.Location = new System.Drawing.Point(8, 52);
            this.tbTongChiTieu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTongChiTieu.Name = "tbTongChiTieu";
            this.tbTongChiTieu.ReadOnly = true;
            this.tbTongChiTieu.Size = new System.Drawing.Size(328, 35);
            this.tbTongChiTieu.TabIndex = 0;
            this.tbTongChiTieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbTongDoanhThu
            // 
            this.gbTongDoanhThu.Controls.Add(this.tbTongDoanhThu);
            this.gbTongDoanhThu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gbTongDoanhThu.Location = new System.Drawing.Point(239, 326);
            this.gbTongDoanhThu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbTongDoanhThu.Name = "gbTongDoanhThu";
            this.gbTongDoanhThu.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbTongDoanhThu.Size = new System.Drawing.Size(345, 123);
            this.gbTongDoanhThu.TabIndex = 2;
            this.gbTongDoanhThu.TabStop = false;
            this.gbTongDoanhThu.Text = "TỔNG DOANH THU";
            // 
            // tbTongDoanhThu
            // 
            this.tbTongDoanhThu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbTongDoanhThu.Location = new System.Drawing.Point(8, 52);
            this.tbTongDoanhThu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTongDoanhThu.Name = "tbTongDoanhThu";
            this.tbTongDoanhThu.ReadOnly = true;
            this.tbTongDoanhThu.Size = new System.Drawing.Size(328, 35);
            this.tbTongDoanhThu.TabIndex = 0;
            this.tbTongDoanhThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chartDoanhThu
            // 
            this.chartDoanhThu.BackColor = System.Drawing.Color.Firebrick;
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.chartDoanhThu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Series.Add(series2);
            this.chartDoanhThu.Size = new System.Drawing.Size(1205, 278);
            this.chartDoanhThu.TabIndex = 1;
            this.chartDoanhThu.Text = "chart1";
            // 
            // DoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 917);
            this.Controls.Add(this.pnDoanhThu);
            this.Controls.Add(this.dtgvDoanhThu);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DoanhThu";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 107, 0);
            this.Text = "DoanhThu";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDoanhThu)).EndInit();
            this.pnDoanhThu.ResumeLayout(false);
            this.gbCongCu.ResumeLayout(false);
            this.gbCongCu.PerformLayout();
            this.gbTongChiTieu.ResumeLayout(false);
            this.gbTongChiTieu.PerformLayout();
            this.gbTongDoanhThu.ResumeLayout(false);
            this.gbTongDoanhThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvDoanhThu;
        private System.Windows.Forms.Panel pnDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.GroupBox gbTongDoanhThu;
        private System.Windows.Forms.TextBox tbTongDoanhThu;
        private System.Windows.Forms.GroupBox gbTongChiTieu;
        private System.Windows.Forms.TextBox tbTongChiTieu;
        private System.Windows.Forms.GroupBox gbCongCu;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.ComboBox cbbLoc;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXuat;
    }
}