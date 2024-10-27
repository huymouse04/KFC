using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;

namespace DAO
{
    public class NhaCungCap_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

        public NhaCungCap_DAO() { }

        public NhaCungCap GetNhaCungCapByMa(string maNhaCungCap)
        {
            if (string.IsNullOrWhiteSpace(maNhaCungCap))
            {
                throw new ArgumentException("Mã nhà cung cấp không thể rỗng hoặc null", nameof(maNhaCungCap));
            }

            return DB.NhaCungCaps.FirstOrDefault(ncc => ncc.MaNhaCungCap == maNhaCungCap);
        }

        public bool IsMaNhaCungCapExists(string maNhaCungCap)
        {
            if (string.IsNullOrWhiteSpace(maNhaCungCap))
            {
                throw new ArgumentException("Mã nhà cung cấp không thể rỗng hoặc null", nameof(maNhaCungCap));
            }
            return DB.NhaCungCaps.Any(ncc => ncc.MaNhaCungCap == maNhaCungCap);
        }

        public void AddNhaCungCap(NhaCungCap_DTO nhaCungCap)
        {
            if (nhaCungCap == null)
            {
                throw new ArgumentNullException(nameof(nhaCungCap), "Nhà cung cấp không được null");
            }

            if (IsMaNhaCungCapExists(nhaCungCap.MaNhaCungCap))
            {
                throw new Exception("Mã nhà cung cấp đã tồn tại!");
            }

            var newNhaCungCap = new NhaCungCap
            {
                MaNhaCungCap = nhaCungCap.MaNhaCungCap,
                AnhNhaCungCap = nhaCungCap.AnhNhaCungCap != null ? new Binary(nhaCungCap.AnhNhaCungCap) : null,
                TenNhaCungCap = nhaCungCap.TenNhaCungCap,
                DiaChi = nhaCungCap.DiaChi,
                SoDienThoai = nhaCungCap.SoDienThoai,
                GhiChu = nhaCungCap.GhiChu
            };

            try
            {
                DB.NhaCungCaps.InsertOnSubmit(newNhaCungCap);
                DB.SubmitChanges();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi thêm nhà cung cấp
                throw new Exception("Lỗi khi thêm nhà cung cấp: " + ex.Message);
            }
        }

        public List<NhaCungCap_DTO> GetAllNhaCungCap()
        {
            return (from ncc in DB.NhaCungCaps
                    select new NhaCungCap_DTO
                    {
                        MaNhaCungCap = ncc.MaNhaCungCap,
                        TenNhaCungCap = ncc.TenNhaCungCap,
                        AnhNhaCungCap = ncc.AnhNhaCungCap != null ? ncc.AnhNhaCungCap.ToArray() : null,
                        DiaChi = ncc.DiaChi,
                        SoDienThoai = ncc.SoDienThoai,
                        GhiChu = ncc.GhiChu
                    }).ToList();
        }

        public void UpdateNhaCungCap(NhaCungCap_DTO nhaCungCap)
        {
            if (nhaCungCap == null)
            {
                throw new ArgumentNullException(nameof(nhaCungCap), "Nhà cung cấp không được null");
            }

            var existingNhaCungCap = DB.NhaCungCaps.FirstOrDefault(ncc => ncc.MaNhaCungCap == nhaCungCap.MaNhaCungCap);
            if (existingNhaCungCap != null)
            {
                existingNhaCungCap.TenNhaCungCap = nhaCungCap.TenNhaCungCap;
                existingNhaCungCap.AnhNhaCungCap = nhaCungCap.AnhNhaCungCap != null ? new Binary(nhaCungCap.AnhNhaCungCap) : null;
                existingNhaCungCap.DiaChi = nhaCungCap.DiaChi;
                existingNhaCungCap.SoDienThoai = nhaCungCap.SoDienThoai;
                existingNhaCungCap.GhiChu = nhaCungCap.GhiChu;

                try
                {
                    DB.SubmitChanges();
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khi cập nhật nhà cung cấp
                    throw new Exception("Lỗi khi cập nhật nhà cung cấp: " + ex.Message);
                }
            }
            else
            {
                throw new Exception("Không tìm thấy nhà cung cấp với mã: " + nhaCungCap.MaNhaCungCap);
            }
        }

        public void DeleteNhaCungCap(string maNhaCungCap)
        {
            if (string.IsNullOrWhiteSpace(maNhaCungCap))
            {
                throw new ArgumentException("Mã nhà cung cấp không thể rỗng hoặc null", nameof(maNhaCungCap));
            }

            var existingNhaCungCap = DB.NhaCungCaps.FirstOrDefault(ncc => ncc.MaNhaCungCap == maNhaCungCap);
            if (existingNhaCungCap != null)
            {
                DB.NhaCungCaps.DeleteOnSubmit(existingNhaCungCap);
                try
                {
                    DB.SubmitChanges();
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khi xóa nhà cung cấp
                    throw new Exception("Lỗi khi xóa nhà cung cấp: " + ex.Message);
                }
            }
            else
            {
                throw new Exception("Không tìm thấy nhà cung cấp với mã: " + maNhaCungCap);
            }
        }
    }
}
