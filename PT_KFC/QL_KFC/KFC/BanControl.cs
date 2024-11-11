using BUS;
using DTO;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace KFC
{
    public partial class BanControl : UserControl
    {
        public Ban_DTO ban { get; private set; }
        private static BanControl selectedControl; // Đối tượng đã chọn
        private System.Windows.Forms.Timer countdownTimer; // Timer để cập nhật thời gian đếm ngược

        public bool IsSelected { get; set; }

        private Ban_BUS bus = new Ban_BUS();

        public BanControl()
        {
            InitializeComponent();
            RegisterClickEvent(this);
            RegisterDoubleClickEvent(this); // Đăng ký sự kiện click đúp

            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000; // 1000 ms = 1 giây
            countdownTimer.Tick += CountdownTimer_Tick; // Sử dụng sự kiện Tick thay vì Elapsed
        }

        public Ban_DTO GetBan()
        {
            return ban;
        }

        // Hàm đăng ký sự kiện click cho tất cả các thành phần con
        private void RegisterClickEvent(Control control)
        {
            control.MouseDown += BanControl_MouseDown; // Đăng ký sự kiện nhấn chuột

            foreach (Control childControl in control.Controls)
            {
                RegisterClickEvent(childControl);
            }
        }

        // Hàm đăng ký sự kiện click đúp cho tất cả các thành phần con
        private void RegisterDoubleClickEvent(Control control)
        {
            control.DoubleClick += BanControl_DoubleClick; // Đăng ký sự kiện click đúp

            foreach (Control childControl in control.Controls)
            {
                RegisterDoubleClickEvent(childControl);
            }
        }

        public void UpdateData(Ban_DTO ban)
        {
            if (ban == null)
            {
                throw new ArgumentNullException(nameof(ban), "Dữ liệu bàn không được null");
            }

            // Dừng timer trước khi cập nhật dữ liệu
            countdownTimer.Stop();

            this.ban = ban;
            lblTrangThai.Text = ban.TrangThaiBan ? "Đang sử dụng" : "Trống";
            lblBan.Text = ban.TenBan;

            // Kiểm tra nếu bàn trống, không hiển thị thời gian đặt
            if (ban.TrangThaiBan)
            {
                // Nếu bàn đang sử dụng, hiển thị thời gian còn lại
                if (ban.ThoiGianDen != DateTime.MinValue && ban.ThoiGianRoi != DateTime.MinValue)
                {
                    TimeSpan thoiGianConLai = (TimeSpan)(ban.ThoiGianRoi - DateTime.Now);

                    if (thoiGianConLai > TimeSpan.Zero)
                    {
                        lblThoiGian.Text = $"Còn lại: {thoiGianConLai.Hours} giờ {thoiGianConLai.Minutes} phút {thoiGianConLai.Seconds} giây";
                        countdownTimer.Start(); // Bắt đầu đếm ngược
                    }
                    else
                    {
                        lblThoiGian.Text = "Hết thời gian";
                    }
                }
                else
                {
                    lblThoiGian.Text = "Chưa có thời gian đặt";
                }
            }
            else
            {
                // Nếu bàn trống, không hiển thị thời gian đặt
                lblThoiGian.Text = "";
            }
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (ban != null && ban.ThoiGianRoi != DateTime.MinValue && ban.ThoiGianRoi > DateTime.Now)
            {
                TimeSpan thoiGianConLai = (TimeSpan)(ban.ThoiGianRoi - DateTime.Now);

                if (thoiGianConLai > TimeSpan.Zero)
                {
                    lblThoiGian.Text = $"Còn lại: {thoiGianConLai.Hours} giờ {thoiGianConLai.Minutes} phút {thoiGianConLai.Seconds} giây";
                }
                else
                {
                    lblThoiGian.Text = "Hết thời gian";
                    countdownTimer.Stop(); // Dừng timer nếu đã hết thời gian
                }
            }
            else
            {
                lblThoiGian.Text = "Hết thời gian";
                countdownTimer.Stop();
            }
        }

        public string TenBan
        {
            get { return lblBan.Text; }
            set { lblBan.Text = value; }
        }

        public string TrangThaiBan
        {
            get { return lblTrangThai.Text; }
            set { lblTrangThai.Text = value; }
        }

        private void BanControl_DoubleClick(object sender, EventArgs e)
        {
            //Mở form cập nhật khi click đúp
            if (ban != null) // Kiểm tra xem ban có hợp lệ không
            {
                CapNhapBan capNhatForm = new CapNhapBan(ban);
                capNhatForm.ShowDialog(); // Hiển thị form cập nhật bàn
            }
        }

        private void BanControl_MouseDown(object sender, MouseEventArgs e)
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

        private void BanControl_Paint_1(object sender, PaintEventArgs e)
        {
            Color borderColor = Color.Red; // Màu viền
            int borderWidth = 2; // Độ dày viền

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}
