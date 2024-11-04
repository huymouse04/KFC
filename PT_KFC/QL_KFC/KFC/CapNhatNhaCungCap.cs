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
    public partial class CapNhatNhaCungCap : Form
    {
        private NhaCungCap_DTO nhaCungCap; // Biến lưu trữ thông tin nhà cung cấp
        private bool isUpdateMode; // Đánh dấu xem là chế độ cập nhật hay thêm mới
        private NhaCungCap_BUS bus = new NhaCungCap_BUS();

        public CapNhatNhaCungCap()
        {
            InitializeComponent();
            isUpdateMode = false; // Đánh dấu đây là chế độ thêm mới
            txtMaNCC.Enabled = true;
        }

        public CapNhatNhaCungCap(NhaCungCap_DTO nhaCungCap)
        {
            InitializeComponent();
            this.nhaCungCap = nhaCungCap;
            isUpdateMode = true; // Đánh dấu đây là chế độ cập nhật
            txtMaNCC.Enabled = false; // Khóa trường mã nhà cung cấp để không thể thay đổi

            if (nhaCungCap != null)
            {
                SetNhaCungCapData(nhaCungCap);
            }
            else
            {
                MessageBox.Show("Thông tin nhà cung cấp không hợp lệ.");
            }
        }

        // Hàm này để nhận dữ liệu nhà cung cấp từ NhaCungCapControl  
        private void SetNhaCungCapData(NhaCungCap_DTO nhaCungCap)
        {
            if (nhaCungCap != null)
            {
                txtTenNCC.Text = nhaCungCap.TenNhaCungCap;
                txtMaNCC.Text = nhaCungCap.MaNhaCungCap;
                txtDiaChi.Text = nhaCungCap.DiaChi;
                mtbSDT.Text = nhaCungCap.SoDienThoai;
                txtGhiChu.Text = nhaCungCap.GhiChu;

                // Kiểm tra và hiển thị ảnh nhà cung cấp nếu có
                if (nhaCungCap.AnhNhaCungCap != null && nhaCungCap.AnhNhaCungCap.Length > 0)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(nhaCungCap.AnhNhaCungCap))
                        {
                            pbAnhNCC.Image = Image.FromStream(ms);
                            pbAnhNCC.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể hiển thị ảnh: " + ex.Message);
                        pbAnhNCC.Image = Properties.Resources.logo;
                        pbAnhNCC.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                else
                {
                    pbAnhNCC.Image = Properties.Resources.logo;
                    pbAnhNCC.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            else
            {
                MessageBox.Show("Thông tin nhà cung cấp không có sẵn.");
            }
        }

        // Phương thức chuyển đổi hình ảnh sang mảng byte[]
        private byte[] ConvertImageToByteArray(Image image)
        {
            if (image == null) return null;

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        // Phương thức làm sạch các trường nhập liệu
        private void ClearInputFields()
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            mtbSDT.Clear();
            txtGhiChu.Clear();
            pbAnhNCC.Image = null;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = openFileDialog.FileName;
                    try
                    {
                        byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                        pbAnhNCC.Image = Image.FromFile(openFileDialog.FileName);
                        pbAnhNCC.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message);
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNCC.Text.Length > 10)
                {
                    MessageBox.Show("Mã nhà cung cấp không được vượt quá 10 ký tự.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTenNCC.Text) || txtTenNCC.Text.Length > 100)
                {
                    MessageBox.Show("Tên nhà cung cấp không được để trống và không quá 100 ký tự.");
                    return;
                }

                if (!mtbSDT.Text.StartsWith("0") || mtbSDT.Text.Length != 10)
                {
                    MessageBox.Show("Số điện thoại phải bắt đầu bằng số 0 và đủ 10 số.");
                    return;
                }

                if (txtDiaChi.Text.Length > 200)
                {
                    MessageBox.Show("Địa chỉ không được vượt quá 200 ký tự.");
                    return;
                }

                if (isUpdateMode)
                {
                    UpdateNhaCungCap();
                }
                else
                {
                    AddNhaCungCap();
                }

                MessageBox.Show("Lưu nhà cung cấp thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void UpdateNhaCungCap()
        {
            nhaCungCap.TenNhaCungCap = txtTenNCC.Text.Trim();
            nhaCungCap.DiaChi = txtDiaChi.Text.Trim();
            nhaCungCap.SoDienThoai = mtbSDT.Text.Trim();
            nhaCungCap.GhiChu = txtGhiChu.Text.Trim();

            if (pbAnhNCC.Image != null)
            {
                nhaCungCap.AnhNhaCungCap = ConvertImageToByteArray(pbAnhNCC.Image);
            }

            bus.UpdateNhaCungCap(nhaCungCap);
        }

        private void AddNhaCungCap()
        {
            NhaCungCap_DTO newNhaCungCap = new NhaCungCap_DTO
            {
                MaNhaCungCap = txtMaNCC.Text.Trim(),
                TenNhaCungCap = txtTenNCC.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                SoDienThoai = mtbSDT.Text.Trim(),
                GhiChu = txtGhiChu.Text.Trim(),
                AnhNhaCungCap = ConvertImageToByteArray(pbAnhNCC.Image)
            };

            bus.AddNhaCungCap(newNhaCungCap);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn hủy và đóng cửa sổ này?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng form hiện tại
            }
        }
    }
}
