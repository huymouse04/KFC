using BUS;
using DTO;
using KFC.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KFC
{
    public partial class LoaiHangControl : UserControl
    {
        public LoaiHang_DTO loaiHang { get; private set; }
        private static LoaiHangControl selectedControl; // Đối tượng đã chọn

        public bool IsSelected { get; set; }

        private LoaiHang_BUS bus = new LoaiHang_BUS();

        public LoaiHangControl()
        {
            InitializeComponent();
            RegisterClickEvent(this);
            RegisterDoubleClickEvent(this); // Đăng ký sự kiện click đúp
        }

        public LoaiHang_DTO GetLoaiHang()
        {
            return loaiHang;
        }

        // Hàm đăng ký sự kiện click cho tất cả các thành phần con
        private void RegisterClickEvent(Control control)
        {
            control.MouseDown += LoaiHangControl_MouseDown;

            foreach (Control childControl in control.Controls)
            {
                RegisterClickEvent(childControl);
            }
        }

        // Hàm đăng ký sự kiện click đúp cho tất cả các thành phần con
        private void RegisterDoubleClickEvent(Control control)
        {
            control.DoubleClick += LoaiHangControl_DoubleClick;

            foreach (Control childControl in control.Controls)
            {
                RegisterDoubleClickEvent(childControl);
            }
        }

        public void UpdateData(LoaiHang_DTO loaiHang)
        {
            if (loaiHang == null)
            {
                throw new ArgumentNullException(nameof(loaiHang), "Dữ liệu loại hàng không được null");
            }

            this.loaiHang = loaiHang; // Gán dữ liệu loại hàng  
            MaLH = loaiHang.MaLoaiHang; // Gán mã loại hàng  
            lblMaLoaiHang.Text = loaiHang.MaLoaiHang; // Hiển thị mã loại hàng  
            lblTenLoaiHang.Text = loaiHang.TenLoaiHang; // Hiển thị tên loại hàng  
        }
        public string MaLH { get; set; }

        public string TenLH
        {
            get { return lblTenLoaiHang.Text; }
            set { lblTenLoaiHang.Text = value; }
        }

        private void LoaiHangControl_DoubleClick(object sender, EventArgs e)
        {
            // Mở form cập nhật khi click đúp
            if (loaiHang != null) // Kiểm tra xem loaiHang có hợp lệ không
            {
                CapNhatLoaiHang capNhatForm = new CapNhatLoaiHang(loaiHang);
                capNhatForm.ShowDialog(); // Hiển thị form cập nhật loại hàng
            }
        }

        private void LoaiHangControl_MouseDown(object sender, MouseEventArgs e)
        {
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
