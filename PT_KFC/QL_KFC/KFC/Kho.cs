using BUS;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace KFC
{
    public partial class Kho : Form
    {
        private Kho_BUS khoBUS = new Kho_BUS();
        private LoaiHang_BUS loaiHangBUS = new LoaiHang_BUS();
        private NhapHang_BUS nhapHang = new NhapHang_BUS();
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

            // Block DateTimePicker cho Ngày Sản Xuất và Ngày Hết Hạn
            dtpNgaySanXuat.Enabled = false;
            dtpNgayHetHan.Enabled = false;
        }

        //Đưa dữ liệu vào combobox
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

        //Dùng để đưa dữ liệu lên datagridview 
        private void LoadDataGridView()
        {
            try
            {
                var khoList = khoBUS.GetAllKho();
                if (khoList != null && khoList.Count > 0)
                {
                    var sortedList = khoList.OrderBy(k => k.MaSanPham).ToList();
                    var dataTable = new DataTable();

                    // Thêm cột vào DataTable
                    dataTable.Columns.Add("MaLoaiHang", typeof(string));
                    dataTable.Columns.Add("MaSanPham", typeof(string));
                    dataTable.Columns.Add("TenSanPham", typeof(string));
                    dataTable.Columns.Add("SoLuong", typeof(int));
                    dataTable.Columns.Add("DonViTinh", typeof(string));
                    dataTable.Columns.Add("DonGia", typeof(float));
                    dataTable.Columns.Add("NgaySanXuat", typeof(DateTime));
                    dataTable.Columns.Add("NgayHetHan", typeof(DateTime));

                    foreach (var item in sortedList)
                    {
                        dataTable.Rows.Add(item.MaLoaiHang, item.MaSanPham, item.TenSanPham, item.SoLuong, item.DonViTinh, item.DonGia, item.NgaySanXuat, item.NgayHetHan);
                    }

                    dtGVKHO.DataSource = dataTable;

                    // Gọi highlight và hiển thị cảnh báo khi form lần đầu mở
                    HighlightExpiryWarnings();
                    // Chỉ hiển thị cảnh báo khi mở form lần đầu tiên
                    if (isFirstLoad)
                    {
                        ShowExpiryWarnings();
                        isFirstLoad = false; // Cập nhật trạng thái để không hiển thị lại
                    }
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

            // Gắn HighlightExpiryWarnings vào sự kiện DataBindingComplete để chắc chắn highlight được áp dụng
            dtGVKHO.DataBindingComplete += (s, e) => HighlightExpiryWarnings();


        }

        //Load dữ liệu kho
        private void Kho_Load(object sender, EventArgs e)
        {

            LoadDataGridView();

        }

        //Cập Nhật
        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã sản phẩm hiện tại từ TextBox
                string maSanPham = txtMaSP.Text;

                // Kiểm tra thông tin nhập vào
                if (string.IsNullOrWhiteSpace(txtTenSP.Text))
                {
                    MessageBox.Show("Tên sản phẩm không được để trống.");
                    return;
                }

                if (!int.TryParse(txtSL.Text, out int soLuong) || soLuong < 0)
                {
                    MessageBox.Show("Số lượng phải là số và không âm.");
                    return;
                }

                if (!float.TryParse(txtDonGia.Text, out float donGia) || donGia < 0)
                {
                    MessageBox.Show("Đơn giá phải là số và không âm.");
                    return;
                }

                // Tạo đối tượng Kho_DTO với thông tin mới (giữ nguyên mã sản phẩm)
                var kho = new Kho_DTO
                {
                    MaSanPham = maSanPham, // Giữ nguyên mã sản phẩm cũ
                    TenSanPham = txtTenSP.Text,
                    SoLuong = soLuong,
                    DonViTinh = txtDVT.Text,
                    DonGia = donGia,
                    MaLoaiHang = cbLH.SelectedValue.ToString(),
                    NgaySanXuat = dtpNgaySanXuat.Value,
                    NgayHetHan = dtpNgayHetHan.Value
                };

                // Cập nhật sản phẩm trong cơ sở dữ liệu
                khoBUS.UpdateKho(kho);
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
            finally
            {
                // Mở khóa trường mã sản phẩm sau khi cập nhật
                txtMaSP.ReadOnly = false;
            }
        }

       


            // Lọc dữ liệu theo mã sản phẩm
            var filteredKho = allKho.Where(k => k.MaSanPham == maSanPhamTimKiem).ToList();

            // Cập nhật DataGridView với dữ liệu đã lọc
            dtGVKHO.DataSource = filteredKho; // Cập nhật nguồn dữ liệu cho DataGridView
        }


        private void ClearForm()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSL.Text = null;
            txtDVT.Text = "";
            txtDonGia.Text = null;
            cbLH.SelectedIndex = -1;
            dtpNgaySanXuat.Value = DateTime.Today;
            dtpNgayHetHan.Value = DateTime.Today;
        }

        private void ResetTextBoxes()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSL.Text = "0";
            txtDVT.Text = "";
            txtDonGia.Text = "0";
            cbLH.SelectedIndex = -1; // Đặt ComboBox về trạng thái ban đầu
            dtpNgaySanXuat.Value = DateTime.Today;
            dtpNgayHetHan.Value = DateTime.Today;
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

