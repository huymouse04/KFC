using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChiTietCombo_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

        public List<ChiTietCombo_DTO> LayDanhSachSanPhamTheoCombo(string maCombo)
        {

                var danhSachSanPham = (from ctc in DB.ChiTietCombos
                                       join sp in DB.ThucDons on ctc.MaSanPham equals sp.MaSanPham
                                       where ctc.MaCombo == maCombo
                                       select new ChiTietCombo_DTO
                                       {
                                           MaCombo = sp.MaSanPham,
                                           MaSanPham = sp.TenSanPham,
                                           SoLuong = ctc.SoLuong
                                       }).ToList();

                return danhSachSanPham;
            
        }

        public List<ChiTietCombo_DTO> LoadChiTietCombos()
        {
            var chiTietCombos = (from ct in DB.ChiTietCombos
                                 select new ChiTietCombo_DTO
                                 {
                                     MaChiTietCombo = ct.MaChiTietCombo,
                                     MaCombo = ct.MaCombo,
                                     MaSanPham = ct.MaSanPham,
                                     SoLuong = ct.SoLuong
                                 }).ToList();

            return chiTietCombos;
        }
    }
}
