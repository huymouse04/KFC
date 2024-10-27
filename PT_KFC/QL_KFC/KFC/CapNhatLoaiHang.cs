using BUS;
using DAO;
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
    public partial class CapNhatLoaiHang : Form
    {
        public event Action DataUpdated;
        private LoaiHang_DTO loaiHang;
        private bool isAdding;
        public string MaLH
        {
            get { return txtMLH.Text; }
            set { txtMLH.Text = value; }
        }

        public string TenLH
        {
            get { return txtTLH.Text; }
            set { txtTLH.Text = value; }
        }
        public CapNhatLoaiHang()
        {
            InitializeComponent();
            isAdding = true;
        }
        public CapNhatLoaiHang(LoaiHang_DTO loaiHang)
        {
            InitializeComponent();
            this.loaiHang = loaiHang;
            LoadData(loaiHang.MaLoaiHang, loaiHang.TenLoaiHang);
            isAdding = false; // Chế độ cập nhật
        }
        public void LoadData(string maLH, string tenLH)
        {
            txtMLH.Text = maLH;
            txtTLH.Text = tenLH;
        }

        private bool ValidateInput()
        {
            // Kiểm tra mã loại hàng
            if (string.IsNullOrWhiteSpace(txtMLH.Text))
            {
                MessageBox.Show("Mã loại hàng không được để trống.");
                return false;
            }

            if (!char.IsLetter(txtMLH.Text[0]))
            {
                MessageBox.Show("Mã loại hàng phải bắt đầu bằng chữ.");
                return false;
            }

            if (txtMLH.Text.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("Mã loại hàng không được chứa kí tự đặc biệt.");
                return false;
            }

            // Kiểm tra tên loại hàng
            if (string.IsNullOrWhiteSpace(txtTLH.Text))
            {
                MessageBox.Show("Tên loại hàng không được để trống.");
                return false;
            }

            if (!char.IsLetter(txtTLH.Text[0]))
            {
                MessageBox.Show("Tên loại hàng phải bắt đầu bằng chữ.");
                return false;
            }

            return true; // Dữ liệu hợp lệ
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) // Kiểm tra dữ liệu nhập
            {
                return; // Dừng nếu không hợp lệ
            }

            var loaiHangBUS = new LoaiHang_BUS();
            var loaiHang = new LoaiHang_DTO
            {
                MaLoaiHang = txtMLH.Text.Trim(),
                TenLoaiHang = txtTLH.Text.Trim()
            };

            if (isAdding) 
            {
                // Gọi phương thức thêm loại hàng
                loaiHangBUS.AddLoaiHang(loaiHang);
                MessageBox.Show("Thêm loại hàng thành công.");
            }
            else // Nếu chế độ cập nhật
            {
                if (loaiHangBUS.UpdateLoaiHang(loaiHang)) // Cập nhật loại hàng
                {
                    MessageBox.Show("Cập nhật loại hàng thành công.");
                }
                else
                {
                    MessageBox.Show("Cập nhật loại hàng không thành công. Vui lòng kiểm tra lại.");
                    return; // Thoát nếu cập nhật không thành công
                }
            }

            DataUpdated?.Invoke(); // Gọi sự kiện nếu có người đăng ký
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Đóng form mà không lưu
            this.Close();
        }
    }
}
