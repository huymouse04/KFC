using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAO
{
    public class Kho_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

        // Lấy tất cả sản phẩm trong kho
        public List<Kho_DTO> GetAllKho()
        {
            var khoItems = from k in DB.Khos
                           select new Kho_DTO
                           {
                               MaLoaiHang = k.MaLoaiHang, // Đặt trước trong cấu trúc
                               MaSanPham = k.MaSanPham,
                               TenSanPham = k.TenSanPham,
                               SoLuong = k.SoLuong,
                               DonViTinh = k.DonViTinh,
                               DonGia = k.DonGia.HasValue ? (float)k.DonGia.Value : 0f,
                               NgaySanXuat = k.NgaySanXuat,  // Ngày sản xuất
                               NgayHetHan = k.NgayHetHan     // Ngày hết hạn
                           };

            return khoItems.ToList();
        }

        public List<Kho_DTO> GetKhoData()
        {
            using (var context = new KFCDataContext(Connection_DAO.ConnectionString))
            {
                return context.Khos
                              .Select(k => new Kho_DTO
                              {
                                  MaSanPham = k.MaSanPham,
                                  TenSanPham = k.TenSanPham,
                                  SoLuong = k.SoLuong,
                                  DonViTinh = k.DonViTinh,
                                  DonGia = k.DonGia.HasValue ? (float)k.DonGia.Value : 0f,
                                  MaLoaiHang = k.MaLoaiHang,
                                  NgaySanXuat = k.NgaySanXuat,
                                  NgayHetHan = k.NgayHetHan
                              }).ToList();
            }
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
                    MaLoaiHang = k.MaLoaiHang,
                    NgaySanXuat = k.NgaySanXuat,  // Ngày sản xuất
                    NgayHetHan = k.NgayHetHan     // Ngày hết hạn

                }).ToList();

                return khoDtos;
            }
            catch (Exception)
            {

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
                MaLoaiHang = kho.MaLoaiHang,
                NgaySanXuat = kho.NgaySanXuat, // Ngày sản xuất
                NgayHetHan = kho.NgayHetHan     // Ngày hết hạn
            };

            DB.Khos.InsertOnSubmit(newKho);
            DB.SubmitChanges();
        }

        // Cập nhật thông tin sản phẩm trong kho
        public void UpdateKho(Kho_DTO kho)
        {
            try
            {
                var existingKho = DB.Khos.FirstOrDefault(k => k.MaSanPham == kho.MaSanPham);
                if (existingKho != null)
                {
                    existingKho.TenSanPham = kho.TenSanPham;
                    existingKho.SoLuong = kho.SoLuong;
                    existingKho.DonViTinh = kho.DonViTinh;
                    existingKho.DonGia = kho.DonGia;
                    existingKho.MaLoaiHang = kho.MaLoaiHang;
                    existingKho.NgaySanXuat = kho.NgaySanXuat; // Cập nhật ngày sản xuất
                    existingKho.NgayHetHan = kho.NgayHetHan;   // Cập nhật ngày hết hạn

                    DB.SubmitChanges();
                    Console.WriteLine("Cập nhật sản phẩm thành công."); // Ghi log thành công
                }
                else
                {
                    Console.WriteLine("Mã sản phẩm không tồn tại."); // Ghi log không tìm thấy
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật sản phẩm: " + ex.Message); // Ghi log lỗi
            }
        }

        // Xóa sản phẩm khỏi kho
        public void DeleteKho(string maSanPham)
        {
            var kho = DB.Khos.SingleOrDefault(k => k.MaSanPham == maSanPham);
            if (kho != null)
            {
                DB.Khos.DeleteOnSubmit(kho);
                DB.SubmitChanges();
            }
        }

        // Lấy danh sách mã sản phẩm
        public List<string> GetMaSanPham()
        {
            return DB.Khos.Select(sp => sp.MaSanPham).ToList();
        }

        // Tìm kiếm sản phẩm theo mã
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
                              MaLoaiHang = k.MaLoaiHang,
                              NgaySanXuat = k.NgaySanXuat,  // Ngày sản xuất
                              NgayHetHan = k.NgayHetHan     // Ngày hết hạn
                          })
                          .SingleOrDefault();
        }

        // Kiểm tra xem sản phẩm có đang được sử dụng không
        public string CheckUsage(string maSanPham)
        {
            bool existsInNhapHang = DB.NhapHangs.Any(nh => nh.MaSanPham == maSanPham);
            bool existsInChiTietCombo = DB.ChiTietCombos.Any(ct => ct.MaSanPham == maSanPham);
            bool existsInThucDon = DB.ThucDons.Any(ct => ct.MaSanPham == maSanPham);

            string usageMessage = "";

            if (existsInNhapHang)
            {
                usageMessage += "Mã sản phẩm này đang được sử dụng trong bảng Nhập Hàng.\n";
            }

            if (existsInChiTietCombo)
            {
                usageMessage += "Mã sản phẩm này đang được sử dụng trong bảng Chi Tiết Combos";
            }

            if (existsInThucDon)
            {
                usageMessage += "Mã sản phẩm này đang được sử dụng trong bảng Thực Đơn";
            }

            return usageMessage; // Trả về thông báo sử dụng hoặc chuỗi rỗng nếu không có
        }
    }
}
