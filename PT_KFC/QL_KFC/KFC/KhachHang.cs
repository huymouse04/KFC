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
            var khachHangList = bus.GetAllKhachHang();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxLoc(); // Tải các item lọc vào ComboBox khi form tải
        }

        private void LoadData()
        {
            // Xóa tất cả các điều khiển hiện có trong flpKhachHang
            flpKhachHang.Controls.Clear();

            // Lấy danh sách khách hàng từ lớp BUS
            var khachHangList = bus.GetAllKhachHang();

            // Duyệt qua danh sách khách hàng và thêm vào flpKhachHang
            foreach (var khachHang in khachHangList)
            {
                KhachHangControl control = new KhachHangControl();
                control.UpdateData(khachHang); // Cập nhật thông tin khách hàng vào control
                flpKhachHang.Controls.Add(control); // Thêm điều khiển vào flpKhachHang
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

            using (CapNhatKhachHang formCapNhat = new CapNhatKhachHang(khachHangDayDu))
            {
                if (formCapNhat.ShowDialog() == DialogResult.OK)
                {
                    LoadData(); // Cập nhật lại dữ liệu sau khi cập nhật
                }
            }
            LoadData();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (CapNhatKhachHang capNhatForm = new CapNhatKhachHang())
            {
                // Hiển thị form cập nhật khách hàng dưới dạng dialog
                if (capNhatForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(); // Cập nhật lại dữ liệu sau khi thêm khách hàng mới
                }
            }
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có khách hàng nào được chọn không
            var selectedControl = flpKhachHang.Controls.OfType<KhachHangControl>().FirstOrDefault(c => c.IsSelected);

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

                            // Cập nhật lại flpKhachHang sau khi xóa
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

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            string searchTerm = tbtTiemKiem.Text.Trim(); // Lấy giá trị tìm kiếm

            // Gọi phương thức tìm kiếm từ lớp BUS
            var result = bus.SearchKhachHang(searchTerm);

            // Cập nhật flpKhachHang với kết quả tìm kiếm
            flpKhachHang.Controls.Clear();
            foreach (var khachHang in result)
            {
                KhachHangControl control = new KhachHangControl();
                control.UpdateData(khachHang); // Cập nhật thông tin khách hàng vào control
                flpKhachHang.Controls.Add(control); // Thêm điều khiển vào flpKhachHang
            }

            // Kiểm tra nếu không có kết quả tìm kiếm
            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            LoadData();
            tbtTiemKiem.Clear();
            cbbLoc.SelectedIndex = 0; // Đặt lại ComboBox về "Tất cả"
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


        // Hàm tải dữ liệu cho ComboBox lọc
        private void LoadComboBoxLoc()
        {
            // Thêm các item vào ComboBox để lọc theo điểm tích lũy
            cbbLoc.Items.Clear();
            cbbLoc.Items.Add("Tất cả");  // Tùy chọn không lọc
            cbbLoc.Items.Add("Dưới 50 điểm");
            cbbLoc.Items.Add("Từ 50 đến dưới 100 điểm");
            cbbLoc.Items.Add("Từ 100 đến dưới 150 điểm");
            cbbLoc.Items.Add("Bằng 150 điểm");

            cbbLoc.SelectedIndex = 0;  // Chọn mặc định là "Tất cả"
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ ComboBox
            string selectedCondition = cbbLoc.SelectedItem.ToString();

            List<KhachHang_DTO> result = new List<KhachHang_DTO>();

            switch (selectedCondition)
            {
                case "Tất cả":
                    result = bus.GetAllKhachHang(); // Lấy toàn bộ khách hàng
                    break;
                case "Dưới 50 điểm":
                    result = bus.GetAllKhachHang().Where(kh => kh.DiemTichLuy < 50).ToList(); // Lọc khách hàng có điểm dưới 50
                    break;
                case "Từ 50 đến dưới 100 điểm":
                    result = bus.GetAllKhachHang().Where(kh => kh.DiemTichLuy >= 50 && kh.DiemTichLuy < 100).ToList(); // Lọc khách hàng có điểm từ 50 đến dưới 100
                    break;
                case "Từ 100 đến dưới 150 điểm":
                    result = bus.GetAllKhachHang().Where(kh => kh.DiemTichLuy >= 100 && kh.DiemTichLuy < 150).ToList(); // Lọc khách hàng có điểm từ 100 đến dưới 150
                    break;
                case "Bằng 150 điểm":
                    result = bus.GetAllKhachHang().Where(kh => kh.DiemTichLuy == 150).ToList(); // Lọc khách hàng có điểm bằng 150
                    break;
                default:
                    MessageBox.Show("Không có điều kiện lọc phù hợp.");
                    return;
            }

            // Cập nhật lại danh sách khách hàng hiển thị
            flpKhachHang.Controls.Clear();
            foreach (var khachHang in result)
            {
                KhachHangControl control = new KhachHangControl();
                control.UpdateData(khachHang); // Cập nhật thông tin khách hàng vào control
                flpKhachHang.Controls.Add(control); // Thêm điều khiển vào flpKhachHang
            }

            // Nếu không có kết quả lọc
            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng với điều kiện lọc đã chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            // Lấy khách hàng được chọn trong danh sách (nếu có)
            var selectedControl = flpKhachHang.Controls.OfType<KhachHangControl>().FirstOrDefault(c => c.IsSelected);

            List<DTO.KhachHang_DTO> ketQuaList;

            // Kiểm tra nếu có khách hàng được chọn để xuất thông tin của khách hàng đó
            if (selectedControl != null)
            {
                KhachHang_DTO khachHang = selectedControl.GetKhachHang(); // Lấy thông tin khách hàng từ control đã chọn
                if (khachHang != null)
                {
                    // Chuyển đổi đối tượng khách hàng thành DataTable
                    ketQuaList = new List<DTO.KhachHang_DTO> { khachHang };
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                // Không có khách hàng nào được chọn, thực hiện xuất theo điều kiện lọc hiện tại
                string selectedCondition = cbbLoc.SelectedItem.ToString();

                switch (selectedCondition)
                {
                    case "Tất cả":
                        ketQuaList = bus.GetAllKhachHang(); // Lấy toàn bộ khách hàng
                        break;
                    case "Dưới 50 điểm":
                        ketQuaList = bus.GetAllKhachHang().Where(kh => kh.DiemTichLuy < 50).ToList();
                        break;
                    case "Từ 50 đến dưới 100 điểm":
                        ketQuaList = bus.GetAllKhachHang().Where(kh => kh.DiemTichLuy >= 50 && kh.DiemTichLuy < 100).ToList();
                        break;
                    case "Từ 100 đến dưới 150 điểm":
                        ketQuaList = bus.GetAllKhachHang().Where(kh => kh.DiemTichLuy >= 100 && kh.DiemTichLuy < 150).ToList();
                        break;
                    case "Bằng 150 điểm":
                        ketQuaList = bus.GetAllKhachHang().Where(kh => kh.DiemTichLuy == 150).ToList();
                        break;
                    default:
                        MessageBox.Show("Không có điều kiện lọc phù hợp.");
                        return;
                }
            }

            // Kiểm tra nếu danh sách trống
            if (ketQuaList == null || ketQuaList.Count == 0)
            {
                MessageBox.Show("Không có khách hàng nào phù hợp để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Chuyển đổi danh sách khách hàng sang DataTable
            DataTable ketQua = ConvertListToDataTable(ketQuaList);

            // Hiển thị form báo cáo với dữ liệu đã chọn hoặc đã lọc
            FormReport formKhachHang = new FormReport(FormReport.LoaiBaoCao.KhachHang, ketQua);
            formKhachHang.Show();
        }
    }
}
