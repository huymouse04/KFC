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

        private Combo_DTO combo; // Biến lưu trữ thông tin 
        private Combo_BUS buscb = new Combo_BUS();

        private ChiTietCombo_DTO chitietcombo; // Biến lưu trữ thông tin
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
                control.ComboClicked += (maCombo) => hienthithongtincombo(combo);
                flpCombo.Controls.Add(control); // Thêm điều khiển vào FlowLayoutPanel
                flpCombo.Refresh();
            }
        }

        // Hiển thị thông tin combo vào các control phía dưới
        private void hienthithongtincombo(Combo_DTO com)
        {
            if (com == null) return;

            // Nếu tìm thấy combo, hiển thị thông tin vào các control
            txtMaCombo.Text = com.MaCombo;
            txtTenCombo.Text = com.TenCombo;
            txtGiaCombo.Text = com.GiaCombo.ToString();
            txtSoLuong.Text = com.SoLuong.ToString();
            dtpNgayBatDau.Value = DateTime.Parse(com.NgayBatDau.ToString());
            dtpNgayKetThuc.Value = DateTime.Parse(com.NgayKetThuc.ToString());
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

        private void btnThemCB_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ form nhập
            var combo = new Combo_DTO
            {
                MaCombo = txtMaCombo.Text,
                TenCombo = txtTenCombo.Text,
                GiaCombo = int.Parse(txtGiaCombo.Text),
                SoLuong = int.Parse(txtSoLuong.Text),
                NgayBatDau = dtpNgayBatDau.Value,
                NgayKetThuc = dtpNgayKetThuc.Value
            };
            try
            {
                // Gọi phương thức thêm từ BUS
                if (buscb.AddCombo(combo)) // Sửa lỗi: AddCombo giờ trả về bool
                {
                    MessageBox.Show("Thêm combo thành công.");
                    LoadDataCombo(); // Load lại danh sách combo
                }
                else
                {
                    MessageBox.Show("Thêm combo thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnCapNhatCB_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ form nhập
            var combo = new Combo_DTO
            {
                MaCombo = txtMaCombo.Text,
                TenCombo = txtTenCombo.Text,
                GiaCombo = int.Parse(txtGiaCombo.Text),
                SoLuong = int.Parse(txtSoLuong.Text),
                NgayBatDau = dtpNgayBatDau.Value,
                NgayKetThuc = dtpNgayKetThuc.Value
            };

            try
            {
                // Gọi phương thức cập nhật từ BUS
                if (buscb.UpdateCombo(combo)) // Sửa lỗi: UpdateCombo giờ trả về bool
                {
                    MessageBox.Show("Cập nhật combo thành công.");
                    LoadDataCombo(); // Load lại danh sách combo
                }
                else
                {
                    MessageBox.Show("Cập nhật combo thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoaCB_Click(object sender, EventArgs e)
        {
            // Lấy mã combo từ ô nhập liệu
            string maCombo = txtMaCombo.Text;

            if (string.IsNullOrEmpty(maCombo))
            {
                MessageBox.Show("Vui lòng nhập mã combo cần xóa.");
                return;
            }

            try
            {
                // Gọi phương thức xóa từ BUS
                if (buscb.DeleteCombo(maCombo)) // Sửa lỗi: DeleteCombo giờ trả về bool
                {
                    MessageBox.Show("Xóa combo thành công.");
                    LoadDataCombo(); // Load lại danh sách combo
                }
                else
                {
                    MessageBox.Show("Xóa combo thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btnLamMoiCB_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu trong các ô nhập liệu
            txtMaCombo.Clear();
            txtTenCombo.Clear();
            txtGiaCombo.Clear();
            txtSoLuong.Clear();
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;

            // Làm mới dữ liệu trong FlowLayoutPanel
            LoadDataCombo();
        }
    }
}
