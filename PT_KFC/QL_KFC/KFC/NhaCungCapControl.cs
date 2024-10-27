using BUS;
using DAO;
using DTO;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KFC
{
    public partial class NhaCungCapControl : UserControl
    {
        public NhaCungCap_DTO nhaCungCap { get; private set; }
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
            if (!control.HasClickEvent()) // Kiểm tra xem sự kiện đã đăng ký hay chưa
            {
                control.MouseDown += NhaCungCapControl_MouseDown;
            }

            foreach (Control childControl in control.Controls)
            {
                RegisterClickEvent(childControl);
            }
        }

        // Hàm đăng ký sự kiện click đúp cho tất cả các thành phần con
        private void RegisterDoubleClickEvent(Control control)
        {
            if (!control.HasDoubleClickEvent()) // Kiểm tra xem sự kiện đã đăng ký hay chưa
            {
                control.DoubleClick += NhaCungCapControl_DoubleClick;
            }

            foreach (Control childControl in control.Controls)
            {
                RegisterDoubleClickEvent(childControl);
            }
        }

        // Cập nhật dữ liệu nhà cung cấp
        public void UpdateData(NhaCungCap_DTO nhaCungCap)
        {
            if (nhaCungCap == null)
            {
                throw new ArgumentNullException(nameof(nhaCungCap), "Dữ liệu nhà cung cấp không được null");
            }

            this.nhaCungCap = nhaCungCap;
            lblTenNCC.Text = nhaCungCap.TenNhaCungCap; // Hiển thị tên nhà cung cấp
            lblSDT.Text = nhaCungCap.SoDienThoai; // Hiển thị số điện thoại

            // Xóa hình ảnh hiện tại nếu có
            if (pbNCC.Image != null)
            {
                pbNCC.Image.Dispose(); // Giải phóng tài nguyên hình ảnh trước khi gán hình ảnh mới
                pbNCC.Image = null;
            }

            if (nhaCungCap.AnhNhaCungCap != null && nhaCungCap.AnhNhaCungCap.Length > 0)
            {
                try
                {
                    using (var ms = new MemoryStream(nhaCungCap.AnhNhaCungCap))
                    {
                        pbNCC.Image = Image.FromStream(ms);
                        pbNCC.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
                    pbNCC.Image = null;  // Hình ảnh mặc định nếu lỗi
                }
            }
            else
            {
                pbNCC.Image = null;  // Không có ảnh, đặt hình mặc định
            }
        }

        // Mã nhà cung cấp
        public string MaNCC { get; set; }

        // Tên nhà cung cấp
        public string TenNCC
        {
            get { return lblTenNCC.Text; }
            set { lblTenNCC.Text = value; }
        }

        // Số điện thoại nhà cung cấp
        public string SoDienThoai
        {
            get { return lblSDT.Text; }
            set { lblSDT.Text = value; }
        }

        private void NhaCungCapControl_DoubleClick(object sender, EventArgs e)
        {
            if (nhaCungCap != null)
            {
                CapNhatNhaCungCap capNhatForm = new CapNhatNhaCungCap(nhaCungCap);
                capNhatForm.ShowDialog(); // Hiển thị form cập nhật nhà cung cấp
            }
        }

        private void NhaCungCapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!Control.ModifierKeys.HasFlag(Keys.Control))
                {
                    if (selectedControl != null && selectedControl != this)
                    {
                        selectedControl.IsSelected = false;
                        selectedControl.BackColor = Color.Transparent;
                    }

                    selectedControl = this;
                    IsSelected = true;
                    this.BackColor = Color.LightBlue;
                }
                else
                {
                    IsSelected = !IsSelected;
                    this.BackColor = IsSelected ? Color.LightBlue : Color.Transparent;
                }
            }
        }
    }

    // Tiện ích để kiểm tra sự kiện đã đăng ký
    public static class ControlExtensions
    {
        public static bool HasClickEvent(this Control control)
        {
            var clickEvent = typeof(Control).GetField("EventClick", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            var eventHandlerList = typeof(Control).GetProperty("Events", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(control) as System.ComponentModel.EventHandlerList;
            var click = clickEvent?.GetValue(null);

            return eventHandlerList?[click] != null;
        }

        public static bool HasDoubleClickEvent(this Control control)
        {
            var doubleClickEvent = typeof(Control).GetField("EventDoubleClick", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            var eventHandlerList = typeof(Control).GetProperty("Events", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(control) as System.ComponentModel.EventHandlerList;
            var doubleClick = doubleClickEvent?.GetValue(null);

            return eventHandlerList?[doubleClick] != null;
        }
    }
}
