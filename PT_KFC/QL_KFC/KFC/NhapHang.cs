using BUS;
using DAO;
using DTO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace KFC
{
    public partial class NhapHang : Form
    {
        NhapHang_BUS nh = new NhapHang_BUS();

        public NhapHang()
        {
            InitializeComponent();
            LoadData();
            dtGVNH.CellClick += dtGVNH_CellClick;
            ClearInputFields();
        }

        private void LoadData()
        {
            var nhapHangList = nh.GetAllNhapHang();
            dtGVNH.DataSource = nhapHangList;

            cbMaLH.DataSource = nh.GetAllLH();
            cbMaLH.DisplayMember = "TenLoaiHang";
            cbMaLH.ValueMember = "MaLoaiHang";

            cbMaNCC.DataSource = nh.GetAllNCC();
            cbMaNCC.DisplayMember = "TenNhaCungCap";
            cbMaNCC.ValueMember = "MaNhaCungCap";

            cbTenSP.DataSource = nh.GetAllSP();
            cbTenSP.DisplayMember = "TenSanPham";
            cbTenSP.ValueMember = "TenSanPham";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput(out NhapHang_DTO nhapHang))
            {
                try
                {
                    nh.AddNhapHang(nhapHang);
                    nh.UpdateSLKho(nhapHang.MaSanPham, nhapHang.SoLuong);
                    MessageBox.Show("Thêm nhập hàng thành công!");
                    LoadData();
                    ClearInputFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }

        private bool ValidateInput(out NhapHang_DTO nhapHang, bool isUpdate = false)
        {
            nhapHang = null;

            if (isUpdate && string.IsNullOrWhiteSpace(txtMaNH.Text))
            {
                MessageBox.Show("Mã nhập hàng không được để trống khi cập nhật.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSL.Text) || !int.TryParse(txtSL.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là một số nguyên dương.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDonGia.Text) || !double.TryParse(txtDonGia.Text, out double dongia) || dongia <= 0)
            {
                MessageBox.Show("Đơn giá phải là một số dương.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDVT.Text))
            {
                MessageBox.Show("Đơn vị tính không được để trống.");
                return false;
            }

            // Kiểm tra điều kiện ngày tháng
            DateTime ngayNhap = dtpNN.Value;
            DateTime ngaySX = dtpNgaySX.Value;
            DateTime ngayHetHan = dtpNgayHH.Value;

            if (ngaySX >= ngayNhap)
            {
                MessageBox.Show("Ngày sản xuất phải trước ngày nhập.");
                return false;
            }

            if (ngayNhap >= ngayHetHan)
            {
                MessageBox.Show("Ngày nhập phải trước ngày hết hạn.");
                return false;
            }

            nhapHang = new NhapHang_DTO
            {
                MaNhapHang = isUpdate ? int.Parse(txtMaNH.Text) : 0,
                MaSanPham = txtMaSP.Text,
                SoLuong = soLuong,
                DonViTinh = txtDVT.Text,
                DonGia = dongia,
                NgayNhap = ngayNhap,
                NgaySanXuat = ngaySX,
                NgayHetHan = ngayHetHan,
                MaNhaCungCap = cbMaNCC.SelectedValue.ToString(),
                MaLoaiHang = cbMaLH.SelectedValue.ToString(),
                TenSanPham = cbTenSP.SelectedValue.ToString()
            };

            return true;
        }


        private void ClearInputFields()
        {
            txtMaNH.Clear();
            txtSL.Clear();
            txtDVT.Clear();
            txtMaSP.Clear();
            txtDonGia.Clear();
            cbTenSP.SelectedIndex = -1;
            cbMaNCC.SelectedIndex = -1;
            cbMaLH.SelectedIndex = -1;
            dtpNN.Value=DateTime.Now;
        }

        private void dtGVNH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int dong = e.RowIndex;

                txtMaNH.Text = dtGVNH.Rows[dong].Cells["MaNhapHang"]?.Value?.ToString() ?? string.Empty;

                txtSL.Text = dtGVNH.Rows[dong].Cells["SoLuong"]?.Value?.ToString() ?? string.Empty;
                txtDVT.Text = dtGVNH.Rows[dong].Cells["DonViTinh"]?.Value?.ToString() ?? string.Empty;
                txtMaSP.Text = dtGVNH.Rows[dong].Cells["MaSanPham"]?.Value?.ToString() ?? string.Empty;
                txtDonGia.Text = dtGVNH.Rows[dong].Cells["DonGia"]?.Value?.ToString() ?? string.Empty;
                if (DateTime.TryParse(dtGVNH.Rows[dong].Cells["NgayNhap"]?.Value?.ToString(), out DateTime ngayNhap))
                {
                    dtpNN.Value = ngayNhap;
                }
                else
                {
                    dtpNN.Value = DateTime.Now;
                }
                if (DateTime.TryParse(dtGVNH.Rows[dong].Cells["NgaySanXuat"]?.Value?.ToString(), out DateTime ngaySX))
                {
                    dtpNgaySX.Value = ngaySX;
                }
                else
                {
                    dtpNgaySX.Value = DateTime.Now;
                }
                if (DateTime.TryParse(dtGVNH.Rows[dong].Cells["NgayHetHan"]?.Value?.ToString(), out DateTime ngayHetHan))
                {
                   dtpNgayHH.Value = ngayHetHan;
                }
                else
                {
                    dtpNgayHH.Value = DateTime.Now;
                }
                cbTenSP.SelectedValue = dtGVNH.Rows[dong].Cells["TenSanPham"]?.Value?.ToString() ?? string.Empty;
                cbMaLH.SelectedValue = dtGVNH.Rows[dong].Cells["MaLoaiHang"]?.Value?.ToString() ?? string.Empty;
                cbMaNCC.SelectedValue = dtGVNH.Rows[dong].Cells["MaNhaCungCap"]?.Value?.ToString() ?? string.Empty;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNH.Text))
            {
                MessageBox.Show("Vui lòng chọn mã nhập hàng cần xóa.");
                return;
            }

            string maNhapHang = txtMaNH.Text;

            try
            {
                nh.DeleteNhapHang(int.Parse(maNhapHang));
                MessageBox.Show("Xóa nhập hàng thành công!");
                LoadData();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNH.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhập hàng cần cập nhật.");
                return;
            }

            if (ValidateInput(out NhapHang_DTO nhapHang, true))
            {
                try
                {
                    nh.UpdateNhapHang(nhapHang);
                    nh.UpdateSLKho(nhapHang.MaSanPham, nhapHang.SoLuong);
                    MessageBox.Show("Cập nhật nhập hàng thành công!");
                    LoadData();

                    ClearInputFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                List<NhapHang_DTO> nhapHangList = new List<NhapHang_DTO>();

                // Kiểm tra tìm kiếm theo mã nhập hàng
                if (!string.IsNullOrWhiteSpace(txtMaNH.Text))
                {
                    if (int.TryParse(txtMaNH.Text, out int maNhapHang))
                    {
                        List<NhapHang_DTO> nhapHang = nh.GetNhapHangByMa(maNhapHang);
                        if (nhapHang != null && nhapHang.Count > 0)
                        {
                            nhapHangList.AddRange(nhapHang); // Thêm vào danh sách
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã nhập hàng phải là một số nguyên hợp lệ.");
                        return;
                    }
                }

                // Kiểm tra tìm kiếm theo mã sản phẩm
                if (!string.IsNullOrWhiteSpace(txtMaSP.Text))
                {
                    List<NhapHang_DTO> nhapHangSP = nh.GetNhapHangByMaSP(txtMaSP.Text);
                    if (nhapHangSP != null && nhapHangSP.Count > 0)
                    {
                        nhapHangList.AddRange(nhapHangSP); // Thêm vào danh sách
                    }
                }
                if (!string.IsNullOrWhiteSpace(cbMaNCC.Text))
                {
                    List<NhapHang_DTO> nhapHangNCCList = nh.GetNhapHangByMaNCC(cbMaNCC.SelectedValue.ToString());
                    if (nhapHangNCCList != null && nhapHangNCCList.Count > 0)
                    {
                        nhapHangList.AddRange(nhapHangNCCList);
                    }
                }
                // Kiểm tra tìm kiếm theo mã loại hàng
                if (!string.IsNullOrWhiteSpace(cbMaLH.Text))
                {
                    List<NhapHang_DTO> nhapHangLH = nh.GetNhapHangByMaLH(cbMaLH.SelectedValue.ToString());
                    if (nhapHangLH != null && nhapHangLH.Count > 0)
                    {
                        nhapHangList.AddRange(nhapHangLH); // Thêm vào danh sách
                    }
                }
                if (!string.IsNullOrWhiteSpace(cbTenSP.Text))
                {
                    List<NhapHang_DTO> nhapHangByTenSP = nh.GetNhapHangByTenSP(cbTenSP.SelectedValue.ToString());
                    if (nhapHangByTenSP != null && nhapHangByTenSP.Count > 0)
                    {
                        nhapHangList.AddRange(nhapHangByTenSP); // Thêm vào danh sách
                    }
                }

                // Hiển thị kết quả tìm kiếm
                if (nhapHangList.Count > 0)
                {
                    dtGVNH.DataSource = nhapHangList;
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu.");
                    LoadData();
                    ClearInputFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            var reportForm = new Form();
            var viewer = new Microsoft.Reporting.WinForms.ReportViewer();
            viewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            viewer.LocalReport.ReportPath = @"Reports\RPNhapHang.rdlc";

            // Tạo nguồn dữ liệu cho báo cáo
            List<NhapHang_DTO> reportData;
            string maSanPham = txtMaSP.Text.Trim();  // Mã sản phẩm

            // Kiểm tra nếu SelectedValue của cbMaLH và cbMaNCC là null
            string maLoaiHang = cbMaLH.SelectedValue?.ToString();  // Mã loại hàng
            string maNhaCungCap = cbMaNCC.SelectedValue?.ToString();  // Mã nhà cung cấp

            if (!string.IsNullOrEmpty(maSanPham) || !string.IsNullOrEmpty(maLoaiHang) || !string.IsNullOrEmpty(maNhaCungCap))
            {
                reportData = nh.GetNhapHangByConditions(maSanPham, maLoaiHang, maNhaCungCap);
            }
            else if (dtGVNH.SelectedRows.Count > 0)
            {
                reportData = new List<NhapHang_DTO>();
                foreach (DataGridViewRow row in dtGVNH.SelectedRows)
                {
                    var nhapHang = new NhapHang_DTO
                    {
                        MaNhapHang = (int)row.Cells["MaNhapHang"].Value,
                        MaSanPham = row.Cells["MaSanPham"].Value.ToString(),
                        SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                        DonGia = Convert.ToDouble(row.Cells["DonGia"].Value),
                        MaLoaiHang = row.Cells["MaLoaiHang"].Value.ToString()
                    };
                    reportData.Add(nhapHang);
                }
            }
            else
            {
                reportData = nh.GetAllNhapHang(); // Lấy toàn bộ danh sách
            }

            ClearInputFields();

            // Kiểm tra reportData trước khi sử dụng
            if (reportData != null && reportData.Count > 0)
            {
                var reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", reportData);
                viewer.LocalReport.DataSources.Clear();
                viewer.LocalReport.DataSources.Add(reportDataSource);
                viewer.RefreshReport();

                reportForm.Controls.Add(viewer);
                viewer.Dock = DockStyle.Fill;
                reportForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTenSP.SelectedItem != null)
            {
                string tensp = cbTenSP.SelectedValue.ToString();

                NhapHang_BUS nhapHangBus = new NhapHang_BUS();
                NhapHang_DTO nhapHangDTO = nhapHangBus.GetTenSanPhamByMa(tensp);

                // Cập nhật giá trị cho các textbox
                if (nhapHangDTO != null)
                {
                    txtMaSP.Text = nhapHangDTO.MaSanPham ?? string.Empty;
                    txtDVT.Text = nhapHangDTO.DonViTinh ?? string.Empty;  // Nếu bạn có textbox cho đơn vị tính
                    txtDonGia.Text = nhapHangDTO.DonGia?.ToString() ?? "0";  // Chuyển đổi giá thành chuỗi
                    
                    
                }
                else
                {
                    // Nếu không tìm thấy sản phẩm, làm trống các textbox
                    txtMaSP.Text = string.Empty;
                    txtDVT.Text = string.Empty;
                    txtDonGia.Text = string.Empty;
                }
            }
            else
            {
                // Nếu không có sản phẩm được chọn, làm trống các textbox
                txtMaSP.Text = string.Empty;
                txtDVT.Text = string.Empty;
                txtDonGia.Text = string.Empty;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

<<<<<<< HEAD
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }
=======
>>>>>>> 15cab5e902a5813aaf6f712e09938fe8465fb609
    }
}
