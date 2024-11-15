using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietDonDat_DTO
    {
        public string MaDonDat { get; set; }
        public int ID { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham {  set; get; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }

        // Calculated field for Total Price
        public float TongGia
        {
            get { return SoLuong * DonGia; }
        }
        public ChiTietDonDat_DTO() { }

        public ChiTietDonDat_DTO(string maDonDat, int iD, string maSanPham, string tenSanPham, int soLuong, int donGia)
        {
            MaDonDat = maDonDat;
            ID = iD;
            MaSanPham = maSanPham;
            TenSanPham = tenSanPham;
            SoLuong = soLuong;
            DonGia = donGia;
        }
    }
}
