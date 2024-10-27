using BUS;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KFC
{
    public partial class Kho : Form
    {
        private Kho_BUS khoBUS = new Kho_BUS();
        private LoaiHang_BUS loaiHangBUS = new LoaiHang_BUS();

        private Kho_DAO khoDAO = new Kho_DAO();


        public List<Kho_DTO> GetAllKho()
        {
            return khoDAO.GetAllKho(); // Gọi phương thức từ lớp DAO
        }

        public Kho()
        {
            InitializeComponent();
            LoadComboBoxLoaiHang();
            LoadDataGridView();

               
        }

        private void LoadComboBoxLoaiHang()
        {
            try
            {
                var loaiHangList = loaiHangBUS.GetAllLoaiHang();
                if (loaiHangList != null && loaiHangList.Count > 0)
                {
                    cbLH.DataSource = loaiHangList;
                    cbLH.DisplayMember = "TenLoaiHang";
                    cbLH.ValueMember = "MaLoaiHang";
                }
                else
                {
                    MessageBox.Show("Không có loại hàng nào trong danh sách.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu ComboBox Loại Hàng: " + ex.Message);
            }
        }

        private void LoadDataGridView()
        {
            try
            {
                var khoList = khoBUS.GetAllKho(); // Gọi phương thức từ Kho_BUS

                if (khoList != null && khoList.Count > 0)
                {
                    // Sắp xếp danh sách sản phẩm theo Mã Sản Phẩm
                    var sortedList = khoList.OrderBy(k => k.MaSanPham).ToList();

                    dtGVKHO.DataSource = null;
                    dtGVKHO.DataSource = sortedList; // Hiển thị dữ liệu đã sắp xếp
                    dtGVKHO.AutoGenerateColumns = true;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu trong kho.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu DataGridView: " + ex.Message);
            }
        }

      

        private void ClearForm()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSL.Text = null;
            txtDVT.Text = "";
            txtDonGia.Text = null;
            cbLH.SelectedIndex = -1;
        }

       

        private void ResetTextBoxes()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSL.Text = "0";
            txtDVT.Text = "";
            txtDonGia.Text = "0";
            cbLH.SelectedIndex = -1; // Đặt ComboBox về trạng thái ban đầu

        }

        private void Kho_Load(object sender, EventArgs e)
        {

            LoadDataGridView();

        }

       
       
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            NhapHang nh = new NhapHang();
            nh.ShowDialog();
        }

        private void btnLoaiHang_Click(object sender, EventArgs e)
        {
            LoaiHang lh = new LoaiHang();
            lh.ShowDialog();
        }
        public bool CheckMaSanPhamExists(string maSanPham)
        {
            var khoList = GetAllKho();
            return khoList.Any(k => k.MaSanPham == maSanPham); // Trả về true nếu mã sản phẩm tồn tại
        }

        private void openformMain(Form childform)
        {
            panel_Body.Controls.Clear(); // Xóa các form con trước đó trong panel
            panel_Body.AutoScroll = true; // Bật thanh cuộn cho panel_Body

            childform.TopLevel = false; // Đặt form không phải là top-level
            childform.FormBorderStyle = FormBorderStyle.None; // Không có viền

            // Đặt kích thước form con vừa phải, không quá lớn
            childform.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            childform.Size = new Size(panel_Body.Width - 2, panel_Body.Height - 45); // Giảm chiều cao một chút để không quá dài

            panel_Body.Controls.Add(childform); // Thêm form vào panel
            panel_Body.Tag = childform; // Đặt tag cho panel
            childform.BringToFront(); // Đưa form lên trước
            childform.Show(); // Hiển thị form mới
        }

        private void openNhaCungCapForm()
        {
            NhaCungCap formNhaCungCap = new NhaCungCap();

            // Đăng ký sự kiện FormClosed để hiển thị lại form Kho khi Nhà Cung Cấp đóng
            formNhaCungCap.FormClosed += (s, args) =>
            {
                // Hiển thị lại tất cả các thành phần của form Kho sau khi form Nhà Cung Cấp đóng
                this.Show(); // Hiển thị lại form Kho
            };

            // Ẩn tất cả các control của form Kho ngoại trừ panel_Body
            foreach (Control control in this.Controls)
            {
                if (control != panel_Body) // Giữ lại panel_Body
                {
                    control.Visible = false; // Ẩn các control
                }
            }

            // Hiển thị form Nhà Cung Cấp trong panel_Body
            openformMain(formNhaCungCap);
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            openNhaCungCapForm();
        }

        private ErrorProvider errorProvider = new ErrorProvider();

        private bool ValidateForm()
        {
            bool isValid = true;

            // Reset lại các lỗi trước đó
            errorProvider.Clear();

            if (txtMaSP.Text.Trim().Length > 30)
            {
                errorProvider.SetError(txtMaSP, "Mã sản phẩm không được vượt quá 30 ký tự.");
                isValid = false;
            }
            if (txtTenSP.Text.Trim().Length > 250)
            {
                errorProvider.SetError(txtTenSP, "Tên sản phẩm không được vượt quá 250 ký tự.");
                isValid = false;
            }
            if (!int.TryParse(txtSL.Text.Trim(), out int soLuong) || soLuong < 0)
            {
                errorProvider.SetError(txtSL, "Số lượng phải là số và không âm.");
                isValid = false;
            }
            if (txtDVT.Text.Trim().Length > 50)
            {
                errorProvider.SetError(txtDVT, "Đơn vị tính không được vượt quá 50 ký tự.");
                isValid = false;
            }
            if (!float.TryParse(txtDonGia.Text.Trim(), out float donGia) || donGia < 0)
            {
                errorProvider.SetError(txtDonGia, "Đơn giá phải là số và không âm.");
                isValid = false;
            }

            return isValid;
        }

        
        private void dtGVKHO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo người dùng click vào hàng hợp lệ
            {
                var selectedRow = dtGVKHO.Rows[e.RowIndex];

                txtMaSP.Text = selectedRow.Cells["MaSanPham"].Value.ToString();
                txtTenSP.Text = selectedRow.Cells["TenSanPham"].Value.ToString();
                txtSL.Text = selectedRow.Cells["SoLuong"].Value.ToString();
                txtDVT.Text = selectedRow.Cells["DonViTinh"].Value.ToString();
                txtDonGia.Text = selectedRow.Cells["DonGia"].Value.ToString();
                cbLH.SelectedValue = selectedRow.Cells["MaLoaiHang"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maSanPham = txtMaSP.Text;

                // Kiểm tra nếu mã sản phẩm đã tồn tại
                if (khoBUS.CheckMaSanPhamExists(maSanPham))
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại, vui lòng nhập mã khác.");
                    return;
                }

                // Thêm sản phẩm mới
                var kho = new Kho_DTO
                {
                    MaSanPham = maSanPham,
                    TenSanPham = txtTenSP.Text,
                    SoLuong = int.Parse(txtSL.Text),
                    DonViTinh = txtDVT.Text,
                    DonGia = float.Parse(txtDonGia.Text),
                    MaLoaiHang = cbLH.SelectedValue.ToString()
                };

                khoBUS.AddKho(kho);
                MessageBox.Show("Thêm sản phẩm thành công.");
                LoadDataGridView(); // Tải lại dữ liệu vào DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }

       
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maSanPhamTimKiem = txtMaSP.Text.Trim();

            if (string.IsNullOrEmpty(maSanPhamTimKiem))
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm cần tìm.");
                return;
            }

            // Lấy danh sách tất cả sản phẩm từ nguồn dữ liệu
            List<Kho_DTO> allKho = khoBUS.GetAllKho(); // Lấy toàn bộ dữ liệu

            // Lọc dữ liệu theo mã sản phẩm
            var filteredKho = allKho.Where(k => k.MaSanPham == maSanPhamTimKiem).ToList();

            // Cập nhật DataGridView với dữ liệu đã lọc
            dtGVKHO.DataSource = filteredKho; // Cập nhật nguồn dữ liệu cho DataGridView
        }

        private void dtGVKHO_SelectionChanged(object sender, EventArgs e)
        {
            if (dtGVKHO.SelectedRows.Count > 0)
            {
                var selectedRow = dtGVKHO.SelectedRows[0];
                txtMaSP.Text = selectedRow.Cells["MaSanPham"].Value.ToString();
                txtTenSP.Text = selectedRow.Cells["TenSanPham"].Value.ToString();
                txtSL.Text = selectedRow.Cells["SoLuong"].Value.ToString();
                txtDVT.Text = selectedRow.Cells["DonViTinh"].Value.ToString();
                txtDonGia.Text = selectedRow.Cells["DonGia"].Value.ToString();
                cbLH.SelectedValue = selectedRow.Cells["MaLoaiHang"].Value.ToString();
            }
        }

        
        private void btnLoaiHang_Click_1(object sender, EventArgs e)
        {
            openLoaiHangForm();
            //LoaiHang loaiHang = new LoaiHang();
            //loaiHang.ShowDialog();
        }

        private void btnNhapHang_Click_1(object sender, EventArgs e)
        {
            openNhapHangForm();
        }

        private void dtGVKHO_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo người dùng click vào hàng hợp lệ
            {
                var selectedRow = dtGVKHO.Rows[e.RowIndex];

                txtMaSP.Text = selectedRow.Cells["MaSanPham"].Value.ToString();
                txtTenSP.Text = selectedRow.Cells["TenSanPham"].Value.ToString();
                txtSL.Text = selectedRow.Cells["SoLuong"].Value.ToString();
                txtDVT.Text = selectedRow.Cells["DonViTinh"].Value.ToString();
                txtDonGia.Text = selectedRow.Cells["DonGia"].Value.ToString();
                cbLH.SelectedValue = selectedRow.Cells["MaLoaiHang"].Value.ToString();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            var allKho = khoBUS.GetAllKho();
            dtGVKHO.DataSource = allKho;
            ClearForm();
        }




        private void openLoaiHangForm()
        {
            LoaiHang formLoaiHang = new LoaiHang();

            // Đăng ký sự kiện FormClosed để hiển thị lại form Kho khi form Loại Hàng đóng
            formLoaiHang.FormClosed += (s, args) =>
            {
                this.Show(); // Hiển thị lại form Kho
            };

            // Ẩn tất cả các control của form Kho ngoại trừ panel_Body
            foreach (Control control in this.Controls)
            {
                if (control != panel_Body) // Giữ lại panel_Body
                {
                    control.Visible = false; // Ẩn các control
                }
            }

            // Hiển thị form Loại Hàng trong panel_Body
            openformMain(formLoaiHang);
        }

        

        private void openNhapHangForm()
        {
            NhapHang formNhapHang = new NhapHang();

            // Đăng ký sự kiện FormClosed để hiển thị lại form Kho khi form Nhập Hàng đóng
            formNhapHang.FormClosed += (s, args) =>
            {
                this.Show(); // Hiển thị lại form Kho
            };

            // Ẩn tất cả các control của form Kho ngoại trừ panel_Body
            foreach (Control control in this.Controls)
            {
                if (control != panel_Body) // Giữ lại panel_Body
                {
                    control.Visible = false; // Ẩn các control
                }
            }

            // Hiển thị form Nhập Hàng trong panel_Body
            openformMain(formNhapHang);
        }

        private void btnNCC_Click_1(object sender, EventArgs e)
        {
            openNhaCungCapForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtGVKHO.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string maSanPham = dtGVKHO.SelectedRows[0].Cells["MaSanPham"].Value.ToString();
                        khoBUS.DeleteKho(maSanPham);
                        MessageBox.Show("Xóa sản phẩm thành công.");
                        LoadDataGridView(); // Tải lại dữ liệu vào DataGridView sau khi xóa
                        ResetTextBoxes();   // Đặt lại các TextBox về trạng thái ban đầu
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã sản phẩm cũ từ DataGridView
                string maSanPhamCu = dtGVKHO.SelectedRows[0].Cells["MaSanPham"].Value.ToString();

                // Lấy mã sản phẩm mới từ TextBox
                string maSanPhamMoi = txtMaSP.Text.Trim();

                // Nếu mã sản phẩm mới khác mã cũ thì kiểm tra xem có tồn tại không
                if (maSanPhamMoi != maSanPhamCu && khoBUS.CheckMaSanPhamExists(maSanPhamMoi))
                {
                    MessageBox.Show("Mã sản phẩm này đã tồn tại, vui lòng nhập mã khác.");
                    return;
                }

                // Nếu mã sản phẩm hợp lệ (không bị trùng), tiến hành cập nhật
                var kho = new Kho_DTO
                {
                    MaSanPham = maSanPhamMoi, // Mã sản phẩm mới hoặc không đổi
                    TenSanPham = txtTenSP.Text,
                    SoLuong = int.Parse(txtSL.Text),
                    DonViTinh = txtDVT.Text,
                    DonGia = float.Parse(txtDonGia.Text),
                    MaLoaiHang = cbLH.SelectedValue.ToString()
                };

                // Tiến hành cập nhật sản phẩm trong cơ sở dữ liệu
                khoBUS.UpdateKho(kho, maSanPhamCu); // Cập nhật với mã sản phẩm cũ

                MessageBox.Show("Cập nhật sản phẩm thành công.");

                // Tải lại dữ liệu vào DataGridView
                LoadDataGridView();

                // Reset form về trạng thái ban đầu
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex.Message);
            }   
        }


        //private void btnNhapHang_Click(object sender, EventArgs e)
        //{
        //    openNhapHangForm();
        //}


    }
}
