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

        // Biến static để lưu trạng thái cảnh báo chỉ trong form Kho
        private static bool hasShownExpiryWarning = false;


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


        //Them
        private void btnAdd_Click(object sender, EventArgs e)
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

        //Cap Nhat
        private void btnUpdate_Click(object sender, EventArgs e)
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


        //Tim Kiem
        private void btnFind_Click(object sender, EventArgs e)
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

        //Xuat
        private void btnIn_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtMaSP.Text.Trim();
            List<DTO.Kho_DTO> ketQuaList;


            if (string.IsNullOrEmpty(tuKhoa))
            {
                ketQuaList = khoBUS.GetAllKho();
            }
            else
            {
                ketQuaList = khoBUS.SearchKho(tuKhoa);
            }

            if (ketQuaList == null || ketQuaList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kho nào với từ khóa đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Chuyển đổi List<DTO.NhanVien_DTO> sang DataTable
            DataTable ketQua = ConvertListToDataTable(ketQuaList);

            FormReport formKho = new FormReport(FormReport.LoaiBaoCao.Kho, ketQua);
            formKho.Show();

        }

        //Lam moi
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var allKho = khoBUS.GetAllKho();
            dtGVKHO.DataSource = allKho;
            ClearForm();
            dtpNgaySanXuat.Enabled = false;  // Đảm bảo DateTimePicker vẫn bị block khi làm mới
            dtpNgayHetHan.Enabled = false;

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

            childform.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right; // Đặt kích thước form con vừa phải, không quá lớn
            childform.Size = new Size(panel_Body.Width - 1, panel_Body.Height - 35); // Giảm chiều cao một chút để không quá dài
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

                // Kiểm tra ngày sản xuất và ngày hết hạn trước khi gán, bỏ qua nếu null
                var ngaySanXuat = dtGVKHO.SelectedRows[0].Cells["NgaySanXuat"].Value;
                var ngayHetHan = dtGVKHO.SelectedRows[0].Cells["NgayHetHan"].Value;

                if (ngaySanXuat != DBNull.Value)
                    dtpNgaySanXuat.Value = Convert.ToDateTime(ngaySanXuat);

                if (ngayHetHan != DBNull.Value)
                    dtpNgayHetHan.Value = Convert.ToDateTime(ngayHetHan);

                // Khóa trường mã sản phẩm để không cho phép chỉnh sửa
                txtMaSP.ReadOnly = true;
            }
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

                // Kiểm tra ngày sản xuất và ngày hết hạn trước khi gán, bỏ qua nếu null
                var ngaySanXuat = selectedRow.Cells["NgaySanXuat"].Value;
                var ngayHetHan = selectedRow.Cells["NgayHetHan"].Value;

                if (ngaySanXuat != DBNull.Value)
                    dtpNgaySanXuat.Value = Convert.ToDateTime(ngaySanXuat);

                if (ngayHetHan != DBNull.Value)
                    dtpNgayHetHan.Value = Convert.ToDateTime(ngayHetHan);

                txtMaSP.ReadOnly = true; // Không cho sửa mã sản phẩm
            }
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
                // Kiểm tra xem ngày hết hạn có giá trị không
                if (row.Cells["NgayHetHan"].Value != null && row.Cells["NgayHetHan"].Value != DBNull.Value)
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
                        // Sản phẩm đã hết hạn (màu đỏ và gạch ngang toàn bộ dòng)
                        row.DefaultCellStyle.BackColor = Color.Red;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.Style.Font = new Font(dtGVKHO.Font, FontStyle.Strikeout);
                        }
                    }
                    else
                    {
                        // Reset các dòng khác (nếu cần)
                        row.DefaultCellStyle.BackColor = Color.White;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.Style.Font = new Font(dtGVKHO.Font, FontStyle.Regular);
                        }
                    }
                }
                else
                {
                    // Nếu không có giá trị ngày hết hạn, bỏ qua dòng này
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private bool isFirstLoad = true; // Biến để theo dõi lần mở đầu tiên


        private void ShowExpiryWarnings()
        {
            if (hasShownExpiryWarning) return; // Nếu đã hiển thị, không hiển thị lại

            bool hasExpiryWarning = false;
            string expiredMessage = "Các sản phẩm đã hết hạn:\n";
            string upcomingExpiryMessage = "Các sản phẩm sắp hết hạn:\n";

            foreach (DataGridViewRow row in dtGVKHO.Rows)
            {
                // Kiểm tra xem ngày hết hạn có giá trị không
                if (row.Cells["NgayHetHan"].Value != null && row.Cells["NgayHetHan"].Value != DBNull.Value)
                {
                    DateTime ngayHetHan = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);
                    TimeSpan remainingTime = ngayHetHan - DateTime.Now;

                    string maSanPham = row.Cells["MaSanPham"].Value.ToString();
                    string tenSanPham = row.Cells["TenSanPham"].Value.ToString();

                    // Kiểm tra sản phẩm đã hết hạn
                    if (remainingTime.TotalDays <= 0)
                    {
                        hasExpiryWarning = true;
                        expiredMessage += $"- {tenSanPham} (Mã SP: {maSanPham}) đã hết hạn vào: {ngayHetHan:dd/MM/yyyy}\n";
                    }
                    // Kiểm tra sản phẩm sắp hết hạn (còn 3 ngày trở xuống)
                    else if (remainingTime.TotalDays <= 3)
                    {
                        hasExpiryWarning = true;
                        int daysLeft = (int)Math.Ceiling(remainingTime.TotalDays);
                        upcomingExpiryMessage += $"- {tenSanPham} (Mã SP: {maSanPham}) còn {daysLeft} ngày trước khi hết hạn: {ngayHetHan:dd/MM/yyyy}\n";
                    }
                }
            }

            // Hiển thị thông báo nếu có sản phẩm hết hạn hoặc sắp hết hạn
            if (hasExpiryWarning)
            {
                string finalMessage = string.Empty;
                if (!string.IsNullOrEmpty(expiredMessage))
                {
                    finalMessage += expiredMessage; // Thêm thông báo sản phẩm hết hạn
                }
                if (!string.IsNullOrEmpty(upcomingExpiryMessage))
                {
                    finalMessage += upcomingExpiryMessage; // Thêm thông báo sản phẩm sắp hết hạn
                }
                MessageBox.Show(finalMessage, "Cảnh báo hết hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hasShownExpiryWarning = true; // Đánh dấu đã hiển thị cảnh báo
            }
        }

        public DataTable ConvertListToDataTable(List<DTO.Kho_DTO> list)
        {
            DataTable dataTable = new DataTable();

            // Lấy tất cả các thuộc tính của đối tượng Kho_DTO
            PropertyInfo[] properties = typeof(Kho_DTO).GetProperties();

            // Tạo các cột trong DataTable tương ứng với các thuộc tính
            foreach (PropertyInfo property in properties)
            {
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Thêm từng đối tượng trong danh sách vào hàng của DataTable
            foreach (Kho_DTO item in list)
            {
                DataRow row = dataTable.NewRow();
                foreach (PropertyInfo property in properties)
                {
                    row[property.Name] = property.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private void btnLoaiHangHoa_Click(object sender, EventArgs e)
        {
            openLoaiHangForm();
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            openNhaCungCapForm();
        }

        private void btnNhapHangg_Click(object sender, EventArgs e)
        {
            openNhapHangForm();
        }



        private void btnXoaaa_Click(object sender, EventArgs e)
        {

            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (dtGVKHO.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để xóa.");
                    return;
                }

                // Lấy thông tin sản phẩm được chọn
                string maSanPham = dtGVKHO.SelectedRows[0].Cells["MaSanPham"].Value.ToString();
                string tenSanPham = dtGVKHO.SelectedRows[0].Cells["TenSanPham"].Value.ToString();

                // Hiển thị hộp thoại xác nhận xóa
                var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{tenSanPham}' (Mã SP: {maSanPham}) không?",
                                                     "Xác nhận xóa",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    // Gọi phương thức xóa từ BUS
                    khoBUS.DeleteKho(maSanPham);
                    MessageBox.Show("Xóa sản phẩm thành công.");
                    LoadDataGridView(); // Tải lại dữ liệu vào DataGridView
                    ClearForm(); // Xóa dữ liệu nhập
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message);
            }
        }
    }
}