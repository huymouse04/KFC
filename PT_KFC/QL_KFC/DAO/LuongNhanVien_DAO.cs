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

        public LuongNhanVien_DAO() { }
        // Thêm lương mới  
        public bool ThemLuong(LuongNhanVien_DTO luong)
        {
            try
            {
                // Kiểm tra hợp lệ cho SoNgayLam
                if (luong.SoNgayLam < 0 || luong.SoNgayLam > 31)
                {
                    MessageBox.Show("Số ngày làm phải từ 0 đến 31.");
                    return false;
                }

                Luong l = new Luong
                {
                    MaNhanVien = luong.MaNhanVien,
                    LuongCoBan = luong.LuongCoBan, // Kiểu int
                    Thang = luong.Thang,
                    SoNgayLam = luong.SoNgayLam,
                    ThuongChuyenCan = luong.ThuongChuyenCan, // Kiểu int
                    ThuongHieuSuat = luong.ThuongHieuSuat, // Kiểu int
                    SoGioLamThem = luong.SoGioLamThem, // Kiểu int
                    KhoanTru = luong.KhoanTru // Kiểu int
                };

                DB.Luongs.InsertOnSubmit(l);
                DB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm lương: " + ex.Message);
                return false;
            }
        }

        // Sửa thông tin lương  
        public bool SuaLuong(LuongNhanVien_DTO luong)
        {
            try
            {
                // Kiểm tra hợp lệ cho SoNgayLam
                if (luong.SoNgayLam < 0 || luong.SoNgayLam > 31)
                {
                    MessageBox.Show("Số ngày làm phải từ 0 đến 31.");
                    return false;
                }

                // Tìm kiếm đối tượng trong cơ sở dữ liệu dựa trên MaNhanVien và Thang (khóa chính)
                var existingLuong = DB.Luongs.FirstOrDefault(x => x.MaNhanVien == luong.MaNhanVien && x.Thang == luong.Thang);

                if (existingLuong != null)
                {
                    // Cập nhật các trường khác
                    existingLuong.LuongCoBan = luong.LuongCoBan;
                    existingLuong.SoNgayLam = luong.SoNgayLam;
                    existingLuong.ThuongChuyenCan = luong.ThuongChuyenCan;
                    existingLuong.ThuongHieuSuat = luong.ThuongHieuSuat;
                    existingLuong.SoGioLamThem = luong.SoGioLamThem;
                    existingLuong.KhoanTru = luong.KhoanTru;

                    // Lưu thay đổi
                    DB.SubmitChanges();
                    return true;
                }
                else
                {
                    // Nếu không tìm thấy lương cần cập nhật
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi để phân tích
                Console.WriteLine("Lỗi khi sửa lương: " + ex.Message);
                return false;
            }
        }

        // Lấy danh sách lương
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

        // Tìm kiếm lương nhân viên
        public List<LuongNhanVien_DTO> SearchLuongNhanVien(string searchTerm)
        {
            var query = from luong in DB.Luongs
                        join nhanVien in DB.NhanViens on luong.MaNhanVien equals nhanVien.MaNhanVien
                        where luong.MaNhanVien.Contains(searchTerm) ||
                              nhanVien.ChucVu.Contains(searchTerm) ||
                              nhanVien.TenNhanVien.Contains(searchTerm) ||
                              luong.Thang.ToString().Contains(searchTerm)
                        select new LuongNhanVien_DTO
                        {
                            MaNhanVien = luong.MaNhanVien,
                            TenNhanVien = nhanVien.TenNhanVien,
                            ChucVu = nhanVien.ChucVu,
                            LuongCoBan = luong.LuongCoBan,
                            Thang = luong.Thang,
                            SoNgayLam = luong.SoNgayLam,
                            ThuongChuyenCan = (int)luong.ThuongChuyenCan,
                            ThuongHieuSuat = (int)luong.ThuongHieuSuat,
                            SoGioLamThem = (int)luong.SoGioLamThem,
                            KhoanTru = (int)luong.KhoanTru
                        };

            return query.ToList();
        }

        // Lấy lương theo tháng
        public List<LuongNhanVien_DTO> GetLuongByMonth(int month)
        {
            try
            {
                return DB.Luongs.Where(l => l.Thang == month)
                .Select(l => new LuongNhanVien_DTO
                {
                    MaNhanVien = l.MaNhanVien,
                    TenNhanVien = l.NhanVien.TenNhanVien,
                    ChucVu = l.NhanVien.ChucVu,
                    LuongCoBan = l.LuongCoBan,
                    Thang = l.Thang,
                    SoNgayLam = l.SoNgayLam,
                    ThuongChuyenCan = (int)l.ThuongChuyenCan,
                    ThuongHieuSuat = (int)l.ThuongHieuSuat,
                    SoGioLamThem = (int)l.SoGioLamThem,
                    KhoanTru = (int)l.KhoanTru
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách lương: " + ex.Message);
            }
        }

        // Lấy lương nhân viên theo mã
        public LuongNhanVien_DTO GetLuongNhanVienByMa(string maNhanVien)
        {
            var result = (from l in DB.Luongs
                          where l.MaNhanVien == maNhanVien
                          select new LuongNhanVien_DTO
                          {
                              MaNhanVien = l.MaNhanVien,
                              LuongCoBan = l.LuongCoBan,
                              Thang = l.Thang,
                              SoNgayLam = l.SoNgayLam,
                              ThuongChuyenCan = (int)l.ThuongChuyenCan,
                              ThuongHieuSuat = (int)l.ThuongHieuSuat,
                              SoGioLamThem = (int)l.SoGioLamThem,
                              KhoanTru = (int)l.KhoanTru
                          }).FirstOrDefault();
            return result;
        }

        // Tìm kiếm lương theo tháng
        public List<LuongNhanVien_DTO> SearchLuongNhanVienTheoThang(string searchTerm, int month)
        {
            var query = from luong in DB.Luongs
                        join nhanVien in DB.NhanViens on luong.MaNhanVien equals nhanVien.MaNhanVien
                        where (luong.MaNhanVien.Contains(searchTerm) || nhanVien.TenNhanVien.Contains(searchTerm))
                              && luong.Thang == month
                        select new LuongNhanVien_DTO
                        {
                            MaNhanVien = luong.MaNhanVien,
                            TenNhanVien = nhanVien.TenNhanVien,
                            ChucVu = nhanVien.ChucVu,
                            LuongCoBan = luong.LuongCoBan,
                            Thang = luong.Thang,
                            SoNgayLam = luong.SoNgayLam,
                            ThuongChuyenCan = (int)luong.ThuongChuyenCan,
                            ThuongHieuSuat = (int)luong.ThuongHieuSuat,
                            SoGioLamThem = (int)luong.SoGioLamThem,
                            KhoanTru = (int)luong.KhoanTru
                        };

            return query.ToList();
        }

    }
}
