using System;

namespace DTO
{
    public class KhuyenMai_DTO
    {
        public string MaKhuyenMai { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public decimal GiaTriGiam { get; set; }
        public int SoLuong { get; set; }
        public bool TrangThai { get; set; }

        // Constructor with parameters
        public KhuyenMai_DTO(string maKhuyenMai, DateTime ngayBatDau, DateTime ngayKetThuc, decimal giaTriGiam, int soLuong, bool trangThai)
        {
            MaKhuyenMai = maKhuyenMai;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            GiaTriGiam = giaTriGiam;
            SoLuong = soLuong;
            TrangThai = trangThai;
        }

        // Default constructor
        public KhuyenMai_DTO() { }
    }
}
