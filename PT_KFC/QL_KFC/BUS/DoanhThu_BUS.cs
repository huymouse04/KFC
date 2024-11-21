using DTO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DoanhThu_BUS
    {
        private DoanhThu_DAO doanhThuDAO = new DoanhThu_DAO();

        // Tìm kiếm doanh thu theo khoảng thời gian
        public List<DoanhThu_DTO> TimKiemDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                if (tuNgay > denNgay)
                {
                    throw new Exception("Ngày bắt đầu không được lớn hơn ngày kết thúc.");
                }
                return doanhThuDAO.TimKiemDoanhThu(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm doanh thu: {ex.Message}");
            }
        }

        // Lọc doanh thu theo tháng và năm
        public List<DoanhThu_DTO> LocDoanhThuTheo(int? thang = null, int? nam = null)
        {
            try
            {
                return doanhThuDAO.LocDoanhThuTheo(null, thang, nam);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lọc doanh thu: {ex.Message}");
            }
        }

        // Lấy tất cả dữ liệu doanh thu
        public List<DoanhThu_DTO> GetAllDoanhThu()
        {
            try
            {
                return doanhThuDAO.GetAllDoanhThu();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy dữ liệu doanh thu: {ex.Message}");
            }
        }

    }
}
