using DAO;
using DTO;
using System;
using System.Collections.Generic;

namespace BUS
{
    public class NhaCungCap_BUS
    {
        private NhaCungCap_DAO dao = new NhaCungCap_DAO();

        public NhaCungCap_BUS() { }

        // Lấy nhà cung cấp theo mã
        public NhaCungCap_DTO GetNhaCungCapByMa(string maNhaCungCap)
        {
            if (string.IsNullOrWhiteSpace(maNhaCungCap))
            {
                throw new ArgumentException("Mã nhà cung cấp không thể rỗng hoặc null", nameof(maNhaCungCap));
            }

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
            ValidateNhaCungCap(nhaCungCap);

            // Không cần chuyển đổi nếu AnhNhaCungCap là byte[]
            try
            {
                dao.AddNhaCungCap(nhaCungCap);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhà cung cấp: " + ex.Message);
            }
        }

        // Lấy tất cả nhà cung cấp
        public List<NhaCungCap_DTO> GetAllNhaCungCap()
        {
            return dao.GetAllNhaCungCap();
        }

        // Cập nhật thông tin nhà cung cấp
        public void UpdateNhaCungCap(NhaCungCap_DTO nhaCungCap)
        {
            ValidateNhaCungCap(nhaCungCap);

            // Không cần chuyển đổi nếu AnhNhaCungCap là byte[]
            try
            {
                dao.UpdateNhaCungCap(nhaCungCap);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật nhà cung cấp: " + ex.Message);
            }
        }

        // Xóa nhà cung cấp
        public void DeleteNhaCungCap(string maNhaCungCap)
        {
            if (string.IsNullOrWhiteSpace(maNhaCungCap))
            {
                throw new ArgumentException("Mã nhà cung cấp không thể rỗng hoặc null", nameof(maNhaCungCap));
            }

            try
            {
                dao.DeleteNhaCungCap(maNhaCungCap);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa nhà cung cấp: " + ex.Message);
            }
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

            // Kiểm tra các thuộc tính khác như TenNhaCungCap, SoDienThoai nếu cần
            if (string.IsNullOrWhiteSpace(nhaCungCap.TenNhaCungCap))
            {
                throw new ArgumentException("Tên nhà cung cấp không thể rỗng hoặc null", nameof(nhaCungCap.TenNhaCungCap));
            }
        }
    }
}
