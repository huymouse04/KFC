using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KFC
{
    public partial class LuongNhanViens : Form
    {

        private LuongNhanVien_BUS bus = new LuongNhanVien_BUS();

        public LuongNhanViens()
        {
            InitializeComponent();

            LoadThang(); // Gọi hàm để load dữ liệu tháng
            LoadNam();   // Gọi hàm để load dữ liệu năm
            bus = new LuongNhanVien_BUS();
            // Kiểm tra và thêm lương khi mở form
            bus.KiemTraVaThemLuong();
            LoadData(); // Tải dữ liệu khi mở form

        }

        private void LoadThang()
        {
            // Thêm các tháng từ 1 đến 12 vào ComboBox cbThang
            cbThang.Items.Add("Tất cả");  // Thêm tùy chọn "Tất cả" để không lọc theo tháng
            for (int i = 1; i <= 12; i++)
            {
                cbThang.Items.Add(i);
            }
            cbThang.SelectedIndex = 0; // Đặt giá trị mặc định là "Tất cả"
        }

        private void LoadNam()
        {
            // Thêm các năm từ năm hiện tại lùi về 30 năm trước vào ComboBox cbNam
            int currentYear = DateTime.Now.Year;
            cbNam.Items.Add("Tất cả"); // Thêm tùy chọn "Tất cả" để không lọc theo năm
            for (int i = currentYear; i >= currentYear - 20; i--)
            {
                cbNam.Items.Add(i);
            }
            cbNam.SelectedIndex = 0; // Đặt giá trị mặc định là "Tất cả"
        }

        // Hàm tải dữ liệu lương lên DataGridView
        private void LoadData()
        {
            List<LuongNhanVien_DTO> listLuong = bus.LayDanhSachLuong();
            dgvLuongNhanVien.DataSource = listLuong;

            //// Cập nhật định dạng cho các cột Lương  
            //UpdateColumnFormat("LuongCoBan");
            //UpdateColumnFormat("ThuongChuyenCan");
            //UpdateColumnFormat("ThuongHieuSuat");

            // Kiểm tra và thêm cột Tổng Lương nếu không tồn tại  
            if (!dgvLuongNhanVien.Columns.Contains("TongLuong"))
            {
                DataGridViewTextBoxColumn tongLuongColumn = new DataGridViewTextBoxColumn
                {
                    Name = "TongLuong",
                    HeaderText = "Tổng Lương",
                    DataPropertyName = "TongLuong"
                };
                dgvLuongNhanVien.Columns.Add(tongLuongColumn);
            }

            // Cập nhật định dạng cho cột Tổng Lương  
            //dgvLuongNhanVien.Columns["TongLuong"].DefaultCellStyle.Format = "#,0";

            // Refresh lại DataGridView  
            dgvLuongNhanVien.Refresh();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ ComboBox tháng, năm và TextBox tìm kiếm
            int? thang = cbThang.SelectedIndex > 0 ? (int?)cbThang.SelectedItem : null;
            int? nam = cbNam.SelectedIndex > 0 ? (int?)cbNam.SelectedItem : null;
            string keyword = txtTimKiem.Text.Trim();

            // Nếu không có điều kiện nào được nhập, thông báo người dùng
            if (thang == null && nam == null && string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm hoặc chọn tháng, năm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Gọi phương thức tìm kiếm với các tham số
            List<LuongNhanVien_DTO> results = bus.TimKiemLuong(thang, nam, keyword);

            // Hiển thị kết quả lên DataGridView
            dgvLuongNhanVien.DataSource = results;

            // Kiểm tra nếu không có kết quả nào được tìm thấy
            if (results == null || results.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }
    }
}
