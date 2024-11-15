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
using ZXing;

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
        DonDat_BUS busdondat = new DonDat_BUS();
        private string currentMaDonDat;





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
            //string maDon;

            //// Tạo mã mới cho đến khi không trùng lặp
            //do
            //{
            //    maDon = GenerateRandomCode(10);
            //}
            //while (existingCodes.Contains(maDon));

            //// Thêm mã mới vào HashSet và lưu vào file
            //existingCodes.Add(maDon);
            //SaveCodeToFile(maDon);

            //// Hiển thị mã mới trong TextBox
            //txtMaDonDat.Text = maDon;

            currentMaDonDat = busdondat.TaoDonDatMoi();
            //MessageBox.Show("Đã tạo mã đơn đặt: " + currentMaDonDat, "Thông báo");
            txtMaDonDat.Text = currentMaDonDat.ToString();

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
            if (string.IsNullOrEmpty(currentMaDonDat))
            {
                MessageBox.Show("Bạn chưa tạo mã đơn đặt. Vui lòng tạo mã trước khi thêm sản phẩm.", "Lỗi");
                return;
            }

            // Tạo đối tượng ChiTietDonDat_DTO từ dữ liệu nhập
            var dto = new ChiTietDonDat_DTO
            {
                MaDonDat = currentMaDonDat,
                MaSanPham = txtMaSanPham.Text,
                SoLuong = int.Parse(txtSoLuong.Text),
                DonGia = int.Parse(txtDonGia.Text)
            };

            // Thêm chi tiết đơn đặt vào cơ sở dữ liệu
            buschitietdondat.AddChiTietDonDat(dto);

            // Tải lại danh sách chi tiết đơn đặt
            LoadChiTietDonDat();

            // Cập nhật tổng tiền
            CapNhatTongTien();
        }

        private void CapNhatTongTien()
        {
            if (!string.IsNullOrEmpty(currentMaDonDat))
            {
                // Lấy danh sách chi tiết đơn đặt cho mã hiện tại
                var danhSachChiTiet = buschitietdondat.GetChiTietDonDatByMaDon(currentMaDonDat);

                // Tính tổng tiền
                int tongTien = danhSachChiTiet.Sum(item => item.SoLuong * item.DonGia);

                // Hiển thị tổng tiền trong TextBox
                txtTongTien.Text = tongTien.ToString(); // Định dạng số
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDonDat.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDonDat.SelectedRows[0];
                var dto = new ChiTietDonDat_DTO
                {
                    ID = (int)selectedRow.Cells["ID"].Value,
                    MaDonDat = currentMaDonDat,
                    MaSanPham = txtSanPham.Text,
                    SoLuong = int.Parse(txtSoLuong.Text),
                    DonGia = int.Parse(txtDonGia.Text)
                };

                buschitietdondat.UpdateChiTietDonDat(dto);

                LoadChiTietDonDat(); // Refresh DataGridView
                CapNhatTongTien();   // Update total
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDonDat.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDonDat.SelectedRows[0];
                int id = (int)selectedRow.Cells["ID"].Value;

                buschitietdondat.DeleteChiTietDonDat(id);

                LoadChiTietDonDat(); // Refresh DataGridView
                CapNhatTongTien();   // Update total
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

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem MaDonDat và TongTien có giá trị hợp lệ không
            if (string.IsNullOrEmpty(currentMaDonDat) || string.IsNullOrEmpty(txtTongTien.Text.Trim()))
            {
                MessageBox.Show("Mã đơn và tổng tiền là bắt buộc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  // Dừng lại nếu không có mã đơn hoặc tổng tiền
            }

            // Kiểm tra và parse Tổng Tiền
            int tongTien = 0;
            bool isValidTongTien = int.TryParse(txtTongTien.Text.Trim(), out tongTien);

            // Kiểm tra xem giá trị nhập vào có hợp lệ không (nếu không hợp lệ, thông báo lỗi)
            if (!isValidTongTien)
            {
                MessageBox.Show("Tổng tiền phải là một số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Nếu không hợp lệ, dừng lại
            }

            // Kiểm tra nếu tổng tiền nhỏ hơn 0
            if (tongTien < 0)
            {
                MessageBox.Show("Tổng tiền phải lớn hơn hoặc bằng 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Nếu tổng tiền nhỏ hơn 0, dừng lại
            }

            // Cố gắng parse SoTienNhan và SoTienTra thành số nguyên, nếu không thì gán mặc định là 0
            int soTienNhan = 0, soTienTra = 0;
            int.TryParse(txtTienNhan.Text.Trim(), out soTienNhan);
            int.TryParse(txtTienTra.Text.Trim(), out soTienTra);

            // Tạo đối tượng DonDat_DTO với các giá trị đã kiểm tra
            var donDat = new DonDat_DTO
            {
                MaDonDat = currentMaDonDat,
                MaBan = string.IsNullOrEmpty(cboBan.Text) ? (string)null : Convert.ToString(cboBan.Text),  // Nếu không có MaBan, gán NULL
                MaKhuyenMai = string.IsNullOrEmpty(cboMaKhuyenMai.Text) ? null : cboMaKhuyenMai.Text,  // Nếu không có MaKhuyenMai, gán NULL
                MaKhachHang = string.IsNullOrEmpty(txtMaKhachHang.Text) ? null : txtMaKhachHang.Text,  // Nếu không có MaKhachHang, gán NULL
                SoTienNhan = soTienNhan,
                SoTienTra = soTienTra
            };

            // Cập nhật thông tin đơn đặt vào cơ sở dữ liệu
            if (busdondat.CapNhatThongTinDonDat(donDat))
            {
                MessageBox.Show($"Thanh toán thành công! Tổng tiền: {tongTien}", "Thông báo");
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại!", "Lỗi");
            }
        }

        private void btnChuyenKhoan_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem giá trị tổng tiền có hợp lệ không
            if (int.TryParse(txtTongTien.Text, out int soTien))
            {
                // Chuỗi thông tin cho mã QR
                string tenChuTaiKhoan = "PHAM BA HUY";  // Tên chủ tài khoản
                string soTaiKhoan = "0358468058";  // Số tài khoản

                // Xây dựng chuỗi mã QR với nội dung bao gồm các ký tự có dấu
                string noiDung = $"STK:{soTaiKhoan}; Tên:{tenChuTaiKhoan}; Số tiền:{soTien}; Nội dung: Thanh toán đơn hàng #{currentMaDonDat}";

                // Tạo mã QR từ chuỗi thông tin
                var qrCodeWriter = new ZXing.BarcodeWriter
                {
                    Format = ZXing.BarcodeFormat.QR_CODE,  // Định dạng mã QR
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Width = 150,  // Kích thước mã QR (300x300)
                        Height = 150
                    },
                    Renderer = new ZXing.Rendering.BitmapRenderer()  // Đặt Renderer cho mã QR
                };

                // Tạo mã QR từ chuỗi
                var qrImage = qrCodeWriter.Write(noiDung);

                // Hiển thị mã QR lên PictureBox
                picQRCode.Image = qrImage;
                picQRCode.Visible = true;  // Hiển thị PictureBox
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tổng tiền hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
