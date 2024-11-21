using DAO;
using DTO;
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BUS
{
    public class Ban_BUS
    {
        private Ban_DAO dao = new Ban_DAO();

        public Ban_BUS() { }

        public Ban_DTO GetBanByMaBan(string maBan)
        {
            return dao.GetBanByMaBan(maBan);
        }
        public Ban_DTO GetBanByMaDonDat(string maDonDat)
        {
            return dao.GetBanByMaDonDat(maDonDat);
        }
        public string GetMaDonByMaBan(string maBan)
        {
            try
            {
                if (string.IsNullOrEmpty(maBan))
                {
                    throw new ArgumentException("Mã bàn không được để trống");
                }
                return dao.GetMaDonByMaBan(maBan);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy mã đơn đặt: " + ex.Message);
            }
        }



        public List<string> GetDanhSachMaBan()
        {
            // Gọi hàm từ Ban_DAO để lấy danh sách
            return dao.GetDanhSachMaBan();
        }

        public List<Ban_DTO> SearchBan(string searchTerm)
        {
            return dao.SearchBan(searchTerm);
        }

        public Ban_DTO GetBanByMa(string maBan)
        {
            var ban = dao.GetBanByMa(maBan);
            if (ban != null)
            {
                return new Ban_DTO
                {
                    MaBan = ban.MaBan,
                    TenBan = ban.TenBan,
                    ThoiGianDen = ban.ThoiGianDen,
                    ThoiGianRoi = ban.ThoiGianRoi,
                    TrangThaiBan = ban.TrangThaiBan ?? false
                };
            }
            return null;
        }

        public void AddBan(Ban_DTO ban)
        {
            ValidateBan(ban);
            dao.AddBan(ban);
        }

        public List<Ban_DTO> GetAllBan()
        {
            return dao.GetAllBan();
        }

        public void UpdateBan(Ban_DTO ban)
        {
            ValidateBan(ban);
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

        // Phương thức cập nhật trạng thái bàn về "Trống" sau khi hết thời gian
        public void UpdateBanStatusToEmpty(string maBan)
        {
            if (string.IsNullOrWhiteSpace(maBan))
            {
                throw new ArgumentException("Mã bàn không thể rỗng hoặc null", nameof(maBan));
            }

            // Gọi phương thức trong DAO để cập nhật trạng thái
            dao.UpdateBanStatusToEmptyAfterExpired(maBan);
        }
    }
}
