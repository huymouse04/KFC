using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien_DTO
    {
        public string MaNhanVien { get; set; }
        public byte[] AnhNhanVien { get; set; } // VARBINARY(MAX) trong SQL Server tương ứng với byte[] trong C#  
        public string TenNhanVien { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string ChucVu { get; set; }
        public int SoGioLam { get; set; }

        public NhanVien_DTO() { }

        public NhanVien_DTO(string maNhanVien, byte[] anhNhanVien, string tenNhanVien, string gioiTinh, DateTime? ngaySinh, string soDienThoai, string email, string diaChi, string chucVu, int soGioLam)
        {
            MaNhanVien = maNhanVien;
            AnhNhanVien = anhNhanVien;
            TenNhanVien = tenNhanVien;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            SoDienThoai = soDienThoai;
            Email = email;
            DiaChi = diaChi;
            ChucVu = chucVu;
            SoGioLam = soGioLam;
        }
    }
}
