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
using DAO;

namespace KFC
{
    public partial class NhanVienControl : UserControl
    {

        public NhanVien_DTO nhanVien { get; private set; }
        private int clickCount = 0; // Biến đếm số lần nhấp
        private static NhanVienControl selectedControl; // Đối tượng đã chọn

        public bool IsSelected { get; set; }

        private NhanVien_BUS bus = new NhanVien_BUS();

        public event EventHandler UserControlDoubleClicked;


        public NhanVienControl()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                bus = new NhanVien_BUS();
            }

            RegisterClickEvent(this);
            RegisterDoubleClickEvent(this);


            this.DoubleClick += (s, e) => UserControlDoubleClicked?.Invoke(this, EventArgs.Empty);

        }



        //protected virtual void OnNhanVienDoubleClicked(NhanVien_DTO nhanVien)
        //{
        //    NhanVienDoubleClicked?.Invoke(nhanVien);
        //}

        public NhanVien_DTO GetNhanVien()
        {
            return nhanVien;
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
        }

        private void RegisterDoubleClickEvent(Control control)
        {
            foreach (Control child in control.Controls)
            {
                child.DoubleClick += NhanVienControl_DoubleClick;
                RegisterDoubleClickEvent(child); // Đăng ký đệ quy cho tất cả các con
            }
         
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

        private void NhanVienControl_DoubleClick(object sender, EventArgs e)
        {
            UserControlDoubleClicked?.Invoke(this, e);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
