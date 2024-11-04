using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang_DTO
    {
        public string MaKhachHang { get; set; }   // Mã khách hàng
        public string TenKhachHang { get; set; }  // Tên khách hàng
        public string SoDienThoai { get; set; }   // Số điện thoại
        public int DiemTichLuy { get; set; }      // Điểm tích lũy

        // Constructor không tham số
        public KhachHang_DTO()
        {
            DiemTichLuy = 0; // Mặc định điểm tích lũy là 0
        }

        // Constructor có tham số
        public KhachHang_DTO(string maKhachHang, string tenKhachHang, string soDienThoai, int diemTichLuy)
        {
            MaKhachHang = maKhachHang;
            TenKhachHang = tenKhachHang;
            SoDienThoai = soDienThoai;
            DiemTichLuy = diemTichLuy;
        }
    }
}
