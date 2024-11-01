using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace DAO
{
    public class LuongNhanVien_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

        private bool isLuongAdded; // Biến để theo dõi trạng thái thêm lương


        public LuongNhanVien_DAO() { }

        public void CapNhatLuong(LuongNhanVien_DTO luongDTO)
        {
            try
            {
                // Tìm lương hiện tại của nhân viên
                var luongToUpdate = DB.Luongs.FirstOrDefault(l => l.MaNhanVien == luongDTO.MaNhanVien
                                                                    && l.Thang == luongDTO.Thang
                                                                    && l.Nam == luongDTO.Nam);
                if (luongToUpdate != null)
                {
                    // Cập nhật các trường thông tin
                    luongToUpdate.LuongCoBan = luongDTO.LuongCoBan;
                    luongToUpdate.SoNgayLam = luongDTO.SoNgayLam;
                    luongToUpdate.ThuongChuyenCan = luongDTO.ThuongChuyenCan;
                    luongToUpdate.ThuongHieuSuat = luongDTO.ThuongHieuSuat;
                    luongToUpdate.SoGioLamThem = luongDTO.SoGioLamThem;
                    luongToUpdate.KhoanTru = luongDTO.KhoanTru;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    DB.SubmitChanges();

                    MessageBox.Show("Cập nhật lương thành công cho nhân viên " + luongDTO.MaNhanVien, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin lương cho nhân viên này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật lương: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public List<LuongNhanVien_DTO> TimKiemLuong(int? thang, int? nam, string keyword)
        {
            try
            {
                var query = from luong in DB.Luongs
                            join nhanVien in DB.NhanViens on luong.MaNhanVien equals nhanVien.MaNhanVien
                            where (thang == null || luong.Thang == thang)
                                  && (nam == null || luong.Nam == nam)
                                  && (string.IsNullOrEmpty(keyword) ||
                                      luong.MaNhanVien.Contains(keyword) ||
                                      nhanVien.TenNhanVien.Contains(keyword) ||
                                      nhanVien.ChucVu.Contains(keyword))
                            select new LuongNhanVien_DTO
                            {
                                MaNhanVien = luong.MaNhanVien,
                                TenNhanVien = nhanVien.TenNhanVien,
                                ChucVu = nhanVien.ChucVu,
                                LuongCoBan = luong.LuongCoBan,
                                Thang = luong.Thang,
                                Nam = luong.Nam,
                                SoNgayLam = luong.SoNgayLam,
                                ThuongChuyenCan = (int)luong.ThuongChuyenCan,
                                ThuongHieuSuat = (int)luong.ThuongHieuSuat,
                                SoGioLamThem = (int)luong.SoGioLamThem,
                                KhoanTru = (int)luong.KhoanTru
                            };

                var resultList = query.ToList();

                // Hiển thị số lượng kết quả tìm kiếm
                MessageBox.Show("Số lượng kết quả tìm kiếm: " + resultList.Count);

                return resultList;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm lương: " + ex.Message);
            }
        }

        public List<LuongNhanVien_DTO> LayDanhSachLuong()
        {
            try
            {
                return (from luong in DB.Luongs
                        join nhanVien in DB.NhanViens on luong.MaNhanVien equals nhanVien.MaNhanVien
                        select new LuongNhanVien_DTO
                        {
                            MaNhanVien = luong.MaNhanVien,
                            TenNhanVien = nhanVien.TenNhanVien,
                            ChucVu = nhanVien.ChucVu,
                            LuongCoBan = luong.LuongCoBan,
                            Thang = luong.Thang,
                            Nam = luong.Nam,
                            SoNgayLam = luong.SoNgayLam,
                            ThuongChuyenCan = (int)luong.ThuongChuyenCan,
                            ThuongHieuSuat = (int)luong.ThuongHieuSuat,
                            SoGioLamThem = (int)luong.SoGioLamThem,
                            KhoanTru = (int)luong.KhoanTru
                        }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách lương: " + ex.Message);
                return new List<LuongNhanVien_DTO>();
            }
        }


        // Kiểm tra xem lương đã được thêm hay chưa
        public bool IsLuongAdded => isLuongAdded;

        public void ThemLuong()
        {
            try
            {
                DateTime today = DateTime.Now;
                var existingLuong = DB.Luongs
                    .FirstOrDefault(l => l.Thang == today.Month && l.Nam == today.Year);

                if (existingLuong == null) // Nếu không có lương đã thêm cho tháng này
                {
                    DB.ExecuteCommand("EXEC sp_ThemLuong");
                    isLuongAdded = true; // Đánh dấu là đã thêm lương
                }
                else
                {
                    isLuongAdded = false; // Đánh dấu là chưa thêm lương
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm lương: " + ex.Message);
            }
        }

        public void KiemTraVaThemLuong()
        {
            DateTime today = DateTime.Now;

            // Kiểm tra nếu hôm nay là ngày 28
            if (today.Day >= 28)
            {
                ThemLuong();

                // Hiển thị thông báo nếu lương đã được thêm
                if (IsLuongAdded)
                {
                    MessageBox.Show("Lương đã được thêm cho tháng " + today.Month + " năm " + today.Year);
                }
                else
                {
                    MessageBox.Show("Lương đã được thêm cho tháng " + today.Month + " năm " + today.Year + " trước đó.");
                }
            }
        }


    }
}
