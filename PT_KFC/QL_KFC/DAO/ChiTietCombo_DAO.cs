using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChiTietCombo_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

        public bool CheckProductInCombo(string maCombo, string maSanPham)
        {
            try
            {
                // Kiểm tra xem sản phẩm đã có trong combo chưa
                var existingProduct = DB.ChiTietCombos.FirstOrDefault(ct => ct.MaCombo == maCombo && ct.MaSanPham == maSanPham);
                return existingProduct != null; // Nếu tìm thấy thì trả về true, nghĩa là sản phẩm đã có trong combo
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false; // Nếu có lỗi thì trả về false
            }
        }

        // Lấy danh sách tất cả sản phẩm
        public List<ThucDon_DTO> LayTatCaSanPham()
        {
            return DB.ThucDons.Select(sp => new ThucDon_DTO
            {
                MaSanPham = sp.MaSanPham,
                TenSanPham = sp.TenSanPham,
            }).ToList();
        }

        public bool AddSanPhamToCombo(ChiTietCombo_DTO chiTietCombo)
        {
            try
            {
                var newChiTietCombo = new ChiTietCombo
                {
                    MaCombo = chiTietCombo.MaCombo,
                    MaSanPham = chiTietCombo.MaSanPham,
                    SoLuong = chiTietCombo.SoLuong
                };
                DB.ChiTietCombos.InsertOnSubmit(newChiTietCombo);
                DB.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteSanPhamFromCombo(string maCombo)
        {
            try
            {
                var chiTietComboList = DB.ChiTietCombos.Where(ct => ct.MaCombo == maCombo).ToList();

                foreach (var item in chiTietComboList)
                {
                    DB.ChiTietCombos.DeleteOnSubmit(item); // Xóa từng sản phẩm liên quan đến combo
                }

                DB.SubmitChanges(); // Lưu các thay đổi vào cơ sở dữ liệu
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public bool DeleteSanPhamFromCombo(string maCombo, string maSanPham)
        {
            try
            {
                // Kiểm tra sự tồn tại của bản ghi trong cơ sở dữ liệu
                var productToDelete = DB.ChiTietCombos.SingleOrDefault(ct => ct.MaCombo == maCombo && ct.MaSanPham == maSanPham);

                if (productToDelete != null)
                {
                    // Xóa bản ghi khỏi cơ sở dữ liệu
                    DB.ChiTietCombos.DeleteOnSubmit(productToDelete);
                    DB.SubmitChanges();
                    return true;
                }
                else
                {
                    return false; // Không tìm thấy sản phẩm để xóa
                }
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc thông báo cho người dùng
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }


        // Cập nhật sản phẩm trong combo
        public bool UpdateSanPhamInCombo(ChiTietCombo_DTO chiTietCombo)
        {
            try
            {
                var existingCombo = DB.ChiTietCombos.SingleOrDefault(c => c.MaCombo == chiTietCombo.MaCombo && c.MaSanPham == chiTietCombo.MaSanPham);
                if (existingCombo != null)
                {
                    existingCombo.SoLuong = chiTietCombo.SoLuong;
                    DB.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public List<ChiTietCombo_DTO> LayDanhSachSanPhamTheoCombo(string maCombo)
        {

                var danhSachSanPham = (from ctc in DB.ChiTietCombos
                                       join sp in DB.ThucDons on ctc.MaSanPham equals sp.MaSanPham
                                       where ctc.MaCombo == maCombo
                                       select new ChiTietCombo_DTO
                                       {
                                           MaCombo = maCombo,
                                           MaSanPham = sp.TenSanPham,
                                           SoLuong = ctc.SoLuong
                                       }).ToList();

                return danhSachSanPham;
            
        }

        public List<ChiTietCombo_DTO> LoadChiTietCombos()
        {
            var chiTietCombos = (from ct in DB.ChiTietCombos
                                 select new ChiTietCombo_DTO
                                 {
                                     MaChiTietCombo = ct.MaChiTietCombo,
                                     MaCombo = ct.MaCombo,
                                     MaSanPham = ct.MaSanPham,
                                     SoLuong = ct.SoLuong
                                 }).ToList();

            return chiTietCombos;
        }
    }
}
