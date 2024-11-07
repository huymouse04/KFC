using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Combo_BUS
    {
        private Combo_DAO dao = new Combo_DAO();

        // Phương thức gọi đến DAO để lấy thông tin combo từ MaCombo
        public Combo_DTO GetComboByMaCombo(string maCombo)
        {
            try
            {
                // Gọi phương thức GetComboByMaCombo từ Combo_DAO để lấy dữ liệu
                return dao.GetComboByMaCombo(maCombo);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi gọi phương thức từ DAO
                throw new Exception("Lỗi khi lấy combo từ BUS: " + ex.Message);
            }
        }

        public bool AddCombo(Combo_DTO comboDTO)
        {
            dao.AddCombo(comboDTO);
            return true;
        }

        public bool UpdateCombo(Combo_DTO comboDTO)
        {
            dao.UpdateCombo(comboDTO);
            return true;
        }

        public bool DeleteCombo(string maCombo)
        {
            dao.DeleteCombo(maCombo);
            return true;
        }

        // Phương thức lấy danh sách combo
        public List<Combo_DTO> GetCombos()
        {
            return dao.LoadCombos();
        }
    }
}
