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
    public partial class NhaCungCap : Form
    {
        public NhaCungCap()
        {
            InitializeComponent();
        }

        private NhaCungCap_BUS bus = new NhaCungCap_BUS();

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // Xóa tất cả các điều khiển hiện có trong FlowLayoutPanel
            flpNhaCungCap.Controls.Clear();

            // Lấy danh sách nhà cung cấp từ lớp BUS
            var nhaCungCapList = bus.GetAllNhaCungCap();

            // Duyệt qua danh sách nhà cung cấp và thêm vào FlowLayoutPanel
            foreach (var nhaCungCap in nhaCungCapList)
            {
                NhaCungCapControl control = new NhaCungCapControl();
                control.UpdateData(nhaCungCap);
                flpNhaCungCap.Controls.Add(control); // Thêm điều khiển vào FlowLayoutPanel
            }
        }

        private void OpenCapNhatNhaCungCap(NhaCungCap_DTO nhaCungCap)
        {
            if (nhaCungCap == null)
            {
                MessageBox.Show("Thông tin nhà cung cấp không hợp lệ.");
                return;
            }

            // Lấy thông tin nhà cung cấp đầy đủ từ database
            NhaCungCap_DTO nhaCungCapDayDu = bus.GetNhaCungCapByMa(nhaCungCap.MaNhaCungCap);

            // Kiểm tra nếu không tìm thấy nhà cung cấp
            if (nhaCungCapDayDu == null)
            {
                MessageBox.Show("Không tìm thấy thông tin nhà cung cấp với mã: " + nhaCungCap.MaNhaCungCap);
                return;
            }

            using (CapNhatNhaCungCap formCapNhat = new CapNhatNhaCungCap(nhaCungCapDayDu)) 
            {
                if (formCapNhat.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (CapNhatNhaCungCap formCapNhat = new CapNhatNhaCungCap()) 
            {
                if (formCapNhat.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }

        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            // Mở form Nhập Hàng
            using (NhapHang formNhapHang = new NhapHang())
            {
                formNhapHang.ShowDialog(); // Mở form nhập hàng
            }
        }

        private void btnLoaiHang_Click(object sender, EventArgs e)
        {
            // Mở form Loại Hàng
            using (LoaiHang formLoaiHang = new LoaiHang())
            {
                formLoaiHang.ShowDialog(); // Mở form loại hàng
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có nhà cung cấp nào được chọn không
            var selectedControl = flpNhaCungCap.Controls.OfType<NhaCungCapControl>().FirstOrDefault(c => c.IsSelected);

            if (selectedControl != null)
            {
                NhaCungCap_DTO nhaCungCap = selectedControl.GetNhaCungCap(); // Lấy thông tin nhà cung cấp từ điều khiển đã chọn

                if (nhaCungCap != null)
                {
                    string maNhaCungCap = nhaCungCap.MaNhaCungCap; // Lấy mã nhà cung cấp

                    // Hiển thị hộp thoại xác nhận
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này không?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Gọi phương thức xóa từ lớp BUS
                        bus.DeleteNhaCungCap(maNhaCungCap);

                        // Cập nhật lại FlowLayoutPanel sau khi xóa
                        LoadData(); // Gọi lại LoadData để nạp lại danh sách nhà cung cấp
                        MessageBox.Show("Xóa nhà cung cấp thành công!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhà cung cấp để xóa.");
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
            var result = bus.SearchNhaCungCap(searchTerm);

            // Cập nhật FlowLayoutPanel với kết quả tìm kiếm
            flpNhaCungCap.Controls.Clear();
            foreach (var nhaCungCap in result)
            {
                NhaCungCapControl control = new NhaCungCapControl();
                control.UpdateData(nhaCungCap); // Cập nhật thông tin nhà cung cấp vào control
                flpNhaCungCap.Controls.Add(control); // Thêm điều khiển vào FlowLayoutPanel
            }

            // Kiểm tra nếu không có kết quả tìm kiếm
            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            }
            return dataTable;

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            //    string tuKhoa = txtTimKiem.Text.Trim();
            //    List<NhaCungCap_DTO> ketQuaList;

            //    if (string.IsNullOrEmpty(tuKhoa))
            //    {
            //        ketQuaList = bus.GetAllNhaCungCap();
            //    }
            //    else
            //    {
            //        ketQuaList = bus.SearchNhaCungCap(tuKhoa);
            //    }

            //    if (ketQuaList == null || ketQuaList.Count == 0)
            //    {
            //        MessageBox.Show("Không tìm thấy nhà cung cấp nào với từ khóa đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }

            //    // Chuyển đổi List<NhaCungCap_DTO> sang DataTable
            //    DataTable ketQua = ConvertListToDataTable(ketQuaList);

            //    FormReport formNhaCungCap = new FormReport(FormReport.LoaiBaoCao.NhaCungCap, ketQua);
            //    formNhaCungCap.Show();
        }

        public DataTable ConvertListToDataTable(List<NhaCungCap_DTO> list)
        {
            DataTable dataTable = new DataTable(typeof(NhaCungCap_DTO).Name);

            // Lấy tất cả các thuộc tính của NhaCungCap_DTO
            var properties = typeof(NhaCungCap_DTO).GetProperties();

            // Tạo các cột cho DataTable dựa trên các thuộc tính
            foreach (var prop in properties)
            {
                var propType = prop.PropertyType;

                // Kiểm tra nếu thuộc tính là kiểu Nullable, lấy kiểu cơ bản nếu cần
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
                    values[i] = propValue;
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
