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
    public partial class NhaCungCapControl : UserControl
    {
        public NhaCungCap_DTO nhaCungCap { get; private set; }
        private int clickCount = 0; // Biến đếm số lần nhấp
        private static NhaCungCapControl selectedControl; // Đối tượng đã chọn

        public bool IsSelected { get; set; }

        private NhaCungCap_BUS bus = new NhaCungCap_BUS();

        public NhaCungCapControl()
        {
            InitializeComponent();
            RegisterClickEvent(this);
            RegisterDoubleClickEvent(this);  // Đăng ký sự kiện click đúp
        }

        public NhaCungCap_DTO GetNhaCungCap()
        {
            return nhaCungCap;
        }

        // Hàm đăng ký sự kiện click cho tất cả các thành phần con
        private void RegisterClickEvent(Control control)
        {
            control.MouseDown += NhaCungCapControl_MouseDown; // Đăng ký sự kiện nhấn chuột

            foreach (Control childControl in control.Controls)
            {
                RegisterClickEvent(childControl);
            }
        }

        // Hàm đăng ký sự kiện click đúp cho tất cả các thành phần con
        private void RegisterDoubleClickEvent(Control control)
        {
            control.DoubleClick += NhaCungCapControl_DoubleClick; // Đăng ký sự kiện click đúp

            foreach (Control childControl in control.Controls)
            {
                RegisterDoubleClickEvent(childControl);
            }
        }

        public void UpdateData(NhaCungCap_DTO nhaCungCap)
        {
            if (nhaCungCap == null)
            {
                throw new ArgumentNullException(nameof(nhaCungCap), "Dữ liệu nhà cung cấp không được null");
            }

            this.nhaCungCap = nhaCungCap; // Gán dữ liệu nhà cung cấp để sử dụng trong các sự kiện
            lblTenNCC.Text = nhaCungCap.TenNhaCungCap; // Hiển thị tên nhà cung cấp  
            lblSoDienThoai.Text = nhaCungCap.SoDienThoai; // Hiển thị số điện thoại

            if (nhaCungCap.AnhNhaCungCap != null && nhaCungCap.AnhNhaCungCap.Length > 0)
            {
                try
                {
                    // Chuyển đổi byte[] thành Image
                    using (var ms = new MemoryStream(nhaCungCap.AnhNhaCungCap))
                    {
                        pbNhaCungCap.Image = Image.FromStream(ms);
                        pbNhaCungCap.SizeMode = PictureBoxSizeMode.Zoom; // Thay đổi chế độ hiển thị hình ảnh
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
                    pbNhaCungCap.Image = Resources.logo; // Hình ảnh mặc định  
                }
            }
            else
            {
                pbNhaCungCap.Image = Resources.logo; // Hình ảnh mặc định  
            }
        }

        public string MaNCC { get; set; }

        public string TenNCC
        {
            get { return lblTenNCC.Text; }
            set { lblTenNCC.Text = value; }
        }

        public string SoDienThoai
        {
            get { return lblSoDienThoai.Text; }
            set { lblSoDienThoai.Text = value; }
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

        private void NhaCungCapControl_DoubleClick(object sender, EventArgs e)
        {
            // Mở form cập nhật khi click đúp
            if (nhaCungCap != null) // Kiểm tra xem nhaCungCap có hợp lệ không
            {
                CapNhatNhaCungCap capNhatForm = new CapNhatNhaCungCap(nhaCungCap);
                capNhatForm.ShowDialog(); // Hiển thị form cập nhật nhà cung cấp
            }
        }

        private bool IsDoubleClick()
        {
            return MouseButtons == MouseButtons.Left && Control.MouseButtons == MouseButtons.None;
        }


        private void NhaCungCapControl_MouseDown(object sender, MouseEventArgs e)
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
