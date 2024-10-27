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
        public string MaKM { get {return lblMaKM.Text; }set {lblMaKM.Text=value; } }
        public string GiaTri
        {
            get { return lblGiaTri.Text; }
            set { lblGiaTri.Text = value; }
        }
        public string SoLuong
        {
            get { return lblSoLuong.Text; }
            set { lblSoLuong.Text = value; }
        }
        public KhuyenMaiControl()
        {
            InitializeComponent();
        }
    }
}
