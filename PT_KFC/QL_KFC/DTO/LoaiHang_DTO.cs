using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiHang_DTO
    {
        public LoaiHang_DTO() { }
        public string MaLoaiHang { get; set; }
        public string TenLoaiHang { get; set; }

        public LoaiHang_DTO(string maLoaiHang, string tenLoaiHang)
        {
            MaLoaiHang = maLoaiHang;
            TenLoaiHang = tenLoaiHang;
        }
    }

}
