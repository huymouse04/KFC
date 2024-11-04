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
        public string MaCombo { get {return lblCombo.Text; } set {lblCombo.Text=value; } }
        public string TenCombo { get { return lblTenCombo.Text; } set { lblTenCombo.Text = value; } }
        public string GiaCombo { get { return lblGia.Text; } set { lblGia.Text = value; } }

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
        }

        private void CapNhatTrangThai()
        {
            pbTrangThai.BackColor = trangThai ? Color.Green : Color.Red;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
