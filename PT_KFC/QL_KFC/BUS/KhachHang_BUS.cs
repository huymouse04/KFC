using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KhachHang_BUS
    {
        private KhachHang_DAO dao = new KhachHang_DAO();

        public KhachHang_BUS() { }


        public List<string> GetDanhSachKhachHang()
        {

           return dao.GetDanhSachKhachHang();
        }


        // Phương thức tìm kiếm khách hàng
        public List<KhachHang_DTO> SearchKhachHang(string searchTerm)
        {
            return dao.SearchKhachHang(searchTerm); // Gọi phương thức tìm kiếm từ DAO
        }

        // Lấy khách hàng theo mã
        public KhachHang_DTO GetKhachHangByMa(string maKhachHang)
        {
            var khachHang = dao.GetKhachHangByMa(maKhachHang);
            if (khachHang != null)
            {
                Console.WriteLine("Lấy thông tin khách hàng thành công: " + khachHang.TenKhachHang);

                return new KhachHang_DTO
                {
                    MaKhachHang = khachHang.MaKhachHang,
                    TenKhachHang = khachHang.TenKhachHang,
                    SoDienThoai = khachHang.SoDienThoai,
                    DiemTichLuy = (int)(khachHang.DiemTichLuy ?? 0)
                };
            }
            else
            {
                Console.WriteLine("Không tìm thấy khách hàng với mã: " + maKhachHang);
            }
            return null;
        }

        // Thêm khách hàng mới
        public void AddKhachHang(KhachHang_DTO khachHang)
        {
            ValidateKhachHang(khachHang); // Kiểm tra dữ liệu đầu vào
            dao.AddKhachHang(khachHang);
        }

        // Lấy tất cả khách hàng
        public List<KhachHang_DTO> GetAllKhachHang()
        {
            return dao.GetAllKhachHang();
        }

        // Cập nhật thông tin khách hàng
        public void UpdateKhachHang(KhachHang_DTO khachHang)
        {
            ValidateKhachHang(khachHang); // Kiểm tra dữ liệu đầu vào
            dao.UpdateKhachHang(khachHang);
        }

        // Xóa khách hàng
        public void DeleteKhachHang(string maKhachHang)
        {
            if (string.IsNullOrWhiteSpace(maKhachHang))
            {
                throw new ArgumentException("Mã khách hàng không thể rỗng hoặc null");
            }

            dao.DeleteKhachHang(maKhachHang);
        }

        // Kiểm tra thông tin khách hàng
        private void ValidateKhachHang(KhachHang_DTO khachHang)
        {
            if (khachHang == null)
            {
                throw new ArgumentNullException(nameof(khachHang), "Thông tin khách hàng không thể null");
            }

            if (string.IsNullOrWhiteSpace(khachHang.MaKhachHang))
            {
                throw new ArgumentException("Mã khách hàng không thể rỗng hoặc null", nameof(khachHang.MaKhachHang));
            }

            if (string.IsNullOrWhiteSpace(khachHang.TenKhachHang))
            {
                throw new ArgumentException("Tên khách hàng không thể rỗng hoặc null", nameof(khachHang.TenKhachHang));
            }
        }
    }
}