using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace KFC
{
    public partial class LichSuHoaDon : Form
    {

        DonDat_BUS busdondat = new DonDat_BUS();

        public LichSuHoaDon()
        {
            InitializeComponent();
            load();
        }

        private void load()
        {
            List<DonDat_DTO> list = busdondat.LayTatCaDonDat();
            dgvLichSu.DataSource = list;
            dgvLichSu.Columns[3].Visible = false;
        }
    }
}
