using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Ban_DTO
    {
        public string MaBan { get; set; }       // Mã bàn
        public string TenBan { get; set; }      // Tên bàn
        public bool TrangThaiBan { get; set; }  // Trạng thái bàn (Đang sử dụng / Trống)

        // Constructor không tham số
        public Ban_DTO()
        {
            TrangThaiBan = false; // Mặc định là bàn trống
        }

        // Constructor có tham số
        public Ban_DTO(string maBan, string tenBan, bool trangThaiBan)
        {
            MaBan = maBan;
            TenBan = tenBan;
            TrangThaiBan = trangThaiBan;
        }
    }
}
