using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.SqlClient;

namespace DAO
{
    public class KhachHang_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

        public KhachHang_DAO() { }


        public List<string> GetDanhSachKhachHang()
        {

            var danhSachKhachHang = DB.KhachHangThanThiets
                                       .Select(b => b.MaKhachHang)
                                       .ToList();
            return danhSachKhachHang;

        }


        // Phương thức tìm kiếm khách hàng dựa trên tham số nhập vào
        public List<KhachHang_DTO> SearchKhachHang(string searchTerm)
        {
            try
            {
                var query = DB.KhachHangThanThiets.AsQueryable();

                var results = query.Where(kh =>
                    kh.MaKhachHang.Contains(searchTerm) ||
                    kh.TenKhachHang.Contains(searchTerm) ||
                    kh.SoDienThoai.Contains(searchTerm)).ToList();

                List<KhachHang_DTO> khachHangDtos = results.Select(kh => new KhachHang_DTO
                {
                    MaKhachHang = kh.MaKhachHang,
                    TenKhachHang = kh.TenKhachHang,
                    SoDienThoai = kh.SoDienThoai,
                    DiemTichLuy = kh.DiemTichLuy ?? 0
                }).ToList();

                return khachHangDtos;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        public KhachHangThanThiet GetKhachHangByMa(string maKhachHang)
        {
            return DB.KhachHangThanThiets.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);
        }

        public bool IsMaKhachHangExists(string maKhachHang)
        {
            return DB.KhachHangThanThiets.Any(kh => kh.MaKhachHang == maKhachHang);
        }

        public void AddKhachHang(KhachHang_DTO khachHang)
        {
            try
            {
                if (IsMaKhachHangExists(khachHang.MaKhachHang))
                {
                    throw new Exception("Mã khách hàng đã tồn tại!");
                }

                var newKhachHang = new KhachHangThanThiet
                {
                    MaKhachHang = khachHang.MaKhachHang,
                    TenKhachHang = khachHang.TenKhachHang,
                    SoDienThoai = khachHang.SoDienThoai,
                    DiemTichLuy = khachHang.DiemTichLuy
                };

                DB.KhachHangThanThiets.InsertOnSubmit(newKhachHang);
                DB.SubmitChanges();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public List<KhachHang_DTO> GetAllKhachHang()
        {
            var khachHangs = from kh in DB.KhachHangThanThiets
                             select new KhachHang_DTO
                             {
                                 MaKhachHang = kh.MaKhachHang,
                                 TenKhachHang = kh.TenKhachHang,
                                 SoDienThoai = kh.SoDienThoai,
                                 DiemTichLuy = kh.DiemTichLuy ?? 0
                             };

            return khachHangs.ToList();
        }

        public void UpdateKhachHang(KhachHang_DTO khachHang)
        {
            try
            {
                if (khachHang == null)
                {
                    throw new ArgumentNullException(nameof(khachHang), "Khách hàng không được null");
                }

                var existingKhachHang = DB.KhachHangThanThiets.FirstOrDefault(kh => kh.MaKhachHang == khachHang.MaKhachHang);
                if (existingKhachHang != null)
                {
                    existingKhachHang.TenKhachHang = khachHang.TenKhachHang;
                    existingKhachHang.SoDienThoai = khachHang.SoDienThoai;
                    existingKhachHang.DiemTichLuy = khachHang.DiemTichLuy;

                    DB.SubmitChanges();
                }
                else
                {
                    throw new Exception("Khách hàng không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void DeleteKhachHang(string maKhachHang)
        {
            try
            {
                var existingKhachHang = DB.KhachHangThanThiets.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);
                if (existingKhachHang != null)
                {
                    DB.KhachHangThanThiets.DeleteOnSubmit(existingKhachHang);
                    DB.SubmitChanges();
                }
                else
                {
                    throw new Exception("Khách hàng không tồn tại.");
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
    }
}
