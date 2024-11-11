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
            ToggleDateTimePickers(); // Khóa hoặc mở khóa DateTimePicker khi tạo mới
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

                // Gán giá trị thời gian nếu có
                if (ban.ThoiGianDen.HasValue)
                {
                    dtpkThoiGianDen.Value = ban.ThoiGianDen.Value;
                }

                if (ban.ThoiGianRoi.HasValue)
                {
                    dtpkThoiGianRoi.Value = ban.ThoiGianRoi.Value;
                }
            }
            else
            {
                MessageBox.Show("Thông tin bàn không có sẵn.");
            }
        }

        // Hàm để bật/tắt DateTimePicker dựa trên trạng thái của bàn
        private void ToggleDateTimePickers()
        {
            // Kiểm tra trạng thái bàn
            bool isBanTrong = radBanTrong.Checked;

            // Nếu bàn trống, khóa DateTimePicker
            dtpkThoiGianDen.Enabled = !isBanTrong;
            dtpkThoiGianRoi.Enabled = !isBanTrong;

            // Nếu bàn không trống, bắt buộc phải chọn giờ
            if (!isBanTrong)
            {
                if (dtpkThoiGianDen.Value == DateTime.MinValue || dtpkThoiGianRoi.Value == DateTime.MinValue)
                {
                    MessageBox.Show("Vui lòng chọn thời gian cho bàn này.");
                }
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
            ban.ThoiGianDen = dtpkThoiGianDen.Value; // Lấy thời gian đến
            ban.ThoiGianRoi = dtpkThoiGianRoi.Value; // Lấy thời gian rời

            bus.UpdateBan(ban);
        }

        private void AddBan()
        {
            Ban_DTO newBan = new Ban_DTO
            {
                MaBan = txtMaBan.Text.Trim(),
                TenBan = txtTenBan.Text.Trim(),
                TrangThaiBan = radKhongTrong.Checked,
                ThoiGianDen = dtpkThoiGianDen.Value, // Lấy thời gian đến
                ThoiGianRoi = dtpkThoiGianRoi.Value  // Lấy thời gian rời
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

                if (radKhongTrong.Checked) // Nếu bàn không trống
                {
                    if (dtpkThoiGianDen.Value == DateTime.MinValue || dtpkThoiGianRoi.Value == DateTime.MinValue)
                    {
                        MessageBox.Show("Vui lòng chọn thời gian.");
                        return;
                    }
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

        // Sự kiện thay đổi trạng thái bàn
        private void radKhongTrong_CheckedChanged(object sender, EventArgs e)
        {
            ToggleDateTimePickers(); // Gọi hàm bật/tắt DateTimePickers
        }

        private void radBanTrong_CheckedChanged(object sender, EventArgs e)
        {
            ToggleDateTimePickers(); // Gọi hàm bật/tắt DateTimePickers
        }
    }
}
