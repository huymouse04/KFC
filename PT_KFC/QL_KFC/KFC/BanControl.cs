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
    public partial class BanControl : UserControl
    {
        public BanControl()
        {
            InitializeComponent();
        }

        private string tenBan;
        private string maBan;

        public string MaBan { get {return lblMaBan.Text; } set => lblMaBan.Text = value; }
        public string TenBan { get { return lblBan.Text; } set => lblBan.Text = value; }
    }
}
