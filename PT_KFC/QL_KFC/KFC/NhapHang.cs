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
            cbMaNCC.DisplayMember = "MaNhaCungCap";
            cbMaNCC.ValueMember = "MaNhaCungCap";

            cbMaSP.DataSource = nh.GetAllSP();
            cbMaSP.DisplayMember = "MaSanPham";
            cbMaSP.ValueMember = "MaSanPham";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput(out NhapHang_DTO nhapHang))
            {
                try
                {
                    nh.AddNhapHang(nhapHang);
                    nh.UpdateSLKho(nhapHang.MaSanPham, nhapHang.SoLuong, nhapHang.TenSanPham, nhapHang.DonViTinh, (float)(nhapHang.DonGia ?? 0), nhapHang.MaLoaiHang);
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

            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
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

            nhapHang = new NhapHang_DTO
            {
                
                MaNhapHang = isUpdate ? int.Parse(txtMaNH.Text) : 0, 
                MaSanPham = cbMaSP.SelectedValue.ToString(),
                SoLuong = soLuong,
                DonViTinh = txtDVT.Text,
                DonGia = dongia,
                NgayNhap = dtpNN.Value,
                MaNhaCungCap = cbMaNCC.SelectedValue.ToString(),
                MaLoaiHang = cbMaLH.SelectedValue.ToString(),
                TenSanPham = txtTenSP.Text
            };

            return true;
        }


        private void ClearInputFields()
        {
            txtMaNH.Clear();
            txtSL.Clear();
            txtDVT.Clear();
            txtTenSP.Clear();
            txtDonGia.Clear();
            cbMaSP.SelectedIndex = -1;
            cbMaNCC.SelectedIndex = -1;
            cbMaLH.SelectedIndex = -1;
        }

        private void dtGVNH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int dong = e.RowIndex;

                txtMaNH.Text = dtGVNH.Rows[dong].Cells["MaNhapHang"]?.Value?.ToString() ?? string.Empty;
                cbMaSP.SelectedValue = dtGVNH.Rows[dong].Cells["MaSanPham"]?.Value?.ToString() ?? string.Empty;
                txtSL.Text = dtGVNH.Rows[dong].Cells["SoLuong"]?.Value?.ToString() ?? string.Empty;
                txtDVT.Text = dtGVNH.Rows[dong].Cells["DonViTinh"]?.Value?.ToString() ?? string.Empty;
                txtTenSP.Text = dtGVNH.Rows[dong].Cells["TenSanPham"]?.Value?.ToString() ?? string.Empty;
                txtDonGia.Text = dtGVNH.Rows[dong].Cells["DonGia"]?.Value?.ToString() ?? string.Empty;
                if (DateTime.TryParse(dtGVNH.Rows[dong].Cells["NgayNhap"]?.Value?.ToString(), out DateTime ngayNhap))
                {
                    dtpNN.Value = ngayNhap;
                }
                else
                {
                    dtpNN.Value = DateTime.Now;
                }

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
                    nh.UpdateSLKho(nhapHang.MaSanPham, nhapHang.SoLuong, nhapHang.TenSanPham, nhapHang.DonViTinh, (float)(nhapHang.DonGia ?? 0), nhapHang.MaLoaiHang);
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
                if (!string.IsNullOrWhiteSpace(cbMaSP.Text))
                {
                    List<NhapHang_DTO> nhapHangSP = nh.GetNhapHangByMaSP(cbMaSP.Text);
                    if (nhapHangSP != null && nhapHangSP.Count > 0)
                    {
                        nhapHangList.AddRange(nhapHangSP); // Thêm vào danh sách
                    }
                }
                if (!string.IsNullOrWhiteSpace(cbMaNCC.Text))
                {
                    List<NhapHang_DTO> nhapHangNCCList = nh.GetNhapHangByMaNCC(cbMaNCC.Text);
                    if (nhapHangNCCList != null && nhapHangNCCList.Count > 0)
                    {
                        nhapHangList.AddRange(nhapHangNCCList);
                    }
                }
                // Kiểm tra tìm kiếm theo mã loại hàng
                if (!string.IsNullOrWhiteSpace(cbMaLH.Text))
                {
                    List<NhapHang_DTO> nhapHangLH = nh.GetNhapHangByMaLH(cbMaLH.Text);
                    if (nhapHangLH != null && nhapHangLH.Count > 0)
                    {
                        nhapHangList.AddRange(nhapHangLH); // Thêm vào danh sách
                    }
                }
                if (!string.IsNullOrWhiteSpace(txtTenSP.Text))
                {
                    List<NhapHang_DTO> nhapHangByTenSP = nh.GetNhapHangByTenSP(txtTenSP.Text.Trim());
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
            string maSanPham = cbMaSP.Text.Trim();  // Mã sản phẩm
            string maLoaiHang = cbMaLH.Text.Trim();  // Mã loại hàng
            string maNhaCungCap = cbMaNCC.Text.Trim();  // Mã nhà cung cấp

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
            var reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", reportData);
            viewer.LocalReport.DataSources.Clear();
            viewer.LocalReport.DataSources.Add(reportDataSource);

            viewer.RefreshReport();
            reportForm.Controls.Add(viewer);
            viewer.Dock = DockStyle.Fill;
            reportForm.ShowDialog();
        }

        private void dtGVNH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaSP.SelectedItem != null)
            {
                string maSanPham = cbMaSP.SelectedValue.ToString();

                NhapHang_BUS nhapHangBus = new NhapHang_BUS();
                NhapHang_DTO nhapHangDTO = nhapHangBus.GetTenSanPhamByMa(maSanPham);

                // Cập nhật giá trị cho các textbox
                if (nhapHangDTO != null)
                {
                    txtTenSP.Text = nhapHangDTO.TenSanPham ?? string.Empty;
                    txtDVT.Text = nhapHangDTO.DonViTinh ?? string.Empty;  // Nếu bạn có textbox cho đơn vị tính
                    txtDonGia.Text = nhapHangDTO.DonGia?.ToString() ?? "0";  // Chuyển đổi giá thành chuỗi
                }
                else
                {
                    // Nếu không tìm thấy sản phẩm, làm trống các textbox
                    txtTenSP.Text = string.Empty;
                    txtDVT.Text = string.Empty;
                    txtDonGia.Text = string.Empty;
                }
            }
            else
            {
                // Nếu không có sản phẩm được chọn, làm trống các textbox
                txtTenSP.Text = string.Empty;
                txtDVT.Text = string.Empty;
                txtDonGia.Text = string.Empty;
            }
        }
    }
}
