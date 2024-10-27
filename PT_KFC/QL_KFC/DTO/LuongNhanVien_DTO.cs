using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LuongNhanVien_DTO
    {
        public string MaNhanVien { get; set; }

        public string TenNhanVien { get; set; } // Để hiển thị tên nhân viên
        public string ChucVu { get; set; } // Để hiển thị chức vụ}  

        public int LuongCoBan { get; set; }
        public int Thang { get; set; }
        public int SoNgayLam { get; set; }
        public int ThuongChuyenCan { get; set; }
        public int ThuongHieuSuat { get; set; }

        public int TongLuong
        {
            get
            {
                // Nếu giá trị null, sử dụng 0 thay vì null.  
                return (LuongCoBan * SoNgayLam) +
                       (ThuongChuyenCan) +
                       (ThuongHieuSuat);
            }
        }

        public LuongNhanVien_DTO() { }

        public LuongNhanVien_DTO(string maNhanVien, int luongCoBan, int thang, int soNgayLam, int thuongChuyenCan, int thuongHieuSuat)
        {
            MaNhanVien = maNhanVien;
            LuongCoBan = luongCoBan;
            Thang = thang;
            SoNgayLam = soNgayLam;
            ThuongChuyenCan = thuongChuyenCan;
            ThuongHieuSuat = thuongHieuSuat;
        }
    }
}
