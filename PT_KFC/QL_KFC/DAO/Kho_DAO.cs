using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Kho_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);
        public List<Kho_DTO> GetAllKho()
        {
            var khoItems = from k in DB.Khos
                           select new Kho_DTO
                           {
                               MaSanPham = k.MaSanPham,
                               TenSanPham = k.TenSanPham,
                               SoLuong = k.SoLuong,
                               DonViTinh = k.DonViTinh,
                               DonGia = k.DonGia.HasValue ? (float)k.DonGia.Value : 0f,
                               MaLoaiHang = k.MaLoaiHang
                           };

            return khoItems.ToList();
        }

        public List<Kho_DTO> SearchKho(string searchTerm)
        {
            try
            {
                var query = DB.Khos.AsQueryable();

                var results = query.Where(kho =>
                    kho.MaSanPham.Contains(searchTerm) ||
                    kho.TenSanPham.Contains(searchTerm) ||
                    kho.DonViTinh.Contains(searchTerm)).ToList();

                List<Kho_DTO> khoDtos = results.Select(k => new Kho_DTO
                {
                    MaSanPham = k.MaSanPham,
                    TenSanPham = k.TenSanPham,
                    SoLuong = k.SoLuong,
                    DonViTinh = k.DonViTinh,
                    DonGia = k.DonGia.HasValue ? (float)k.DonGia.Value : 0f,
                    MaLoaiHang = k.MaLoaiHang
                }).ToList();

                return khoDtos;
            }
            catch (Exception)
            {
                // Xử lý ngoại lệ ở đây nếu cần, ví dụ ghi log lỗi
                return null;
            }
        }

        public void AddKho(Kho_DTO kho)
        {
            Kho newKho = new Kho
            {
                MaSanPham = kho.MaSanPham,
                TenSanPham = kho.TenSanPham,
                SoLuong = kho.SoLuong,
                DonViTinh = kho.DonViTinh,
                DonGia = kho.DonGia,
                MaLoaiHang = kho.MaLoaiHang
            };

            DB.Khos.InsertOnSubmit(newKho);
            DB.SubmitChanges();
        }


        public void UpdateKho(Kho_DTO kho, string maSanPhamCu)
        {
            var existingKho = DB.Khos.SingleOrDefault(k => k.MaSanPham == maSanPhamCu);
            if (existingKho != null)
            {
                existingKho.MaSanPham = kho.MaSanPham;
                existingKho.TenSanPham = kho.TenSanPham;
                existingKho.SoLuong = kho.SoLuong;
                existingKho.DonViTinh = kho.DonViTinh;
                existingKho.DonGia = kho.DonGia;
                existingKho.MaLoaiHang = kho.MaLoaiHang;

                DB.SubmitChanges();
            }
        }


        public void DeleteKho(string maSanPham)
        {
            var kho = DB.Khos.SingleOrDefault(k => k.MaSanPham == maSanPham);
            if (kho != null)
            {
                DB.Khos.DeleteOnSubmit(kho);
                DB.SubmitChanges();
            }
        }

        public List<string> GetMaSanPham()
        {
            return DB.Khos.Select(sp => sp.MaSanPham).ToList();
        }
        public Kho_DTO TimKiemSanPhamTheoMa(string maSanPham)
        {
            return DB.Khos.Where(k => k.MaSanPham == maSanPham)
                          .Select(k => new Kho_DTO
                          {
                              MaSanPham = k.MaSanPham,
                              TenSanPham = k.TenSanPham,
                              SoLuong = k.SoLuong,
                              DonViTinh = k.DonViTinh,
                              DonGia = k.DonGia.HasValue ? (float)k.DonGia.Value : 0f,
                              MaLoaiHang = k.MaLoaiHang
                          })
                          .SingleOrDefault();
        }
    }
}
