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
                // Kiểm tra null hoặc rỗng cho mã combo và mã sản phẩm
                if (string.IsNullOrWhiteSpace(maCombo))
                {
                    throw new Exception("Mã combo không hợp lệ.");
                }
                if (string.IsNullOrWhiteSpace(maSanPham))
                {
                    throw new Exception("Mã sản phẩm không hợp lệ.");
                }

                // Kiểm tra xem sản phẩm đã có trong combo chưa
                var existingProduct = DB.ChiTietCombos.FirstOrDefault(ct => ct.MaCombo == maCombo && ct.MaSanPham == maSanPham);
                return existingProduct != null; // Nếu tìm thấy thì trả về true
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
                DonGia = (int)sp.DonGia,
            }).ToList();
        }

        public bool AddSanPhamToCombo(ChiTietCombo_DTO chiTietCombo)
        {
            try
            {
                // Kiểm tra null hoặc rỗng cho các trường hợp bắt buộc
                if (string.IsNullOrWhiteSpace(chiTietCombo.MaCombo))
                {
                    throw new Exception("Mã combo không hợp lệ.");
                }

                if (string.IsNullOrWhiteSpace(chiTietCombo.MaSanPham))
                {
                    throw new Exception("Mã sản phẩm không hợp lệ.");
                }

                if (chiTietCombo.SoLuong <= 0)
                {
                    throw new Exception("Số lượng sản phẩm phải lớn hơn 0.");
                }

                // Kiểm tra xem sản phẩm đã có trong combo chưa
                if (CheckProductInCombo(chiTietCombo.MaCombo, chiTietCombo.MaSanPham))
                {
                    throw new Exception("Sản phẩm đã có trong combo.");
                }

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
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false; // Nếu có lỗi thì trả về false
            }
        }


        public bool DeleteSanPhamFromCombo(string maCombo)
        {
            try
            {

                // Kiểm tra null hoặc rỗng cho mã combo và mã sản phẩm
                if (string.IsNullOrWhiteSpace(maCombo))
                {
                    throw new Exception("Mã combo không hợp lệ.");
                }

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
                // Kiểm tra null hoặc rỗng cho mã combo và mã sản phẩm
                if (string.IsNullOrWhiteSpace(maCombo))
                {
                    throw new Exception("Mã combo không hợp lệ.");
                }

                if (string.IsNullOrWhiteSpace(maSanPham))
                {
                    throw new Exception("Mã sản phẩm không hợp lệ.");
                }

                // Kiểm tra sự tồn tại của sản phẩm trong combo
                var productToDelete = DB.ChiTietCombos.SingleOrDefault(ct => ct.MaCombo == maCombo && ct.MaSanPham == maSanPham);

                if (productToDelete != null)
                {
                    DB.ChiTietCombos.DeleteOnSubmit(productToDelete);
                    DB.SubmitChanges();
                    return true;
                }
                else
                {
                    throw new Exception("Không tìm thấy sản phẩm trong combo.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false; // Nếu có lỗi thì trả về false
            }
        }



        // Cập nhật sản phẩm trong combo
        public bool UpdateSanPhamInCombo(ChiTietCombo_DTO chiTietCombo)
        {
            try
            {
                // Kiểm tra tính hợp lệ của soLuong và các mã
                if (chiTietCombo.SoLuong <= 0)
                {
                    throw new Exception("Số lượng sản phẩm phải lớn hơn 0.");
                }

                var existingCombo = DB.ChiTietCombos.SingleOrDefault(c => c.MaCombo == chiTietCombo.MaCombo && c.MaSanPham == chiTietCombo.MaSanPham);
                if (existingCombo != null)
                {
                    existingCombo.SoLuong = chiTietCombo.SoLuong;
                    DB.SubmitChanges();
                    return true;
                }
                else
                {
                    throw new Exception("Không tìm thấy sản phẩm trong combo để cập nhật.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false; // Nếu có lỗi thì trả về false
            }
        }


        public List<ChiTietCombo_DTO> LayDanhSachSanPhamTheoCombo(string maCombo)
        {
            try
            {
                // Kiểm tra tính hợp lệ của maCombo
                if (string.IsNullOrWhiteSpace(maCombo))
                {
                    throw new Exception("Mã combo không hợp lệ.");
                }

                var danhSachSanPham = (from ctc in DB.ChiTietCombos
                                       join sp in DB.ThucDons on ctc.MaSanPham equals sp.MaSanPham
                                       where ctc.MaCombo == maCombo
                                       select new ChiTietCombo_DTO
                                       {
                                           MaCombo = maCombo,
                                           MaSanPham = sp.TenSanPham,
                                           SoLuong = ctc.SoLuong,
                                           GiaSanPham = (int)sp.DonGia,
                                       }).ToList();

                return danhSachSanPham;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return new List<ChiTietCombo_DTO>(); // Trả về danh sách rỗng nếu có lỗi
            }
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
