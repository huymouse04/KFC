using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO
{
    public class NhaCungCap_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

        public NhaCungCap_DAO() { }

        // Phương thức tìm kiếm nhà cung cấp dựa trên tham số nhập vào
        public List<NhaCungCap_DTO> SearchNhaCungCap(string searchTerm)
        {
            try
            {
                var query = DB.NhaCungCaps.AsQueryable();

                var results = query.Where(ncc =>
                    ncc.MaNhaCungCap.Contains(searchTerm) ||
                    ncc.TenNhaCungCap.Contains(searchTerm) ||
                    ncc.SoDienThoai.Contains(searchTerm) ||
                    ncc.DiaChi.Contains(searchTerm)).ToList();

                List<NhaCungCap_DTO> nhaCungCapDtos = results.Select(ncc => new NhaCungCap_DTO
                {
                    MaNhaCungCap = ncc.MaNhaCungCap,
                    TenNhaCungCap = ncc.TenNhaCungCap,
                    SoDienThoai = ncc.SoDienThoai,
                    DiaChi = ncc.DiaChi,
                    GhiChu = ncc.GhiChu,
                    AnhNhaCungCap = ncc.AnhNhaCungCap != null ? ncc.AnhNhaCungCap.ToArray() : null
                }).ToList();

                return nhaCungCapDtos;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        public NhaCungCap GetNhaCungCapByMa(string maNhaCungCap)
        {
            // Trả về nhà cung cấp từ cơ sở dữ liệu theo mã nhà cung cấp
            return DB.NhaCungCaps.FirstOrDefault(ncc => ncc.MaNhaCungCap == maNhaCungCap);
        }

        public bool IsMaNhaCungCapExists(string maNhaCungCap)
        {
            return DB.NhaCungCaps.Any(ncc => ncc.MaNhaCungCap == maNhaCungCap);
        }

        public void AddNhaCungCap(NhaCungCap_DTO nhaCungCap)
        {
            try
            {
                if (IsMaNhaCungCapExists(nhaCungCap.MaNhaCungCap))
                {
                    throw new Exception("Mã nhà cung cấp đã tồn tại!");
                }

                var newNhaCungCap = new NhaCungCap
                {
                    MaNhaCungCap = nhaCungCap.MaNhaCungCap,
                    AnhNhaCungCap = nhaCungCap.AnhNhaCungCap != null ? new Binary(nhaCungCap.AnhNhaCungCap) : null,
                    TenNhaCungCap = nhaCungCap.TenNhaCungCap,
                    SoDienThoai = nhaCungCap.SoDienThoai,
                    DiaChi = nhaCungCap.DiaChi,
                    GhiChu = nhaCungCap.GhiChu
                };

                DB.NhaCungCaps.InsertOnSubmit(newNhaCungCap);
                DB.SubmitChanges();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public List<NhaCungCap_DTO> GetAllNhaCungCap()
        {
            var nhaCungCaps = from ncc in DB.NhaCungCaps
                              select new NhaCungCap_DTO
                              {
                                  MaNhaCungCap = ncc.MaNhaCungCap,
                                  AnhNhaCungCap = ncc.AnhNhaCungCap != null ? ncc.AnhNhaCungCap.ToArray() : null,
                                  TenNhaCungCap = ncc.TenNhaCungCap,
                                  SoDienThoai = ncc.SoDienThoai,
                                  DiaChi = ncc.DiaChi,
                                  GhiChu = ncc.GhiChu
                              };

            return nhaCungCaps.ToList();
        }

        public void UpdateNhaCungCap(NhaCungCap_DTO nhaCungCap)
        {
            try
            {
                if (nhaCungCap == null)
                {
                    throw new ArgumentNullException(nameof(nhaCungCap), "Nhà cung cấp không được null");
                }

                var existingNhaCungCap = DB.NhaCungCaps.FirstOrDefault(ncc => ncc.MaNhaCungCap == nhaCungCap.MaNhaCungCap);
                if (existingNhaCungCap != null)
                {
                    existingNhaCungCap.AnhNhaCungCap = nhaCungCap.AnhNhaCungCap != null ? new Binary(nhaCungCap.AnhNhaCungCap) : null;
                    existingNhaCungCap.TenNhaCungCap = nhaCungCap.TenNhaCungCap;
                    existingNhaCungCap.SoDienThoai = nhaCungCap.SoDienThoai;
                    existingNhaCungCap.DiaChi = nhaCungCap.DiaChi;
                    existingNhaCungCap.GhiChu = nhaCungCap.GhiChu;

                    DB.SubmitChanges();
                }
                else
                {
                    throw new Exception("Nhà cung cấp không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void DeleteNhaCungCap(string maNhaCungCap)
        {
            try
            {
                var existingNhaCungCap = DB.NhaCungCaps.FirstOrDefault(ncc => ncc.MaNhaCungCap == maNhaCungCap);
                if (existingNhaCungCap != null)
                {
                    DB.NhaCungCaps.DeleteOnSubmit(existingNhaCungCap);
                    DB.SubmitChanges();
                }
                else
                {
                    throw new Exception("Nhà cung cấp không tồn tại.");
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
