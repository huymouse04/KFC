using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class LuongNhanVien_BUS
    {
        private LuongNhanVien_DAO dao = new LuongNhanVien_DAO();

        public LuongNhanVien_BUS() { }

        public List<LuongNhanVien_DTO> SearchLuongNhanVienTheoThang(string searchTerm, int month)
        {
            return dao.SearchLuongNhanVienTheoThang(searchTerm, month);
        }


        public List<LuongNhanVien_DTO> SearchLuongByMonth(int month)
        {
            return dao.GetLuongByMonth(month);
        }

        public List<LuongNhanVien_DTO> SearchLuongNhanVien(string searchTerm)
        {
            return dao.SearchLuongNhanVien(searchTerm); // Gọi phương thức tìm kiếm từ DAO
        }

        public List<LuongNhanVien_DTO> LayDanhSachLuong()
        {
            return dao.LayDanhSachLuong();
        }

        // Thêm lương
        public bool ThemLuong(LuongNhanVien_DTO luong)
        {
            try
            {
                if (KiemTraThongTinLuong(luong))
                {
                    return dao.ThemLuong(luong);
                }
                else
                {
                    MessageBox.Show("Thông tin lương không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Sửa lương
        public bool SuaLuong(LuongNhanVien_DTO luong)
        {
            try
            {
                if (KiemTraThongTinLuong(luong))
                {
                    return dao.SuaLuong(luong);
                }
                else
                {
                    MessageBox.Show("Thông tin lương không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Kiểm tra thông tin lương trước khi thêm hoặc sửa
        private bool KiemTraThongTinLuong(LuongNhanVien_DTO luong)
        {
            if (string.IsNullOrEmpty(luong.MaNhanVien))
            {
                MessageBox.Show("Mã nhân viên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (luong.Thang < 1 || luong.Thang > 12)
            {
                MessageBox.Show("Tháng phải nằm trong khoảng từ 1 đến 12.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (luong.LuongCoBan < 0 || luong.SoNgayLam < 0 || luong.ThuongChuyenCan < 0 || luong.ThuongHieuSuat < 0)
            {
                MessageBox.Show("Lương cơ bản, số ngày làm, thưởng chuyên cần và thưởng hiệu suất không được là số âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public LuongNhanVien_DTO GetLuongNhanVien(string maNhanVien)
        {
            return dao.GetLuongNhanVienByMa(maNhanVien);
        }
    }
}

