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
    public partial class LuongNhanVien : Form
    {
        private string maNhanVien;
        private int thang;
        private LuongNhanVien_BUS bus = new LuongNhanVien_BUS();
        private NhanVien_BUS nvbus = new NhanVien_BUS();
        public LuongNhanVien()
        {
            InitializeComponent();
            LoadData(); // Tải dữ liệu khi mở form

        }

        public void CapNhatDanhSachLuong()
        {
            LoadData();
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
            string searchTerm = txtTimKiem.Text.Trim();
            int? month = null;

            // Kiểm tra nếu ComboBox chọn tháng có giá trị hợp lệ
            if (cbThang.SelectedIndex != -1)
            {
                month = int.Parse(cbThang.SelectedItem.ToString()); // Lấy giá trị tháng từ ComboBox
            }

            List<LuongNhanVien_DTO> results = new List<LuongNhanVien_DTO>();

            // Nếu người dùng chọn tháng và có từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchTerm) && month.HasValue)
            {
                results = bus.SearchLuongNhanVienTheoThang(searchTerm, month.Value);
            }
            // Nếu chỉ chọn tháng mà không có từ khóa tìm kiếm
            else if (month.HasValue)
            {
                results = bus.SearchLuongByMonth(month.Value);
            }
            // Nếu chỉ tìm theo từ khóa mà không chọn tháng
            else if (!string.IsNullOrEmpty(searchTerm))
            {
                results = bus.SearchLuongNhanVien(searchTerm);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm hoặc chọn tháng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Hiển thị kết quả lên DataGridView
            dgvLuongNhanVien.DataSource = results;

            // Kiểm tra nếu không có kết quả nào được tìm thấy
            if (results == null || results.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            int? thang = null;  // Biến để lưu giá trị tháng nếu được chọn

            // Nếu ComboBox tháng được chọn, lấy giá trị tháng
            if (cbThang.SelectedIndex != -1)
            {
                thang = int.Parse(cbThang.SelectedItem.ToString()); // Lấy giá trị tháng từ ComboBox
            }

            List<DTO.LuongNhanVien_DTO> ketQuaList = new List<DTO.LuongNhanVien_DTO>();

            // Nếu từ khóa rỗng và không chọn tháng, lấy tất cả nhân viên
            if (string.IsNullOrEmpty(tuKhoa) && thang == null)
            {
                ketQuaList = bus.LayDanhSachLuong(); // Lấy tất cả dữ liệu
            }
            else if (!string.IsNullOrEmpty(tuKhoa) && thang != null)
            {
                // Kết hợp tìm kiếm theo từ khóa và tháng
                ketQuaList = bus.SearchLuongNhanVienTheoThang(tuKhoa, thang.Value);
            }
            else if (thang != null)
            {
                // Nếu chỉ chọn tháng, tìm theo tháng
                ketQuaList = bus.SearchLuongByMonth(thang.Value);
            }
            else
            {
                // Nếu chỉ tìm theo từ khóa (không có tháng)
                ketQuaList = bus.SearchLuongNhanVien(tuKhoa);
            }

            // Kiểm tra kết quả tìm kiếm
            if (ketQuaList == null || ketQuaList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên nào với từ khóa hoặc tháng đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Chuyển đổi List<DTO.LuongNhanVien_DTO> sang DataTable
            DataTable ketQua = ConvertListToDataTable(ketQuaList);

            // Hiển thị báo cáo
            FormReport formLuong = new FormReport(FormReport.LoaiBaoCao.LuongNhanVien, ketQua);
            formLuong.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CapNhatLuong cnl = new CapNhatLuong();
            cnl.ShowDialog();

        }

        public DataTable ConvertListToDataTable(List<DTO.LuongNhanVien_DTO> list)
        {
            DataTable dataTable = new DataTable(typeof(DTO.LuongNhanVien_DTO).Name);

            // Lấy tất cả các thuộc tính của DTO.NhanVien_DTO
            var properties = typeof(DTO.LuongNhanVien_DTO).GetProperties();

            // Tạo các cột cho DataTable dựa trên các thuộc tính
            foreach (var prop in properties)
            {
                // Kiểm tra nếu thuộc tính là kiểu Nullable, lấy kiểu cơ bản nếu cần
                var propType = prop.PropertyType;
                if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    propType = Nullable.GetUnderlyingType(propType);
                }

                dataTable.Columns.Add(prop.Name, propType);
            }

            // Thêm dữ liệu từ List vào DataTable
            foreach (var item in list)
            {
                var values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    var propValue = properties[i].GetValue(item, null);
                    // Nếu giá trị null, gán DBNull.Value
                    values[i] = propValue ?? DBNull.Value;
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            txtTimKiem.Clear();
            cbThang.SelectedIndex = -1;
        }

        private void dgvLuongNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvLuongNhanVien.Rows[e.RowIndex];

                try
                {
                    string maNhanVien = selectedRow.Cells["MaNhanVien"].Value?.ToString();
                    if (string.IsNullOrEmpty(maNhanVien))
                    {
                        MessageBox.Show("Mã nhân viên không hợp lệ.");
                        return;
                    }

                    LuongNhanVien_DTO luongDTO = new LuongNhanVien_DTO
                    {
                        MaNhanVien = maNhanVien,
                        LuongCoBan = int.Parse(selectedRow.Cells["LuongCoBan"].Value.ToString()),
                        Thang = int.Parse(selectedRow.Cells["Thang"].Value.ToString()), // Lấy tháng từ DataGridView
                        SoNgayLam = int.Parse(selectedRow.Cells["SoNgayLam"].Value.ToString()),
                        ThuongChuyenCan = int.Parse(selectedRow.Cells["ThuongChuyenCan"].Value.ToString()),
                        ThuongHieuSuat = int.Parse(selectedRow.Cells["ThuongHieuSuat"].Value.ToString()),
                        SoGioLamThem = int.Parse(selectedRow.Cells["SoGioLamThem"].Value.ToString()),
                        KhoanTru = int.Parse(selectedRow.Cells["KhoanTru"].Value.ToString())

                    };

                    // Lấy thông tin nhân viên từ BUS
                    var nhanVien = nvbus.GetNhanVienByMa(maNhanVien);
                    if (nhanVien != null)
                    {
                        luongDTO.TenNhanVien = nhanVien.TenNhanVien; // Thêm tên nhân viên
                        luongDTO.ChucVu = nhanVien.ChucVu; // Thêm chức vụ
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên.");
                        return;
                    }

                    // Mở Form Cập Nhật
                    var capNhatLuongForm = new CapNhatLuong(luongDTO, this);
                    capNhatLuongForm.SalaryUpdated += (s, ev) => this.CapNhatDanhSachLuong(); // Đăng ký sự kiện
                    capNhatLuongForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có một lỗi xảy ra: {ex.Message}\nStack Trace: {ex.StackTrace}");
                }
            }
        }
    }
}
