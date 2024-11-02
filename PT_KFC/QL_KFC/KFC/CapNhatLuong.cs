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
    public partial class CapNhatLuong : Form
    {
        private LuongNhanVien_BUS bus = new LuongNhanVien_BUS();
        private NhanVien_BUS nvbus = new NhanVien_BUS();
        public event EventHandler SalaryUpdated;
        private LuongNhanVien luongForm; // Thêm biến để lưu đối tượng LuongNhanVien

        private LuongNhanVien_DTO luongDTO;
        private bool isUpdateMode;
        public CapNhatLuong()
        {
            InitializeComponent();
            InitializeFormForAdding();

        }

        private string maNhanVien;

        public CapNhatLuong(LuongNhanVien_DTO luong, LuongNhanVien luongForm)
        {
            InitializeComponent();
            this.luongDTO = luong; // Gán đối tượng khi khởi tạo
            isUpdateMode = true;
            InitializeFormForEditing();
            this.luongForm = luongForm; // Gán đối tượng hiện tại

        }
        private void InitializeFormForAdding()
        {
            LoadNhanVienToComboBox();
            cboMaNV.SelectedIndexChanged += cboMaNV_SelectedIndexChanged;
            txtTenNV.Enabled = false;
            txtChucVu.Enabled = false;


            txtLuongCB.KeyPress += txt_KeyPress;
            txtSoNgayLam.KeyPress += txt_KeyPress;
            txtThuongCC.KeyPress += txt_KeyPress;
            txtThuongNL.KeyPress += txt_KeyPress;
            txtGioLamThem.KeyPress += txt_KeyPress;
            txtKhoanTru.KeyPress += txt_KeyPress;

            txtLuongCB.Validating += txt_Validating;
            txtSoNgayLam.Validating += txt_Validating;
            txtThuongCC.Validating += txt_Validating;
            txtThuongNL.Validating += txt_Validating;
            txtGioLamThem.Validating += txt_Validating;
            txtKhoanTru.Validating += txt_Validating;

            txtThuongCC.TextChanged += CalculateTotalSalary;
            txtLuongCB.TextChanged += CalculateTotalSalary;
            txtThuongNL.TextChanged += CalculateTotalSalary;
            txtKhoanTru.TextChanged += CalculateTotalSalary;
            txtGioLamThem.TextChanged += CalculateTotalSalary;
            txtSoNgayLam.TextChanged += CalculateTotalSalary;
        }

        private void InitializeFormForEditing()
        {
            if (luongDTO != null)
            {
                cboMaNV.Enabled = false;
                LoadNhanVienToComboBox();
                LoadMonthsToComboBox(); // Gọi hàm tải tháng

                LoadDataForEditing(luongDTO); // Sử dụng luongDTO đã được gán
            }
            else
            {
                MessageBox.Show("Thông tin lương không hợp lệ.");
            }

            txtLuongCB.KeyPress += txt_KeyPress;
            txtSoNgayLam.KeyPress += txt_KeyPress;
            txtThuongCC.KeyPress += txt_KeyPress;
            txtThuongNL.KeyPress += txt_KeyPress;
            txtGioLamThem.KeyPress += txt_KeyPress;
            txtKhoanTru.KeyPress += txt_KeyPress;

            txtLuongCB.Validating += txt_Validating;
            txtSoNgayLam.Validating += txt_Validating;
            txtThuongCC.Validating += txt_Validating;
            txtThuongNL.Validating += txt_Validating;
            txtGioLamThem.Validating += txt_Validating;
            txtKhoanTru.Validating += txt_Validating;

            txtTenNV.Enabled = false;
            txtChucVu.Enabled = false;
            txtThuongCC.TextChanged += CalculateTotalSalary;
            txtLuongCB.TextChanged += CalculateTotalSalary;
            txtThuongNL.TextChanged += CalculateTotalSalary;
            txtKhoanTru.TextChanged += CalculateTotalSalary;
            txtGioLamThem.TextChanged += CalculateTotalSalary;
            txtSoNgayLam.TextChanged += CalculateTotalSalary;
        }

        private void LoadMonthsToComboBox()
        {
            // Thêm tháng vào ComboBox
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i.ToString());
            }
        }

        private void LoadDataForEditing(LuongNhanVien_DTO luong)
        {
            if (luong != null)
            {
                cboMaNV.Text = luong.MaNhanVien;
                txtTenNV.Text = luong.TenNhanVien; // Tên nhân viên
                txtChucVu.Text = luong.ChucVu; // Chức vụ
                txtLuongCB.Text = luong.LuongCoBan.ToString();
                txtSoNgayLam.Text = luong.SoNgayLam.ToString();
                txtThuongCC.Text = luong.ThuongChuyenCan.ToString();
                txtThuongNL.Text = luong.ThuongHieuSuat.ToString();
                txtGioLamThem.Text = luong.SoGioLamThem.ToString();
                txtKhoanTru.Text = luong.KhoanTru.ToString();

                // Đặt giá trị cho cboThang
                if (luong.Thang >= 1 && luong.Thang <= 12)
                {
                    cboThang.SelectedItem = luong.Thang.ToString();
                }
                else
                {
                    MessageBox.Show("Tháng không hợp lệ.");
                }

                CalculateTotalSalary(null, null);
            }
            else
            {
                MessageBox.Show("Thông tin lương không hợp lệ.");
            }
        }

        private void CalculateTotalSalary(object sender, EventArgs e)
        {
            // Khai báo và khởi tạo biến lương cơ bản, số ngày làm việc và các lương thưởng  
            int luongCoBan = 0;
            int soNgayLam = 0;
            int thuongChuyenCan = 0;
            int thuongHieuSuat = 0;
            int gioLamThem = 0; 
            int khoanTru = 0;

            // Kiểm tra và chuyển đổi giá trị từ các TextBox  
            int.TryParse(txtLuongCB.Text, out luongCoBan);
            int.TryParse(txtSoNgayLam.Text, out soNgayLam);
            int.TryParse(txtThuongCC.Text, out thuongChuyenCan);
            int.TryParse(txtThuongNL.Text, out thuongHieuSuat);
            int.TryParse(txtGioLamThem.Text, out gioLamThem);
            int.TryParse(txtKhoanTru.Text, out khoanTru);

            // Tính tổng lương theo công thức  
            int tongLuong = (luongCoBan /30 * soNgayLam) + thuongChuyenCan + thuongHieuSuat + (gioLamThem * (luongCoBan / 30 / 8)) - khoanTru;

            // Cập nhật tổng lương vào txtTongLuong  
            txtTongLuong.Text = tongLuong.ToString();
        }

        private void LoadNhanVienToComboBox()
        {
            // Lấy danh sách nhân viên  
            var nhanVienList = nvbus.GetAllNhanVien();

            cboMaNV.DataSource = nhanVienList;
            cboMaNV.DisplayMember = "MaNhanVien"; // Hiển thị mã nhân viên  
            cboMaNV.ValueMember = "MaNhanVien";   // Giá trị của ComboBox  
        }
   
        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi người dùng chọn mã nhân viên  
            if (cboMaNV.SelectedItem is NhanVien_DTO selectedNhanVien)
            {
                txtTenNV.Text = selectedNhanVien.TenNhanVien;
                txtChucVu.Text = selectedNhanVien.ChucVu;
            }
        }

        private void New()
        {
            cboMaNV.Text = string.Empty;
            txtTenNV.Text = string.Empty;
            txtChucVu.Text = string.Empty;
            txtLuongCB.Text = string.Empty;
            txtSoNgayLam.Text = string.Empty;
            txtThuongCC.Text = string.Empty;
            txtThuongNL.Text = string.Empty;
            cboThang.Text = string.Empty;
            txtGioLamThem.Text = string.Empty;
            txtKhoanTru.Text = string.Empty;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng LuongNhanVien_DTO từ các TextBox
                LuongNhanVien_DTO luong = new LuongNhanVien_DTO
                {
                    MaNhanVien = cboMaNV.Text,
                    LuongCoBan = int.Parse(txtLuongCB.Text),
                    Thang = int.Parse(cboThang.Text),
                    SoNgayLam = int.Parse(txtSoNgayLam.Text),
                    ThuongChuyenCan = int.Parse(txtThuongCC.Text),
                    ThuongHieuSuat = int.Parse(txtThuongNL.Text),
                    SoGioLamThem = int.Parse(txtGioLamThem.Text),
                    KhoanTru = int.Parse(txtKhoanTru.Text)
                };

                // Nếu đang ở chế độ cập nhật, gọi phương thức cập nhật
                if (isUpdateMode)
                {
                    if (bus.SuaLuong(luong)) // Gọi phương thức cập nhật
                    {
                        MessageBox.Show("Cập nhật lương thành công!");
                        SalaryUpdated?.Invoke(this, EventArgs.Empty); // Kích hoạt sự kiện
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật lương thất bại!");
                    }
                }
                else // Nếu không, gọi phương thức thêm
                {
                    if (bus.ThemLuong(luong))
                    {
                        MessageBox.Show("Thêm lương thành công!");
                        SalaryUpdated?.Invoke(this, EventArgs.Empty); // Kích hoạt sự kiện
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thêm lương thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            New();
        }

        private void txt_Validating(object sender, CancelEventArgs e)
        {
            if (sender is TextBox txt)
            {
                // Kiểm tra nếu TextBox rỗng hoặc không phải số
                if (!int.TryParse(txt.Text, out _))
                {
                    MessageBox.Show("Vui lòng nhập một số hợp lệ.");
                    e.Cancel = true; // Hủy sự kiện nếu không hợp lệ
                }
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và xóa
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Hủy sự kiện nếu không phải số hoặc phím xóa
            }
        }
    }
}
