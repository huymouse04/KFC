using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThucDon_DTO
    {
        public string MaSanPham { get; set; } // Mã sản phẩm
        public string TenSanPham { get; set; } // Tên sản phẩm
        public float DonGia { get; set; } // Đơn giá
        public byte[] HinhAnh { get; set; } // Hình ảnh dưới dạng byte[]
        public string MaLoaiHang { get; set; } // Mã loại hàng

        // Constructor mặc định
        public ThucDon_DTO() { }

        // Constructor với tất cả các tham số
        public ThucDon_DTO(string maSanPham, string tenSanPham, float donGia,byte[] hinhAnh ,string maLoaiHang )
        {
            MaSanPham = maSanPham ?? throw new ArgumentNullException(nameof(maSanPham));
            TenSanPham = tenSanPham ?? throw new ArgumentNullException(nameof(tenSanPham));
            DonGia = donGia;
            MaLoaiHang = maLoaiHang ?? throw new ArgumentNullException(nameof(maLoaiHang));
            HinhAnh = hinhAnh ?? Array.Empty<byte>(); // Tránh null bằng cách sử dụng mảng rỗng
        }
    }

}
