using BUS;
using DAO;
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
    public partial class KhuyenMai : Form
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);
        private KhuyenMai_BUS bus = new KhuyenMai_BUS();
        private string selectedMaKM;
        public KhuyenMai()
        {
            InitializeComponent();
            LoadKhuyenMai();

        }
        private void ClearControls()
        {
            txtKM.Clear();
            dtBatDau.Value = DateTime.Now;
            dtKetThuc.Value = DateTime.Now;
            txtGiaTri.Clear();
            txtSL.Clear();
            radConHL.Checked = false;
            radHetHL.Checked = false;
            txtTimKiem.Clear();
        }
        private void LoadKhuyenMai()
        {
            // Xóa các điều khiển hiện có trong flowLayoutPanel để tránh dữ liệu bị lặp
            flowLayoutPanel.Controls.Clear();

            // Lấy danh sách chương trình khuyến mãi từ cơ sở dữ liệu
            var khuyenMais = (from km in DB.KhuyenMais
                              select new
                              {
                                  MaKM = km.MaKhuyenMai,
                                  GiaTriGiam = km.GiaTriGiam,
                                  SoLuong = km.SoLuong
                              }).ToList();

            // Thêm các điều khiển khuyến mãi vào form
            foreach (var km in khuyenMais)
            {
                var khuyenMaiControl = new KhuyenMaiControl
                {
                    MaKM = km.MaKM,
                    GiaTri = km.GiaTriGiam.HasValue ? km.GiaTriGiam.Value.ToString("N2") : "0", // Kiểm tra null và định dạng
                    SoLuong = km.SoLuong.HasValue ? km.SoLuong.Value.ToString() : "0" // Kiểm tra null
                };
                khuyenMaiControl.OnMaKMDoubleClicked += KhuyenMaiControl_OnMaKMDoubleClicked;
                khuyenMaiControl.Click += (s, e) => SelectKhuyenMai(km.MaKM);
                // Thêm vào flow layout panel
                flowLayoutPanel.Controls.Add(khuyenMaiControl);
            }
        }
        private void SelectKhuyenMai(string maKM)
        {
            selectedMaKM = maKM; // Lưu mã khuyến mãi được chọn
                                 // Đổi màu nền cho tất cả control khác về trắng
            foreach (var control in flowLayoutPanel.Controls.OfType<KhuyenMaiControl>())
            {
                control.BackColor = Color.White;
                control.IsSelected = false; // Bỏ chọn
            }

            // Đánh dấu khuyến mãi đã chọn
            var selectedControl = flowLayoutPanel.Controls.OfType<KhuyenMaiControl>().FirstOrDefault(c => c.MaKM == maKM);
            if (selectedControl != null)
            {
                selectedControl.BackColor = Color.DarkRed; // Đổi màu nền để chỉ ra đã chọn
                selectedControl.IsSelected = true;
            }
        }
        private void KhuyenMaiControl_OnMaKMDoubleClicked(string maKM)
        {
            var khuyenMai = bus.LayKhuyenMaiTheoMa(maKM);

            if (khuyenMai != null)
            {
                // Điền dữ liệu vào các control tương ứng
                txtKM.Text = khuyenMai.MaKhuyenMai;
                dtBatDau.Value = khuyenMai.NgayBatDau;
                dtKetThuc.Value = khuyenMai.NgayKetThuc;
                txtGiaTri.Text = khuyenMai.GiaTriGiam.ToString();
                txtSL.Text = khuyenMai.SoLuong.ToString();

                // Kiểm tra trạng thái khuyến mãi
                DateTime today = DateTime.Now;

                // Tự động tick radio button dựa trên ngày hết hạn
                if (khuyenMai.NgayKetThuc >= today) // Nếu ngày hết hạn chưa qua
                {
                    radConHL.Checked = true;  // Khuyến mãi còn hiệu lực
                    radHetHL.Checked = false;  // Khuyến mãi hết hiệu lực
                }
                else // Nếu ngày hết hạn đã qua
                {
                    radConHL.Checked = false; // Khuyến mãi không còn hiệu lực
                    radHetHL.Checked = true;  // Khuyến mãi hết hiệu lực
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var validationResult = ValidateInput();
                if (!validationResult.isValid)
                {
                    return; // Nếu không hợp lệ, thoát khỏi hàm  
                }
                string makm = bus.TaoMa();
                var khuyenMai = new KhuyenMai_DTO(
                    makm,
                    dtBatDau.Value,
                    dtKetThuc.Value,
                    decimal.Parse(txtGiaTri.Text),
                    int.Parse(txtSL.Text),
                    validationResult.trangThai
                );

                if (bus.ThemKhuyenMai(khuyenMai))
                {
                    MessageBox.Show("Thêm khuyến mãi thành công!");
                    LoadKhuyenMai();
                    ClearControls();
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ hoặc thêm khuyến mãi thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                var validationResult = ValidateInput();
                if (!validationResult.isValid)
                {
                    return; // Nếu không hợp lệ, thoát khỏi hàm  
                }

                var khuyenMai = new KhuyenMai_DTO(
                    txtKM.Text,
                    dtBatDau.Value,
                    dtKetThuc.Value,
                    decimal.Parse(txtGiaTri.Text),
                    int.Parse(txtSL.Text),
                    validationResult.trangThai // Gán trạng thái vào thuộc tính TrangThai  
                );

                bool isSuccess = bus.CapNhatKM(khuyenMai);
                if (isSuccess)
                {
                    MessageBox.Show("Cập nhật khuyến mãi thành công!");
                    LoadKhuyenMai();
                    ClearControls();
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ hoặc cập nhật khuyến mãi thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        private (bool isValid, bool trangThai) ValidateInput()
        {
            bool trangThai;

            // Kiểm tra trạng thái của radio button  
            if (radConHL.Checked)
            {
                trangThai = true; // Nếu radConHL được chọn, gán giá trị true  

                // Kiểm tra nếu Ngày Kết Thúc nhỏ hơn Ngày Hôm Nay  
                if (dtKetThuc.Value < DateTime.Today)
                {
                    MessageBox.Show("Ngày kết thúc không thể nhỏ hơn ngày hôm nay khi khuyến mãi còn hiệu lực.");
                    return (false, false); // Trả về không hợp lệ  
                }
            }
            else if (radHetHL.Checked)
            {
                trangThai = false; // Nếu radHetHL được chọn, gán giá trị false  

                // Kiểm tra nếu Ngày Kết Thúc lớn hơn hoặc bằng Ngày Hôm Nay  
                if (dtKetThuc.Value >= DateTime.Today)
                {
                    MessageBox.Show("Ngày kết thúc phải nhỏ hơn ngày hôm nay khi khuyến mãi đã hết hiệu lực.");
                    return (false, false); // Trả về không hợp lệ  
                }
            }
            else
            {
                // Nếu không có radio button nào được chọn, hiển thị thông báo lỗi  
                MessageBox.Show("Vui lòng chọn trạng thái khuyến mãi.");
                return (false, false); // Trả về không hợp lệ  
            }


            if (!decimal.TryParse(txtGiaTri.Text, out decimal giaTri) || giaTri <= 0)
            {
                MessageBox.Show("Giá trị khuyến mãi không hợp lệ (phải là số dương).");
                return (false, false);
            }

            if (!int.TryParse(txtSL.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng khuyến mãi phải là số nguyên dương.");
                return (false, false);
            }

            // Kiểm tra ngày bắt đầu và ngày kết thúc  
            if (dtBatDau.Value >= dtKetThuc.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.");
                return (false, false);
            }

            return (true, trangThai); // Trả về hợp lệ và giá trị trangThai  
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedMaKM)) // Kiểm tra nếu có khuyến mãi được chọn
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khuyến mãi này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool isSuccess = bus.XoaKM(selectedMaKM);
                    if (isSuccess)
                    {
                        MessageBox.Show("Xóa khuyến mãi thành công!");
                        LoadKhuyenMai(); // Tải lại danh sách khuyến mãi
                        ClearControls(); // Xóa dữ liệu trong các control
                    }
                    else
                    {
                        MessageBox.Show("Xóa khuyến mãi thất bại.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần xóa.");
            }
        }

        private void KhuyenMai_Load(object sender, EventArgs e)
        {
            LoadKhuyenMai();
        }
        private void TimKiemKhuyenMai()
        {
            try
            {
                // Lấy mã khuyến mãi từ TextBox
                string maKMCanTim = txtTimKiem.Text.Trim();

                // Kiểm tra mã khuyến mãi
                if (string.IsNullOrWhiteSpace(maKMCanTim))
                {
                    MessageBox.Show("Vui lòng nhập mã khuyến mãi để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi phương thức tìm kiếm từ lớp BUS
                var danhSachKM = bus.TimKiemKhuyenMaiTheoMa(maKMCanTim);

                // Xóa các điều khiển hiện có trong flowLayoutPanel
                flowLayoutPanel.Controls.Clear();

                // Kiểm tra nếu không tìm thấy khuyến mãi
                if (!danhSachKM.Any())
                {
                    MessageBox.Show("Không tìm thấy khuyến mãi với mã này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Thêm các điều khiển khuyến mãi tìm thấy vào flowLayoutPanel
                foreach (var km in danhSachKM)
                {
                    var khuyenMaiControl = new KhuyenMaiControl
                    {
                        MaKM = km.MaKhuyenMai,
                        GiaTri = km.GiaTriGiam.ToString("N2"),
                        SoLuong =km.SoLuong.ToString()
                    };

                    // Đăng ký các sự kiện cho điều khiển khuyến mãi
                    khuyenMaiControl.OnMaKMDoubleClicked += KhuyenMaiControl_OnMaKMDoubleClicked;
                    khuyenMaiControl.Click += (s, e) => SelectKhuyenMai(km.MaKhuyenMai);

                    // Thêm vào flowLayoutPanel
                    flowLayoutPanel.Controls.Add(khuyenMaiControl);
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi cho người dùng
                MessageBox.Show($"Đã xảy ra lỗi trong quá trình tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            LoadKhuyenMai();
            ClearControls();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemKhuyenMai();
        }
    }
}
