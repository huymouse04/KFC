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

        // Phương thức lấy danh sách combo
        public List<Combo_DTO> GetCombos()
        {
            return dao.LoadCombos();
        }
    }
}
