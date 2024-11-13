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
    public partial class CapNhatKhachHang : Form
    {
        private KhachHang_DTO khachHang; // Biến lưu trữ thông tin khách hàng
        private bool isUpdateMode; // Đánh dấu xem là chế độ cập nhật hay thêm mới
        private KhachHang_BUS bus = new KhachHang_BUS(); // Lớp quản lý khách hàng

        public CapNhatKhachHang()
        {
            InitializeComponent();
            isUpdateMode = false; // Đánh dấu đây là chế độ thêm mới
            txtMaKhachHang.Enabled = true; // Cho phép nhập mã khách hàng
        }

        public CapNhatKhachHang(KhachHang_DTO khachHang)
        {
            InitializeComponent();
            this.khachHang = khachHang;
            isUpdateMode = true; // Đánh dấu đây là chế độ cập nhật
            txtMaKhachHang.Enabled = false; // Khóa trường mã khách hàng để không thể thay đổi

            if (khachHang != null)
            {
                SetKhachHangData(khachHang);
            }
            else
            {
                MessageBox.Show("Thông tin khách hàng không hợp lệ.");
            }
        }

        // Hàm này để nhận dữ liệu khách hàng từ CapNhatKhachHangControl  
        private void SetKhachHangData(KhachHang_DTO khachHang)
        {
            if (khachHang != null)
            {
                txtMaKhachHang.Text = khachHang.MaKhachHang;
                txtTenKhachHang.Text = khachHang.TenKhachHang;
                txtSDT.Text = khachHang.SoDienThoai;
                txtDiem.Text = khachHang.DiemTichLuy.ToString();
            }
            else
            {
                MessageBox.Show("Thông tin khách hàng không có sẵn.");
            }
        }

        // Phương thức làm sạch các trường nhập liệu
        private void ClearInputFields()
        {
            txtMaKhachHang.Clear();
            txtTenKhachHang.Clear();
            txtSDT.Clear();
            txtDiem.Clear();
        }

        private void UpdateKhachHang()
        {
            khachHang.TenKhachHang = txtTenKhachHang.Text.Trim();
            khachHang.SoDienThoai = txtSDT.Text.Trim();
            khachHang.DiemTichLuy = int.Parse(txtDiem.Text.Trim());

            bus.UpdateKhachHang(khachHang);
        }

        private void AddKhachHang()
        {
            KhachHang_DTO newKhachHang = new KhachHang_DTO
            {
                MaKhachHang = txtMaKhachHang.Text.Trim(),
                TenKhachHang = txtTenKhachHang.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                DiemTichLuy = int.Parse(txtDiem.Text.Trim())
            };

            bus.AddKhachHang(newKhachHang);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKhachHang.Text.Length > 10)
                {
                    MessageBox.Show("Mã khách hàng không được vượt quá 10 ký tự.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text) || txtTenKhachHang.Text.Length > 100)
                {
                    MessageBox.Show("Tên khách hàng không được để trống và không quá 100 ký tự.");
                    return;
                }

                if (!txtSDT.Text.StartsWith("0") || txtSDT.Text.Length != 10)
                {
                    MessageBox.Show("Số điện thoại phải bắt đầu bằng số 0 và đủ 10 số.");
                    return;
                }

                if (isUpdateMode)
                {
                    UpdateKhachHang();
                }
                else
                {
                    AddKhachHang();
                }

                MessageBox.Show("Lưu khách hàng thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn hủy và đóng cửa sổ này?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng form hiện tại
            }
        }
    }
}
