using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace DAO
{
    public class Ban_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);
        DonDat_DAO daoDonDat = new DonDat_DAO();
        public Ban_DAO() { }

        public Ban_DTO GetBanByMaBan(string maBan)
        {
            try
            {
                if (string.IsNullOrEmpty(maBan))
                {
                    throw new ArgumentException("Mã bàn không được để trống");
                }

                var ban = GetBanByMa(maBan);
                if (ban == null)
                {
                    return null;
                }

                return new Ban_DTO
                {
                    MaBan = ban.MaBan,
                    TenBan = ban.TenBan,
                    ThoiGianDen = ban.ThoiGianDen,
                    ThoiGianRoi = ban.ThoiGianRoi,
                    TrangThaiBan = ban.TrangThaiBan ?? false,
                    MaDonDat = ban.MaDonDat
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin bàn: " + ex.Message);
            }
        }
        public Ban_DTO GetBanByMaDonDat(string maDonDat)
        {
            try
            {
                // Kiểm tra mã đơn đặt hợp lệ
                if (string.IsNullOrEmpty(maDonDat))
                {
                    throw new ArgumentException("Mã đơn đặt không được để trống");
                }

                // Truy vấn trực tiếp để lấy bàn dựa trên MaDonDat
                var ban = DB.Bans.FirstOrDefault(b => b.MaDonDat == maDonDat);

                if (ban == null)
                {
                    return null; // Không tìm thấy bàn liên kết với mã đơn đặt
                }

                // Trả về thông tin bàn dưới dạng DTO
                return new Ban_DTO
                {
                    MaBan = ban.MaBan,
                    TenBan = ban.TenBan,
                    ThoiGianDen = ban.ThoiGianDen,
                    ThoiGianRoi = ban.ThoiGianRoi,
                    TrangThaiBan = ban.TrangThaiBan ?? false,
                    MaDonDat = ban.MaDonDat
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin bàn từ mã đơn đặt: " + ex.Message);
            }
        }

        public string GetMaDonByMaBan(string maBan)
        {
            try
            {
                var ban = DB.Bans.FirstOrDefault(b => b.MaBan == maBan);
                return ban?.MaDonDat; // Returns null if ban is null or MaDonDat is null
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        // Hàm lấy danh sách mã bàn từ bảng Ban
        public List<string> GetDanhSachMaBan()
        {

            var danhSachMaBan = DB.Bans
                                       .Select(b => b.MaBan)
                                       .ToList();
            return danhSachMaBan;

        }

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
                    ThoiGianDen = ban.ThoiGianDen,
                    ThoiGianRoi = ban.ThoiGianRoi,
                    TrangThaiBan = ban.TrangThaiBan ?? false,
                    MaDonDat = ban.MaDonDat,

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
            return DB.Bans.Any(ban => ban.MaBan == maBan);  // Kiểm tra nếu có bất kỳ bàn nào có mã trùng với mã truyền vào
        }

        public void AddBan(Ban_DTO ban)
        {
            try
            {
                // Kiểm tra xem mã bàn đã tồn tại chưa
                if (IsMaBanExists(ban.MaBan))
                {
                    throw new Exception("Mã bàn đã tồn tại!");
                }

                // Khởi tạo đối tượng mới từ DTO
                var newBan = new Ban
                {
                    MaBan = ban.MaBan,
                    TenBan = ban.TenBan,
                    TrangThaiBan = ban.TrangThaiBan,
                    MaDonDat = ban.MaDonDat

                };

                // Kiểm tra và gán ThoiGianDen, nếu không có giá trị thì gán DateTime.MinValue
                newBan.ThoiGianDen = ban.ThoiGianDen ?? DateTime.MinValue;

                // Kiểm tra và gán ThoiGianRoi, nếu không có giá trị thì gán DateTime.MinValue
                newBan.ThoiGianRoi = ban.ThoiGianRoi ?? DateTime.MinValue;

                // Thêm đối tượng vào cơ sở dữ liệu
                DB.Bans.InsertOnSubmit(newBan);
                DB.SubmitChanges();
            }
            catch (Exception ex)
            {
                HandleException(ex); // Xử lý ngoại lệ
            }
        }

        public List<Ban_DTO> GetAllBan()
        {
            var bans = from ban in DB.Bans
                       select new Ban_DTO
                       {
                           MaBan = ban.MaBan,
                           TenBan = ban.TenBan,
                           ThoiGianDen = ban.ThoiGianDen ?? DateTime.Now,
                           ThoiGianRoi = ban.ThoiGianRoi ?? DateTime.Now,
                           TrangThaiBan = ban.TrangThaiBan ?? false,
                           MaDonDat = ban.MaDonDat,
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

                // Tìm bàn hiện tại trong cơ sở dữ liệu
                var existingBan = DB.Bans.FirstOrDefault(b => b.MaBan == ban.MaBan);

                if (existingBan != null)
                {
                    // Cập nhật thông tin cho bàn
                    existingBan.TenBan = ban.TenBan;

                    // Kiểm tra và gán thời gian vào các trường
                    // Nếu ThoiGianDen và ThoiGianRoi là null, sẽ giữ nguyên giá trị cũ hoặc gán DateTime.MinValue nếu cần
                    existingBan.ThoiGianDen = ban.ThoiGianDen ?? existingBan.ThoiGianDen;
                    existingBan.ThoiGianRoi = ban.ThoiGianRoi ?? existingBan.ThoiGianRoi;

                    // Cập nhật trạng thái bàn
                    existingBan.TrangThaiBan = ban.TrangThaiBan;
                    existingBan.MaDonDat = ban.MaDonDat;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    DB.SubmitChanges();
                }
                else
                {
                    throw new Exception("Bàn không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex); // Xử lý lỗi
            }
        }

        public void DeleteBan(string maBan)
        {
            try
            {
                var existingBan = DB.Bans.FirstOrDefault(ban => ban.MaBan == maBan);
                if (existingBan != null)
                {
                    DB.Bans.DeleteOnSubmit(existingBan);  // Xóa bản ghi khỏi cơ sở dữ liệu
                    DB.SubmitChanges();  // Lưu thay đổi
                }
                else
                {
                    throw new Exception("Bàn không tồn tại.");  // Báo lỗi nếu bàn không tồn tại
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);  // Gọi hàm xử lý ngoại lệ nếu có lỗi
            }
        }

        // Phương thức xử lý ngoại lệ
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
