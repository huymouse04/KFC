using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhanVien_BUS
    {
        private NhanVien_DAO dao = new NhanVien_DAO();

        public NhanVien_BUS() { }

        // Phương thức tìm kiếm nhân viên
        public List<NhanVien_DTO> SearchNhanVien(string searchTerm)
        {
            return dao.SearchNhanVien(searchTerm); // Gọi phương thức tìm kiếm từ DAO
        }


        // Lấy nhân viên theo mã
        public NhanVien_DTO GetNhanVienByMa(string maNhanVien)
        {
            var nhanVien = dao.GetNhanVienByMa(maNhanVien);
            if (nhanVien != null)
            {
                // Kiểm tra thông tin nhân viên được trả về
                Console.WriteLine("Lấy thông tin nhân viên thành công: " + nhanVien.TenNhanVien);

                return new NhanVien_DTO
                {
                    MaNhanVien = nhanVien.MaNhanVien,
                    TenNhanVien = nhanVien.TenNhanVien,
                    GioiTinh = nhanVien.GioiTinh,
                    DiaChi = nhanVien.DiaChi,
                    SoDienThoai = nhanVien.SoDienThoai,
                    Email = nhanVien.Email,
                    NgaySinh = nhanVien.NgaySinh,
                    AnhNhanVien = nhanVien.AnhNhanVien != null ? nhanVien.AnhNhanVien.ToArray() : null, // Chuyển đổi Binary sang byte[]
                    ChucVu = nhanVien.ChucVu,
                    SoGioLam = (int)(nhanVien.SoGioLam ?? 0) // Đảm bảo SoGioLam không null
                };
            }
            else
            {
                Console.WriteLine("Không tìm thấy nhân viên với mã: " + maNhanVien);
            }
            return null;
        }


        // Thêm nhân viên mới
        public void AddNhanVien(NhanVien_DTO nhanVien)
        {
            ValidateNhanVien(nhanVien);

            // Không cần chuyển đổi nếu AnhNhanVien là byte[]
            dao.AddNhanVien(nhanVien);
        }

        // Lấy tất cả nhân viên
        public List<NhanVien_DTO> GetAllNhanVien()
        {
            return dao.GetAllNhanVien();
        }

        // Cập nhật thông tin nhân viên
        public void UpdateNhanVien(NhanVien_DTO nhanVien)
        {
            ValidateNhanVien(nhanVien);

            // Không cần chuyển đổi nếu AnhNhanVien là byte[]
            dao.UpdateNhanVien(nhanVien);
        }

        // Xóa nhân viên
        public void DeleteNhanVien(string maNhanVien)
        {
            if (string.IsNullOrWhiteSpace(maNhanVien))
            {
                throw new ArgumentException("Mã nhân viên không thể rỗng hoặc null");
            }

            dao.DeleteNhanVien(maNhanVien);
        }

        // Kiểm tra thông tin nhân viên
        private void ValidateNhanVien(NhanVien_DTO nhanVien)
        {
            if (nhanVien == null)
            {
                throw new ArgumentNullException(nameof(nhanVien), "Thông tin nhân viên không thể null");
            }

            if (string.IsNullOrWhiteSpace(nhanVien.MaNhanVien))
            {
                throw new ArgumentException("Mã nhân viên không thể rỗng hoặc null", nameof(nhanVien.MaNhanVien));
            }

            // Thêm các kiểm tra khác như TenNhanVien, SoDienThoai, Email nếu cần  
            if (string.IsNullOrWhiteSpace(nhanVien.TenNhanVien))
            {
                throw new ArgumentException("Tên nhân viên không thể rỗng hoặc null", nameof(nhanVien.TenNhanVien));
            }
        }
    }
}
