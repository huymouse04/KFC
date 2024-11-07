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
    public partial class ComboControl : UserControl
    {

        public Combo_DTO combo { get; private set; }

        public string MaCombo { get {return lblCombo.Text; } set {lblCombo.Text=value; } }
        public string TenCombo { get { return lblTenCombo.Text; } set { lblTenCombo.Text = value; } }
        public int GiaCombo
        {
            get
            {
                int giacombo;
                if (int.TryParse(lblGia.Text, out giacombo))
                {
                    return giacombo;
                }
                return 0; // hoặc bất kỳ giá trị mặc định nào bạn muốn nếu chuyển đổi thất bại
            }
            set
            {
                lblGia.Text = value.ToString();
            }
        }
        public int SoLuong
        {
            get
            {
                int soLuong;
                if (int.TryParse(lblSoLuong.Text, out soLuong))
                {
                    return soLuong;
                }
                return 0; // hoặc bất kỳ giá trị mặc định nào bạn muốn nếu chuyển đổi thất bại
            }
            set
            {
                lblSoLuong.Text = value.ToString();
            }
        }


        private bool trangThai;
        public bool TrangThai 
        {
            get 
            { 
                return trangThai; 
            }
            set 
            { 
                trangThai = value;
                CapNhatTrangThai();
            }
        }

        public ComboControl()
        {
            InitializeComponent();
            RegisterDoubleClickEvent(this);  // Đăng ký sự kiện nhấp đúp
            RegisterClickEvent(this);

        }

        public void UpdateData(Combo_DTO combo)
        {
            if (combo == null)
            {
                throw new ArgumentNullException(nameof(combo), "Dữ liệu nhân viên không được null");
            }

            this.combo = combo; // Gán dữ liệu nhân viên để sử dụng trong các sự kiện
            lblCombo.Text = combo.MaCombo; // Hiển thị tên nhân viên  
            lblTenCombo.Text = combo.TenCombo; // Hiển thị chức vụ  
            lblGia.Text =  combo.GiaCombo.ToString();
            lblSoLuong.Text = combo.SoLuong.ToString();

            CapNhatTrangThai();
        }

        private void CapNhatTrangThai()
        {
            // Kiểm tra combo để tránh lỗi NullReferenceException
            if (combo == null)
            {
                pbTrangThai.BackColor = Color.Red; // Mặc định màu đỏ nếu combo chưa được gán
                return;
            }

            bool conSoLuong = combo.SoLuong > 0;
            bool trongThoiGianHieuLuc = combo.NgayBatDau <= DateTime.Now && combo.NgayKetThuc >= DateTime.Now;

            pbTrangThai.BackColor = (conSoLuong && trongThoiGianHieuLuc) ? Color.Green : Color.Red;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ComboControl_DoubleClick(object sender, EventArgs e)
        {
            // Kiểm tra xem combo đã có dữ liệu chưa
            if (combo != null)
            {
                // Gọi sự kiện tùy chỉnh khi nhấp đúp vào ComboControl
                OnComboDoubleClicked(combo.MaCombo);
            }
        }

        public event Action<string> ComboDoubleClicked;

        protected virtual void OnComboDoubleClicked(string maCombo)
        {
            ComboDoubleClicked?.Invoke(maCombo); // Kích hoạt sự kiện và truyền MaCombo
        }

        private void RegisterDoubleClickEvent(Control control)
        {
            // Đăng ký sự kiện nhấp đúp cho chính điều khiển này
            control.DoubleClick += ComboControl_DoubleClick;

            // Đăng ký sự kiện nhấp đúp cho tất cả các điều khiển con
            foreach (Control child in control.Controls)
            {
                RegisterDoubleClickEvent(child);
            }
        }

        private void RegisterClickEvent(Control control)
        {
            // Đăng ký sự kiện nhấp đúp cho chính điều khiển này
            control.Click += ComboControl_Click;

            // Đăng ký sự kiện nhấp đúp cho tất cả các điều khiển con
            foreach (Control child in control.Controls)
            {
                RegisterClickEvent(child);
            }
        }

        public event Action<string> ComboClicked; // Sự kiện khi click vào combo
        private string maCombo; // Mã combo

        private void ComboControl_Click(object sender, EventArgs e)
        {
            ComboClicked?.Invoke(maCombo);
        }
    }
}
