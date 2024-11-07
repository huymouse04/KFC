using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ThucDon_DAO
    {
        private KFCDataContext db = new KFCDataContext(Connection_DAO.ConnectionString);

        public List<ThucDon_DTO> LayDanhSachThucDon()
        {
            try
            {
                // Lấy danh sách thực đơn
                var thucDonList = db.ThucDons.ToList();

                // Tạo danh sách DTO
                var result = new List<ThucDon_DTO>();

                foreach (var td in thucDonList)
                {
                    var kho = db.Khos.FirstOrDefault(k => k.MaSanPham == td.MaSanPham);
                    var loaiHang = db.LoaiHangs.FirstOrDefault(lh => lh.MaLoaiHang == td.MaLoaiHang);

                    var thucDonDTO = new ThucDon_DTO
                    {
                        MaSanPham = td.MaSanPham,
                        TenSanPham = td.TenSanPham,
                        DonGia = td.DonGia.HasValue ? (float)td.DonGia.Value : 0,
                        HinhAnh = td.HinhAnh != null ? td.HinhAnh.ToArray() : new byte[0],
                        MaLoaiHang = td.MaLoaiHang
                    };

                    result.Add(thucDonDTO);
                }

                return result; // Trả về danh sách không null
            }
            catch (Exception ex)
            {
                // Ghi log hoặc xử lý lỗi
                throw new Exception("Lỗi khi lấy danh sách thực đơn: " + ex.Message);
            }
        }
        public DataTable MaLH(string maSanPham)
        {
            // Truy vấn để lấy thông tin MaLoaiHang và TenLoaiHang dựa trên MaSanPham từ Kho và LoaiHang
            var query = from k in db.Khos
                        join lh in db.LoaiHangs on k.MaLoaiHang equals lh.MaLoaiHang
                        where k.MaSanPham == maSanPham
                        select new
                        {
                            MaSanPham = k.MaSanPham,
                            MaLoaiHang = lh.MaLoaiHang,
                            TenLoaiHang = lh.TenLoaiHang
                        };

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MaSanPham", typeof(string));
            dataTable.Columns.Add("MaLoaiHang", typeof(string));
            dataTable.Columns.Add("TenLoaiHang", typeof(string));

            foreach (var item in query)
            {
                dataTable.Rows.Add(item.MaSanPham, item.MaLoaiHang, item.TenLoaiHang);
            }

            return dataTable;
        }
        public bool ThemThucDon(ThucDon_DTO thucDon)
        {
            try
            {
                // Kiểm tra nếu mã sản phẩm đã tồn tại
                if (db.ThucDons.Any(td => td.MaSanPham == thucDon.MaSanPham))
                {
                    throw new Exception("Mã sản phẩm đã tồn tại.");
                }

                ThucDon newThucDon = new ThucDon
                {
                    MaSanPham = thucDon.MaSanPham,
                    TenSanPham = thucDon.TenSanPham,
                    DonGia = thucDon.DonGia,
                    HinhAnh = thucDon.HinhAnh,
                    MaLoaiHang = thucDon.MaLoaiHang
                };
                db.ThucDons.InsertOnSubmit(newThucDon);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc hiển thị thông báo lỗi chi tiết nếu cần
                throw new Exception("Lỗi khi thêm thực đơn: " + ex.Message);
            }
        }
        public bool XoaThucDon(string maSanPham)
        {
            try
            {
                var thucDon = db.ThucDons.FirstOrDefault(td => td.MaSanPham == maSanPham);

                if (thucDon == null)
                {
                    Console.WriteLine("Không tìm thấy sản phẩm với mã: " + maSanPham);
                    return false; 
                }

              
                db.ThucDons.DeleteOnSubmit(thucDon);
                db.SubmitChanges();
                Console.WriteLine("Đã xóa sản phẩm thành công: " + maSanPham);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa thực đơn: " + ex.Message);
                return false;
            }
        }
        public ThucDon_DTO LayThucDonTheoMa(string maSP)
        {
            var khuyenMai = db.ThucDons.FirstOrDefault(km => km.MaSanPham == maSP);
            if (khuyenMai != null)
            {
                return new ThucDon_DTO(
                    khuyenMai.MaSanPham,
                    khuyenMai.TenSanPham,
                    khuyenMai.DonGia.HasValue ? (float)khuyenMai.DonGia.Value : 0,
                    khuyenMai.HinhAnh != null ? khuyenMai.HinhAnh.ToArray() : new byte[0],
                    khuyenMai.MaLoaiHang
                    
                );
            }
            return null;
        }
        public bool CapNhatThucDon(ThucDon_DTO thucDon)
        {
            try
            {
                var thucdon = db.ThucDons.FirstOrDefault(td => td.MaSanPham == thucDon.MaSanPham);
                if (thucdon != null)
                {
                    thucdon.TenSanPham=thucDon.TenSanPham;
                    thucdon.HinhAnh = thucDon.HinhAnh;
                    thucdon.MaLoaiHang = thucDon.MaLoaiHang;
                    thucdon.DonGia = thucDon.DonGia;
                    db.SubmitChanges(); // Lưu thay đổi vào database
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public List<ThucDon_DTO> TimKiemKThucDonTheoMa(string maTD)
        {
            var thucDons = db.ThucDons
                              .Where(td => td.MaSanPham.Contains(maTD))
                              .AsEnumerable() 
                              .Select(td => new ThucDon_DTO
                              {
                                  MaSanPham = td.MaSanPham,
                                  TenSanPham = td.TenSanPham,
                                  DonGia = td.DonGia.HasValue ? (float)td.DonGia.Value : 0,
                                  HinhAnh = td.HinhAnh != null ? td.HinhAnh.ToArray() : new byte[0],
                                  MaLoaiHang = td.MaLoaiHang
                              }).ToList();

            return thucDons;
        }

        public List<ThucDon_DTO> TimKiemKThucDonTheoTen(string tenTD)
        {
            var thucDons = db.ThucDons
                              .Where(td => td.TenSanPham.Contains(tenTD))
                              .AsEnumerable() 
                              .Select(td => new ThucDon_DTO
                              {
                                  MaSanPham = td.MaSanPham,
                                  TenSanPham = td.TenSanPham,
                                  DonGia = td.DonGia.HasValue ? (float)td.DonGia.Value : 0,
                                  HinhAnh = td.HinhAnh != null ? td.HinhAnh.ToArray() : new byte[0],
                                  MaLoaiHang = td.MaLoaiHang
                              }).ToList();

            return thucDons;
        }

    }
}