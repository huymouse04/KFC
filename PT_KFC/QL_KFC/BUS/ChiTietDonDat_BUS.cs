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


        public void AddChiTietDonDatOrCombo(string maDonDat, string maSanPhamOrCombo, int soLuong)
        {

                dao.AddChiTietDonDatOrCombo(maDonDat, maSanPhamOrCombo, soLuong);
            

        }


        public void AddComboToOrder(string maDonDat, string maCombo, int comboQuantity)
        {
            dao.AddComboToOrder(maDonDat,maCombo,comboQuantity);
        }


        public List<ChiTietDonDat_DTO> GetChiTietDonDatByMaDon(string maDonDat)
        {
            var chiTietDonDats = dao.GetChiTietDonDatByMaDon(maDonDat); // Gọi DAO để lấy dữ liệu

            // Chuyển dữ liệu từ DAO (ChiTietDonDat) sang DTO (ChiTietDonDat_DTO) trước khi trả về
            List<ChiTietDonDat_DTO> chiTietDTOs = chiTietDonDats.Select(c => new ChiTietDonDat_DTO
            {
                ID = c.ID,
                MaDonDat = c.MaDonDat,
                MaSanPham = c.MaSanPham,
                SoLuong = c.SoLuong,
                DonGia = (int)c.DonGia
            }).ToList();

            return chiTietDTOs;
        }
        
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
