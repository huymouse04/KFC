using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChiTietDonDat_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

        // Method to get all order details
        public List<ChiTietDonDat_DTO> GetAllChiTietDonDat()
        {
            var chiTietList = (from c in DB.ChiTietDonDats
                               join t in DB.ThucDons on c.MaSanPham equals t.MaSanPham
                               select new ChiTietDonDat_DTO
                               {
                                   MaDonDat = c.MaDonDat,  // Kiểm tra MaDonDat có tồn tại trong ChiTietDonDat không
                                   ID = c.ID,
                                   MaSanPham = c.MaSanPham,
                                   TenSanPham = t.TenSanPham,
                                   SoLuong = c.SoLuong,
                                   DonGia = (float)c.DonGia
                               }).ToList();

            return chiTietList;
        }


        // Method to get a specific order detail by ID
        public ChiTietDonDat_DTO GetChiTietDonDatById(int id)
        {
            var chiTiet = DB.ChiTietDonDats
            .Where(c => c.ID == id)
                                  .Select(c => new ChiTietDonDat_DTO
                                  {
                                      MaDonDat = c.MaDonDat,
                                      ID = c.ID,
                                      MaSanPham = c.MaSanPham,
                                      SoLuong = c.SoLuong,
                                      DonGia = (float)c.DonGia
                                  })
                                  .FirstOrDefault();
            return chiTiet;
        }

        // Method to add a new order detail
        public void AddChiTietDonDat(ChiTietDonDat_DTO dto)
        {
            // Kiểm tra xem MaDonDat có tồn tại trong bảng DonDat không
            var donDat = DB.DonDats.FirstOrDefault(d => d.MaDonDat == dto.MaDonDat);

            if (donDat == null)
            {
                // Thêm một bản ghi mới vào bảng DonDat nếu không tồn tại
                donDat = new DonDat
                {
                    MaDonDat = dto.MaDonDat,
                    // Thêm các thuộc tính khác của DonDat nếu cần
                };
                DB.DonDats.InsertOnSubmit(donDat);
                DB.SubmitChanges();  // Commit thêm bản ghi DonDat
            }

            // Kiểm tra xem MaSanPham có tồn tại trong bảng ThucDon không
            var sanPham = DB.ThucDons.FirstOrDefault(t => t.MaSanPham == dto.MaSanPham);

            if (sanPham == null)
            {
                throw new Exception($"MaSanPham '{dto.MaSanPham}' không tồn tại trong bảng ThucDon.");
            }

            // Tiến hành thêm bản ghi vào bảng ChiTietDonDat
            var chiTiet = new ChiTietDonDat
            {
                MaDonDat = dto.MaDonDat,
                MaSanPham = dto.MaSanPham,
                SoLuong = dto.SoLuong,
                DonGia = dto.DonGia
            };

            DB.ChiTietDonDats.InsertOnSubmit(chiTiet);
            DB.SubmitChanges();
        }




        // Method to update an order detail
        public void UpdateChiTietDonDat(ChiTietDonDat_DTO dto)
        {
            var chiTiet = DB.ChiTietDonDats
                           .FirstOrDefault(c => c.ID == dto.ID); // Use FirstOrDefault
            if (chiTiet != null)
            {
                chiTiet.MaDonDat = dto.MaDonDat;
                chiTiet.MaSanPham = dto.MaSanPham;
                chiTiet.SoLuong = dto.SoLuong;
                chiTiet.DonGia = dto.DonGia;
                DB.SubmitChanges();
            }
        }

        // Method to delete an order detail
        public void DeleteChiTietDonDat(int id)
        {
            var chiTiet = DB.ChiTietDonDats
                          .FirstOrDefault(c => c.ID == id); // Use FirstOrDefault
            if (chiTiet != null)
            {
                DB.ChiTietDonDats.DeleteOnSubmit(chiTiet);
                DB.SubmitChanges();
            }
        }
    }
}
