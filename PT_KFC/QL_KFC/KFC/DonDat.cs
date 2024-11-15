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
using DAO;
using System.IO;

namespace KFC
{
    public partial class DonDat : Form
    {
        private Button btnCB; // Lưu nút Combo ở cấp lớp để truy cập dễ dàng

        // Khai báo một HashSet để lưu các mã đã tạo
        private HashSet<string> existingCodes = new HashSet<string>();
        ThucDon_BUS busthucdon = new ThucDon_BUS();
        LoaiHang_BUS busloaihang = new LoaiHang_BUS();
        Combo_BUS buscombo = new Combo_BUS();
        ChiTietDonDat_BUS buschitietdondat = new ChiTietDonDat_BUS();



        public DonDat()
        {
            InitializeComponent();
            LoadCodesFromFile();
            load();
            txtMaDonDat2.Enabled = false;
            txtMaDonDat.Enabled = false;
            LoadLoaiHangButtons();
            LoadChiTietDonDat();
        }

        private void DonDat_Load(object sender, EventArgs e)
        {

        }

        private void LoadChiTietDonDat()
        {
            dgvDonDat.DataSource = buschitietdondat.GetAllChiTietDonDat();
        }

        private void load()
        {
            List<ThucDon_DTO> listThucDon = busthucdon.LayDanhSachThucDon2();
            dgvThucDon.DataSource = listThucDon;
            dgvThucDon.Refresh();
            dgvThucDon.Columns[3].Visible = false;

        }

        private void btnMaDonDat_Click(object sender, EventArgs e)
        {
            string maDon;

            // Tạo mã mới cho đến khi không trùng lặp
            do
            {
                maDon = GenerateRandomCode(10);
            }
            while (existingCodes.Contains(maDon));

            // Thêm mã mới vào HashSet và lưu vào file
            existingCodes.Add(maDon);
            SaveCodeToFile(maDon);

            // Hiển thị mã mới trong TextBox
            txtMaDonDat.Text = maDon;
        }

        private string GenerateRandomCode(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] code = new char[length];

            for (int i = 0; i < length; i++)
            {
                code[i] = chars[random.Next(chars.Length)];
            }

            return new string(code);
        }

        // Hàm lưu mã mới vào file
        private void SaveCodeToFile(string code)
        {
            using (StreamWriter writer = new StreamWriter("existingCodes.txt", true))
            {
                writer.WriteLine(code);
            }
        }

        // Hàm tải các mã đã lưu từ file vào HashSet khi khởi động
        private void LoadCodesFromFile()
        {
            if (File.Exists("existingCodes.txt"))
            {
                foreach (var line in File.ReadAllLines("existingCodes.txt"))
                {
                    existingCodes.Add(line.Trim()); // Thêm từng dòng vào HashSet
                }
            }
        }

        private void InitializeComboButton()
        {
            // Khởi tạo nút Combo nếu nó chưa tồn tại
            if (btnCB == null)
            {
                btnCB = new Button
                {
                    Text = "Combo",
                    AutoSize = true,
                    Width = 150,
                    Height = 40,
                    ForeColor = Color.White,
                    Dock = DockStyle.Top,
                };

                pnDSM.Controls.Add(btnCB); // Thêm nút Combo vào panel lần đầu tiên
            }
        }

