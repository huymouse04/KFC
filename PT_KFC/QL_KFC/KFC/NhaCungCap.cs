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
    public partial class NhaCungCap : Form
    {
        public NhaCungCap()
        {
            InitializeComponent();
            LoadData();
        }

        private NhaCungCap_BUS bus = new NhaCungCap_BUS();
        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Xóa tất cả các điều khiển hiện có trong FlowLayoutPanel
                flpNhaCungCap.Controls.Clear();

                // Lấy danh sách nhà cung cấp từ lớp BUS
                var nhaCungCapList = bus.GetAllNhaCungCap();

                if (nhaCungCapList != null && nhaCungCapList.Count > 0)
                {
                    // Duyệt qua danh sách nhà cung cấp và thêm vào FlowLayoutPanel
                    foreach (var nhaCungCap in nhaCungCapList)
                    {
                        NhaCungCapControl control = new NhaCungCapControl();
                        control.UpdateData(nhaCungCap); // Cập nhật thông tin nhà cung cấp vào control
                        flpNhaCungCap.Controls.Add(control); // Thêm điều khiển vào FlowLayoutPanel
                    }
                }
                else
                {
                    MessageBox.Show("Không có nhà cung cấp nào được tìm thấy.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tải danh sách nhà cung cấp: " + ex.Message);
            }
        }

        private void FormCapNhat_OnNhaCungCapSaved(object sender, NhaCungCap_DTO e)
        {
            // Kiểm tra xem nhà cung cấp đã tồn tại trong FlowLayoutPanel chưa
            var existingControl = flpNhaCungCap.Controls.OfType<NhaCungCapControl>()
                .FirstOrDefault(c => c.GetNhaCungCap().MaNhaCungCap == e.MaNhaCungCap);

            if (existingControl != null)
            {
                // Nếu tồn tại, cập nhật thông tin nhà cung cấp trên control
                existingControl.UpdateData(e);
                MessageBox.Show("Cập nhật nhà cung cấp thành công!"); // Thông báo cập nhật thành công
            }
            else
            {
                // Nếu không tồn tại, bạn có thể thêm thông báo nếu cần
                MessageBox.Show("Không tìm thấy nhà cung cấp để cập nhật.");
            }

            // Tải lại danh sách nhà cung cấp
            LoadData();
        }

        // Thêm hàm tìm kiếm nhà cung cấp theo mã
        private void TimKiemNhaCungCap()
        {
            try
            {
                string maNhaCungCap = txtTimKiem.Text.Trim(); // Lấy mã nhà cung cấp từ TextBox

                if (string.IsNullOrEmpty(maNhaCungCap))
                {
                    MessageBox.Show("Vui lòng nhập mã nhà cung cấp để tìm kiếm.");
                    return;
                }

                // Tìm nhà cung cấp theo mã
                var nhaCungCap = bus.GetNhaCungCapByMa(maNhaCungCap);

                if (nhaCungCap != null)
                {
                    // Xóa tất cả các điều khiển hiện có trong FlowLayoutPanel
                    flpNhaCungCap.Controls.Clear();

                    // Tạo một control cho nhà cung cấp tìm thấy và thêm vào FlowLayoutPanel
                    NhaCungCapControl control = new NhaCungCapControl();
                    control.UpdateData(nhaCungCap);
                    flpNhaCungCap.Controls.Add(control);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp với mã: " + maNhaCungCap);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tìm kiếm nhà cung cấp: " + ex.Message);
            }
        }

        private void OpenCapNhatNhaCungCap(NhaCungCap_DTO nhaCungCap)
        {
            if (nhaCungCap == null)
            {
                MessageBox.Show("Thông tin nhà cung cấp không hợp lệ.");
                return;
            }

            try
            {
                // Lấy thông tin nhà cung cấp đầy đủ từ database
                NhaCungCap_DTO nhaCungCapDayDu = bus.GetNhaCungCapByMa(nhaCungCap.MaNhaCungCap);

                // Kiểm tra nếu không tìm thấy nhà cung cấp
                if (nhaCungCapDayDu == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin nhà cung cấp với mã: " + nhaCungCap.MaNhaCungCap);
                    return;
                }

                // Mở form cập nhật với thông tin đầy đủ
                CapNhatNhaCungCap formCapNhat = new CapNhatNhaCungCap(nhaCungCapDayDu);

                // Lắng nghe sự kiện OnNhaCungCapSaved
                formCapNhat.OnNhaCungCapSaved += FormCapNhat_OnNhaCungCapSaved;
                formCapNhat.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi mở form cập nhật: " + ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CapNhatNhaCungCap cn = new CapNhatNhaCungCap(new NhaCungCap_DTO());

                // Lắng nghe sự kiện OnNhaCungCapSaved để cập nhật danh sách khi thêm mới
                cn.OnNhaCungCapSaved += FormCapNhat_OnNhaCungCapSaved;
                cn.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm nhà cung cấp: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có nhà cung cấp nào được chọn không
                var selectedControl = flpNhaCungCap.Controls.OfType<NhaCungCapControl>().FirstOrDefault(c => c.IsSelected);

                if (selectedControl != null)
                {
                    NhaCungCap_DTO nhaCungCap = selectedControl.GetNhaCungCap(); // Lấy thông tin nhà cung cấp từ điều khiển đã chọn

                    if (nhaCungCap != null)
                    {
                        string maNhaCungCap = nhaCungCap.MaNhaCungCap; // Lấy mã nhà cung cấp

                        // Hiển thị hộp thoại xác nhận
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này không?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // Gọi phương thức xóa từ lớp BUS
                            bus.DeleteNhaCungCap(maNhaCungCap);

                            // Cập nhật lại FlowLayoutPanel sau khi xóa
                            LoadData(); // Gọi lại LoadData để nạp lại danh sách nhà cung cấp
                            MessageBox.Show("Xóa nhà cung cấp thành công!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhà cung cấp để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xóa nhà cung cấp: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemNhaCungCap();
        }
    }
}
