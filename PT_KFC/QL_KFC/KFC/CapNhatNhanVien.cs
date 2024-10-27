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
using BUS;
using System.IO;

namespace KFC
{
    public partial class CapNhatNhanVien : Form
    {
        private NhanVien_DTO nhanVien; // Biến lưu trữ thông tin nhân viên
        private bool isUpdateMode; // Đánh dấu xem là chế độ cập nhật hay thêm mới
        public CapNhatNhanVien()
        {
            InitializeComponent();
            isUpdateMode = false; // Đánh dấu đây là chế độ thêm mới
            txtMaNV.Enabled = true;
        }

        public CapNhatNhanVien(NhanVien_DTO nhanVien)
        {
            InitializeComponent();
            this.nhanVien = nhanVien;
            isUpdateMode = true; // Đánh dấu đây là chế độ cập nhật
            txtMaNV.Enabled = false; // Khóa trường mã nhân viên để không thể thay đổi

            if (nhanVien != null)
            {
                // Kiểm tra giá trị nhân viên
                Console.WriteLine("Thông tin lương nhận được: " + nhanVien.TenNhanVien);

                SetNhanVienData(nhanVien);
            }
            else
            {
                MessageBox.Show("Thông tin lương không hợp lệ.");
            }
        }

        private NhanVien_BUS bus = new NhanVien_BUS();

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



        public byte[] ConvertImageToByteArray(string imagePath)
        {
            using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    return ms.ToArray();
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
            txtMaNV.Clear();
            txtTenNV.Clear();
            dtpNgaySinh.Value = DateTime.Now; // Đặt lại ngày sinh về ngày hiện tại
            mtbSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            pbAnhNV.Image = null; // Đặt lại hình ảnh
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
                        byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                        // Lưu trữ ảnh byte[] vào đối tượng nhân viên
                        pbAnhNV.Image = Image.FromFile(openFileDialog.FileName); // Hiển thị ảnh trong PictureBox
                        pbAnhNV.SizeMode = PictureBoxSizeMode.Zoom; // Thay đổi chế độ hiển thị hình ảnh
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.Text.Length > 30)
                {
                    MessageBox.Show("Mã nhân viên không được vượt quá 30 ký tự.");
                    return;
                }

                // Kiểm tra độ dài địa chỉ
                if (txtDiaChi.Text.Length > 300)
                {
                    MessageBox.Show("Địa chỉ không được vượt quá 300 ký tự.");
                    return;
                }

                // Kiểm tra tên nhân viên
                if (string.IsNullOrWhiteSpace(txtTenNV.Text) || txtTenNV.Text.Length > 250)
                {
                    MessageBox.Show("Tên nhân viên không được để trống và không quá 250 ký tự.");
                    return;
                }

                // Kiểm tra số điện thoại
                if (!mtbSDT.Text.StartsWith("0") || mtbSDT.Text.Length != 10)
                {
                    MessageBox.Show("Số điện thoại phải bắt đầu bằng số 0 và đủ 10 số.");
                    return;
                }

                // Kiểm tra số giờ làm
                if (int.TryParse(txtSoGioLam.Text, out int soGioLam))
                {
                    if (soGioLam < 0 || soGioLam > 2000000000) // Giả định số giờ làm tối đa là 200
                    {
                        MessageBox.Show("Số giờ làm không hợp lệ. Nó phải nằm trong khoảng từ 0 đến 2000000000.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Số giờ làm phải là một số hợp lệ.");
                    return;
                }

                // Tiến hành lưu thông tin nhân viên
                if (isUpdateMode)
                {
                    // Cập nhật nhân viên
                    UpdateNhanVien();
                }
                else
                {
                    // Thêm mới nhân viên
                    AddNhanVien();
                }

                MessageBox.Show("Lưu nhân viên thành công!");
                this.Close(); // Đóng form sau khi lưu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void UpdateNhanVien()
        {
            // Cập nhật thông tin nhân viên
            nhanVien.TenNhanVien = txtTenNV.Text.Trim();
            nhanVien.GioiTinh = GetSelectedGender();
            nhanVien.NgaySinh = dtpNgaySinh.Value;
            nhanVien.SoDienThoai = mtbSDT.Text.Trim();
            nhanVien.Email = txtEmail.Text.Trim();
            nhanVien.DiaChi = txtDiaChi.Text.Trim();
            nhanVien.SoGioLam = int.Parse(txtSoGioLam.Text);

            // Kiểm tra số giờ làm và chức vụ
            nhanVien.ChucVu = nhanVien.SoGioLam < 50 ? "Tạm thời" : cbChucVu.Text.Trim();

            if (pbAnhNV.Image != null)
            {
                nhanVien.AnhNhanVien = ConvertImageToByteArray(pbAnhNV.Image);
            }

            bus.UpdateNhanVien(nhanVien);
        }

        private void AddNhanVien()
        {
            // Thêm mới nhân viên
            NhanVien_DTO newNhanVien = new NhanVien_DTO
            {
                MaNhanVien = txtMaNV.Text.Trim(),
                TenNhanVien = txtTenNV.Text.Trim(),
                GioiTinh = GetSelectedGender(),
                NgaySinh = dtpNgaySinh.Value,
                SoDienThoai = mtbSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                SoGioLam = int.Parse(txtSoGioLam.Text),
                AnhNhanVien = ConvertImageToByteArray(pbAnhNV.Image)
            };

            // Kiểm tra số giờ làm và chức vụ
            newNhanVien.ChucVu = newNhanVien.SoGioLam < 50 ? "Tạm thời" : cbChucVu.Text.Trim();

            bus.AddNhanVien(newNhanVien);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearInputFields();

        }

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
    }
}
