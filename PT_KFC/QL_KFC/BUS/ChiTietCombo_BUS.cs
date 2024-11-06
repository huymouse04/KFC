using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietCombo_BUS
    {
        private ChiTietCombo_DAO dao = new ChiTietCombo_DAO();

        // Phương thức lấy danh sách combo
        public List<ChiTietCombo_DTO> GetChiTietCombos()
        {
            return dao.LoadChiTietCombos();
        }

        public List<ChiTietCombo_DTO> LayDanhSachSanPhamTheoCombo(string maCombo)
        {
            return dao.LayDanhSachSanPhamTheoCombo(maCombo);
        }
    }
}
