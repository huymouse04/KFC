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

        // Tạo đối tượng DTO
        private LuongNhanVien_DTO luongNhanVien = new LuongNhanVien_DTO();
        public LuongNhanViens()
        {
            InitializeComponent();

            LoadThang(); // Gọi hàm để load dữ liệu tháng
            LoadNam();   // Gọi hàm để load dữ liệu năm
            bus = new LuongNhanVien_BUS();
            // Kiểm tra và thêm lương khi mở form
            bus.KiemTraVaThemLuong();
            LoadData(); // Tải dữ liệu khi mở form
            txtMaNV.Enabled = false;
            txtHoTenNV.Enabled = false;
            txtChucVu.Enabled = false;
        }

        private void LoadThang()
        {
            // Thêm các tháng từ 1 đến 12 vào ComboBox cbThang
            cboThang.Items.Add("tất cả");
            cbThang.Items.Add("Tất cả");  // Thêm tùy chọn "Tất cả" để không lọc theo tháng
            for (int i = 1; i <= 12; i++)
            {
                cbThang.Items.Add(i);
                cboThang.Items.Add(i);
            }
            cbThang.SelectedIndex = 0; // Đặt giá trị mặc định là "Tất cả"
            cboThang.SelectedIndex = 0;
        }

        private void LoadNam()
        {
            // Thêm các năm từ năm hiện tại lùi về 30 năm trước vào ComboBox cbNam
            int currentYear = DateTime.Now.Year;
            cboNam.Items.Add("tất cả");
            cbNam.Items.Add("Tất cả"); // Thêm tùy chọn "Tất cả" để không lọc theo năm
            for (int i = currentYear; i >= currentYear - 20; i--)
            {
                cbNam.Items.Add(i);
                cboNam.Items.Add(i);
            }
            cbNam.SelectedIndex = 0; // Đặt giá trị mặc định là "Tất cả"
            cboNam.SelectedIndex = 0;
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

            //// Kiểm tra và thêm cột Tổng Lương nếu không tồn tại  
            //if (!dgvLuongNhanVien.Columns.Contains("TongLuong"))
            //{
            //    DataGridViewTextBoxColumn tongLuongColumn = new DataGridViewTextBoxColumn
            //    {
            //        Name = "TongLuong",
            //        HeaderText = "Tổng Lương",
            //        DataPropertyName = "TongLuong"
            //    };
            //    dgvLuongNhanVien.Columns.Add(tongLuongColumn);
            //}

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

        private void dgvLuongNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu hàng được nhấp đúp không phải là hàng tiêu đề
            if (e.RowIndex >= 0)
            {
                // Lấy hàng hiện tại
                DataGridViewRow row = dgvLuongNhanVien.Rows[e.RowIndex];

                // Gán giá trị từ hàng vào các điều khiển cập nhật
                txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtHoTenNV.Text = row.Cells["TenNhanVien"].Value.ToString();
                txtChucVu.Text = row.Cells["ChucVu"].Value.ToString();
                txtLuongCB.Text = row.Cells["LuongCoBan"].Value.ToString();
                txtSoNgayCong.Text = row.Cells["SoNgayLam"].Value.ToString();
                txtSoGioLamThem.Text = row.Cells["SoGioLamThem"].Value.ToString();
                txtThuongCC.Text = row.Cells["ThuongChuyenCan"].Value.ToString();
                txtThuongHS.Text = row.Cells["ThuongHieuSuat"].Value.ToString();
               
                txtKhoanTru.Text = row.Cells["KhoanTru"].Value.ToString();

                int thang;
                if (int.TryParse(row.Cells["Thang"].Value.ToString(), out thang))
                {
                    // Gán chỉ số cho ComboBox thang, phải đảm bảo ComboBox chứa các giá trị từ 1 đến 12
                    cboThang.SelectedIndex = thang; // Tháng từ 1-12, chỉ số từ 0-11
                }

                int nam;
                if (int.TryParse(row.Cells["Nam"].Value.ToString(), out nam))
                {
                    int index = cboNam.Items.IndexOf(nam); // Tìm chỉ số của năm
                    if (index != -1)
                    {
                        cboNam.SelectedIndex = index; // Gán chỉ số cho ComboBox
                    }
                }

                // Kiểm tra sự tồn tại của cột "TongLuong" trước khi gán giá trị
                if (dgvLuongNhanVien.Columns.Contains("TongLuong") && row.Cells["TongLuong"].Value != null)
                {
                    txtTongTien.Text = row.Cells["TongLuong"].Value.ToString();
                }
            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường không được để trống
            if (string.IsNullOrWhiteSpace(txtLuongCB.Text) ||
                string.IsNullOrWhiteSpace(txtSoNgayCong.Text) ||
                string.IsNullOrWhiteSpace(txtThuongCC.Text) ||
                string.IsNullOrWhiteSpace(txtThuongHS.Text) ||
                string.IsNullOrWhiteSpace(txtSoGioLamThem.Text) ||
                string.IsNullOrWhiteSpace(txtKhoanTru.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra kiểu dữ liệu và chuyển đổi giá trị
            if (!int.TryParse(txtSoNgayCong.Text, out int soNgayCong))
            {
                MessageBox.Show("Giá trị ngày công không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtThuongCC.Text, out int thuongChuyenCan))
            {
                MessageBox.Show("Giá trị thưởng chuyên cần không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtThuongHS.Text, out int thuongHieuSuat))
            {
                MessageBox.Show("Giá trị thưởng hiệu suất không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtSoGioLamThem.Text, out int soGioLamThem))
            {
                MessageBox.Show("Giá trị giờ làm thêm không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtKhoanTru.Text, out int khoanTru))
            {
                MessageBox.Show("Giá trị khoản trừ không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtLuongCB.Text, out int luongCoBan))
            {
                MessageBox.Show("Giá trị lương cơ bản không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã nhân viên hiện tại
            string maNhanVien = txtMaNV.Text;

            // Giữ nguyên tên và chức vụ
            string tenNhanVien = txtHoTenNV.Text;
            string chucVu = txtChucVu.Text;

            // Tạo đối tượng DTO
            LuongNhanVien_DTO luongDTO = new LuongNhanVien_DTO
            {
                MaNhanVien = maNhanVien,
                TenNhanVien = tenNhanVien,
                ChucVu = chucVu,
                LuongCoBan = luongCoBan,
                Thang = int.TryParse(cboThang.SelectedItem?.ToString(), out int thang) ? thang : 0,
                Nam = int.TryParse(cboNam.SelectedItem?.ToString(), out int nam) ? nam : 0,
                SoNgayLam = soNgayCong,
                ThuongChuyenCan = thuongChuyenCan,
                ThuongHieuSuat = thuongHieuSuat,
                SoGioLamThem = soGioLamThem,
                KhoanTru = khoanTru
            };

            // Gọi phương thức cập nhật lương
            bus.CapNhatLuong(luongDTO);
            LoadData();
        }

        private void CapNhatGiaTriDTO()
        {
            // Sử dụng int.TryParse để đảm bảo chuyển đổi thành công hoặc gán giá trị 0 nếu không hợp lệ
            if (!int.TryParse(txtLuongCB.Text, out int lcb))
                lcb = 0;
            luongNhanVien.LuongCoBan = lcb;

            if (!int.TryParse(txtSoNgayCong.Text, out int snl))
                snl = 0;
            luongNhanVien.SoNgayLam = snl;

            if (!int.TryParse(txtThuongCC.Text, out int tcc))
                tcc = 0;
            luongNhanVien.ThuongChuyenCan = tcc;

            if (!int.TryParse(txtThuongHS.Text, out int ths))
                ths = 0;
            luongNhanVien.ThuongHieuSuat = ths;

            if (!int.TryParse(txtSoGioLamThem.Text, out int sglt))
                sglt = 0;
            luongNhanVien.SoGioLamThem = sglt;

            if (!int.TryParse(txtKhoanTru.Text, out int kt))
                kt = 0;
            luongNhanVien.KhoanTru = kt;
        }


        // Hàm hiển thị tổng lương trên Form
        private void HienThiTongLuong()
        {
            txtTongTien.Text = luongNhanVien.TongLuong.ToString("#,0");
        }

        private void txtLuongCB_TextChanged(object sender, EventArgs e)
        {
            CapNhatGiaTriDTO();
            HienThiTongLuong();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            int? thang = cbThang.SelectedIndex > 0 ? (int?)cbThang.SelectedItem : null;
            int? nam = cbNam.SelectedIndex > 0 ? (int?)cbNam.SelectedItem : null;
            string keyword = txtTimKiem.Text.Trim();

            // Lấy kết quả tìm kiếm
            List<LuongNhanVien_DTO> ketQua = bus.TimKiemLuong(thang, nam, keyword);

            if (ketQua != null && ketQua.Count > 0)
            {
                // Chuyển List sang DataTable
                DataTable ketQuaDataTable = ConvertToDataTable(ketQua);

                // Hiển thị báo cáo
                FormReport formLuong = new FormReport(FormReport.LoaiBaoCao.LuongNhanVien, ketQuaDataTable);
                formLuong.Show();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private DataTable ConvertToDataTable(List<LuongNhanVien_DTO> list)
        {
            DataTable dataTable = new DataTable();

            // Thêm cột vào DataTable dựa trên các thuộc tính của LuongNhanVien_DTO
            dataTable.Columns.Add("MaNhanVien", typeof(string));
            dataTable.Columns.Add("TenNhanVien", typeof(string));
            dataTable.Columns.Add("ChucVu", typeof(string));
            dataTable.Columns.Add("LuongCoBan", typeof(int));
            dataTable.Columns.Add("Thang", typeof(int));
            dataTable.Columns.Add("Nam", typeof(int));
            dataTable.Columns.Add("SoNgayLam", typeof(int));
            dataTable.Columns.Add("ThuongChuyenCan", typeof(int));
            dataTable.Columns.Add("ThuongHieuSuat", typeof(int));
            dataTable.Columns.Add("SoGioLamThem", typeof(int));
            dataTable.Columns.Add("KhoanTru", typeof(int));
            dataTable.Columns.Add("TongLuong", typeof(int)); // Giả sử `TongLuong` là kiểu decimal

            // Thêm dữ liệu từ danh sách vào DataTable
            foreach (var item in list)
            {
                dataTable.Rows.Add(
                    item.MaNhanVien,
                    item.TenNhanVien,
                    item.ChucVu,
                    item.LuongCoBan,
                    item.Thang,
                    item.Nam,
                    item.SoNgayLam,
                    item.ThuongChuyenCan,
                    item.ThuongHieuSuat,
                    item.SoGioLamThem,
                    item.KhoanTru,
                    item.TongLuong
                );
            }

            return dataTable;
        }

    }
}