        private void LoadLoaiHangButtons()
        {
            // Khởi tạo và thêm nút Combo nếu nó chưa tồn tại
            InitializeComboButton();

            // Đăng ký sự kiện Click cho nút Combo để hiển thị tất cả sản phẩm combo
            btnCB.Click += (sender, e) => HienThiSanPhamTheoLoai("COMBO");

            List<LoaiHang_DTO> loaiHangs = busloaihang.GetAllLoaiHang();

            pnDSM.Controls.Clear();
            pnDSM.Controls.Add(btnCB); // Thêm lại nút Combo sau khi xóa

            pnDSM.AutoScroll = true;

            // Tạo nút cho mỗi loại hàng
            foreach (var loaiHang in loaiHangs)
            {
                Button btnLoaiHang = new Button
                {
                    Text = loaiHang.TenLoaiHang,
                    Tag = loaiHang.MaLoaiHang,
                    AutoSize = true,
                    Width = 150,
                    Height = 40,
                    ForeColor = Color.White,
                    Dock = DockStyle.Top,
                };

                // Đăng ký sự kiện Click cho nút loại hàng
                btnLoaiHang.Click += (sender, e) => HienThiSanPhamTheoLoai(loaiHang.MaLoaiHang);

                pnDSM.Controls.Add(btnLoaiHang);
            }
        }

        // Phương thức để hiển thị sản phẩm theo loại hàng
        private void HienThiSanPhamTheoLoai(string maLoaiHang)
        {
            List<ThucDon_DTO> danhSachSanPham;

            if (maLoaiHang == "COMBO")
            {
                List<Combo_DTO> comboList = buscombo.GetCombos();
                danhSachSanPham = comboList.Select(combo => new ThucDon_DTO
                {
                    MaSanPham = combo.MaCombo,
                    TenSanPham = combo.TenCombo,
                    DonGia = combo.GiaCombo
                    // Gán thêm các thuộc tính khác nếu cần
                }).ToList();
            }
            else
            {
                // Lấy danh sách sản phẩm theo mã loại hàng
                danhSachSanPham = busthucdon.LayDanhSachThucDonTheoLoai(maLoaiHang);
            }

            // Hiển thị danh sách sản phẩm trong DataGridView
            dgvThucDon.DataSource = danhSachSanPham;
            dgvThucDon.Refresh();
        }

        private void dgvThucDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu hàng được nhấp đúp không phải là hàng tiêu đề
            if (e.RowIndex >= 0)
            {
                // Lấy hàng hiện tại
                DataGridViewRow row = dgvThucDon.Rows[e.RowIndex];

                // Gán giá trị từ hàng vào các điều khiển cập nhật
                txtMaSanPham.Text = row.Cells["MaSanPham"].Value.ToString();
                txtSanPham.Text = row.Cells["TenSanPham"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();

            }
        }

        private void txtMaDonDat_TextChanged(object sender, EventArgs e)
        {
            txtMaDonDat2.Text = txtMaDonDat.Text.Trim();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var dto = new ChiTietDonDat_DTO
            {
                MaDonDat = txtMaDonDat.Text,
                MaSanPham = txtMaSanPham.Text,
                SoLuong = int.Parse(txtSoLuong.Text),
                DonGia = float.Parse(txtDonGia.Text)
            };

            buschitietdondat.AddChiTietDonDat(dto);
            LoadChiTietDonDat(); // Refresh the DataGridView
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDonDat.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDonDat.SelectedRows[0];
                var dto = new ChiTietDonDat_DTO
                {
                    ID = (int)selectedRow.Cells["ID"].Value,
                    MaDonDat = txtMaDonDat.Text,
                    MaSanPham = txtSanPham.Text,
                    SoLuong = int.Parse(txtSoLuong.Text),
                    DonGia = float.Parse(txtDonGia.Text)
                };

                buschitietdondat.UpdateChiTietDonDat(dto);
                LoadChiTietDonDat(); // Refresh the DataGridView
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDonDat.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDonDat.SelectedRows[0];
                int id = (int)selectedRow.Cells["ID"].Value;

                buschitietdondat.DeleteChiTietDonDat(id);
                LoadChiTietDonDat(); // Refresh the DataGridView
            }
        }



        private void dgvDonDat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvThucDon.Rows[e.RowIndex];
                txtMaDonDat.Text = row.Cells["MaDonDat"].Value.ToString();
                txtMaSanPham.Text = row.Cells["MaSanPham"].Value.ToString();
                txtSanPham.Text = row.Cells["TenSanPham"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
            }
        }
    }
}
