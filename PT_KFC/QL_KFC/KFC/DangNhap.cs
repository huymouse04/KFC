using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace KFC
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();

            txtTaiKhoan.TextChanged += txtTaiKhoan_TextChanged;
            txtMatKhau.TextChanged += txtMatKhau_TextChanged;
        }


        private bool IsValidUser(string tk, string mk)
        {
            // Kiểm tra nếu chọn radio Quản lý  
            if (rdoQuanLy.Checked)
            {
                // Kiểm tra tài khoản và mật khẩu cho quản lý  
                return tk == "admin" && mk == "admin"; // Thay đổi tùy theo yêu cầu  
            }
            // Kiểm tra nếu chọn radio Nhân viên  
            else if (rdoNhanVien.Checked)
            {
                // Kiểm tra tài khoản và mật khẩu cho nhân viên  
                return tk == "nv" && mk == "nv"; // Thay đổi tùy theo yêu cầu  
            }
            // Nếu không chọn radio nào  
            return false;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tk = txtTaiKhoan.Text; // Tên tài khoản  
            string mk = txtMatKhau.Text; // Mật khẩu  
            bool hasError = false;

            // Xóa các lỗi hiện tại trước khi kiểm tra
            errorProvider1.SetError(txtTaiKhoan, string.Empty);
            errorProvider1.SetError(txtMatKhau, string.Empty);
            errorProvider1.SetError(rdoQuanLy, string.Empty);
            errorProvider1.SetError(rdoNhanVien, string.Empty);

            // Kiểm tra tài khoản có được nhập chưa
            if (string.IsNullOrWhiteSpace(tk))
            {
                errorProvider1.SetError(txtTaiKhoan, "Vui lòng nhập tên tài khoản");
                hasError = true;
            }

            // Kiểm tra mật khẩu có được nhập chưa
            if (string.IsNullOrWhiteSpace(mk))
            {
                errorProvider1.SetError(txtMatKhau, "Vui lòng nhập mật khẩu");
                hasError = true;
            }

            // Kiểm tra xem có chọn vai trò hay chưa
            if (!rdoQuanLy.Checked && !rdoNhanVien.Checked)
            {
                errorProvider1.SetError(rdoQuanLy, "Vui lòng chọn vai trò");
                errorProvider1.SetError(rdoNhanVien, "Vui lòng chọn vai trò");
                hasError = true;
            }

            // Nếu có lỗi thì không thực hiện tiếp tục
            if (hasError)
            {
                return;
            }

            // Nếu không có lỗi, kiểm tra tài khoản và mật khẩu
            if (IsValidUser(tk, mk))
            {
                this.Hide(); // Ẩn form đăng nhập
                Main mainForm = new Main(); // Tạo form chính  

                // Kiểm tra quyền và bật tắt các nút trên form chính
                if (rdoQuanLy.Checked)
                {
                    mainForm.SetButtonState(true); // Kích hoạt tất cả các nút
                }
                else if (rdoNhanVien.Checked)
                {
                    mainForm.SetButtonState(false); // Hạn chế một số nút
                }

                mainForm.Show(); // Hiển thị form chính  
            }
            else
            {
                // Kiểm tra lỗi cho tài khoản và mật khẩu
                if (tk != "admin" && tk != "nv") // Sai tài khoản
                {
                    errorProvider1.SetError(txtTaiKhoan, "Tài khoản không đúng");
                }
                if (mk != "admin" && mk != "nv") // Sai mật khẩu
                {
                    errorProvider1.SetError(txtMatKhau, "Mật khẩu không đúng");
                }
            }
        }
    

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                errorProvider1.SetError(txtTaiKhoan, string.Empty);
            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                errorProvider1.SetError(txtMatKhau, string.Empty);
            }
        }
    }
}
