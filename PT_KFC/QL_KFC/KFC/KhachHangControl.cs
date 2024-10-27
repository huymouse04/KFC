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
    public partial class KhachHangControl : UserControl
    {
        public KhachHangControl()
        {
            InitializeComponent();
        }

        private string tenKH;
        private string diemTL;
        private string maKH;

        public string MaKH { get { return lblMaKH.Text; } set { lblMaKH.Text = value; } }
        public string TenKH { get { return lblTen.Text; } set { lblTen.Text = value; } }
        public string DiemTL { get { return lblDiemTL.Text; } set { lblDiemTL.Text = value; } }
    }
}
