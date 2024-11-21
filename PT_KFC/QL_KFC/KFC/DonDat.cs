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



        public DonDat()
        {
            InitializeComponent();
            LoadCodesFromFile();
            load();
            txtMaDonDat2.Enabled = false;
            txtMaDonDat.Enabled = false;
            LoadLoaiHangButtons();
        }

        private void DonDat_Load(object sender, EventArgs e)
        {

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

                pnDSM.Controls.Add(btnLoaiHang);
            }
        }
        private void dgvThucDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu hàng được nhấp đúp không phải là hàng tiêu đề
            if (e.RowIndex >= 0)
            {
                // Lấy hàng hiện tại
                DataGridViewRow row = dgvThucDon.Rows[e.RowIndex];

                // Gán giá trị từ hàng vào các điều khiển cập nhật
                txtSanPham.Text = row.Cells["TenSanPham"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();

            }
        }

        private void txtMaDonDat_TextChanged(object sender, EventArgs e)
        {
            txtMaDonDat2.Text = txtMaDonDat.Text.Trim();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

        }
    }
}
