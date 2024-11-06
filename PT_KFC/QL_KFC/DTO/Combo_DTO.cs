using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Combo_DTO
    {
        public string MaCombo { get; set; }
        public string TenCombo { get; set; }
        public int GiaCombo { get; set; }
        public int SoLuong { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }

        public Combo_DTO() { }

        public Combo_DTO(string maCombo, string tenCombo, int giaCombo, int soLuong, DateTime? ngayBatDau, DateTime? ngayKetThuc)
        {
            MaCombo = maCombo;
            TenCombo = tenCombo;
            GiaCombo = giaCombo;
            SoLuong = soLuong;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
        }
    }
}

