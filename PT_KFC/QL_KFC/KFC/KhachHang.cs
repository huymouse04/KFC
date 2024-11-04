using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace KFC
{
    public partial class KhachHang : Form
    {
        private KhachHang_BUS bus = new KhachHang_BUS(); // Khởi tạo lớp BUS cho khách hàng

        public KhachHang()
        {
            InitializeComponent();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // Xóa tất cả các điều khiển hiện có trong panelKhachHang
            panelKhachHang.Controls.Clear();

            // Lấy danh sách khách hàng từ lớp BUS
            var khachHangList = bus.GetAllKhachHang();

            // Duyệt qua danh sách khách hàng và thêm vào panelKhachHang
            foreach (var khachHang in khachHangList)
            {
                KhachHangControl control = new KhachHangControl();
                control.UpdateData(khachHang);
                panelKhachHang.Controls.Add(control); // Thêm điều khiển vào panelKhachHang
            }
        }

        private void OpenCapNhatKhachHang(KhachHang_DTO khachHang)
        {
            if (khachHang == null)
            {
                MessageBox.Show("Thông tin khách hàng không hợp lệ.");
                return;
            }

            // Lấy thông tin khách hàng đầy đủ từ database
            KhachHang_DTO khachHangDayDu = bus.GetKhachHangByMa(khachHang.MaKhachHang);

            // Kiểm tra nếu không tìm thấy khách hàng
            if (khachHangDayDu == null)
            {
                MessageBox.Show("Không tìm thấy thông tin khách hàng với mã: " + khachHang.MaKhachHang);
                return;
            }

            //using (CapNhatKhachHang formCapNhat = new CapNhatKhachHang(khachHangDayDu))
            //{
            //    if (formCapNhat.ShowDialog() == DialogResult.OK)
            //    {
            //        LoadData();
            //    }
            //}
        }

        private void btnThemm_Click(object sender, EventArgs e)
        {
            using (CapNhatKhachHang capNhatForm = new CapNhatKhachHang())
            {
                // Hiển thị form cập nhật khách hàng dưới dạng dialog
                if (capNhatForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(); // Gọi phương thức LoadData() để cập nhật dữ liệu
                }
            }
        }

        private void btnXoaa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có khách hàng nào được chọn không
            var selectedControl = panelKhachHang.Controls.OfType<KhachHangControl>().FirstOrDefault(c => c.IsSelected);

            if (selectedControl != null)
            {
                KhachHang_DTO khachHang = selectedControl.GetKhachHang(); // Lấy thông tin khách hàng từ control đã chọn

                if (khachHang != null)
                {
                    string maKhachHang = khachHang.MaKhachHang; // Lấy mã khách hàng

                    // Hiển thị hộp thoại xác nhận
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Thực hiện xóa khách hàng
                            bus.DeleteKhachHang(maKhachHang);
                            MessageBox.Show("Xóa khách hàng thành công!");

                            // Cập nhật lại panelKhachHang sau khi xóa
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = tbtTimKiem.Text.Trim(); // Lấy giá trị tìm kiếm

            // Gọi phương thức tìm kiếm từ lớp BUS
            var result = bus.SearchKhachHang(searchTerm);

            // Cập nhật panelKhachHang với kết quả tìm kiếm
            panelKhachHang.Controls.Clear();
            foreach (var khachHang in result)
            {
                KhachHangControl control = new KhachHangControl();
                control.UpdateData(khachHang); // Cập nhật thông tin khách hàng vào control
                panelKhachHang.Controls.Add(control); // Thêm điều khiển vào panelKhachHang
            }

            // Kiểm tra nếu không có kết quả tìm kiếm
            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblKhachHang_Click(object sender, EventArgs e)
        {
            // Gọi lại dữ liệu khi nhấn vào lblKhachHang
            LoadData();
            tbtTimKiem.Clear();
        }

        public DataTable ConvertListToDataTable(List<DTO.KhachHang_DTO> list)
        {
            DataTable dataTable = new DataTable(typeof(DTO.KhachHang_DTO).Name);

            // Lấy tất cả các thuộc tính của DTO.KhachHang_DTO
            var properties = typeof(DTO.KhachHang_DTO).GetProperties();

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
                    values[i] = propValue ?? DBNull.Value; // Gán DBNull.Value nếu giá trị null
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }



    }
}
