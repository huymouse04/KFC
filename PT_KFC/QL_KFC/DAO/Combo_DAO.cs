using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Combo_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

        public List<Combo_DTO> LoadCombos()
        {
            var combos = (from combo in DB.Combos
                          select new Combo_DTO
                          {
                              MaCombo = combo.MaCombo,
                              TenCombo = combo.TenCombo,
                              GiaCombo = combo.GiaCombo ?? 0, // xử lý null cho giá trị float
                              SoLuong = combo.SoLuong ?? 0,    // xử lý null cho giá trị int
                              NgayBatDau = combo.NgayBatDau.HasValue && combo.NgayBatDau.Value >= new DateTime(1753, 1, 1) ? combo.NgayBatDau.Value : (DateTime?)null,
                              NgayKetThuc = combo.NgayKetThuc.HasValue && combo.NgayKetThuc.Value >= new DateTime(1753, 1, 1) ? combo.NgayKetThuc.Value : (DateTime?)null,
                          }).ToList();

            return combos;
        }
    }
}
