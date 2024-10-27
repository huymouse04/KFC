using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCap_DTO
    {
        public string MaNhaCungCap { get; set; } // Mã nhà cung cấp  
        public string TenNhaCungCap { get; set; } // Tên nhà cung cấp  
        public byte[] AnhNhaCungCap { get; set; } // Ảnh nhà cung cấp  
        public string DiaChi { get; set; }        // Địa chỉ  
        public string SoDienThoai { get; set; }   // Số điện thoại  
        public string GhiChu { get; set; }        // Ghi chú  

        // Constructor không tham số  
        public NhaCungCap_DTO() { }

        // Constructor có tham số  
        public NhaCungCap_DTO(string maNhaCungCap, string tenNhaCungCap, byte[] anhNhaCungCap, string diaChi, string soDienThoai, string ghiChu)
        {
            MaNhaCungCap = maNhaCungCap;
            TenNhaCungCap = tenNhaCungCap;
            AnhNhaCungCap = anhNhaCungCap;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            GhiChu = ghiChu;
        }
    }
}
