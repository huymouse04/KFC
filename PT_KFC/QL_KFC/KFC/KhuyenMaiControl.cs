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
    public partial class KhuyenMaiControl : UserControl
    {
        public event Action<string> OnMaKMDoubleClicked;
        public event Action<string> OnMaKMClicked;
        public string MaKM { get {return lblMaKM.Text; }set {lblMaKM.Text=value; } }
        public string GiaTri
        {
            get { return lblGiaTri.Text; }
            set { lblGiaTri.Text = $"{value} VND"; }
        }
        public string SoLuong
        {
            get { return lblSoLuong.Text; }
            set { lblSoLuong.Text = $"Số Lượng: {value}"; }
            //lblDonGia.Text = $"Giá: {value} VND";
        }
        public KhuyenMaiControl()
        {
            InitializeComponent();
            //this.DoubleClick += KhuyenMaiControl_DoubleClick;
            lblMaKM.Click += (s, e) => OnLabelClick(lblMaKM.Text);
            lblMaKM.DoubleClick += (s, e) => OnLabelDoubleClick(lblMaKM.Text);

            lblGiaTri.Click += (s, e) => OnLabelClick(lblMaKM.Text);
            lblGiaTri.DoubleClick += (s, e) => OnLabelDoubleClick(lblMaKM.Text);

            lblSoLuong.Click += (s, e) => OnLabelClick(lblMaKM.Text);
            lblSoLuong.DoubleClick += (s, e) => OnLabelDoubleClick(lblMaKM.Text);
        }
        public bool IsSelected = false;
        private void lblMaKM_Click(object sender, EventArgs e)
        {

        }

        private void lblMaKM_DoubleClick(object sender, EventArgs e)
        {

        }
        private void OnLabelClick(string maKM)
        {
            IsSelected = !IsSelected; // Toggle selection state
            this.BackColor = IsSelected ? Color.DarkRed : Color.White; // Thay đổi màu nền khi chọn hoặc bỏ chọn
        }

        private void OnLabelDoubleClick(string maKM)
        {
            OnMaKMDoubleClicked?.Invoke(maKM);
            this.BackColor = Color.White; // Đặt lại màu nền sau khi double-click
            IsSelected = false; // Bỏ chọn
        }
        //private void KhuyenMaiControl_DoubleClick(object sender, EventArgs e)
        //{
        //    OnMaKMDoubleClicked?.Invoke(MaKM);
        //}
    }
}
