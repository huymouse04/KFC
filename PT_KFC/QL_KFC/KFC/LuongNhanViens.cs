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
    public partial class LuongNhanViens : Form
    {
        public LuongNhanViens()
        {
            InitializeComponent();
        }

        private void vbButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang thử gán dữ liệu vào DataGridView");
            dgvLuongNhanVien.AutoGenerateColumns = true;

            List<LuongNhanVien_DTO> testData = new List<LuongNhanVien_DTO>
    {
        new LuongNhanVien_DTO
        {
            MaNhanVien = "NV001",
            TenNhanVien = "Test User",
            ChucVu = "Nhân viên",
            LuongCoBan = 5000000,
            Thang = 1,
            Nam = 2024,
            SoNgayLam = 20,
            ThuongChuyenCan = 500000,
            ThuongHieuSuat = 300000,
            SoGioLamThem = 10,
            KhoanTru = 100000
        }
    };

            dgvLuongNhanVien.DataSource = testData;


        }
    }
}
