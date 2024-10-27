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
    public partial class CapNhatNhaCungCap : Form
    {

        // Khai báo sự kiện để gửi dữ liệu nhà cung cấp sau khi thêm/cập nhật thành công
        public event EventHandler<NhaCungCap_DTO> OnNhaCungCapSaved;

        private NhaCungCap_BUS bus = new NhaCungCap_BUS();
        private NhaCungCap_DTO nhaCungCap;
        public CapNhatNhaCungCap(NhaCungCap_DTO nhaCungCap)
        {
            InitializeComponent();
            this.nhaCungCap = nhaCungCap;
            LoadData();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Giải phóng hình ảnh cũ nếu có
                    pbNCC.Image?.Dispose();
                    pbNCC.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void LoadData()
        {
            if (nhaCungCap != null)
            {
                txtMaNCC.Text = nhaCungCap.MaNhaCungCap;
                txtTenNCC.Text = nhaCungCap.TenNhaCungCap;
                txtDiaChi.Text = nhaCungCap.DiaChi;
                txtSDT.Text = nhaCungCap.SoDienThoai;
                txtGhiChu.Text = nhaCungCap.GhiChu;

                // Xử lý hình ảnh
                if (nhaCungCap.AnhNhaCungCap != null && nhaCungCap.AnhNhaCungCap.Length > 0)
                {
                    try
                    {
                        using (var ms = new MemoryStream(nhaCungCap.AnhNhaCungCap))
                        {
                            pbNCC.Image?.Dispose(); // Giải phóng hình ảnh cũ nếu có
                            pbNCC.Image = Image.FromStream(ms);
                            pbNCC.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
                    }
                }
                else
                {
                    SetDefaultImage(); // Có thể giữ lại hoặc loại bỏ
                }
            }
        }

        private void SetDefaultImage()
        {
            pbNCC.Image?.Dispose(); // Giải phóng hình ảnh cũ nếu có
            pbNCC.Image = null; // Có thể để null nếu không cần ảnh mặc định
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường thông tin bắt buộc
                if (string.IsNullOrEmpty(txtMaNCC.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã nhà cung cấp.");
                    return;
                }

                if (string.IsNullOrEmpty(txtTenNCC.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên nhà cung cấp.");
                    return;
                }

                if (string.IsNullOrEmpty(txtSDT.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại.");
                    return;
                }

                // Cập nhật nhà cung cấp
                nhaCungCap.MaNhaCungCap = txtMaNCC.Text;
                nhaCungCap.TenNhaCungCap = txtTenNCC.Text;
                nhaCungCap.DiaChi = txtDiaChi.Text;
                nhaCungCap.SoDienThoai = txtSDT.Text;
                nhaCungCap.GhiChu = txtGhiChu.Text;

                // Xử lý ảnh nếu có chọn
                if (pbNCC.Image != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        pbNCC.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        nhaCungCap.AnhNhaCungCap = ms.ToArray();
                    }
                }

                // Cập nhật nhà cung cấp
                bus.UpdateNhaCungCap(nhaCungCap);
                LoadData();
                MessageBox.Show("Cập nhật nhà cung cấp thành công!");
                OnNhaCungCapSaved?.Invoke(this, nhaCungCap);

                // Tải lại dữ liệu để hiển thị thông tin đã cập nhật
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form mà không lưu thay đổi

        }
    }
}
