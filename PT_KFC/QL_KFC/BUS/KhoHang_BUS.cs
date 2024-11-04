using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Windows.Forms;

namespace BUS
{
    public class Kho_BUS
    {
        private Kho_DAO khoDAO = new Kho_DAO();
        
        // Phương thức tìm kiếm nhân viên
        public List<Kho_DTO> SearchKho(string searchTerm)
        {
            return khoDAO.SearchKho(searchTerm); // Gọi phương thức tìm kiếm từ DAO
        }

        // Phương thức tìm kiếm sản phẩm
        public List<Kho_DTO> SearchKho(string searchTerm)
        {
            return khoDAO.SearchKho(searchTerm); // Gọi phương thức tìm kiếm từ DAO
        }

        // Lấy tất cả sản phẩm trong kho
        public List<Kho_DTO> GetAllKho()
        {
            return khoDAO.GetAllKho();
        }

        // Lấy danh sách mã sản phẩm
        public List<string> GetAllMaSanPham()
        {
            return khoDAO.GetMaSanPham();
        }

        // Kiểm tra xem mã sản phẩm có tồn tại không
        public bool CheckMaSanPhamExists(string maSanPham)
        {
            var khoList = GetAllKho(); // Lấy tất cả sản phẩm
            return khoList.Any(k => k.MaSanPham == maSanPham); // Kiểm tra nếu mã sản phẩm đã tồn tại
        }

        // Thêm sản phẩm vào kho
        public void AddKho(Kho_DTO kho)
        {
            khoDAO.AddKho(kho);
        }

        // Cập nhật thông tin sản phẩm trong kho
        public void UpdateKho(Kho_DTO kho)
        {
            khoDAO.UpdateKho(kho);
        }

        // Xóa sản phẩm khỏi kho
        public void DeleteKho(string maSanPham)
        {
            khoDAO.DeleteKho(maSanPham);
        }

        // Tìm kiếm sản phẩm theo mã
        public Kho_DTO TimKiemSanPhamTheoMa(string maSanPham)
        {
            return khoDAO.TimKiemSanPhamTheoMa(maSanPham);
        }

        // Kiểm tra việc sử dụng mã sản phẩm
        public string TermDeleteKho(string maSanPham)
        {
            return khoDAO.CheckUsage(maSanPham);
        }

        // (Tùy chọn) Kiểm tra ngày hết hạn sản phẩm
        public bool IsProductExpired(Kho_DTO kho)
        {
            return kho.NgayHetHan < DateTime.Now; // Trả về true nếu sản phẩm đã hết hạn
        }
    }
}
