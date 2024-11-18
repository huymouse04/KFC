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

        public void AddChiTietDonDatOrCombo(string maDonDat, string maSanPhamOrCombo, int soLuong)
        {
            // Kiểm tra xem MaDonDat có tồn tại trong bảng DonDat không
            var donDat = DB.DonDats.FirstOrDefault(d => d.MaDonDat == maDonDat);

            if (donDat == null)
            {
                // Thêm một bản ghi mới vào bảng DonDat nếu không tồn tại
                donDat = new DonDat
                {
                    MaDonDat = maDonDat,
                    // Thêm các thuộc tính khác của DonDat nếu cần
                };
                DB.DonDats.InsertOnSubmit(donDat);
                DB.SubmitChanges();  // Commit thêm bản ghi DonDat
            }

            // Kiểm tra nếu là mã combo
            var combo = DB.Combos.FirstOrDefault(c => c.MaCombo == maSanPhamOrCombo);
            if (combo != null)
            {
                // Nếu là combo, lấy phần trăm giảm giá của combo
                var phanTramGiamGia = combo.PhanTramGiam;

                var comboDetails = DB.ChiTietCombos.Where(cd => cd.MaCombo == maSanPhamOrCombo).ToList();
                if (!comboDetails.Any())
                {
                    throw new Exception($"Combo '{maSanPhamOrCombo}' không có sản phẩm nào.");
                }

                // Thêm từng sản phẩm trong combo vào chi tiết đơn đặt
                foreach (var detail in comboDetails)
                {
                    // Lấy thông tin sản phẩm từ ThucDon
                    var product = DB.ThucDons.FirstOrDefault(t => t.MaSanPham == detail.MaSanPham);
                    if (product == null)
                    {
                        throw new Exception($"Sản phẩm '{detail.MaSanPham}' không tồn tại trong bảng ThucDon.");
                    }

                    // Tính giá sau khi áp dụng giảm giá combo
                    double donGiaSauGiam = Convert.ToDouble(product.DonGia * (1 - phanTramGiamGia / 100.0));

                    var chiTiet = new ChiTietDonDat
                    {
                        MaDonDat = maDonDat,
                        MaSanPham = detail.MaSanPham,
                        SoLuong = detail.SoLuong * soLuong, // Nhân số lượng sản phẩm với số lượng combo
                        DonGia = (int)donGiaSauGiam // Giá của sản phẩm sau giảm giá
                    };

                    DB.ChiTietDonDats.InsertOnSubmit(chiTiet);
                }

                DB.SubmitChanges(); // Lưu thay đổi vào DB
            }
            else
            {
                // Nếu không phải combo, kiểm tra xem mã sản phẩm có tồn tại trong bảng ThucDon không
                var sanPham = DB.ThucDons.FirstOrDefault(t => t.MaSanPham == maSanPhamOrCombo);
                if (sanPham == null)
                {
                    throw new Exception($"Mã sản phẩm '{maSanPhamOrCombo}' không tồn tại trong bảng ThucDon.");
                }

                var chiTiet = new ChiTietDonDat
                {
                    MaDonDat = maDonDat,
                    MaSanPham = maSanPhamOrCombo,
                    SoLuong = soLuong,
                    DonGia = (int)sanPham.DonGia // Giá của sản phẩm
                };

                DB.ChiTietDonDats.InsertOnSubmit(chiTiet);
                DB.SubmitChanges(); // Lưu thay đổi vào DB
            }
        }




        // Phương thức lấy danh sách chi tiết đơn đặt theo mã đơn đặt
        public List<ChiTietDonDat> GetChiTietDonDatByMaDon(string maDonDat)
        {
            // Truy vấn vào bảng ChiTietDonDat để lấy các bản ghi theo MaDonDat
            var query = DB.ChiTietDonDats.Where(c => c.MaDonDat == maDonDat).ToList();
            return query;
        }

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
                                   DonGia = (int)c.DonGia
                               }).ToList();

            return chiTietList;
        }

        public void AddComboToOrder(string maDonDat, string maCombo, int comboQuantity)
        {
        //    // Lấy thông tin combo và các sản phẩm thuộc combo
        //    var combo = DB.Combos.FirstOrDefault(c => c.MaCombo == maCombo);
        //    if (combo == null)
        //    {
        //        throw new Exception($"Combo '{maCombo}' không tồn tại.");
        //    }

        //    var phanTramGiamGia = combo.PhanTramGiam; // Giả sử bạn có trường này lưu % giảm giá

        //    var comboDetails = DB.ChiTietCombos.Where(cd => cd.MaCombo == maCombo).ToList();
        //    if (!comboDetails.Any())
        //    {
        //        throw new Exception($"Combo '{maCombo}' không có sản phẩm nào.");
        //    }

        //    // Thêm từng sản phẩm trong combo vào chi tiết đơn đặt
        //    foreach (var detail in comboDetails)
        //    {
        //        // Lấy thông tin sản phẩm từ ThucDon
        //        var product = DB.ThucDons.FirstOrDefault(t => t.MaSanPham == detail.MaSanPham);
        //        if (product == null)
        //        {
        //            throw new Exception($"Sản phẩm '{detail.MaSanPham}' không tồn tại trong bảng ThucDon.");
        //        }

        //        double donGiaSauGiam = Convert.ToDouble(product.DonGia * (1 - phanTramGiamGia / 100.0));


        //        var chiTiet = new ChiTietDonDat
        //        {
        //            MaDonDat = maDonDat,
        //            MaSanPham = detail.MaSanPham,
        //            SoLuong = detail.SoLuong * comboQuantity, // Nhân số lượng sản phẩm với số lượng combo
        //            DonGia = (int)donGiaSauGiam // Giá của sản phẩm
        //        };

        //        DB.ChiTietDonDats.InsertOnSubmit(chiTiet);
        //    }

        //    DB.SubmitChanges(); // Lưu thay đổi vào DB
        }
        public void AddChiTietDonDat(ChiTietDonDat_DTO dto)
        {
            //    // Kiểm tra xem MaDonDat có tồn tại trong bảng DonDat không
            //    var donDat = DB.DonDats.FirstOrDefault(d => d.MaDonDat == dto.MaDonDat);

            //    if (donDat == null)
            //    {
            //        // Thêm một bản ghi mới vào bảng DonDat nếu không tồn tại
            //        donDat = new DonDat
            //        {
            //            MaDonDat = dto.MaDonDat,
            //            // Thêm các thuộc tính khác của DonDat nếu cần
            //        };
            //        DB.DonDats.InsertOnSubmit(donDat);
            //        DB.SubmitChanges();  // Commit thêm bản ghi DonDat
            //    }

            //    // Kiểm tra xem MaSanPham có tồn tại trong bảng ThucDon không
            //    var sanPham = DB.ThucDons.FirstOrDefault(t => t.MaSanPham == dto.MaSanPham);

            //    if (sanPham == null)
            //    {
            //        throw new Exception($"MaSanPham '{dto.MaSanPham}' không tồn tại trong bảng ThucDon.");
            //    }

            //    // Tiến hành thêm bản ghi vào bảng ChiTietDonDat
            //    var chiTiet = new ChiTietDonDat
            //    {
            //        MaDonDat = dto.MaDonDat,
            //        MaSanPham = dto.MaSanPham,
            //        SoLuong = dto.SoLuong,
            //        DonGia = (int)dto.DonGia
            //    };

            //    DB.ChiTietDonDats.InsertOnSubmit(chiTiet);
            //    DB.SubmitChanges();
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
                                      DonGia = (int)c.DonGia
                                  })
                                  .FirstOrDefault();
            return chiTiet;
        }

        // Method to add a new order detail
      

        // Method to update an order detail
        public void UpdateChiTietDonDat(ChiTietDonDat_DTO dto)
        {
            // Kiểm tra tính hợp lệ của MaSanPham
            var sanPham = DB.ThucDons.FirstOrDefault(t => t.MaSanPham == dto.MaSanPham);
            if (sanPham == null)
            {
                throw new Exception($"Sản phẩm '{dto.MaSanPham}' không tồn tại trong bảng ThucDon.");
            }

            // Tìm bản ghi theo ID
            var chiTiet = DB.ChiTietDonDats
                           .FirstOrDefault(c => c.ID == dto.ID);

            if (chiTiet != null)
            {
                chiTiet.MaDonDat = dto.MaDonDat;
                chiTiet.MaSanPham = dto.MaSanPham;
                chiTiet.SoLuong = dto.SoLuong;
                chiTiet.DonGia = (int)dto.DonGia;

                DB.SubmitChanges();  // Lưu thay đổi vào cơ sở dữ liệu
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
