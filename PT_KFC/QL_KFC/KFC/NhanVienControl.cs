using BUS;
using DTO;
using KFC.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KFC
{
    public partial class NhanVienControl : UserControl
    {

        public NhanVien_DTO nhanVien { get; private set; }
        private int clickCount = 0; // Biến đếm số lần nhấp
        private static NhanVienControl selectedControl; // Đối tượng đã chọn

        public bool IsSelected { get; set; }

        private NhanVien_BUS bus = new NhanVien_BUS();

        public NhanVienControl()
        {
            InitializeComponent();
            RegisterClickEvent(this);
            RegisterDoubleClickEvent(this);  // Đăng ký sự kiện click đúp

        }

        public NhanVien_DTO GetNhanVien()
        {
            return nhanVien;
        }


      
        // Hàm đăng ký sự kiện click cho tất cả các thành phần con
        private void RegisterClickEvent(Control control)
        {
            // Đăng ký sự kiện nhấn chuột cho chính control
            control.MouseDown += NhanVienControl_MouseDown;

            // Đăng ký sự kiện click cho tất cả các thành phần con
            foreach (Control childControl in control.Controls)
            {
                RegisterClickEvent(childControl);
            }
        }

        // Hàm đăng ký sự kiện click đúp cho tất cả các thành phần con
        private void RegisterDoubleClickEvent(Control control)
        {
            control.DoubleClick += NhanVienControl_DoubleClick; // Đăng ký sự kiện click đúp

            foreach (Control childControl in control.Controls)
            {
                RegisterDoubleClickEvent(childControl); // Đăng ký sự kiện cho điều khiển con
            }
        }

        public void UpdateData(NhanVien_DTO nhanVien)
        {
            if (nhanVien == null)
            {
                throw new ArgumentNullException(nameof(nhanVien), "Dữ liệu nhân viên không được null");
            }

            this.nhanVien = nhanVien; // Gán dữ liệu nhân viên để sử dụng trong các sự kiện
            lblTenNV.Text = nhanVien.TenNhanVien; // Hiển thị tên nhân viên  
            lblChucVu.Text = nhanVien.ChucVu; // Hiển thị chức vụ  

            if (nhanVien.AnhNhanVien != null && nhanVien.AnhNhanVien.Length > 0)
            {
                try
                {
                    // Chuyển đổi byte[] thành Image
                    using (var ms = new MemoryStream(nhanVien.AnhNhanVien))
                    {
                        pbNhanVien.Image = Image.FromStream(ms);
                        pbNhanVien.SizeMode = PictureBoxSizeMode.Zoom; // Thay đổi chế độ hiển thị hình ảnh
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
                    pbNhanVien.Image = Resources.logo; // Hình ảnh mặc định  
                }
            }
            else
            {
                pbNhanVien.Image = Resources.logo; // Hình ảnh mặc định  
            }
        }

        public string MaNV { get; set; }

        public string TenNV
        {
            get { return lblTenNV.Text; }
            set { lblTenNV.Text = value; }
        }

        public string ChucVu
        {
            get { return lblChucVu.Text; }
            set { lblChucVu.Text = value; }
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

        private void NhanVienControl_DoubleClick(object sender, EventArgs e)
        {
            // Mở form cập nhật khi click đúp
            if (nhanVien != null) // Kiểm tra xem nhanVien có hợp lệ không
            {
                CapNhatNhanVien capNhatForm = new CapNhatNhanVien(nhanVien);
                capNhatForm.ShowDialog(); // Hiển thị form cập nhật nhân viên
            }
        }

        private bool IsDoubleClick()
        {
            return MouseButtons == MouseButtons.Left && Control.MouseButtons == MouseButtons.None;
        }

        private void NhanVienControl_MouseDown(object sender, MouseEventArgs e)
        {
            // Xử lý sự kiện nhấn chuột
            if (e.Button == MouseButtons.Left)
            {
                if (!Control.ModifierKeys.HasFlag(Keys.Control)) // Kiểm tra phím Ctrl có được giữ không
                {
                    // Đặt màu nền cho đối tượng này
                    if (selectedControl != null && selectedControl != this)
                    {
                        selectedControl.IsSelected = false; // Đối tượng trước không được chọn
                        selectedControl.BackColor = Color.Transparent; // Đặt lại màu nền cho đối tượng trước
                    }

                    selectedControl = this; // Gán đối tượng hiện tại thành đối tượng đã chọn
                    IsSelected = true; // Đánh dấu là đã chọn
                    this.BackColor = Color.LightBlue; // Đổi màu nền
                }
                else
                {
                    // Nếu Ctrl được giữ, chỉ đổi màu nền
                    IsSelected = !IsSelected; // Chuyển đổi trạng thái chọn
                    this.BackColor = IsSelected ? Color.LightBlue : Color.Transparent;
                }
            }
        }
    }
}
