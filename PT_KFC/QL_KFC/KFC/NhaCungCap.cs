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
            LoadData();
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
            LoadData();
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

            LoadData();

        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            // Mở form Nhập Hàng
            using (NhapHang formNhapHang = new NhapHang())
            {
                // Hiển thị form cập nhật nhà cung cấp dưới dạng dialog
                if (formNhapHang.ShowDialog() == DialogResult.OK)
                {
                    // Nếu cập nhật thành công (DialogResult.OK), load lại dữ liệu của form Nhà Cung Cấp
                    LoadData(); // Gọi phương thức LoadData() trên form Nhà Cung Cấp để cập nhật dữ liệu
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có nhà cung cấp nào được chọn không
            var selectedControl = flpNhaCungCap.Controls.OfType<NhaCungCapControl>().FirstOrDefault(c => c.IsSelected);

            if (selectedControl != null)
            {
                NhaCungCap_DTO nhaCungCap = selectedControl.GetNhaCungCap(); // Lấy thông tin nhà cung cấp từ control đã chọn

                if (nhaCungCap != null)
                {
                    string maNhaCungCap = nhaCungCap.MaNhaCungCap; // Lấy mã nhà cung cấp

                    // Hiển thị hộp thoại xác nhận
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này không?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Kiểm tra xem nhà cung cấp có đang được sử dụng trong bảng Nhập Hàng không
                            string usageMessage = bus.TermDeleteNhaCungCap(maNhaCungCap);

                            if (string.IsNullOrEmpty(usageMessage))
                            {
                                // Nếu không có thông báo sử dụng, thực hiện xóa nhà cung cấp
                                bus.DeleteNhaCungCap(maNhaCungCap);
                                MessageBox.Show("Xóa nhà cung cấp thành công!");

                                // Cập nhật lại FlowLayoutPanel sau khi xóa
                                LoadData();
                            }
                            else
                            {
                                // Nếu có thông báo sử dụng, hiển thị thông báo cho người dùng
                                MessageBox.Show(usageMessage);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa nhà cung cấp: " + ex.Message);
                        }
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
            txtFind.Clear();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtFind.Text.Trim(); // Lấy giá trị tìm kiếm

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng xử lý nếu không có từ khóa tìm kiếm
            }

            // Gọi phương thức tìm kiếm từ lớp BUS
            var result = bus.SearchNhaCungCap(searchTerm);

            // Kiểm tra nếu không có kết quả tìm kiếm
            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Cập nhật FlowLayoutPanel với kết quả tìm kiếm
                flpNhaCungCap.Controls.Clear();
                foreach (var nhaCungCap in result)
                {
                    NhaCungCapControl control = new NhaCungCapControl();
                    control.UpdateData(nhaCungCap); // Cập nhật thông tin nhà cung cấp vào control
                    flpNhaCungCap.Controls.Add(control); // Thêm điều khiển vào FlowLayoutPanel
                }
            }

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
