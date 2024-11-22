using BUS;
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
    public partial class KhachHangControl : UserControl
    {
        public KhachHang_DTO khachHang { get; private set; }
        private int clickCount = 0; // Biến đếm số lần nhấp
        private static KhachHangControl selectedControl; // Đối tượng đã chọn

        public bool IsSelected { get; set; }

        private KhachHang_BUS bus = new KhachHang_BUS();

        public KhachHangControl()
        {
            InitializeComponent();
            RegisterClickEvent(this);
            RegisterDoubleClickEvent(this);  // Đăng ký sự kiện click đúp
        }

        public KhachHang_DTO GetKhachHang()
        {
            return khachHang;
        }

        // Hàm đăng ký sự kiện click cho tất cả các thành phần con
        private void RegisterClickEvent(Control control)
        {
            control.MouseDown += KhachHangControl_MouseDown; // Đăng ký sự kiện nhấn chuột

            foreach (Control childControl in control.Controls)
            {
                RegisterClickEvent(childControl);
            }
        }

        // Hàm đăng ký sự kiện click đúp cho tất cả các thành phần con
        private void RegisterDoubleClickEvent(Control control)
        {
            control.DoubleClick += KhachHangControl_DoubleClick; // Đăng ký sự kiện click đúp

            foreach (Control childControl in control.Controls)
            {
                RegisterDoubleClickEvent(childControl);
            }
        }

        public void UpdateData(KhachHang_DTO khachHang)
        {
            if (khachHang == null)
            {
                throw new ArgumentNullException(nameof(khachHang), "Dữ liệu khách hàng không được null");
            }

            this.khachHang = khachHang;
            lblMaKH.Text = khachHang.MaKhachHang;
            lblTen.Text = khachHang.TenKhachHang;
            lblDiemTL.Text = khachHang.DiemTichLuy.ToString();

            Invalidate(); // Làm mới control để cập nhật viền khi điểm thay đổi
        }

        public string MaKH
        {
            get { return lblMaKH.Text; }
            set { lblMaKH.Text = value; }
        }

        public string TenKH
        {
            get { return lblTen.Text; }
            set { lblTen.Text = value; }
        }

        public string DiemTL
        {
            get { return lblDiemTL.Text; }
            set { lblDiemTL.Text = value; }
        }

        private void KhachHangControl_DoubleClick(object sender, EventArgs e)
        {
            // Mở form cập nhật khi click đúp
            if (khachHang != null) // Kiểm tra xem khachHang có hợp lệ không
            {
                CapNhatKhachHang capNhatForm = new CapNhatKhachHang(khachHang);
                capNhatForm.ShowDialog(); // Hiển thị form cập nhật khách hàng
            }
        }

        private bool IsDoubleClick()
        {
            return MouseButtons == MouseButtons.Left && Control.MouseButtons == MouseButtons.None;
        }

        private void KhachHangControl_MouseDown(object sender, MouseEventArgs e)
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

        private void KhachHangControl_Paint_1(object sender, PaintEventArgs e)
        {
            Color borderColor = Color.Red; // Màu viền mặc định là đỏ
            int borderWidth = 2; // Độ dày mặc định của viền

            // Cập nhật màu viền và độ dày dựa trên DiemTichLuy
            if (khachHang != null)
            {
                if (khachHang.DiemTichLuy >= 300)
                {
                    borderColor = Color.DarkRed; // Màu viền đặc biệt cho mức cao nhất
                    borderWidth = 4;
                    this.BackColor = Color.Gold; // Đổi nền cho khách hàng cao cấp
                }
                else if (khachHang.DiemTichLuy >= 150)
                {
                    borderColor = Color.OrangeRed;
                    borderWidth = 3;
                }
                else if (khachHang.DiemTichLuy >= 50)
                {
                    borderColor = Color.Tomato;
                    borderWidth = 2;
                }
                else
                {
                    borderColor = Color.Red;
                    borderWidth = 1;
                }
            }

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
