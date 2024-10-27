using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class Kho_BUS
    {
        private Kho_DAO khoDAO = new Kho_DAO();

        public List<Kho_DTO> GetAllKho()
        {
            return khoDAO.GetAllKho();
        }
        public List<string> GetAllMaSanPham()
        {
            return khoDAO.GetMaSanPham();
        }
        public bool CheckMaSanPhamExists(string maSanPham)
        {
            var khoList = GetAllKho(); // Lấy tất cả sản phẩm
            return khoList.Any(k => k.MaSanPham == maSanPham); // Kiểm tra nếu mã sản phẩm đã tồn tại
        }

        public void AddKho(Kho_DTO kho)
        {
            khoDAO.AddKho(kho);
        }

        public void UpdateKho(Kho_DTO kho, string maSanPhamCu)
        {
            // Kiểm tra nếu mã sản phẩm mới chưa tồn tại hoặc là mã cũ đang chỉnh sửa
            khoDAO.UpdateKho(kho, maSanPhamCu); // Gọi DAO để cập nhật
        }

        public void DeleteKho(string maSanPham)
        {
            khoDAO.DeleteKho(maSanPham);
        }

        public Kho_DTO TimKiemSanPhamTheoMa(string maSanPham)
        {
            return khoDAO.TimKiemSanPhamTheoMa(maSanPham);
        }
    }
}