<<<<<<< HEAD
        

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

=======
>>>>>>> 46a91a48266264f7c9dbf8c18844f4fcc5a03f24

        private void dtGVKHO_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dtGVKHO.SelectedRows.Count > 0)
            {
                // Lấy mã sản phẩm từ dòng được chọn
                string maSanPham = dtGVKHO.SelectedRows[0].Cells["MaSanPham"].Value.ToString();

                // Hiển thị thông tin vào các TextBox
                cbLH.SelectedValue = dtGVKHO.SelectedRows[0].Cells["MaLoaiHang"].Value.ToString();
                txtMaSP.Text = maSanPham;
                txtTenSP.Text = dtGVKHO.SelectedRows[0].Cells["TenSanPham"].Value.ToString();
                txtSL.Text = dtGVKHO.SelectedRows[0].Cells["SoLuong"].Value.ToString();
                txtDVT.Text = dtGVKHO.SelectedRows[0].Cells["DonViTinh"].Value.ToString();
                txtDonGia.Text = dtGVKHO.SelectedRows[0].Cells["DonGia"].Value.ToString();
                dtpNgaySanXuat.Value = Convert.ToDateTime(dtGVKHO.SelectedRows[0].Cells["NgaySanXuat"].Value);
                dtpNgayHetHan.Value = Convert.ToDateTime(dtGVKHO.SelectedRows[0].Cells["NgayHetHan"].Value);

                // Khóa trường mã sản phẩm để không cho phép chỉnh sửa
                txtMaSP.ReadOnly = true;
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
            if (e.RowIndex >= 0)
            {
                var selectedRow = dtGVKHO.Rows[e.RowIndex];
                txtMaSP.Text = selectedRow.Cells["MaSanPham"].Value.ToString();
                txtTenSP.Text = selectedRow.Cells["TenSanPham"].Value.ToString();
                txtSL.Text = selectedRow.Cells["SoLuong"].Value.ToString();
                txtDVT.Text = selectedRow.Cells["DonViTinh"].Value.ToString();
                txtDonGia.Text = selectedRow.Cells["DonGia"].Value.ToString();
                cbLH.SelectedValue = selectedRow.Cells["MaLoaiHang"].Value.ToString();
                dtpNgaySanXuat.Value = Convert.ToDateTime(selectedRow.Cells["NgaySanXuat"].Value);
                dtpNgayHetHan.Value = Convert.ToDateTime(selectedRow.Cells["NgayHetHan"].Value);
                txtMaSP.ReadOnly = true; // Không cho sửa mã sản phẩm
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            var allKho = khoBUS.GetAllKho();
            dtGVKHO.DataSource = allKho;
            ClearForm();
            dtpNgaySanXuat.Enabled = false;  // Đảm bảo DateTimePicker vẫn bị block khi làm mới
            dtpNgayHetHan.Enabled = false;
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
<<<<<<< HEAD
        


        public DataTable ConvertListToDataTable(List<DTO.Kho_DTO> list)

=======
      
>>>>>>> 46a91a48266264f7c9dbf8c18844f4fcc5a03f24

        private void btnDelete_Click(object sender, EventArgs e)

        {
            //DataTable dataTable = new DataTable();

            //// Lấy tất cả các thuộc tính của đối tượng Kho_DTO
            //PropertyInfo[] properties = typeof(Kho_DTO).GetProperties();

            //// Tạo các cột trong DataTable tương ứng với các thuộc tính
            //foreach (PropertyInfo property in properties)
            //{
            //    dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            //}

            //// Thêm từng đối tượng trong danh sách vào hàng của DataTable
            //foreach (Kho_DTO item in list)
            //{
            //    DataRow row = dataTable.NewRow();
            //    foreach (PropertyInfo property in properties)
            //    {
            //        row[property.Name] = property.GetValue(item) ?? DBNull.Value;
            //    }
            //    dataTable.Rows.Add(row);
            //}

            //return dataTable;
        }

       
        // Thiết lập DatePickers để người dùng không thể chỉnh sửa ngày sản xuất và ngày hết hạn
        private void InitializeDatePickers()
        {
            dtpNgaySanXuat.Enabled = false;
            dtpNgayHetHan.Enabled = false;
        }

        // Kiểm tra và làm nổi bật những sản phẩm sắp hết hạn (còn 3 ngày)
        private void HighlightExpiryWarnings()
        {
            foreach (DataGridViewRow row in dtGVKHO.Rows)
            {
                if (row.Cells["NgayHetHan"].Value != null)
                {
                    DateTime ngayHetHan = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);
                    TimeSpan remainingTime = ngayHetHan - DateTime.Now;

                    // Kiểm tra ngày hết hạn và áp dụng màu nền, bôi đen sản phẩm đã hết hạn
                    if (remainingTime.TotalDays <= 3 && remainingTime.TotalDays > 0)
                    {
                        // Sản phẩm sắp hết hạn (màu vàng)
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else if (remainingTime.TotalDays <= 0)
                    {
                        // Sản phẩm đã hết hạn (màu đỏ và gạch ngang tên sản phẩm)
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.Cells["TenSanPham"].Style.Font = new Font(dtGVKHO.Font, FontStyle.Strikeout);
                    }
                    else
                    {
                        // Reset các dòng khác (nếu cần)
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.Cells["TenSanPham"].Style.Font = new Font(dtGVKHO.Font, FontStyle.Regular);
                    }
                }
            }
        }

        private bool isFirstLoad = true; // Biến để theo dõi lần mở đầu tiên

        //Dùng để báo người dùng sản phẩm nào sắp hết hạns
        private void ShowExpiryWarnings()
        {
            bool hasExpiryWarning = false;
            string warningMessage = "Các sản phẩm sau đây đã hoặc sắp hết hạn:\n";

            foreach (DataGridViewRow row in dtGVKHO.Rows)
            {
                if (row.Cells["NgayHetHan"].Value != null)
                {
                    DateTime ngayHetHan = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);
                    TimeSpan remainingTime = ngayHetHan - DateTime.Now;

                    // Nếu sản phẩm đã hết hạn hoặc còn 3 ngày sắp hết hạn
                    if (remainingTime.TotalDays <= 3)
                    {
                        hasExpiryWarning = true;
                        string maSanPham = row.Cells["MaSanPham"].Value.ToString();
                        string tenSanPham = row.Cells["TenSanPham"].Value.ToString();
                        warningMessage += $"- {tenSanPham} (Mã SP: {maSanPham}), hết hạn: {ngayHetHan:dd/MM/yyyy}\n";
                    }
                }
            }

            // Hiển thị thông báo nếu có sản phẩm đã hoặc sắp hết hạn
            if (hasExpiryWarning)
            {
                MessageBox.Show(warningMessage, "Cảnh báo hết hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

<<<<<<< HEAD
=======

>>>>>>> 46a91a48266264f7c9dbf8c18844f4fcc5a03f24

        //private void btnXuat_Click(object sender, EventArgs e)
        //{
        //    string tuKhoa = txtMaSP.Text.Trim();
        //    List<DTO.Kho_DTO> ketQuaList;


        //    if (string.IsNullOrEmpty(tuKhoa))
        //    {
        //        ketQuaList = khoBUS.GetAllKho();
        //    }
        //    else
        //    {
        //        ketQuaList = khoBUS.SearchKho(tuKhoa);
        //    }

        //    if (ketQuaList == null || ketQuaList.Count == 0)
        //    {
        //        MessageBox.Show("Không tìm thấy kho nào với từ khóa đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    // Chuyển đổi List<DTO.NhanVien_DTO> sang DataTable
        //    DataTable ketQua = ConvertListToDataTable(ketQuaList);

        //    FormReport formKho = new FormReport(FormReport.LoaiBaoCao.Kho, ketQua);
        //    formKho.Show();
        //}


        // public DataTable ConvertListToDataTable(List<DTO.Kho_DTO> list)
        //{
        //    DataTable dataTable = new DataTable();

        //    // Lấy tất cả các thuộc tính của đối tượng Kho_DTO
        //    PropertyInfo[] properties = typeof(Kho_DTO).GetProperties();

        //    // Tạo các cột trong DataTable tương ứng với các thuộc tính
        //    foreach (PropertyInfo property in properties)
        //    {
        //        dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
        //    }

        //    // Thêm từng đối tượng trong danh sách vào hàng của DataTable
        //    foreach (Kho_DTO item in list)
        //    {
        //        DataRow row = dataTable.NewRow();
        //        foreach (PropertyInfo property in properties)
        //        {
        //            row[property.Name] = property.GetValue(item) ?? DBNull.Value;
        //        }
        //        dataTable.Rows.Add(row);
        //    }

        //    return dataTable;
        //}

        //private void btnThem_Click_1(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string maSanPham = txtMaSP.Text;
        //        // Kiểm tra nếu mã sản phẩm đã tồn tại
        //        if (khoBUS.CheckMaSanPhamExists(maSanPham))
        //        {
        //            MessageBox.Show("Mã sản phẩm đã tồn tại, vui lòng nhập mã khác.");
        //            return;
        //        }

<<<<<<< HEAD
        //        // Thêm sản phẩm mới
        //        var kho = new Kho_DTO
        //        {
        //            MaSanPham = maSanPham,
        //            TenSanPham = txtTenSP.Text,
        //            SoLuong = int.Parse(txtSL.Text),
        //            DonViTinh = txtDVT.Text,
        //            DonGia = float.Parse(txtDonGia.Text),
        //            MaLoaiHang = cbLH.SelectedValue.ToString()
        //        };
=======

                // Kiểm tra nếu mã sản phẩm đã tồn tại
                if (khoBUS.CheckMaSanPhamExists(maSanPham))
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại, vui lòng nhập mã khác.");
                    return;
                }
>>>>>>> 46a91a48266264f7c9dbf8c18844f4fcc5a03f24

        //        khoBUS.AddKho(kho);
        //        MessageBox.Show("Thêm sản phẩm thành công.");
        //        LoadDataGridView(); // Tải lại dữ liệu vào DataGridView
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
        //    }
        //}

<<<<<<< HEAD
=======
                khoBUS.AddKho(kho);
                MessageBox.Show("Thêm sản phẩm thành công.");
                LoadDataGridView(); // Tải lại dữ liệu vào DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }

>>>>>>> 46a91a48266264f7c9dbf8c18844f4fcc5a03f24
    }
}