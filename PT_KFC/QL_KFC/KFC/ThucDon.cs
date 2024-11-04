using BUS;
using DAO;
using DTO;
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
    public partial class ThucDon : Form
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);
        private ThucDon_BUS bus = new ThucDon_BUS();
        public string selectedMaSP;
        public ThucDon()
        {
            InitializeComponent();
            HienThiThucDon();
            LayMaSP();
        }
        private void SelectKhuyenMai(string maSP)
        {
            selectedMaSP = maSP; // Lưu mã khuyến mãi được chọn
                                 // Đổi màu nền cho tất cả control khác về trắng
            foreach (var control in flowLayoutPanel1.Controls.OfType<ThucDonControl>())
            {
                control.BackColor = Color.White;
                control.IsSelected = false; // Bỏ chọn
            }

            // Đánh dấu khuyến mãi đã chọn
            var selectedControl = flowLayoutPanel1.Controls.OfType<ThucDonControl>().FirstOrDefault(c => c.MaSanPham == maSP);
            if (selectedControl != null)
            {
                selectedControl.BackColor = Color.DarkRed; // Đổi màu nền để chỉ ra đã chọn
                selectedControl.IsSelected = true;
            }
        }
        private void HienThiThucDon()
        {
            var danhSachThucDon = bus.LayDanhSachThucDon();

            flowLayoutPanel1.Controls.Clear(); // Xóa các control hiện có

            foreach (var item in danhSachThucDon)
            {
                var thucDonControl = new ThucDonControl
                {
                    MaSanPham = item.MaSanPham,
                    TenMon = item.TenSanPham,
                    DonGia = item.DonGia.ToString("N2"),
                    ImagePath = ConvertToImagePath(item.HinhAnh) // Chuyển đổi byte[] thành đường dẫn hình ảnh
                };

                // Kết nối sự kiện double-click
                thucDonControl.OnMaSanPhamDoubleClicked += ThucDonControl_OnMaSPDoubleClicked;
                thucDonControl.Click += (s, e) => SelectKhuyenMai(item.MaSanPham);

                flowLayoutPanel1.Controls.Add(thucDonControl);
            }
        }
        private void ThucDonControl_OnMaSPDoubleClicked(string maSP)
        {
            var thucdon = bus.LayThucDonTheoMa(maSP);

            if (thucdon != null)
            {
                cbMaMon.Text = thucdon.MaSanPham;
                txtTenMon.Text = thucdon.TenSanPham;
                txtImagePath.Text = ConvertToImagePath(thucdon.HinhAnh);
                txtGia.Text = thucdon.DonGia.ToString();
                cbMaLH.Text = thucdon.MaLoaiHang;
            }
        }
        private void LayMaSP()
        {
            List<string> maSanPhamList = bus.LayDanhSachMaSanPham();
            cbMaMon.DataSource = maSanPhamList;
            cbMaLH.DataSource = bus.GetAllLH2(cbMaMon.Text);
            cbMaLH.DisplayMember = "TenLoaiHang";
            cbMaLH.ValueMember = "MaLoaiHang";
        }
        private void LayLoaiHangTheoMaSanPham(string maSanPham)
        {
            DataTable loaiHangTable = bus.GetAllLH2(maSanPham);
            cbMaLH.DataSource = loaiHangTable;
            cbMaLH.DisplayMember = "TenLoaiHang";
            cbMaLH.ValueMember = "MaLoaiHang";
        }
        private string ConvertToImagePath(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return string.Empty;

            string tempFilePath = Path.GetTempFileName();
            File.WriteAllBytes(tempFilePath, imageData);
            return tempFilePath;
        }

        private void cbMaMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayLoaiHangTheoMaSanPham(cbMaMon.Text);
        }
        private bool KiemTraDuLieu()
        {
            // Kiểm tra Mã Sản Phẩm
            if (string.IsNullOrWhiteSpace(cbMaMon.Text))
            {
                MessageBox.Show("Vui lòng chọn Mã Sản Phẩm.");
                cbMaMon.Focus();
                return false;
            }

            // Kiểm tra Tên Món
            if (string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Món.");
                txtTenMon.Focus();
                return false;
            }

            // Kiểm tra Giá
            if (string.IsNullOrWhiteSpace(txtGia.Text))
            {
                MessageBox.Show("Vui lòng nhập Giá.");
                txtGia.Focus();
                return false;
            }
            if (!float.TryParse(txtGia.Text, out float gia))
            {
                MessageBox.Show("Giá không hợp lệ. Vui lòng nhập số.");
                txtGia.Focus();
                return false;
            }


            // Kiểm tra đường dẫn Hình Ảnh (nếu cần thiết)
            if (!string.IsNullOrWhiteSpace(txtImagePath.Text) && !File.Exists(txtImagePath.Text))
            {
                MessageBox.Show("Đường dẫn hình ảnh không tồn tại.");
                txtImagePath.Focus();
                return false;
            }

            return true; // Tất cả dữ liệu đều hợp lệ
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
            {
                return; // Dừng lại nếu dữ liệu không hợp lệ
            }

            try
            {
                // Tiếp tục thực hiện thêm món ăn nếu dữ liệu hợp lệ
                string maSanPham = cbMaMon.Text;
                string tenMon = txtTenMon.Text;
                float gia = float.Parse(txtGia.Text);
                byte[] hinhAnh = File.Exists(txtImagePath.Text) ? File.ReadAllBytes(txtImagePath.Text) : null;
                string maLoaiHang = cbMaLH.SelectedValue.ToString();

                var thucDon = new ThucDon_DTO
                {
                    MaSanPham = maSanPham,
                    TenSanPham = tenMon,
                    DonGia = gia,
                    HinhAnh = hinhAnh,
                    MaLoaiHang = maLoaiHang
                };

                bool isSuccess = bus.ThemThucDon(thucDon);

                if (isSuccess)
                {
                    MessageBox.Show("Món ăn đã được thêm thành công!");
                    HienThiThucDon();
                    ClearControls();
                }
                else
                {
                    MessageBox.Show("Thêm món ăn thất bại. Vui lòng kiểm tra dữ liệu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        public void ClearControls() {
           
            cbMaMon.SelectedIndex = -1;
            txtGia.Text= string.Empty;
            txtImagePath.Text= string.Empty;
            txtTenMon.Text= string.Empty;
            txtTimKiem.Text= string.Empty;
        
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtImagePath.Text = ofd.FileName;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaSP))
            {
                MessageBox.Show("Vui lòng chọn món cần xóa.");
                return;
            }

            // Hiển thị hộp thoại xác nhận
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa món này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            // Gọi phương thức xóa trong DAO
            var thucDonDAO = new ThucDon_DAO();
            if (thucDonDAO.XoaThucDon(selectedMaSP))
            {
                MessageBox.Show("Đã xóa món thành công.");
                HienThiThucDon(); 
                ClearControls(); 
            }
            else
            {
                MessageBox.Show("Lỗi khi xóa món.");
            }
        }

        private void btnReNew_Click(object sender, EventArgs e)
        {
            HienThiThucDon();
            ClearControls();
        }
    }
}
