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
using Microsoft.Reporting.WinForms;

namespace KFC
{
    public partial class ThucDon : Form
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);
        private ThucDon_BUS bus = new ThucDon_BUS();
        private LoaiHang_BUS lh=new LoaiHang_BUS();
        private Kho_BUS k=new Kho_BUS();
        public string selectedMaSP;
        public ThucDon()
        {
            InitializeComponent();
            HienThiThucDon();
            LayMaSP();
        }
        private void SelectThucDon(string maSP)
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
                thucDonControl.Click += (s, e) => SelectThucDon(item.MaSanPham);

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
            if (!float.TryParse(txtGia.Text, out float gia) || gia <= 0)
            {
                MessageBox.Show("Giá không hợp lệ. Vui lòng nhập số lớn hơn 0.");
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

            return true;
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

                string maLoaiHang = cbMaLH.SelectedValue?.ToString();
                if (maLoaiHang == null)
                {
                    MessageBox.Show("Vui lòng chọn Mã Loại Hàng.");
                    cbMaLH.Focus();
                    return;
                }

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
                    
                    ClearControls();HienThiThucDon();
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
        public void ClearControls()
        {

            cbMaMon.SelectedIndex = -1;
            txtGia.Text = string.Empty;
            txtImagePath.Text = string.Empty;
            txtTenMon.Text = string.Empty;
            txtTimKiem.Text = string.Empty;

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
            if (string.IsNullOrEmpty(cbMaMon.Text))
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
            if (thucDonDAO.XoaThucDon(cbMaMon.Text))
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {

                if (!KiemTraDuLieu())
                {
                    return;
                }

                var td = new ThucDon_DTO(
                    cbMaMon.Text,
                    txtTenMon.Text,
                    float.Parse(txtGia.Text),
                    Encoding.UTF8.GetBytes(txtImagePath.Text),
                cbMaLH.Text
                );

                bool isSuccess = bus.CapNhatThucDon(td);
                if (isSuccess)
                {
                    MessageBox.Show("Cập nhật thực đơn thành công!");
                    HienThiThucDon();
                    ClearControls();
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ hoặc cập nhật thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            List<ThucDon_DTO> thucDons;
            flowLayoutPanel1.Controls.Clear();

            // Kiểm tra nếu ô tìm kiếm không rỗng
            if (!string.IsNullOrEmpty(searchText))
            {
                // Tìm kiếm theo mã sản phẩm trước
                thucDons = bus.TimKiemTheoMa(searchText);

                // Nếu không tìm thấy, tìm kiếm theo tên sản phẩm
                if (!thucDons.Any())
                {
                    thucDons = bus.TimKiemTheoTen(searchText);
                }

                // Hiển thị kết quả tìm kiếm
                if (thucDons.Any())
                {
                    foreach (var item in thucDons)
                    {
                        var thucdonControl = new ThucDonControl
                        {
                            TenMon = item.TenSanPham,
                            DonGia = item.DonGia.ToString("N2"),
                            ImagePath = ConvertToImagePath(item.HinhAnh)
                        };

                        thucdonControl.OnMaSanPhamDoubleClicked += ThucDonControl_OnMaSPDoubleClicked;
                        thucdonControl.Click += (s, v) => SelectThucDon(item.MaSanPham);
                        flowLayoutPanel1.Controls.Add(thucdonControl);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp.");
                    HienThiThucDon();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm.");
                HienThiThucDon();
            }
        }
        private bool IsDigitsOnly(string str)
        {
            return str.All(char.IsDigit);
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            var reportForm = new Form();
            var viewer = new Microsoft.Reporting.WinForms.ReportViewer();
            viewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            viewer.LocalReport.ReportPath = @"Reports\RPThucDon.rdlc"; 
            List<ThucDon_DTO> report;
            List<LoaiHang_DTO> loaiHang=lh.GetAllLoaiHang();
            List<Kho_DTO> kho = k.GetAllKho();
            string masp=cbMaMon.Text;
            if (!string.IsNullOrEmpty(masp))
            {
                report = bus.Xuat(masp);
            }
            else { 
            report=bus.LayDanhSachThucDon();
            }
            ClearControls();
            if (report != null && report.Count > 0)
            {
                // Tạo nguồn dữ liệu cho báo cáo
                var reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", report);
                var loaihangs = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", loaiHang);
                var khos= new Microsoft.Reporting.WinForms.ReportDataSource("DataSet3", kho);
                // Xóa các nguồn dữ liệu cũ trước khi thêm mới
                viewer.LocalReport.DataSources.Clear();

                // Thêm nguồn dữ liệu vào báo cáo
                viewer.LocalReport.DataSources.Add(reportDataSource);
                viewer.LocalReport.DataSources.Add(loaihangs);
                viewer.LocalReport.DataSources.Add(khos);
                viewer.RefreshReport();

                // Hiển thị báo cáo
                reportForm.Controls.Add(viewer);
                viewer.Dock = DockStyle.Fill;
                reportForm.ShowDialog();
            }
            else
            {
                // Không có dữ liệu để xuất
                MessageBox.Show("Không có dữ liệu để xuất báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
