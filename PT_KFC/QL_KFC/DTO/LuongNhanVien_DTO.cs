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
        public string ChucVu { get; set; } // Để hiển thị chức vụ
        public int LuongCoBan { get; set; }
        public int Thang { get; set; }
        public int SoNgayLam { get; set; }
        public int ThuongChuyenCan { get; set; }
        public int ThuongHieuSuat { get; set; }
        public int SoGioLamThem { get; set; } // Số giờ làm thêm
        public int KhoanTru { get; set; } // Khoản trừ

        public int TongLuong
        {
            get
            {
                // Tính tổng lương dựa trên lương cơ bản, số ngày làm việc, tiền thưởng và khoản trừ
                return (LuongCoBan / 30 * SoNgayLam) + // Tính theo số ngày làm việc
                       (ThuongChuyenCan) +
                       (ThuongHieuSuat) +
                       (SoGioLamThem * (LuongCoBan / 30 / 8)) - // Giả định 1 ngày làm 8 giờ
                       (KhoanTru);
            }
        }

        public LuongNhanVien_DTO() { }

        public LuongNhanVien_DTO(string maNhanVien, string tenNhanVien, string chucVu, int luongCoBan, int thang, int soNgayLam, int thuongChuyenCan, int thuongHieuSuat, int soGioLamThem, int khoanTru)
        {
            MaNhanVien = maNhanVien;
            TenNhanVien = tenNhanVien;
            ChucVu = chucVu;
            LuongCoBan = luongCoBan;
            Thang = thang;
            SoNgayLam = soNgayLam;
            ThuongChuyenCan = thuongChuyenCan;
            ThuongHieuSuat = thuongHieuSuat;
            SoGioLamThem = soGioLamThem;
            KhoanTru = khoanTru;
        }
    }
}
