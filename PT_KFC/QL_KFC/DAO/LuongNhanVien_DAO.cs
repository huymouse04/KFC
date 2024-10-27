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
                Luong l = new Luong
                {
                    MaNhanVien = luong.MaNhanVien,
                    LuongCoBan = luong.LuongCoBan, // Cast to double?  
                    Thang = luong.Thang,
                    SoNgayLam = luong.SoNgayLam,
                    ThuongChuyenCan = luong.ThuongChuyenCan, // Cast to double?  
                    ThuongHieuSuat = luong.ThuongHieuSuat // Cast to double?  
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
        // Sửa thông tin lương  
        public bool SuaLuong(LuongNhanVien_DTO luong)
        {
            try
            {
                // Tìm kiếm đối tượng trong cơ sở dữ liệu dựa trên MaNhanVien và Thang (khóa chính)
                var existingLuong = DB.Luongs.FirstOrDefault(x => x.MaNhanVien == luong.MaNhanVien && x.Thang == luong.Thang);

                if (existingLuong != null)
                {
                    // Cập nhật các trường khác
                    existingLuong.LuongCoBan = luong.LuongCoBan;
                    existingLuong.SoNgayLam = luong.SoNgayLam;
                    existingLuong.ThuongChuyenCan = luong.ThuongChuyenCan;
                    existingLuong.ThuongHieuSuat = luong.ThuongHieuSuat;

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
                Console.WriteLine(ex.Message);
                return false;
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
                            LuongCoBan = (int)luong.LuongCoBan,
                            Thang = luong.Thang,
                            SoNgayLam = (int)luong.SoNgayLam,
                            ThuongChuyenCan = (int)luong.ThuongChuyenCan,
                            ThuongHieuSuat = (int)luong.ThuongHieuSuat
                        }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách lương: " + ex.Message);
                return new List<LuongNhanVien_DTO>();
            }
        }

        // Phương thức tìm kiếm nhân viên dựa trên tham số nhập vào
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
                            ChucVu = nhanVien.ChucVu, // lấy chức vụ từ bảng nhân viên
                            LuongCoBan = (int)luong.LuongCoBan,
                            Thang = luong.Thang,
                            SoNgayLam = (int)luong.SoNgayLam,
                            ThuongChuyenCan = (int)luong.ThuongChuyenCan,
                            ThuongHieuSuat = (int)luong.ThuongHieuSuat
                        };
            return query.ToList();
        }

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
                    LuongCoBan = (int)l.LuongCoBan,
                    Thang = l.Thang,
                    SoNgayLam = (int)l.SoNgayLam,
                    ThuongChuyenCan = (int)l.ThuongChuyenCan,
                    ThuongHieuSuat = (int)l.ThuongHieuSuat
                })
                .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách lương: " + ex.Message);
            }
        }
        public LuongNhanVien_DTO GetLuongNhanVienByMa(string maNhanVien)
        {
            // Giả sử bạn đang sử dụng LINQ để truy vấn
            var result = (from l in DB.Luongs
                          where l.MaNhanVien == maNhanVien
                          select new LuongNhanVien_DTO
                          {
                              MaNhanVien = l.MaNhanVien,
                              LuongCoBan = (int)l.LuongCoBan,  // Kiểm tra kiểu dữ liệu
                              Thang = l.Thang,
                              SoNgayLam = (int)l.SoNgayLam,
                              ThuongChuyenCan = (int)l.ThuongChuyenCan,
                              ThuongHieuSuat = (int)l.ThuongHieuSuat
                          }).FirstOrDefault();
            return result;
        }
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
                            LuongCoBan = (int)luong.LuongCoBan,
                            Thang = luong.Thang,
                            SoNgayLam = (int)luong.SoNgayLam,
                            ThuongChuyenCan = (int)luong.ThuongChuyenCan,
                            ThuongHieuSuat = (int)luong.ThuongHieuSuat
                        };

            return query.ToList();
        }

    }
}
