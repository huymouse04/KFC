using DAO;
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
    public partial class Main : Form
    {

        private Image[] images; // Mảng chứa ảnh từ tài nguyên
        private int currentImageIndex = 0;
        private Timer timer;

        public Main()
        {
            InitializeComponent();
            LoadImagesFromResources();

            // Tải ảnh ngay khi form được khởi tạo
            LoadImage();

            // Thiết lập Timer để thay đổi ảnh
            timer = new Timer();
            timer.Interval = 2000; // Thay đổi ảnh mỗi 2 giây
            timer.Tick += timer1_Tick;
            timer.Start();
        }

        private Form formMain;

        private void openformMain(Form childform)
        {
            if (formMain != null)
            {
                formMain.Close();
            }
            formMain = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childform);
            panel_Body.Tag = childform;
            childform.BringToFront();
            childform.Show();

        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            openformMain(new NhanVien());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (images != null && images.Length > 0)
            {
                Image currentImage = images[currentImageIndex];
                Size imageSize = currentImage.Size;
                Size panelSize = panel_Body.Size;

                // Tính tỷ lệ để ảnh lấp đầy panel nhưng giữ nguyên tỷ lệ ảnh
                float ratioWidth = (float)panelSize.Width / imageSize.Width;
                float ratioHeight = (float)panelSize.Height / imageSize.Height;
                float ratio = Math.Max(ratioWidth, ratioHeight); // Chọn tỷ lệ lớn hơn để đảm bảo ảnh lấp đầy

                // Tính toán kích thước mới của ảnh sau khi zoom
                int newWidth = (int)(imageSize.Width * ratio);
                int newHeight = (int)(imageSize.Height * ratio);

                // Tính toán vị trí vẽ ảnh sao cho ảnh lấp đầy panel (một phần có thể bị cắt)
                int posX = (panelSize.Width - newWidth) / 2;
                int posY = (panelSize.Height - newHeight) / 2;

                // Vẽ ảnh với kích thước mới
                e.Graphics.DrawImage(currentImage, posX, posY, newWidth, newHeight);
            }
        }

        private void LoadImagesFromResources()
        {
            images = new Image[]
            {
                Properties.Resources.banner3, // Thay "banner" bằng tên tài nguyên của ảnh
                Properties.Resources.banner5,
                Properties.Resources.banner6,
                Properties.Resources.banner7
            };
        }

        // Phương thức tải ảnh
        private void LoadImage()
        {
            if (images.Length > 0)
            {
                // Tải ảnh ban đầu
                panel_Body.Invalidate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Thay đổi ảnh khi Timer kích hoạt
            if (images.Length > 0)
            {
                currentImageIndex = (currentImageIndex + 1) % images.Length;
                panel_Body.Invalidate(); // Yêu cầu vẽ lại panel ngay khi ảnh thay đổi
            }
        }

        public void SetButtonState(bool isManager)
        {
            btnNhanVien.Visible = isManager; // Nếu là quản lý thì nút này sẽ hoạt động
            btnKho.Visible = true;
            btnBan.Visible = true;
            btnComBo.Visible = isManager;
            btnDoanhThu.Visible = isManager;
            btnDonDat.Visible = true;
            btnHoaDon.Visible = true;
            btnKhachHang.Visible = true;
            btnKhuyenMai.Visible = isManager;
            btnThucDon.Visible = isManager;      
            btnThoat.Visible = true ;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhap dn = new DangNhap();
            dn.Show();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            openformMain(new Kho());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            openformMain(new KhachHang());
        }

        private void btnThucDon_Click(object sender, EventArgs e)
        {
            openformMain(new ThucDon());
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            openformMain(new KhuyenMai());
        }


        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            openformMain(new KhachHang());
        }
    }
}
