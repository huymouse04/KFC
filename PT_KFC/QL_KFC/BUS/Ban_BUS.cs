using DAO;
using DTO;
using System;
using System.Collections.Generic;

namespace BUS
{
    public class Ban_BUS
    {
        private Ban_DAO dao = new Ban_DAO();

        public Ban_BUS() { }

        // Phương thức tìm kiếm bàn
        public List<Ban_DTO> SearchBan(string searchTerm)
        {
            return dao.SearchBan(searchTerm); // Gọi phương thức tìm kiếm từ DAO
        }

        // Lấy bàn theo mã
        public Ban_DTO GetBanByMa(string maBan)
        {
            var ban = dao.GetBanByMa(maBan);
            if (ban != null)
            {
                Console.WriteLine("Lấy thông tin bàn thành công: " + ban.TenBan);

                return new Ban_DTO
                {
                    MaBan = ban.MaBan,
                    TenBan = ban.TenBan,
                    TrangThaiBan = ban.TrangThaiBan ?? false
                };
            }
            else
            {
                Console.WriteLine("Không tìm thấy bàn với mã: " + maBan);
            }
            return null;
        }

        // Thêm bàn mới
        public void AddBan(Ban_DTO ban)
        {
            ValidateBan(ban); // Kiểm tra dữ liệu đầu vào
            dao.AddBan(ban);
        }

        // Lấy tất cả bàn
        public List<Ban_DTO> GetAllBan()
        {
            return dao.GetAllBan();
        }

        // Cập nhật thông tin bàn
        public void UpdateBan(Ban_DTO ban)
        {
            ValidateBan(ban); // Kiểm tra dữ liệu đầu vào
            dao.UpdateBan(ban);
        }

        // Xóa bàn
        public void DeleteBan(string maBan)
        {
            if (string.IsNullOrWhiteSpace(maBan))
            {
                throw new ArgumentException("Mã bàn không thể rỗng hoặc null");
            }

            dao.DeleteBan(maBan);
        }

        // Kiểm tra thông tin bàn
        private void ValidateBan(Ban_DTO ban)
        {
            if (ban == null)
            {
                throw new ArgumentNullException(nameof(ban), "Thông tin bàn không thể null");
            }

            if (string.IsNullOrWhiteSpace(ban.MaBan))
            {
                throw new ArgumentException("Mã bàn không thể rỗng hoặc null", nameof(ban.MaBan));
            }

            if (string.IsNullOrWhiteSpace(ban.TenBan))
            {
                throw new ArgumentException("Tên bàn không thể rỗng hoặc null", nameof(ban.TenBan));
            }
        }
    }
}
