using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class LuongNhanVien_BUS
    {
        private LuongNhanVien_DAO dao = new LuongNhanVien_DAO();

        public LuongNhanVien_BUS() { }


        public void KiemTraVaThemLuong()
        {
            dao.KiemTraVaThemLuong();
        }

        public bool IsLuongAdded()
        {
            return dao.IsLuongAdded; // Trả về trạng thái đã thêm lương
        }

        public List<LuongNhanVien_DTO> LayDanhSachLuong()
        {
            return dao.LayDanhSachLuong();
        }
    }
}

