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
        private List<DoanhThu_DTO> currentDoanhThuList; // Thêm biến để lưu trữ danh sách hiện tại
        private SortOrder currentSortOrder = SortOrder.Ascending; // Thêm biến để theo dõi trạng thái sắp xếp
        private string currentSortColumn = string.Empty; // Thêm biến để theo dõi cột đang được sắp xếp

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
            SetupChartAppearance();
        }

        private void SetupChartAppearance()
        {
            chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "{0:0.##}%";
            chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy";
            chartDoanhThu.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
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

            // Thêm sự kiện click vào header của cột
            dtgvDoanhThu.ColumnHeaderMouseClick += DtgvDoanhThu_ColumnHeaderMouseClick;
        }

        private void DtgvDoanhThu_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (currentDoanhThuList == null || !currentDoanhThuList.Any())
                return;

            DataGridViewColumn column = dtgvDoanhThu.Columns[e.ColumnIndex];
            string columnName = column.Name;

            // Đảo ngược trạng thái sắp xếp nếu click vào cùng một cột
            if (columnName == currentSortColumn)
            {
                currentSortOrder = currentSortOrder == SortOrder.Ascending ?
                    SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                currentSortColumn = columnName;
                currentSortOrder = SortOrder.Ascending;
            }

            // Sắp xếp dữ liệu dựa trên cột được chọn
            var sortedList = SortDoanhThuList(currentDoanhThuList, columnName, currentSortOrder);
            UpdateDataGridView(sortedList);
            UpdateChartWithPercentages(sortedList);
        }

        private List<DoanhThu_DTO> SortDoanhThuList(List<DoanhThu_DTO> list, string columnName, SortOrder sortOrder)
        {
            IOrderedEnumerable<DoanhThu_DTO> orderedList;

            // Sử dụng if-else thay vì switch expression
            if (columnName == "MaNhapHang")
                orderedList = sortOrder == SortOrder.Ascending ?
                    list.OrderBy(item => item.MaNhapHang) :
                    list.OrderByDescending(item => item.MaNhapHang);
            else if (columnName == "Thang")
                orderedList = sortOrder == SortOrder.Ascending ?
                    list.OrderBy(item => item.Thang) :
                    list.OrderByDescending(item => item.Thang);
            else if (columnName == "Nam")
                orderedList = sortOrder == SortOrder.Ascending ?
                    list.OrderBy(item => item.Nam) :
                    list.OrderByDescending(item => item.Nam);
            else if (columnName == "NgayGhiNhan")
                orderedList = sortOrder == SortOrder.Ascending ?
                    list.OrderBy(item => item.NgayGhiNhan) :
                    list.OrderByDescending(item => item.NgayGhiNhan);
            else if (columnName == "MaHoaDon")
                orderedList = sortOrder == SortOrder.Ascending ?
                    list.OrderBy(item => item.MaHoaDon) :
                    list.OrderByDescending(item => item.MaHoaDon);
            else if (columnName == "TongDoanhThu")
                orderedList = sortOrder == SortOrder.Ascending ?
                    list.OrderBy(item => item.TongDoanhThu) :
                    list.OrderByDescending(item => item.TongDoanhThu);
            else if (columnName == "TongChiTieu")
                orderedList = sortOrder == SortOrder.Ascending ?
                    list.OrderBy(item => item.TongChiTieu) :
                    list.OrderByDescending(item => item.TongChiTieu);
            else if (columnName == "TongTienDoanhThu")
                orderedList = sortOrder == SortOrder.Ascending ?
                    list.OrderBy(item => item.TongDoanhThu - item.TongChiTieu) :
                    list.OrderByDescending(item => item.TongDoanhThu - item.TongChiTieu);
            else
                orderedList = sortOrder == SortOrder.Ascending ?
                    list.OrderBy(item => item.NgayGhiNhan) :
                    list.OrderByDescending(item => item.NgayGhiNhan);

            return orderedList.ToList();
        }

        private void LoadInitialData()
        {
            try
            {
                currentDoanhThuList = doanhThuBUS.GetAllDoanhThu();
                if (currentDoanhThuList == null || !currentDoanhThuList.Any())
                {
                    MessageBox.Show("Không có dữ liệu hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                UpdateDataGridView(currentDoanhThuList);
                UpdateChartWithPercentages(currentDoanhThuList);
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
                currentDoanhThuList = doanhThuBUS.TimKiemDoanhThu(tuNgay, denNgay);
                UpdateDataGridView(currentDoanhThuList);
                UpdateChartWithPercentages(currentDoanhThuList);
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

                currentDoanhThuList = doanhThuBUS.LocDoanhThuTheo(thang: thang, nam: nam);
                UpdateDataGridView(currentDoanhThuList);
                UpdateChartWithPercentages(currentDoanhThuList);
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

        private void cbbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLoc.Clear();

            switch (cbbLoc.SelectedItem.ToString())
            {
                case "Tháng":
                    SetPlaceholder(txtLoc, "MM/yyyy");
                    break;
                case "Năm":
                    SetPlaceholder(txtLoc, "yyyy");
                    break;
            }
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Tag = placeholder; // Store the placeholder in the Tag property
            textBox.ForeColor = Color.Gray; // Set the text color to gray for placeholder
            textBox.Text = placeholder;

            // Add events for handling placeholder behavior
            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == (string)textBox.Tag)
                {
                    textBox.Text = string.Empty;
                    textBox.ForeColor = Color.Black; // Restore the text color
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = (string)textBox.Tag;
                    textBox.ForeColor = Color.Gray; // Set the text color to gray
                }
            };
        }


        private void txtLoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            string currentText = txtLoc.Text;

            switch (cbbLoc.SelectedItem.ToString())
            {
                case "Tháng":
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
                    {
                        e.Handled = true;
                    }
                    // Kiểm tra định dạng MM/yyyy
                    if (e.KeyChar != (char)Keys.Back && currentText.Length >= 7)
                    {
                        e.Handled = true;
                    }
                    break;

                case "Năm":
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    // Giới hạn năm 4 số
                    if (e.KeyChar != (char)Keys.Back && currentText.Length >= 4)
                    {
                        e.Handled = true;
                    }
                    break;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (currentDoanhThuList != null)
            {
                currentDoanhThuList.Clear();
                currentDoanhThuList = null;
            }
        }
    }

}
