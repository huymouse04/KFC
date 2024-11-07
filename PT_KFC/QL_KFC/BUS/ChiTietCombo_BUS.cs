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
    public class ChiTietCombo_BUS
    {
        private ChiTietCombo_DAO dao = new ChiTietCombo_DAO();

        public bool CheckProductInCombo(string maCombo, string maSanPham)
        {
            return dao.CheckProductInCombo(maCombo, maSanPham);
        }


        public List<ThucDon_DTO> LayTatCaSanPham()
        {
            return dao.LayTatCaSanPham();
        }

        public bool AddSanPhamToCombo(ChiTietCombo_DTO chiTietCombo)
        {
            return dao.AddSanPhamToCombo(chiTietCombo);
        }

        public bool DeleteSanPhamFromCombo(string maCombo, string maSanPham)
        {
            return dao.DeleteSanPhamFromCombo(maCombo, maSanPham);
        }

        public bool DeleteSanPhamFromCombo(string maCombo)
        {
            return dao.DeleteSanPhamFromCombo(maCombo);
        }


        public bool UpdateSanPhamInCombo(ChiTietCombo_DTO chiTietCombo)
        {
            return dao.UpdateSanPhamInCombo(chiTietCombo);
        }

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
