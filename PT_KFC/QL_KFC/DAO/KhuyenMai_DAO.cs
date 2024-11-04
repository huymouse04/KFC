using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAO
{
    public class KhuyenMai_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

        public List<KhuyenMai_DTO> GetAllKhuyenMai()
        {
            var khuyenMais = from km in DB.KhuyenMais
                             select new KhuyenMai_DTO
                             {
                                 MaKhuyenMai = km.MaKhuyenMai,
                                 NgayBatDau = km.NgayBatDau,
                                 NgayKetThuc = km.NgayKetThuc,
                                 GiaTriGiam = km.GiaTriGiam ?? 0m, 
                                 SoLuong = km.SoLuong ?? 0,       
                                 TrangThai = km.TrangThai ?? false
                             };

            return khuyenMais.ToList();
        }
        public bool ThemKhuyenMai(KhuyenMai_DTO khuyenMai)
        {
            try
            {
                var newKhuyenMai = new KhuyenMai
                {
                    MaKhuyenMai = khuyenMai.MaKhuyenMai,
                    NgayBatDau = khuyenMai.NgayBatDau,
                    NgayKetThuc = khuyenMai.NgayKetThuc,
                    GiaTriGiam = khuyenMai.GiaTriGiam,
                    SoLuong = khuyenMai.SoLuong,
                    TrangThai = khuyenMai.TrangThai
                };

                DB.KhuyenMais.InsertOnSubmit(newKhuyenMai);
                DB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm khuyến mãi: " + ex.Message);
                return false;
            }
        }
        public string GenerateUniqueMaKhuyenMai()
        {
            // Lấy danh sách các mã khuyến mãi hiện có
            var existingMaKMs = DB.KhuyenMais.Select(km => km.MaKhuyenMai).ToList();

            // Tìm mã khuyến mãi mới
            int newId = 1; // Bắt đầu từ 1
            while (existingMaKMs.Contains($"KM{newId:D2}"))
            {
                newId++;
            }

            // Trả về mã khuyến mãi mới
            return $"KM{newId:D2}";
        }

        public KhuyenMai_DTO LayKhuyenMaiTheoMa(string maKM)
        {
            var khuyenMai = DB.KhuyenMais.FirstOrDefault(km => km.MaKhuyenMai == maKM);
            if (khuyenMai != null)
            {
                return new KhuyenMai_DTO(
                    khuyenMai.MaKhuyenMai,
                    khuyenMai.NgayBatDau,
                    khuyenMai.NgayKetThuc,
                    khuyenMai.GiaTriGiam ?? 0m,
                    khuyenMai.SoLuong ?? 0,
                    khuyenMai.TrangThai ?? false
                );
            }
            return null;
        }
        public bool CapNhatKhuyenMai(KhuyenMai_DTO khuyenMai)
        {
            try
            {
                var kmToUpdate = DB.KhuyenMais.FirstOrDefault(km => km.MaKhuyenMai == khuyenMai.MaKhuyenMai);
                if (kmToUpdate != null)
                {
                    kmToUpdate.NgayBatDau = khuyenMai.NgayBatDau;
                    kmToUpdate.NgayKetThuc = khuyenMai.NgayKetThuc;
                    kmToUpdate.GiaTriGiam = khuyenMai.GiaTriGiam;
                    kmToUpdate.SoLuong = khuyenMai.SoLuong;
                    kmToUpdate.TrangThai = khuyenMai.TrangThai;

                    DB.SubmitChanges(); // Lưu thay đổi vào database
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
            }
            return false;
        }

        public bool XoaKhuyenMai(string maKhuyenMai)
        {
            try
            {
                var kmToDelete = DB.KhuyenMais.FirstOrDefault(km => km.MaKhuyenMai == maKhuyenMai);
                if (kmToDelete != null)
                {
                    DB.KhuyenMais.DeleteOnSubmit(kmToDelete);
                    DB.SubmitChanges(); // Lưu thay đổi vào database
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
            }
            return false;
        }
        public List<KhuyenMai_DTO> TimKiemKhuyenMaiTheoMa(string maKM)
        {
            var khuyenMais = (from km in DB.KhuyenMais
                              where km.MaKhuyenMai.Contains(maKM) 
                              select new KhuyenMai_DTO
                              {
                                  MaKhuyenMai = km.MaKhuyenMai,
                                  NgayBatDau = km.NgayBatDau,
                                  NgayKetThuc = km.NgayKetThuc,
                                  GiaTriGiam = km.GiaTriGiam ?? 0m,
                                  SoLuong = km.SoLuong ?? 0,
                                  TrangThai = km.TrangThai ?? false
                              }).ToList();
            return khuyenMais;
        }


    }
}
