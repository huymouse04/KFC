using System;
using System.Collections.Generic;
using DAO;
using DTO;

namespace BUS
{
    public class LoaiHang_BUS
    {
        private LoaiHang_DAO loaiHangDAO = new LoaiHang_DAO();

        // Lấy tất cả loại hàng
        public List<LoaiHang_DTO> GetAllLoaiHang()
        {
            return loaiHangDAO.GetAllLoaiHang();
        }

        // Lấy tất cả mã loại hàng
        public List<string> GetAllMaLoaiHang()
        {
            return loaiHangDAO.GetMaLoaiHang();
        }

        // Thêm loại hàng
        public void AddLoaiHang(LoaiHang_DTO loaiHang)
        {
            loaiHangDAO.AddLoaiHang(loaiHang);
        }

        // Cập nhật loại hàng
        public bool UpdateLoaiHang(LoaiHang_DTO loaiHang)
        {
            return loaiHangDAO.UpdateLoaiHang(loaiHang);
        }
        public bool DeleteLoaiHang(string maLoaiHang)
        {
            if (string.IsNullOrWhiteSpace(maLoaiHang))
            {
                throw new ArgumentException("Mã loại hàng không hợp lệ", nameof(maLoaiHang));
            }

            return loaiHangDAO.DeleteLoaiHang(maLoaiHang); // Gọi phương thức xóa trong DAO
        }
        public bool HasNhapHangWithMaLoai(string maLoaiHang)
        {
            return loaiHangDAO.HasNhapHangWithMaLoai(maLoaiHang);
        }

    }
}
