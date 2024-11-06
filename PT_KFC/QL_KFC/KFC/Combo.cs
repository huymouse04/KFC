using BUS;
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
    public partial class Combo : Form
    {

        private Combo_DTO combo; // Biến lưu trữ thông tin nhân viên
        private Combo_BUS buscb = new Combo_BUS();

        private ChiTietCombo_DTO chitietcombo; // Biến lưu trữ thông tin nhân viên
        private ChiTietCombo_BUS busct = new ChiTietCombo_BUS();
        public Combo()
        {
            InitializeComponent();
        }

        private void LoadDataCombo()
        {
            // Xóa tất cả các điều khiển hiện có trong FlowLayoutPanel
            flpCombo.Controls.Clear();

            // Lấy danh sách nhân viên từ lớp BUS
            var combolist = buscb.GetCombos();

            // Duyệt qua danh sách nhân viên và thêm vào FlowLayoutPanel
            foreach (var combo in combolist)
            {
                ComboControl control = new ComboControl();
                control.UpdateData(combo); // Cập nhật thông tin nhân viên vào control
                control.ComboDoubleClicked += (maCombo) => LoadSanPhamTrongCombo(maCombo);

                flpCombo.Controls.Add(control); // Thêm điều khiển vào FlowLayoutPanel
                flpCombo.Refresh();
            }
        }

        private void LoadSanPhamTrongCombo(string maCombo)
        {
            var danhSachSanPham = busct.LayDanhSachSanPhamTheoCombo(maCombo);

            if (danhSachSanPham == null || danhSachSanPham.Count == 0)
            {
                MessageBox.Show("Combo này hiện chưa có sản phẩm nào.");
                dgvChiTietComBo.DataSource = null;
            }
            else
            {
                dgvChiTietComBo.DataSource = danhSachSanPham;
            }
        }

        private void Combo_Load(object sender, EventArgs e)
        {
            LoadDataCombo();
        }
    }
}
