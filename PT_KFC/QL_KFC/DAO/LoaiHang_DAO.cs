using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DAO
{
    public class LoaiHang_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

        public LoaiHang_DAO() { }

        // Lấy tất cả loại hàng
        public List<LoaiHang_DTO> GetAllLoaiHang()
        {
            var loaiHangs = from lh in DB.LoaiHangs
                            select new LoaiHang_DTO
                            {
                                MaLoaiHang = lh.MaLoaiHang,
                                TenLoaiHang = lh.TenLoaiHang
                            };

            return loaiHangs.ToList();
        }

        // Lấy mã loại hàng
        public List<string> GetMaLoaiHang()
        {
            return DB.LoaiHangs.Select(lh => lh.MaLoaiHang).ToList();
        }

        // Thêm loại hàng
        public void AddLoaiHang(LoaiHang_DTO loaiHang)
        {
            var newLoaiHang = new LoaiHang
            {
                MaLoaiHang = loaiHang.MaLoaiHang,
                TenLoaiHang = loaiHang.TenLoaiHang
            };

            DB.LoaiHangs.InsertOnSubmit(newLoaiHang);
            DB.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
        }

        // Cập nhật loại hàng
        public bool UpdateLoaiHang(LoaiHang_DTO loaiHang)
        {
            try
            {
                var existingLoaiHang = DB.LoaiHangs.SingleOrDefault(lh => lh.MaLoaiHang == loaiHang.MaLoaiHang);
                if (existingLoaiHang != null)
                {
                    existingLoaiHang.TenLoaiHang = loaiHang.TenLoaiHang;
                    DB.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                    return true; // Cập nhật thành công
                }
                return false; // Không tìm thấy loại hàng
            }
            catch
            {
                return false; // Cập nhật không thành công
            }
        }
        public bool DeleteLoaiHang(string maLoaiHang)
        {
            try
            {
                var loaiHangToDelete = DB.LoaiHangs.SingleOrDefault(lh => lh.MaLoaiHang == maLoaiHang);
                if (loaiHangToDelete != null)
                {
                    DB.LoaiHangs.DeleteOnSubmit(loaiHangToDelete);
                    DB.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                    return true; // Xóa thành công
                }
                return false; // Không tìm thấy loại hàng
            }
            catch (Exception ex)
            {
                // Bạn có thể ghi log hoặc xử lý ngoại lệ ở đây nếu cần
                Console.WriteLine(ex.Message); // Để kiểm tra lỗi
                return false; // Xóa không thành công
            }
        }
        public bool HasNhapHangWithMaLoai(string maLoaiHang)
        {
            return DB.NhapHangs.Any(nh => nh.MaLoaiHang == maLoaiHang);
        }
    }
}
