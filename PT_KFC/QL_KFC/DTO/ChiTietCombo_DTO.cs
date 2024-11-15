using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietCombo_DTO
    {
        public int MaChiTietCombo { get; set; }
        public string MaCombo { get; set; }
        public string MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public int GiaSanPham { get; set; }

        public ChiTietCombo_DTO() { }

        public ChiTietCombo_DTO(int maChiTietCombo, string maCombo, string maSanPham, int soLuong, int giaSanPham)
        {
            MaChiTietCombo = maChiTietCombo;
            MaCombo = maCombo;
            MaSanPham = maSanPham;
            SoLuong = soLuong;
            GiaSanPham = giaSanPham;
        }
    }
}
