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
        public  DateTime? ThoiGianDen { get; set; } // Thời gian khách đến
        public DateTime? ThoiGianRoi { get; set; } // Thời gian khách rời
        public bool TrangThaiBan { get; set; }  // Trạng thái bàn (Đang sử dụng / Trống)
        public string MaDonDat {  get; set; }

        // Constructor không tham số
        public Ban_DTO()
        {
            TrangThaiBan = false; // Mặc định là bàn trống
        }

        public Ban_DTO(string maBan, string tenBan, DateTime? thoiGianDen, DateTime? thoiGianRoi, bool trangThaiBan, string maDonDat)
        {
            MaBan = maBan;
            TenBan = tenBan;
            ThoiGianDen = thoiGianDen;
            ThoiGianRoi = thoiGianRoi;
            TrangThaiBan = trangThaiBan;
            MaDonDat = maDonDat;
        }
    }
}
