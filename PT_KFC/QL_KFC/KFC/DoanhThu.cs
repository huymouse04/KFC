using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KFC
{
    public partial class DoanhThu : Form
    {
        private DoanhThu_BUS doanhThuBUS = new DoanhThu_BUS();

        public DoanhThu()
        {
            InitializeComponent();
            ConfigureFormControls();
            ConfigureDataGridView();
            LoadInitialData();
        }

        private void ConfigureFormControls()
        {
            // Cấu hình sự kiện
            btnTimKiem.Click += btnTimKiem_Click;
            btnLoc.Click += btnLoc_Click;
            btnLamMoi.Click += btnLamMoi_Click;

            // Cấu hình ComboBox lọc - chỉ còn tháng và năm
            cbbLoc.Items.Clear();
            cbbLoc.Items.AddRange(new string[] { "Tháng", "Năm" });
            cbbLoc.SelectedIndex = 0;

            // Cấu hình biểu đồ
            ConfigureChartAppearance();
        }

        private void ConfigureDataGridView()
        {
            dtgvDoanhThu.Columns.Clear();

            // Thêm các cột hiển thị đầy đủ thông tin
            dtgvDoanhThu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaNhapHang",
                HeaderText = "Mã Nhập Hàng",
                DataPropertyName = "MaNhapHang",
                Width = 100
            });

            dtgvDoanhThu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Thang",
                HeaderText = "Tháng",
                DataPropertyName = "Thang",
                Width = 80
            });

            dtgvDoanhThu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nam",
                HeaderText = "Năm",
                DataPropertyName = "Nam",
                Width = 80
            });

            dtgvDoanhThu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayGhiNhan",
                HeaderText = "Ngày Ghi Nhận",
                DataPropertyName = "NgayGhiNhan",
                Width = 120
            });

            dtgvDoanhThu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaHoaDon",
                HeaderText = "Mã Hóa Đơn",
                DataPropertyName = "MaHoaDon",
                Width = 100
            });

            dtgvDoanhThu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TongDoanhThu",
                HeaderText = "Tổng Doanh Thu",
                DataPropertyName = "TongDoanhThu",
                Width = 120
            });

            dtgvDoanhThu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TongChiTieu",
                HeaderText = "Tổng Chi Tiêu",
                DataPropertyName = "TongChiTieu",
                Width = 120
            });

            dtgvDoanhThu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TongTienDoanhThu",
                HeaderText = "Tổng Tiền Doanh Thu",
                DataPropertyName = "TongTienDoanhThu",
                Width = 150
            });
        }


        private void ConfigureChartAppearance()
        {
            chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "{0:0.##}%";
            chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy";
            chartDoanhThu.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
        }

        private void LoadInitialData()
        {
            try
            {
                var doanhThuList = doanhThuBUS.GetAllDoanhThu();
                if (doanhThuList == null || !doanhThuList.Any())
                {
                    MessageBox.Show("Không có dữ liệu hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                UpdateDataGridView(doanhThuList);
                UpdateChartWithPercentages(doanhThuList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dateTimePicker1.Value;
            DateTime denNgay = dateTimePicker2.Value;

            try
            {
                var doanhThuList = doanhThuBUS.TimKiemDoanhThu(tuNgay, denNgay);
                UpdateDataGridView(doanhThuList);
                UpdateChartWithPercentages(doanhThuList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                int? thang = null;
                int? nam = null;

                switch (cbbLoc.SelectedItem.ToString())
                {
                    case "Tháng":
                        if (DateTime.TryParseExact(txtLoc.Text, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime thangNam))
                        {
                            thang = thangNam.Month;
                            nam = thangNam.Year;
                        }
                        break;
                    case "Năm":
                        if (int.TryParse(txtLoc.Text, out int namLoc))
                            nam = namLoc;
                        break;
                }

                var doanhThuList = doanhThuBUS.LocDoanhThuTheo(thang: thang, nam: nam);
                UpdateDataGridView(doanhThuList);
                UpdateChartWithPercentages(doanhThuList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadInitialData();
        }

        private void UpdateDataGridView(List<DoanhThu_DTO> doanhThuList)
        {
            var displayList = doanhThuList.Select(dt => new
            {
                MaNhapHang = dt.MaNhapHang,
                Thang = dt.Thang,
                Nam = dt.Nam,
                NgayGhiNhan = dt.NgayGhiNhan.ToString("dd/MM/yyyy"),
                MaHoaDon = dt.MaHoaDon,
                TongDoanhThu = dt.TongDoanhThu.ToString("N0") + " VND",
                TongChiTieu = dt.TongChiTieu.ToString("N0") + " VND",
                TongTienDoanhThu = (dt.TongDoanhThu - dt.TongChiTieu).ToString("N0") + " VND"
            }).ToList();

            dtgvDoanhThu.DataSource = displayList;

            // Tính tổng tiền doanh thu
            float tongTienDoanhThu = doanhThuList.Sum(dt => dt.TongDoanhThu - dt.TongChiTieu);
            tbTongDoanhThu.Text = tongTienDoanhThu.ToString("N0") + " VND";
        }

        private void UpdateChartWithPercentages(List<DoanhThu_DTO> doanhThuList)
        {
            if (doanhThuList == null || !doanhThuList.Any()) return;

            float tongDoanhThu = doanhThuList.Sum(dt => dt.TongDoanhThu);
            float tongChiTieu = doanhThuList.Sum(dt => dt.TongChiTieu);

            chartDoanhThu.Series.Clear();
            Series doanhThuSeries = new Series("Doanh Thu (%)");
            Series chiTieuSeries = new Series("Chi Tiêu (%)");

            doanhThuSeries.ChartType = SeriesChartType.Column;
            chiTieuSeries.ChartType = SeriesChartType.Column;

            foreach (var item in doanhThuList)
            {
                float phanTramDoanhThu = tongDoanhThu > 0 ? (item.TongDoanhThu / tongDoanhThu) * 100 : 0;
                float phanTramChiTieu = tongChiTieu > 0 ? (item.TongChiTieu / tongChiTieu) * 100 : 0;

                doanhThuSeries.Points.AddXY(item.NgayGhiNhan.ToString("dd/MM/yyyy"), phanTramDoanhThu);
                chiTieuSeries.Points.AddXY(item.NgayGhiNhan.ToString("dd/MM/yyyy"), phanTramChiTieu);
            }

            chartDoanhThu.Series.Add(doanhThuSeries);
            chartDoanhThu.Series.Add(chiTieuSeries);

            chartDoanhThu.ChartAreas[0].AxisX.Title = "Ngày";
            chartDoanhThu.ChartAreas[0].AxisY.Title = "Tỷ Lệ (%)";
            chartDoanhThu.Titles.Clear();
            chartDoanhThu.Titles.Add(new Title("Biểu Đồ Doanh Thu và Chi Tiêu"));

            // Cập nhật tổng doanh thu và chi tiêu
            tbTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VND";
            tbTongChiTieu.Text = tongChiTieu.ToString("N0") + " VND";
        }

    }
}
