using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace DAO
{
    public class Ban_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

        public Ban_DAO() { }

        // Phương thức tìm kiếm bàn dựa trên tham số nhập vào
        public List<Ban_DTO> SearchBan(string searchTerm)
        {
            try
            {
                var query = DB.Bans.AsQueryable();

                var results = query.Where(ban =>
                    ban.MaBan.Contains(searchTerm) ||
                    ban.TenBan.Contains(searchTerm)).ToList();

                List<Ban_DTO> banDtos = results.Select(ban => new Ban_DTO
                {
                    MaBan = ban.MaBan,
                    TenBan = ban.TenBan,
                    TrangThaiBan = ban.TrangThaiBan ?? false // Thêm giá trị mặc định là false
                }).ToList();

                return banDtos;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        public Ban GetBanByMa(string maBan)
        {
            return DB.Bans.FirstOrDefault(ban => ban.MaBan == maBan);
        }

        public bool IsMaBanExists(string maBan)
        {
            return DB.Bans.Any(ban => ban.MaBan == maBan);
        }

        public void AddBan(Ban_DTO ban)
        {
            try
            {
                if (IsMaBanExists(ban.MaBan))
                {
                    throw new Exception("Mã bàn đã tồn tại!");
                }

                var newBan = new Ban
                {
                    MaBan = ban.MaBan,
                    TenBan = ban.TenBan,
                    TrangThaiBan = ban.TrangThaiBan
                };

                DB.Bans.InsertOnSubmit(newBan);
                DB.SubmitChanges();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public List<Ban_DTO> GetAllBan()
        {
            var bans = from ban in DB.Bans
                       select new Ban_DTO
                       {
                           MaBan = ban.MaBan,
                           TenBan = ban.TenBan,
                           TrangThaiBan = ban.TrangThaiBan ?? false
                       };

            return bans.ToList();
        }

        public void UpdateBan(Ban_DTO ban)
        {
            try
            {
                if (ban == null)
                {
                    throw new ArgumentNullException(nameof(ban), "Bàn không được null");
                }

                var existingBan = DB.Bans.FirstOrDefault(b => b.MaBan == ban.MaBan);
                if (existingBan != null)
                {
                    existingBan.TenBan = ban.TenBan;
                    existingBan.TrangThaiBan = ban.TrangThaiBan;

                    DB.SubmitChanges();
                }
                else
                {
                    throw new Exception("Bàn không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void DeleteBan(string maBan)
        {
            try
            {
                var existingBan = DB.Bans.FirstOrDefault(ban => ban.MaBan == maBan);
                if (existingBan != null)
                {
                    DB.Bans.DeleteOnSubmit(existingBan);
                    DB.SubmitChanges();
                }
                else
                {
                    throw new Exception("Bàn không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void HandleException(Exception ex)
        {
            if (ex is ArgumentNullException)
            {
                throw new Exception("Lỗi: Đối tượng truyền vào không được null. Chi tiết: " + ex.Message);
            }
            else if (ex is InvalidOperationException)
            {
                throw new Exception("Lỗi: Hoạt động không hợp lệ. Chi tiết: " + ex.Message);
            }
            else if (ex is SqlException)
            {
                throw new Exception("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
            else
            {
                throw new Exception("Lỗi không xác định: " + ex.Message);
            }
        }
    }
}
