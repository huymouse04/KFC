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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();

        }


        private NhanVien_BUS bus = new NhanVien_BUS();

        private void NhanVien_Load(object sender, EventArgs e)
        {
            //LoadDanhSachNhanVien();
            LoadData();
        }

        private void LoadData()
        {
            // Xóa tất cả các điều khiển hiện có trong FlowLayoutPanel
            flpNhanVien.Controls.Clear();

            // Lấy danh sách nhân viên từ lớp BUS
            var nhanVienList = bus.GetAllNhanVien();

            // Duyệt qua danh sách nhân viên và thêm vào FlowLayoutPanel
            foreach (var nhanVien in nhanVienList)
            {
                NhanVienControl control = new NhanVienControl();
                control.UpdateData(nhanVien); // Cập nhật thông tin nhân viên vào control
                flpNhanVien.Controls.Add(control); // Thêm điều khiển vào FlowLayoutPanel
            }
        }

        private void OpenCapNhatNhanVien(NhanVien_DTO nhanVien)
        {
            if (nhanVien == null)
            {
                MessageBox.Show("Thông tin nhân viên không hợp lệ.");
                return;
            }

            // Lấy thông tin nhân viên đầy đủ từ database
            NhanVien_DTO nhanVienDayDu = bus.GetNhanVienByMa(nhanVien.MaNhanVien);

            // Kiểm tra nếu không tìm thấy nhân viên
            if (nhanVienDayDu == null)
            {
                MessageBox.Show("Không tìm thấy thông tin nhân viên với mã: " + nhanVien.MaNhanVien);
                return;
            }

            // Mở form cập nhật với thông tin đầy đủ
            CapNhatNhanVien formCapNhat = new CapNhatNhanVien(nhanVienDayDu);
            formCapNhat.ShowDialog();
        }

        private void btnLuongNhanVien_Click(object sender, EventArgs e)
        {
            LuongNhanVien FormLuong = new LuongNhanVien();
            FormLuong.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CapNhatNhanVien cn = new CapNhatNhanVien();
            cn.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có nhân viên nào được chọn không
            var selectedControl = flpNhanVien.Controls.OfType<NhanVienControl>().FirstOrDefault(c => c.IsSelected);

            if (selectedControl != null)
            {
                NhanVien_DTO nhanVien = selectedControl.GetNhanVien(); // Lấy thông tin nhân viên từ điều khiển đã chọn

                if (nhanVien != null)
                {
                    string maNhanVien = nhanVien.MaNhanVien; // Lấy mã nhân viên

                    // Hiển thị hộp thoại xác nhận
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Gọi phương thức xóa từ lớp BUS
                        bus.DeleteNhanVien(maNhanVien);

                        // Cập nhật lại FlowLayoutPanel sau khi xóa
                        LoadData(); // Gọi lại LoadData để nạp lại danh sách nhân viên
                        MessageBox.Show("Xóa nhân viên thành công!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            txtTimKiem.Clear();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
             string searchTerm = txtTimKiem.Text.Trim(); // Lấy giá trị tìm kiếm

            // Gọi phương thức tìm kiếm từ lớp BUS
            var result = bus.SearchNhanVien(searchTerm);

            // Cập nhật FlowLayoutPanel với kết quả tìm kiếm
            flpNhanVien.Controls.Clear();
            foreach (var nhanVien in result)
            {
                NhanVienControl control = new NhanVienControl();
                control.UpdateData(nhanVien); // Cập nhật thông tin nhân viên vào control
                flpNhanVien.Controls.Add(control); // Thêm điều khiển vào FlowLayoutPanel
            }

            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public DataTable ConvertListToDataTable(List<DTO.NhanVien_DTO> list)
        {
            DataTable dataTable = new DataTable(typeof(DTO.NhanVien_DTO).Name);

            // Lấy tất cả các thuộc tính của DTO.NhanVien_DTO
            var properties = typeof(DTO.NhanVien_DTO).GetProperties();

            // Tạo các cột cho DataTable dựa trên các thuộc tính
            foreach (var prop in properties)
            {
                var propType = prop.PropertyType;

                // Nếu là DateTime, tạo cột với kiểu string để chỉ hiển thị ngày
                if (propType == typeof(DateTime) ||
                    (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>) && Nullable.GetUnderlyingType(propType) == typeof(DateTime)))
                {
                    dataTable.Columns.Add(prop.Name, typeof(string)); // Đổi cột thành kiểu string
                }
                else
                {
                    // Kiểm tra nếu thuộc tính là kiểu Nullable, lấy kiểu cơ bản nếu cần
                    if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        propType = Nullable.GetUnderlyingType(propType);
                    }
                    dataTable.Columns.Add(prop.Name, propType);
                }
            }

            // Thêm dữ liệu từ List vào DataTable
            foreach (var item in list)
            {
                var values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    var propValue = properties[i].GetValue(item, null);

                    // Kiểm tra nếu là kiểu DateTime và định dạng lại chỉ hiển thị ngày
                    if (propValue is DateTime dateValue)
                    {
                        values[i] = dateValue.ToString("dd/MM/yyyy"); // Chuyển đổi DateTime thành string chỉ chứa ngày
                    }
                    else
                    {
                        values[i] = propValue ?? DBNull.Value; // Gán DBNull.Value nếu giá trị null
                    }
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }


        private void btnXuat_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            List<DTO.NhanVien_DTO> ketQuaList;

            if (string.IsNullOrEmpty(tuKhoa))
            {
                ketQuaList = bus.GetAllNhanVien();
            }
            else
            {
                ketQuaList = bus.SearchNhanVien(tuKhoa);
            }

            if (ketQuaList == null || ketQuaList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên nào với từ khóa đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Chuyển đổi List<DTO.NhanVien_DTO> sang DataTable
            DataTable ketQua = ConvertListToDataTable(ketQuaList);

            FormReport formNhanVien = new FormReport(FormReport.LoaiBaoCao.NhanVien, ketQua);
            formNhanVien.Show();
        }
    }
}
