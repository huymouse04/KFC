using BUS;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KFC
{
    public partial class NhanVien : Form
    {

        private NhanVien_DTO nhanVien; // Biến lưu trữ thông tin nhân viên
        private NhanVien_BUS bus = new NhanVien_BUS();

        public NhanVien()
        {
            InitializeComponent();
            txtMaNV.Enabled = true;
        }

        public NhanVien(NhanVien_DTO nhanVien)
        {
            InitializeComponent();
            this.nhanVien = nhanVien;
            txtMaNV.Enabled = false; // Khóa trường mã nhân viên để không thể thay đổi
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
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
                control.UserControlDoubleClicked += (s, e) => HienThiThongTinNhanVien(nhanVien);

                flpNhanVien.Controls.Add(control); // Thêm điều khiển vào FlowLayoutPanel
                flpNhanVien.Refresh();
            }
        }

        private void HienThiThongTinNhanVien(NhanVien_DTO nhanVien)
        {
            if (nhanVien == null) return;

            txtMaNV.Enabled = false;

            txtMaNV.Text = nhanVien.MaNhanVien;
            txtTenNV.Text = nhanVien.TenNhanVien;
            mtbSDT.Text = nhanVien.SoDienThoai;
            dtpNgaySinh.Value = nhanVien.NgaySinh ?? DateTime.Now;
            txtEmail.Text = nhanVien.Email;
            txtDiaChi.Text = nhanVien.DiaChi;
            txtSoGioLam.Text = nhanVien.SoGioLam.ToString();
            cbChucVu.Text = nhanVien.ChucVu;
            rdbNam.Checked = nhanVien.GioiTinh == "Nam";
            rdbNu.Checked = nhanVien.GioiTinh == "Nữ";

            // Load ảnh nếu có
            if (nhanVien.AnhNhanVien != null)
            {
                using (MemoryStream ms = new MemoryStream(nhanVien.AnhNhanVien))
                {
                    pbAnhNV.Image = Image.FromStream(ms);
                    pbAnhNV.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            else
            {
                pbAnhNV.Image = Properties.Resources.logo;
                pbAnhNV.SizeMode = PictureBoxSizeMode.Zoom;
            }

            // Kiểm tra chức vụ và cho phép chỉnh sửa số giờ làm việc
            txtSoGioLam.Enabled = nhanVien.ChucVu.Equals("Tạm Thời", StringComparison.OrdinalIgnoreCase);
        }
    


        private void btnLuongNhanVien_Click(object sender, EventArgs e)
        {
            // Mở form lương
            LuongNhanViens luongForm = new LuongNhanViens();
            luongForm.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu các TextBox trống
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtTenNV.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSoGioLam.Text) || string.IsNullOrWhiteSpace(cbChucVu.Text) ||
                string.IsNullOrWhiteSpace(mtbSDT.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Ngăn không cho tiếp tục thực hiện
            }


            var newNhanVien = new NhanVien_DTO
            {
                MaNhanVien = txtMaNV.Text,
                TenNhanVien = txtTenNV.Text,
                GioiTinh = rdbNam.Checked ? "Nam" : "Nữ",
                NgaySinh = dtpNgaySinh.Value,
                SoDienThoai = mtbSDT.Text,
                Email = txtEmail.Text,
                DiaChi = txtDiaChi.Text,
                ChucVu = cbChucVu.Text,
                SoGioLam = int.Parse(txtSoGioLam.Text),
                AnhNhanVien = nhanVien?.AnhNhanVien // Lưu trữ ảnh đã chọn
            };

            try
            {
                bus.AddNhanVien(newNhanVien);
                LoadData();
                MessageBox.Show("Thêm nhân viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Thêm hộp thoại xác nhận trước khi xóa
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string maNhanVien = txtMaNV.Text;
                    bus.DeleteNhanVien(maNhanVien);
                    MessageBox.Show("Xóa nhân viên thành công!");
                    LoadData(); // Gọi lại LoadData sau khi xóa thành công
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            txtMaNV.Enabled = true;
            ClearInputFields();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text.Trim(); // Lấy giá trị tìm kiếm

            // Gọi phương thức tìm kiếm từ lớp BUS
            var result = bus.SearchNhanVien(searchTerm);

            // Cập nhật FlowLayoutPanel với kết quả tìm kiếm
            flpNhanVien.Controls.Clear();
            // Duyệt qua danh sách nhân viên và thêm vào FlowLayoutPanel
            foreach (var nhanVien in result)
            {
                NhanVienControl control = new NhanVienControl();
                control.UpdateData(nhanVien); // Cập nhật thông tin nhân viên vào control
                control.UserControlDoubleClicked += (s, i) => HienThiThongTinNhanVien(nhanVien);


                flpNhanVien.Controls.Add(control); // Thêm điều khiển vào FlowLayoutPanel
                flpNhanVien.Refresh();
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

        //private void btnXuat_Click(object sender, EventArgs e)
        //{
        //    string tuKhoa = txtTimKiem.Text.Trim();
        //    List<DTO.NhanVien_DTO> ketQuaList;

        //    if (string.IsNullOrEmpty(tuKhoa))
        //    {
        //        ketQuaList = bus.GetAllNhanVien();
        //    }
        //    else
        //    {
        //        ketQuaList = bus.SearchNhanVien(tuKhoa);
        //    }

        //    if (ketQuaList == null || ketQuaList.Count == 0)
        //    {
        //        MessageBox.Show("Không tìm thấy nhân viên nào với từ khóa đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    // Chuyển đổi List<DTO.NhanVien_DTO> sang DataTable
        //    DataTable ketQua = ConvertListToDataTable(ketQuaList);

        //    FormReport formNhanVien = new FormReport(FormReport.LoaiBaoCao.NhanVien, ketQua);
        //    formNhanVien.Show();
        //}

        private void txtSoGioLam_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra số giờ làm
            if (int.TryParse(txtSoGioLam.Text, out int soGioLam))
            {
                if (soGioLam < 50)
                {
                    // Đặt chức vụ là "Tạm thời" và khóa ComboBox chức vụ
                    cbChucVu.Text = "Tạm thời";
                    cbChucVu.Enabled = false; // Khóa ComboBox chức vụ
                }
                else
                {
                    // Mở khóa ComboBox chức vụ nếu số giờ làm từ 50 trở lên
                    cbChucVu.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số giờ làm hợp lệ.");
            }
        }

        // Hàm này để nhận dữ liệu nhân viên từ NhanVienControl  
        private void SetNhanVienData(NhanVien_DTO nhanVien)
        {
            if (nhanVien != null)
            {
                txtTenNV.Text = nhanVien.TenNhanVien;
                cbChucVu.Text = nhanVien.ChucVu;
                txtMaNV.Text = nhanVien.MaNhanVien;
                mtbSDT.Text = nhanVien.SoDienThoai;
                txtEmail.Text = nhanVien.Email;
                txtDiaChi.Text = nhanVien.DiaChi;
                txtSoGioLam.Text = nhanVien.SoGioLam.ToString();
                dtpNgaySinh.Value = nhanVien.NgaySinh ?? DateTime.Now; // Nếu ngày sinh chưa được xác định

                // Kiểm tra và hiển thị ảnh nhân viên nếu có
                if (nhanVien.AnhNhanVien != null && nhanVien.AnhNhanVien.Length > 0)
                {
                    try
                    {
                        // Chuyển đổi byte[] thành Image
                        using (MemoryStream ms = new MemoryStream(nhanVien.AnhNhanVien))
                        {
                            pbAnhNV.Image = Image.FromStream(ms);
                            pbAnhNV.SizeMode = PictureBoxSizeMode.Zoom; // Thay đổi chế độ hiển thị hình ảnh
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể hiển thị ảnh: " + ex.Message);
                        pbAnhNV.Image = Properties.Resources.logo; // Ảnh mặc định khi không thể load ảnh
                        pbAnhNV.SizeMode = PictureBoxSizeMode.Zoom; // Thay đổi chế độ hiển thị hình ảnh
                    }
                }
                else
                {
                    pbAnhNV.Image = Properties.Resources.logo; // Ảnh mặc định khi không có ảnh
                    pbAnhNV.SizeMode = PictureBoxSizeMode.Zoom; // Thay đổi chế độ hiển thị hình ảnh
                }

                // Kiểm tra giới tính
                rdbNam.Checked = nhanVien.GioiTinh == "Nam";
                rdbNu.Checked = nhanVien.GioiTinh == "Nữ";
            }
            else
            {
                MessageBox.Show("Thông tin nhân viên không có sẵn.");
            }
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\"; // Thư mục khởi đầu
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp"; // Bộ lọc tệp hình ảnh
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Hiển thị đường dẫn tệp ảnh trong TextBox
                    txtPath.Text = openFileDialog.FileName;

                    // Đọc tệp hình ảnh vào byte[]
                    try
                    {
                        pbAnhNV.Image = Image.FromFile(openFileDialog.FileName); // Hiển thị ảnh trong PictureBox
                        pbAnhNV.SizeMode = PictureBoxSizeMode.Zoom; // Thay đổi chế độ hiển thị hình ảnh
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải ảnh: " + ex.Message);
                    }
                }
            }
        }

        // Phương thức chuyển đổi hình ảnh sang mảng byte[]
        private byte[] ConvertImageToByteArray(Image image)
        {
            if (image == null) return null;

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Lưu hình ảnh vào MemoryStream
                return ms.ToArray(); // Chuyển đổi thành mảng byte
            }
        }

        // Phương thức làm sạch các trường nhập liệu
        private void ClearInputFields()
        {
            // Clear all input fields for a new entry
            txtMaNV.Clear();
            txtTenNV.Clear();
            mtbSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtTimKiem.Clear();
            txtSoGioLam.Clear();
            cbChucVu.SelectedIndex = -1;
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            pbAnhNV.Image = Properties.Resources.logo; // Reset to default image
            txtPath.Clear(); // Clear the path TextBox
        }

        private string GetSelectedGender()
        {
            if (rdbNam.Checked)
                return "Nam";
            else if (rdbNu.Checked)
                return "Nữ";

            return null; // Hoặc một giá trị mặc định nếu không chọn
        }
        // Hàm kiểm tra số điện thoại
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.StartsWith("0") && phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
        }

        private void btnCapNhatNV_Click(object sender, EventArgs e)
        {

            // Kiểm tra nếu các TextBox trống
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtTenNV.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSoGioLam.Text) || string.IsNullOrWhiteSpace(cbChucVu.Text) ||
                string.IsNullOrWhiteSpace(mtbSDT.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Ngăn không cho tiếp tục thực hiện
            }

            var updatedNhanVien = new NhanVien_DTO
            {
                MaNhanVien = txtMaNV.Text,
                TenNhanVien = txtTenNV.Text,
                GioiTinh = rdbNam.Checked ? "Nam" : "Nữ",
                NgaySinh = dtpNgaySinh.Value,
                SoDienThoai = mtbSDT.Text,
                Email = txtEmail.Text,
                DiaChi = txtDiaChi.Text,
                ChucVu = cbChucVu.Text,
                SoGioLam = int.Parse(txtSoGioLam.Text),
                AnhNhanVien = ConvertImageToByteArray(pbAnhNV.Image)

            };

            try
            {
                bus.UpdateNhanVien(updatedNhanVien);
               
                MessageBox.Show("Cập nhật nhân viên thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

    }
}
