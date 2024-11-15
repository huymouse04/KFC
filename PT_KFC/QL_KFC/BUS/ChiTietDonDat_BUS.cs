using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietDonDat_BUS
    {
        private ChiTietDonDat_DAO dao = new ChiTietDonDat_DAO();

        // Method to get all order details
        public List<ChiTietDonDat_DTO> GetAllChiTietDonDat()
        {
            return dao.GetAllChiTietDonDat();
        }

        // Method to get a specific order detail by ID
        public ChiTietDonDat_DTO GetChiTietDonDatById(int id)
        {
            return dao.GetChiTietDonDatById(id);
        }

        // Method to add a new order detail
        public void AddChiTietDonDat(ChiTietDonDat_DTO dto)
        {
            dao.AddChiTietDonDat(dto);
        }

        // Method to update an order detail
        public void UpdateChiTietDonDat(ChiTietDonDat_DTO dto)
        {
            dao.UpdateChiTietDonDat(dto);
        }

        // Method to delete an order detail
        public void DeleteChiTietDonDat(int id)
        {
            dao.DeleteChiTietDonDat(id);
        }
    }
}
