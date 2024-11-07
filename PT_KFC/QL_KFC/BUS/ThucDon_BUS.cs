using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ThucDon_BUS
    {
        ThucDon_DAO dao=new ThucDon_DAO();
        public List<ThucDon_DTO> LayDanhSachThucDon()
        {
            return dao.LayDanhSachThucDon();
        }
        public List<string> LayDanhSachMaSanPham()
        {
            Kho_DAO khoDao = new Kho_DAO();
            return khoDao.GetMaSanPham();
        }
        public DataTable GetAllLH2(string maSP)
        {
            return dao.MaLH(maSP);
        }
        public bool ThemThucDon(ThucDon_DTO thucDon)
        {
            try
            {
                // Kiểm tra dữ liệu cần thiết trước khi gọi DAO
                if (string.IsNullOrWhiteSpace(thucDon.MaSanPham) || string.IsNullOrWhiteSpace(thucDon.TenSanPham))
                {
                    throw new Exception("Dữ liệu không hợp lệ: Mã sản phẩm và tên món ăn không được để trống.");
                }

                return dao.ThemThucDon(thucDon);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi hoặc ghi log nếu cần
                throw new Exception("Lỗi trong BUS khi thêm thực đơn: " + ex.Message);
            }
        }
        public bool XoaThucDon(string maSanPham)
        {
            return dao.XoaThucDon(maSanPham);
        }
        public ThucDon_DTO LayThucDonTheoMa(string maSP)
        {
            return dao.LayThucDonTheoMa(maSP);
        }
        public bool CapNhatThucDon(ThucDon_DTO td)
        {
            return dao.CapNhatThucDon(td);
        }
        public List<ThucDon_DTO> TimKiemTheoMa(string maSP) { 
            return dao.TimKiemKThucDonTheoMa(maSP) ;
        }
        public List<ThucDon_DTO>TimKiemTheoTen(string tenSP)
        {
            return dao.TimKiemKThucDonTheoTen(tenSP) ;
        }
    }
}
