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
        public ThucDonControl()
        {
            InitializeComponent();
        }

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
        public string ImagePath
        {
            get { return pbMon.ImageLocation; }
            set
            {
                if (File.Exists(value))
                {
                    using (var imgStream = new FileStream(value, FileMode.Open, FileAccess.Read))
                    {
                        pbMon.Image = Image.FromStream(imgStream);
                    }
                }
                else
                {
                    pbMon.Image = Resources.logo; // Hiển thị ảnh trống nếu không tìm thấy
                }
            }
        }
    }
}
