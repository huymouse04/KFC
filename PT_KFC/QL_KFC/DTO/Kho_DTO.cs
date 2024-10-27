using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Kho_DTO
    {
        public string MaSanPham { get; set; }  // Mã sản phẩm  
        public string TenSanPham { get; set; }  // Tên sản phẩm  
        public int SoLuong { get; set; }        // Số lượng  
        public string DonViTinh { get; set; }   // Đơn vị tính  
        public float DonGia { get; set; }       // Đơn giá  
        public string MaLoaiHang { get; set; }  // Mã loại hàng  

        // Constructor không tham số  
        public Kho_DTO() { }

        // Constructor có tham số  
        public Kho_DTO(string maSanPham, string tenSanPham, int soLuong, string donViTinh, float donGia, string maLoaiHang)
        {
            MaSanPham = maSanPham;
            TenSanPham = tenSanPham;
            SoLuong = soLuong;
            DonViTinh = donViTinh;
            DonGia = donGia;
            MaLoaiHang = maLoaiHang;
        }
    }
}
