using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KFC
{
    public partial class DoanhThu : Form
    {
        private RadioButton rdoTheoThang;
        private RadioButton rdoTheoNgay;
        private Chart chart;
        private ChartArea chartArea; // Khai báo chartArea

        public DoanhThu()
        {
            InitializeComponent();
            this.Text = "Biểu đồ doanh thu";
            this.Size = new Size(900, 700);

            // Khởi tạo RadioButton
            rdoTheoThang = new RadioButton();
            rdoTheoThang.Text = "Theo Tháng";
            rdoTheoThang.Checked = true;
            rdoTheoThang.Location = new Point(20, 20);
            rdoTheoThang.Font = new Font("Arial", 12, FontStyle.Bold);
            rdoTheoThang.ForeColor = Color.DarkBlue;
            rdoTheoThang.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);

            rdoTheoNgay = new RadioButton();
            rdoTheoNgay.Text = "Theo Ngày";
            rdoTheoNgay.Location = new Point(150, 20);
            rdoTheoNgay.Font = new Font("Arial", 12, FontStyle.Bold);
            rdoTheoNgay.ForeColor = Color.DarkBlue;
            rdoTheoNgay.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);

            // Khởi tạo biểu đồ
            chart = new Chart();
            chart.Dock = DockStyle.Bottom;
            chart.Height = 500;

            // Khởi tạo chartArea và thêm vào chart
            chartArea = new ChartArea("MainArea"); // Đảm bảo chartArea được khởi tạo
            chartArea.BackColor = Color.WhiteSmoke;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            chartArea.AxisY.LabelStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            chartArea.AxisX.LabelStyle.ForeColor = Color.DarkSlateGray;
            chartArea.AxisY.LabelStyle.ForeColor = Color.DarkSlateGray;

            // Thêm chartArea vào chart
            chart.ChartAreas.Add(chartArea);

            // Thêm tiêu đề
            Title title = new Title();
            title.Text = "Biểu đồ doanh thu";
            title.Font = new Font("Arial", 18, FontStyle.Bold);
            title.ForeColor = Color.DarkRed;
            chart.Titles.Add(title);

            // Thêm các control vào form
            this.Controls.Add(rdoTheoThang);
            this.Controls.Add(rdoTheoNgay);
            this.Controls.Add(chart);

            // Hiển thị biểu đồ theo tháng mặc định
            HienThiDoanhThuTheoThang();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra lựa chọn của RadioButton và cập nhật biểu đồ
            if (rdoTheoThang.Checked)
            {
                HienThiDoanhThuTheoThang();
            }
            else if (rdoTheoNgay.Checked)
            {
                HienThiDoanhThuTheoNgay();
            }
        }

        private void HienThiDoanhThuTheoThang()
        {
            // Xóa các series trước đó
            chart.Series.Clear();

            // Tạo series mới cho doanh thu theo tháng
            Series series = new Series();
            series.Name = "DoanhThuTheoThang";
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.DeepSkyBlue;
            series.BackGradientStyle = GradientStyle.TopBottom;
            series.BackSecondaryColor = Color.MidnightBlue;
            series.BorderWidth = 2;
            series.BorderColor = Color.DarkBlue;
            series.ShadowOffset = 3;
            series.IsValueShownAsLabel = true;
            series.LabelForeColor = Color.Black;
            series.Font = new Font("Arial", 12, FontStyle.Bold);

            // Doanh thu giả lập theo từng tháng
            List<int> doanhThu = new List<int> { 12000000, 15000000, 17000000, 13000000, 20000000, 19000000, 21000000, 18000000, 16000000, 22000000, 23000000, 25000000 };
            for (int i = 0; i < doanhThu.Count; i++)
            {
                series.Points.AddXY($"Tháng {i + 1}", doanhThu[i]);
            }

            // Cấu hình cột
            foreach (var point in series.Points)
            {
                point.Color = Color.LightSkyBlue;
                point.BackGradientStyle = GradientStyle.VerticalCenter;
                point.BackSecondaryColor = Color.SteelBlue;
                point.BorderWidth = 1;
                point.BorderColor = Color.Navy;
            }

            // Thêm series vào biểu đồ
            chart.Series.Add(series);

            // Cấu hình 3D
            chartArea.Area3DStyle.Enable3D = true;
            chartArea.Area3DStyle.LightStyle = LightStyle.Realistic;
            chartArea.Area3DStyle.Inclination = 15;
            chartArea.Area3DStyle.Rotation = 10;
        }

        private void HienThiDoanhThuTheoNgay()
        {
            // Xóa các series trước đó
            chart.Series.Clear();

            // Tạo series mới cho doanh thu theo ngày trong tháng
            Series series = new Series();
            series.Name = "DoanhThuTheoNgay";
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.Crimson;
            series.BorderWidth = 3;
            series.ShadowOffset = 2;
            series.IsValueShownAsLabel = true;
            series.LabelForeColor = Color.Black;
            series.Font = new Font("Arial", 12, FontStyle.Bold);

            // Doanh thu giả lập theo từng ngày trong tháng
            List<int> doanhThu = new List<int> { 500000, 700000, 600000, 550000, 800000, 750000, 900000, 650000, 700000, 800000, 850000, 950000, 1000000, 1100000, 1150000 };
            for (int i = 0; i < doanhThu.Count; i++)
            {
                series.Points.AddXY($"Ngày {i + 1}", doanhThu[i]);
            }

            // Thêm series vào biểu đồ
            chart.Series.Add(series);

            // Cấu hình 3D
            chartArea.Area3DStyle.Enable3D = false; // Tắt 3D cho biểu đồ đường
        }
    }
}