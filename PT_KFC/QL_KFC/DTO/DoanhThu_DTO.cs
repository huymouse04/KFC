using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DoanhThu_DTO
    {
        public int MaNhapHang { get; set; }      // Mã nhập hàng
        public int Thang { get; set; }           // Tháng
        public int Nam { get; set; }             // Năm
        public DateTime NgayGhiNhan { get; set; } // Ngày ghi nhận
        public int MaHoaDon { get; set; }         // Mã hóa đơn
        public float TongChiTieu { get; set; }    // Tổng chi tiêu
        public float TongDoanhThu { get; set; }   // Tổng doanh thu

        // Constructor mặc định
        public DoanhThu_DTO() { }

        // Constructor với tham số
        public DoanhThu_DTO(int maNhapHang, int thang, int nam, DateTime ngayGhiNhan, int maHoaDon, float tongChiTieu, float tongDoanhThu)
        {
            MaNhapHang = maNhapHang;
            Thang = thang;
            Nam = nam;
            NgayGhiNhan = ngayGhiNhan;
            MaHoaDon = maHoaDon;
            TongChiTieu = tongChiTieu;
            TongDoanhThu = tongDoanhThu;
        }
    }
}
