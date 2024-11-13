using KFC.Properties;
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
    public partial class ThucDonControl : UserControl
    {
        public event Action<string> OnMaSanPhamDoubleClicked;
        public event Action<string> OnMaSanPhamClicked;
        private string selectedMaSanPham;

        public ThucDonControl()
        {
            InitializeComponent();

            lblTenMon.Click += (s, e) => OnLabelClick();
            lblTenMon.DoubleClick += (s, e) => OnLabelDoubleClick();

            lblDonGia.Click += (s, e) => OnLabelClick();
            lblDonGia.DoubleClick += (s, e) => OnLabelDoubleClick();

            pbMon.Click += (s, e) => OnLabelClick();
            pbMon.DoubleClick += (s, e) => OnLabelDoubleClick();

            this.Click += (s, e) => OnLabelClick();
            this.DoubleClick += (s, e) => OnLabelDoubleClick();
            tableLayoutPanel2.Click+= (s, e) => OnLabelClick();
            tableLayoutPanel2.DoubleClick += (s, e) => OnLabelDoubleClick();
            CenterContent();
        }
        public string MaSanPham { get; set; }

        public string TenMon
        {
            get { return lblTenMon.Text; }
            set { lblTenMon.Text = value; }
        }

        public string DonGia
        {
            get
            {
                return lblDonGia.Text;
            }
            set
            {
                lblDonGia.Text = $"Giá: {value} VND";
            }
        }
        public bool IsSelected = false;
        private void OnLabelClick()
        {
            IsSelected = !IsSelected; // Đổi trạng thái chọn

            if (IsSelected)
            {
                this.BackColor = Color.DarkRed; // Đổi màu nền khi chọn
                selectedMaSanPham = MaSanPham; // Lưu mã sản phẩm khi được chọn
                OnMaSanPhamClicked?.Invoke(MaSanPham); // Gọi sự kiện click
            }
            else
            {
                this.BackColor = SystemColors.Control; // Trở lại màu nền ban đầu khi bỏ chọn
                selectedMaSanPham = null; // Bỏ chọn mã sản phẩm
            }
        }

        // Xử lý sự kiện khi double-click vào control
        private void OnLabelDoubleClick()
        {
            OnMaSanPhamDoubleClicked?.Invoke(MaSanPham); // Gọi sự kiện double-click
            this.BackColor = SystemColors.Control; // Đặt lại màu nền ban đầu
            IsSelected = false; // Bỏ chọn
        }
        public byte[] HinhAnh // thêm thuộc tính này để nhận mảng byte
        {
            set
            {
                if (value != null && value.Length > 0) // kiểm tra xem mảng byte có hợp lệ không
                {
                    using (var ms = new MemoryStream(value))
                    {
                        pbMon.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbMon.Image = Resources.logo; // Hiển thị ảnh logo nếu không có hình ảnh
                }
            }
        }

        public string ImagePath
        {
            get { return pbMon.ImageLocation; }
            set
            {
                if (File.Exists(value))
                {
                    try
                    {
                        using (var imgStream = File.OpenRead(value))
                        {
                            pbMon.Image = Image.FromStream(imgStream);
                        }
                    }
                    catch (Exception ex)
                    {
                        
                        pbMon.Image = Resources.logo; // Hiển thị ảnh trống nếu có lỗi
                    }
                }
                else
                {
                    pbMon.Image = Resources.logo; // Hiển thị ảnh trống nếu không tìm thấy
                }
            }
        }
        private void CenterContent()
        {
            // Căn giữa nội dung của lblTenMon
            lblTenMon.TextAlign = ContentAlignment.MiddleCenter;

            // Căn giữa nội dung của lblDonGia
            lblDonGia.TextAlign = ContentAlignment.MiddleCenter;

            // Căn giữa và tự động co dãn hình ảnh trong PictureBox
            pbMon.Dock = DockStyle.Fill;
            pbMon.SizeMode = PictureBoxSizeMode.Zoom;

            // Đảm bảo TableLayoutPanel chiếm toàn bộ diện tích Control
            tableLayoutPanel2.Dock = DockStyle.Fill;
        }

    }
}

