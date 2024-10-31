using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using System.Data.SqlClient;

namespace DAO
{
    public class NhanVien_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

        public NhanVien_DAO() {
            if (string.IsNullOrEmpty(Connection_DAO.ConnectionString))
            {
                throw new InvalidOperationException("Connection string is not initialized. Please initialize it before using the DAO.");
            }
            DB = new KFCDataContext(Connection_DAO.ConnectionString);
        }


        // Phương thức tìm kiếm nhân viên dựa trên tham số nhập vào
        public List<NhanVien_DTO> SearchNhanVien(string searchTerm)
        {
            try
            {
                var query = DB.NhanViens.AsQueryable();

                var results = query.Where(nv =>
                    nv.MaNhanVien.Contains(searchTerm) ||
                    nv.TenNhanVien.Contains(searchTerm) ||
                    nv.SoDienThoai.Contains(searchTerm) ||
                    nv.ChucVu.Contains(searchTerm)).ToList();

                List<NhanVien_DTO> nhanVienDtos = results.Select(nv => new NhanVien_DTO
                {
                    MaNhanVien = nv.MaNhanVien,
                    TenNhanVien = nv.TenNhanVien,
                    SoDienThoai = nv.SoDienThoai,
                    ChucVu = nv.ChucVu,
                    GioiTinh = nv.GioiTinh,
                    NgaySinh = nv.NgaySinh,
                    Email = nv.Email,
                    DiaChi = nv.DiaChi,
                    AnhNhanVien = nv.AnhNhanVien != null ? nv.AnhNhanVien.ToArray() : null,
                    SoGioLam = (int)(nv.SoGioLam ?? 0)
                }).ToList();

                return nhanVienDtos;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        public NhanVien GetNhanVienByMa(string maNhanVien)
        {
            // Trả về nhân viên từ cơ sở dữ liệu theo mã nhân viên
            return DB.NhanViens.FirstOrDefault(nv => nv.MaNhanVien == maNhanVien);
        }

        public bool IsMaNhanVienExists(string maNhanVien)
        {
            return DB.NhanViens.Any(nv => nv.MaNhanVien == maNhanVien);
        }

        public void AddNhanVien(NhanVien_DTO nhanVien)
        {
            try
            {
                if (IsMaNhanVienExists(nhanVien.MaNhanVien))
                {
                    throw new Exception("Mã nhân viên đã tồn tại!");
                }

                // Kiểm tra giới tính
                if (nhanVien.GioiTinh == null || string.IsNullOrWhiteSpace(nhanVien.GioiTinh))
                {
                    throw new Exception("Bạn phải chọn giới tính.");
                }

                // Kiểm tra email hợp lệ
                IsValidGmail(nhanVien.Email);

                var newNhanVien = new NhanVien
                {
                    MaNhanVien = nhanVien.MaNhanVien,
                    AnhNhanVien = nhanVien.AnhNhanVien != null ? new Binary(nhanVien.AnhNhanVien) : null,
                    TenNhanVien = nhanVien.TenNhanVien,
                    GioiTinh = nhanVien.GioiTinh,
                    NgaySinh = nhanVien.NgaySinh,
                    SoDienThoai = nhanVien.SoDienThoai,
                    Email = nhanVien.Email,
                    DiaChi = nhanVien.DiaChi,
                    ChucVu = nhanVien.ChucVu,
                    SoGioLam = nhanVien.SoGioLam
                };

                DB.NhanViens.InsertOnSubmit(newNhanVien);
                DB.SubmitChanges();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public List<NhanVien_DTO> GetAllNhanVien()
        {
            var nhanViens = from nv in DB.NhanViens
                            select new NhanVien_DTO
                            {
                                MaNhanVien = nv.MaNhanVien,
                                AnhNhanVien = nv.AnhNhanVien != null ? nv.AnhNhanVien.ToArray() : null, // Lưu trữ byte[] trực tiếp
                                TenNhanVien = nv.TenNhanVien,
                                GioiTinh = nv.GioiTinh,
                                NgaySinh = nv.NgaySinh.HasValue && nv.NgaySinh.Value >= new DateTime(1753, 1, 1) ? nv.NgaySinh.Value : (DateTime?)null,
                                SoDienThoai = nv.SoDienThoai,
                                Email = nv.Email,
                                DiaChi = nv.DiaChi,
                                ChucVu = nv.ChucVu,
                                SoGioLam = (int)(nv.SoGioLam ?? 0)
                            };

            return nhanViens.ToList();
        }

        public void UpdateNhanVien(NhanVien_DTO nhanVien)
        {
            try
            {
                if (nhanVien == null)
                {
                    throw new ArgumentNullException(nameof(nhanVien), "Nhân viên không được null");
                }

                // Kiểm tra email hợp lệ
                IsValidGmail(nhanVien.Email);

                var existingNhanVien = DB.NhanViens.FirstOrDefault(nv => nv.MaNhanVien == nhanVien.MaNhanVien);
                if (existingNhanVien != null)
                {
                    existingNhanVien.AnhNhanVien = nhanVien.AnhNhanVien != null ? new Binary(nhanVien.AnhNhanVien) : null;
                    existingNhanVien.TenNhanVien = nhanVien.TenNhanVien;
                    existingNhanVien.GioiTinh = nhanVien.GioiTinh;
                    existingNhanVien.NgaySinh = nhanVien.NgaySinh;
                    existingNhanVien.SoDienThoai = nhanVien.SoDienThoai;
                    existingNhanVien.Email = nhanVien.Email;
                    existingNhanVien.DiaChi = nhanVien.DiaChi;
                    existingNhanVien.ChucVu = nhanVien.ChucVu;
                    existingNhanVien.SoGioLam = nhanVien.SoGioLam;

                    DB.SubmitChanges();
                }
                else
                {
                    throw new Exception("Nhân viên không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void DeleteNhanVien(string maNhanVien)
        {
            try
            {
                var existingNhanVien = DB.NhanViens.FirstOrDefault(nv => nv.MaNhanVien == maNhanVien);
                if (existingNhanVien != null)
                {
                    // Kiểm tra xem nhân viên có lương không
                    if (KiemTraNhanVienCoLuong(maNhanVien))
                    {
                        // Xóa tất cả các bản ghi trong bảng lương liên quan đến nhân viên
                        var luongRecords = DB.Luongs.Where(l => l.MaNhanVien == maNhanVien).ToList();
                        DB.Luongs.DeleteAllOnSubmit(luongRecords);
                    }

                    // Xóa nhân viên
                    DB.NhanViens.DeleteOnSubmit(existingNhanVien);
                    DB.SubmitChanges();
                }
                else
                {
                    throw new Exception("Nhân viên không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void HandleException(Exception ex)
        {
            if (ex is ArgumentNullException)
            {
                throw new Exception("Lỗi: Đối tượng truyền vào không được null. Chi tiết: " + ex.Message);
            }
            else if (ex is InvalidOperationException)
            {
                throw new Exception("Lỗi: Hoạt động không hợp lệ. Chi tiết: " + ex.Message);
            }
            else if (ex is SqlException)
            {
                throw new Exception("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
            else
            {
                throw new Exception("Lỗi không xác định: " + ex.Message);
            }
        }

        private bool IsValidGmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("Email không được bỏ trống.");
            }

            if (!email.EndsWith("@gmail.com"))
            {
                throw new Exception("Email phải có đuôi @gmail.com.");
            }
            if (email.Length > 150)
            {
                throw new Exception("Email không được quá 150 ký tự.");
            }

            if (email.Contains(" "))
            {
                throw new Exception("Email không được chứa dấu cách.");
            }

            var validChars = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, validChars))
            {
                throw new Exception("Email không hợp lệ.");
            }

            // Kiểm tra dấu chấm
            if (email.StartsWith(".") || email.EndsWith(".") || email.Contains(".."))
            {
                throw new Exception("Email không được bắt đầu hoặc kết thúc bằng dấu chấm và không được có hai dấu chấm liên tiếp.");
            }

            return true;
        }

        public bool KiemTraNhanVienCoLuong(string maNhanVien)
        {
            using (var context = new KFCDataContext(Connection_DAO.ConnectionString))
            {
                return context.Luongs.Any(l => l.MaNhanVien == maNhanVien);
            }
        }

    }
}

