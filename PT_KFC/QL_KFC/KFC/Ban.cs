using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace KFC
{
    public partial class Ban : Form
    {
        private Ban_BUS bus = new Ban_BUS(); // Khởi tạo lớp BUS cho bàn

        public Ban()
        {
            InitializeComponent();
        }

        private void Ban_Load(object sender, EventArgs e)
        {

            LoadData();
            LoadComboBoxLoc();
        }

        private void LoadData()
        {
            // Xóa tất cả các điều khiển hiện có trong flpBan
            flpBan.Controls.Clear();

            // Lấy danh sách bàn từ lớp BUS
            var banList = bus.GetAllBan();

            // Duyệt qua danh sách bàn và thêm vào flpBan
            foreach (var ban in banList)
            {
                BanControl control = new BanControl();
                control.UpdateData(ban); // Cập nhật thông tin bàn vào control
                flpBan.Controls.Add(control); // Thêm điều khiển vào flpBan
            }
        }

        private void OpenCapNhatBan(Ban_DTO ban)
        {
            if (ban == null)
            {
                MessageBox.Show("Thông tin bàn không hợp lệ.");
                return;
            }

            // Lấy thông tin bàn đầy đủ từ database
            Ban_DTO banDayDu = bus.GetBanByMa(ban.MaBan);

            if (banDayDu == null)
            {
                MessageBox.Show("Không tìm thấy thông tin bàn với mã: " + ban.MaBan);
                return;
            }

            using (CapNhapBan formCapNhat = new CapNhapBan(banDayDu))
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
            using (CapNhapBan capNhatForm = new CapNhapBan())
            {
                if (capNhatForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(); // Cập nhật lại dữ liệu sau khi thêm bàn mới
                }
            }
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có bàn nào được chọn không
            var selectedControl = flpBan.Controls.OfType<BanControl>().FirstOrDefault(c => c.IsSelected);

            if (selectedControl != null)
            {
                Ban_DTO ban = selectedControl.GetBan(); // Lấy thông tin bàn từ control đã chọn

                if (ban != null)
                {
                    string maBan = ban.MaBan; // Lấy mã bàn

                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bàn này không?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            bus.DeleteBan(maBan);
                            MessageBox.Show("Xóa bàn thành công!");
                            LoadData(); // Cập nhật lại flpBan sau khi xóa
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa bàn: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bàn để xóa.");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = tbtTiemKiem.Text.Trim(); // Lấy giá trị tìm kiếm

            var result = bus.SearchBan(searchTerm);

            flpBan.Controls.Clear();
            foreach (var ban in result)
            {
                BanControl control = new BanControl();
                control.UpdateData(ban); // Cập nhật thông tin bàn vào control
                flpBan.Controls.Add(control);
            }

            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy bàn nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

            LoadData();
            tbtTiemKiem.Clear();
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
            cbbLoc.Items.Add("Tất cả");
            cbbLoc.Items.Add("Trống");
            cbbLoc.Items.Add("Không Trống");

            cbbLoc.SelectedIndex = 0;  // Chọn mặc định là "Tất cả"
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            // Lấy điều kiện lọc từ ComboBox
            string selectedCondition = cbbLoc.SelectedItem.ToString();

            Ban_BUS bus = new Ban_BUS();
            List<Ban_DTO> result = new List<Ban_DTO>();

            // Lọc theo trạng thái bàn
            switch (selectedCondition)
            {
                case "Tất cả":
                    result = bus.GetAllBan(); // Lấy tất cả bàn
                    break;
                case "Trống":
                    result = bus.GetAllBan().Where(b => b.TrangThaiBan == false).ToList(); 
                    break;
                case "Không Trống":
                    result = bus.GetAllBan().Where(b => b.TrangThaiBan == true).ToList(); 
                    break;
                default:
                    MessageBox.Show("Không có điều kiện lọc phù hợp.");
                    return;
            }

            // Cập nhật lại danh sách bàn hiển thị
            flpBan.Controls.Clear(); // Xóa các điều khiển cũ

            foreach (var ban in result)
            {
                BanControl control = new BanControl();
                control.UpdateData(ban); // Cập nhật thông tin bàn vào control
                flpBan.Controls.Add(control); // Thêm control vào panel hiển thị bàn
            }

            // Kiểm tra nếu không có kết quả lọc
            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy bàn với điều kiện lọc đã chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateBanStatusAfterTimeExpired(Ban_DTO ban)
        {
            // Kiểm tra nếu bàn đã hết thời gian và cần đặt lại trạng thái
            if (ban.ThoiGianRoi <= DateTime.Now)
            {
                bus.UpdateBanStatusToEmpty(ban.MaBan); // Cập nhật trạng thái bàn
            }
        }
    }
}
