using BUS;
using DTO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace KFC
{
    public partial class LoaiHang : Form
    {
        private LoaiHang_BUS loaiHangBUS = new LoaiHang_BUS();

        public LoaiHang()
        {
            InitializeComponent();
            LoadLoaiHang();
        }

        private void LoadLoaiHang()
        {
            flowLayoutPanel1.Controls.Clear(); // Xóa tất cả các điều khiển hiện có
            var loaiHangs = loaiHangBUS.GetAllLoaiHang(); // Lấy lại danh sách loại hàng

            foreach (var lh in loaiHangs)
            {
                var loaiHangControl = new LoaiHangControl();
                loaiHangControl.UpdateData(lh); // Cập nhật dữ liệu cho control
                flowLayoutPanel1.Controls.Add(loaiHangControl); // Thêm control vào flow layout
            }
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var editForm = new CapNhatLoaiHang();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadLoaiHang(); // Tải lại danh sách loại hàng sau khi thêm
            }
        }

        private void loaiHangControl1_DoubleClick(object sender, EventArgs e)
        {
            var control = sender as LoaiHangControl;
            if (control != null)
            {
                var editForm = new CapNhatLoaiHang();
                editForm.DataUpdated += LoadLoaiHang; // Đăng ký sự kiện
                editForm.LoadData(control.MaLH, control.TenLH); // Nạp dữ liệu vào form chỉnh sửa
                editForm.ShowDialog();
              
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var selectedControl = flowLayoutPanel1.Controls.OfType<LoaiHangControl>()
        .FirstOrDefault(c => c.IsSelected);

            if (selectedControl != null)
            {
                var maLH = selectedControl.MaLH;

                // Kiểm tra xem loại hàng có liên quan đến bản ghi nhập hàng không
                if (loaiHangBUS.HasNhapHangWithMaLoai(maLH))
                {
                    MessageBox.Show($"Không thể xóa loại hàng với mã: {maLH} vì còn sản phẩm với loại hàng này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng xử lý nếu không thể xóa
                }

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa loại hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Gọi hàm xóa từ BUS
                    if (loaiHangBUS.DeleteLoaiHang(maLH))
                    {
                        LoadLoaiHang(); // Tải lại danh sách loại hàng sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Xóa loại hàng không thành công.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại hàng để xóa.");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadLoaiHang();
        }
    }
}
