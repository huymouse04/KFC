using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhaCungCap_BUS
    {
        private NhaCungCap_DAO dao = new NhaCungCap_DAO();

        public NhaCungCap_BUS() { }

        // Phương thức tìm kiếm nhà cung cấp
        public List<NhaCungCap_DTO> SearchNhaCungCap(string searchTerm)
        {
            return dao.SearchNhaCungCap(searchTerm); // Gọi phương thức tìm kiếm từ DAO
        }

        // Lấy nhà cung cấp theo mã
        public NhaCungCap_DTO GetNhaCungCapByMa(string maNhaCungCap)
        {
            var nhaCungCap = dao.GetNhaCungCapByMa(maNhaCungCap);
            if (nhaCungCap != null)
            {
                // Kiểm tra thông tin nhà cung cấp được trả về
                Console.WriteLine("Lấy thông tin nhà cung cấp thành công: " + nhaCungCap.TenNhaCungCap);

                return new NhaCungCap_DTO
                {
                    MaNhaCungCap = nhaCungCap.MaNhaCungCap,
                    TenNhaCungCap = nhaCungCap.TenNhaCungCap,
                    DiaChi = nhaCungCap.DiaChi,
                    SoDienThoai = nhaCungCap.SoDienThoai,
                    GhiChu = nhaCungCap.GhiChu,
                    AnhNhaCungCap = nhaCungCap.AnhNhaCungCap != null ? nhaCungCap.AnhNhaCungCap.ToArray() : null // Chuyển đổi Binary sang byte[]
                };
            }
            else
            {
                Console.WriteLine("Không tìm thấy nhà cung cấp với mã: " + maNhaCungCap);
            }
            return null;
        }

        // Thêm nhà cung cấp mới
        public void AddNhaCungCap(NhaCungCap_DTO nhaCungCap)
        {
            ValidateNhaCungCap(nhaCungCap); // Kiểm tra dữ liệu đầu vào
            dao.AddNhaCungCap(nhaCungCap);
        }

        // Lấy tất cả nhà cung cấp
        public List<NhaCungCap_DTO> GetAllNhaCungCap()
        {
            return dao.GetAllNhaCungCap();
        }

        // Cập nhật thông tin nhà cung cấp
        public void UpdateNhaCungCap(NhaCungCap_DTO nhaCungCap)
        {
            ValidateNhaCungCap(nhaCungCap); // Kiểm tra dữ liệu đầu vào
            dao.UpdateNhaCungCap(nhaCungCap);
        }

        // Xóa nhà cung cấp
        public void DeleteNhaCungCap(string maNhaCungCap)
        {
            if (string.IsNullOrWhiteSpace(maNhaCungCap))
            {
                throw new ArgumentException("Mã nhà cung cấp không thể rỗng hoặc null");
            }

            dao.DeleteNhaCungCap(maNhaCungCap);
        }

        // Kiểm tra thông tin nhà cung cấp
        private void ValidateNhaCungCap(NhaCungCap_DTO nhaCungCap)
        {
            if (nhaCungCap == null)
            {
                throw new ArgumentNullException(nameof(nhaCungCap), "Thông tin nhà cung cấp không thể null");
            }

            if (string.IsNullOrWhiteSpace(nhaCungCap.MaNhaCungCap))
            {
                throw new ArgumentException("Mã nhà cung cấp không thể rỗng hoặc null", nameof(nhaCungCap.MaNhaCungCap));
            }

            if (string.IsNullOrWhiteSpace(nhaCungCap.TenNhaCungCap))
            {
                throw new ArgumentException("Tên nhà cung cấp không thể rỗng hoặc null", nameof(nhaCungCap.TenNhaCungCap));
            }
        }

        public string TermDeleteNhaCungCap(string maNhaCungCap)
        {
            return dao.CheckUsage(maNhaCungCap);
        }
    }
}
