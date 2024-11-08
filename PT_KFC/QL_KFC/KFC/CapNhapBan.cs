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
    public partial class CapNhapBan : Form
    {
        private Ban_DTO ban; // Biến lưu trữ thông tin bàn
        private bool isUpdateMode; // Đánh dấu xem là chế độ cập nhật hay thêm mới
        private Ban_BUS bus = new Ban_BUS(); // Lớp quản lý bàn

        public CapNhapBan()
        {
            InitializeComponent();
            isUpdateMode = false; // Đánh dấu đây là chế độ thêm mới
            txtMaBan.Enabled = true; // Cho phép nhập mã bàn
        }

        public CapNhapBan(Ban_DTO ban)
        {
            InitializeComponent();
            this.ban = ban;
            isUpdateMode = true; // Đánh dấu đây là chế độ cập nhật
            txtMaBan.Enabled = false; // Khóa trường mã bàn để không thể thay đổi

            if (ban != null)
            {
                SetBanData(ban);
            }
            else
            {
                MessageBox.Show("Thông tin bàn không hợp lệ.");
            }
        }

        // Hàm này để nhận dữ liệu bàn từ CapNhatBanControl  
        private void SetBanData(Ban_DTO ban)
        {
            if (ban != null)
            {
                txtMaBan.Text = ban.MaBan;
                txtTenBan.Text = ban.TenBan;
                radKhongTrong.Checked = ban.TrangThaiBan;
                radBanTrong.Checked = !ban.TrangThaiBan;
            }
            else
            {
                MessageBox.Show("Thông tin bàn không có sẵn.");
            }
        }

        // Phương thức làm sạch các trường nhập liệu
        private void ClearInputFields()
        {
            txtMaBan.Clear();
            txtTenBan.Clear();
            radKhongTrong.Checked = true;
        }
        
        private void UpdateBan()
        {
            ban.TenBan = txtTenBan.Text.Trim();
            ban.TrangThaiBan = radKhongTrong.Checked;

            bus.UpdateBan(ban);
        }

        private void AddBan()
        {
            Ban_DTO newBan = new Ban_DTO
            {
                MaBan = txtMaBan.Text.Trim(),
                TenBan = txtTenBan.Text.Trim(),
                TrangThaiBan = radKhongTrong.Checked
            };

            bus.AddBan(newBan);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaBan.Text.Length > 10)
                {
                    MessageBox.Show("Mã bàn không được vượt quá 10 ký tự.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTenBan.Text) || txtTenBan.Text.Length > 100)
                {
                    MessageBox.Show("Tên bàn không được để trống và không quá 100 ký tự.");
                    return;
                }

                if (isUpdateMode)
                {
                    UpdateBan();
                }
                else
                {
                    AddBan();
                }

                MessageBox.Show("Lưu bàn thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
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
