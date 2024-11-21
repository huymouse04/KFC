using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DoanhThu_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

        // Lấy doanh thu từ ngày đến ngày
        public List<DoanhThu_DTO> TimKiemDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                var doanhThuList = (from dt in DB.DoanhThus
                                    where dt.NgayGhiNhan >= tuNgay && dt.NgayGhiNhan <= denNgay
                                    select new DoanhThu_DTO
                                    {
                                        MaNhapHang = dt.MaNhapHang.GetValueOrDefault(),
                                        Thang = dt.Thang,
                                        Nam = dt.Nam,
                                        NgayGhiNhan = dt.NgayGhiNhan,
                                        MaHoaDon = dt.MaHoaDon.GetValueOrDefault(),
                                        TongChiTieu = (float)dt.TongChiTieu.GetValueOrDefault(),
                                        TongDoanhThu = (float)dt.TongDoanhThu.GetValueOrDefault()
                                    }).ToList();

                return doanhThuList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return new List<DoanhThu_DTO>();
            }
        }

        // Lọc doanh thu theo tháng và năm
        public List<DoanhThu_DTO> LocDoanhThuTheo(DateTime? ngay = null, int? thang = null, int? nam = null)
        {
            try
            {
                var query = DB.DoanhThus.AsQueryable();

                if (thang.HasValue && nam.HasValue)
                {
                    query = query.Where(dt => dt.Thang == thang.Value && dt.Nam == nam.Value);
                }
                else if (nam.HasValue)
                {
                    query = query.Where(dt => dt.Nam == nam.Value);
                }

                var doanhThuList = query.Select(dt => new DoanhThu_DTO
                {
                    MaNhapHang = dt.MaNhapHang.GetValueOrDefault(),
                    Thang = dt.Thang,
                    Nam = dt.Nam,
                    NgayGhiNhan = dt.NgayGhiNhan,
                    MaHoaDon = dt.MaHoaDon.GetValueOrDefault(),
                    TongChiTieu = (float)dt.TongChiTieu.GetValueOrDefault(),
                    TongDoanhThu = (float)dt.TongDoanhThu.GetValueOrDefault()
                }).ToList();

                return doanhThuList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return new List<DoanhThu_DTO>();
            }
        }

        // Tự động xóa doanh thu cách đây 6 năm trở lên
        public void TuDongXoaDoanhThuCu()
        {
            try
            {
                var namHienTai = DateTime.Now.Year;
                var doanhThuCu = DB.DoanhThus.Where(dt => dt.Nam <= namHienTai - 6).ToList();

                if (doanhThuCu.Any())
                {
                    DB.DoanhThus.DeleteAllOnSubmit(doanhThuCu);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }

        // Thêm hoặc cập nhật doanh thu
        public bool ThemHoacCapNhatDoanhThu(DoanhThu_DTO doanhThu)
        {
            try
            {
                var existingDoanhThu = DB.DoanhThus.SingleOrDefault(dt => dt.MaNhapHang == doanhThu.MaNhapHang);

                if (existingDoanhThu != null)
                {
                    existingDoanhThu.Thang = doanhThu.Thang;
                    existingDoanhThu.Nam = doanhThu.Nam;
                    existingDoanhThu.NgayGhiNhan = doanhThu.NgayGhiNhan;
                    existingDoanhThu.MaHoaDon = doanhThu.MaHoaDon;
                    existingDoanhThu.TongChiTieu = doanhThu.TongChiTieu;
                    existingDoanhThu.TongDoanhThu = doanhThu.TongDoanhThu;
                }
                else
                {
                    var newDoanhThu = new DoanhThu
                    {
                        MaNhapHang = doanhThu.MaNhapHang,
                        Thang = doanhThu.Thang,
                        Nam = doanhThu.Nam,
                        NgayGhiNhan = doanhThu.NgayGhiNhan,
                        MaHoaDon = doanhThu.MaHoaDon,
                        TongChiTieu = doanhThu.TongChiTieu,
                        TongDoanhThu = doanhThu.TongDoanhThu
                    };
                    DB.DoanhThus.InsertOnSubmit(newDoanhThu);
                }

                DB.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        // Lấy tất cả doanh thu
        public List<DoanhThu_DTO> GetAllDoanhThu()
        {
            try
            {
                var doanhThuList = from dt in DB.DoanhThus
                                   select new DoanhThu_DTO
                                   {
                                       MaNhapHang = dt.MaNhapHang.GetValueOrDefault(),
                                       Thang = dt.Thang,
                                       Nam = dt.Nam,
                                       NgayGhiNhan = dt.NgayGhiNhan,
                                       MaHoaDon = dt.MaHoaDon.GetValueOrDefault(),
                                       TongChiTieu = (float)dt.TongChiTieu.GetValueOrDefault(),
                                       TongDoanhThu = (float)dt.TongDoanhThu.GetValueOrDefault()
                                   };

                return doanhThuList.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return new List<DoanhThu_DTO>();
            }
        }

    }
}