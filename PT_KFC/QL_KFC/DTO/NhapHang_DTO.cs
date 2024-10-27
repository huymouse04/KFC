using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhapHang_DTO
    {
        public int MaNhapHang { get; set; }
        public string MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
        public double? DonGia { get; set; }
        public DateTime NgayNhap { get; set; }
        public string MaLoaiHang { get; set; }
        public string MaNhaCungCap { get; set; }
        public string TenSanPham { get; set; }
        public NhapHang_DTO() { }
        public NhapHang_DTO(int maNhapHang, string maSanPham, int soLuong, string donViTinh, double donGia, DateTime ngayNhap, string maLoaiHang, string maNhaCungCap, string tenSanPham)
        {
            MaNhapHang = maNhapHang;
            MaSanPham = maSanPham;
            SoLuong = soLuong;
            DonViTinh = donViTinh;
            DonGia = donGia;
            NgayNhap = ngayNhap;
            MaLoaiHang = maLoaiHang;
            MaNhaCungCap = maNhaCungCap;
            TenSanPham = tenSanPham;
        }
    }
}
