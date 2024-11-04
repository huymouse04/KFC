using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS
{
    public class NhapHang_BUS
    {
        private NhapHang_DAO dao = new NhapHang_DAO();

        public NhapHang_BUS() { }

        public void AddNhapHang(NhapHang_DTO nhapHang)
        {
            ValidateNhapHang(nhapHang);
            dao.AddNhapHang(nhapHang); // Thực hiện thêm vào DAO
        }

        public List<NhapHang_DTO> GetAllNhapHang()
        {
            return dao.GetAllNhapHang();
        }

        public List<NhapHang_DTO> GetNhapHangByMa(int maNhapHang)
        {
            if (maNhapHang <= 0)
            {
                throw new ArgumentException("Mã nhập hàng không hợp lệ", nameof(maNhapHang));
            }

            return dao.GetNhapHangByMa(maNhapHang); // Trả về danh sách
        }

        public List<NhapHang_DTO> GetNhapHangByMaSP(string maSP)
        {
            if (string.IsNullOrWhiteSpace(maSP))
            {
                throw new ArgumentException("Mã sản phẩm không hợp lệ", nameof(maSP));
            }

            return dao.GetNhapHangByMaSP(maSP); // Trả về danh sách
        }

        public List<NhapHang_DTO> GetNhapHangByMaLH(string maLH)
        {
            if (string.IsNullOrWhiteSpace(maLH))
            {
                throw new ArgumentException("Mã loại hàng không hợp lệ", nameof(maLH));
            }

            return dao.GetNhapHangByMaLH(maLH); // Trả về danh sách
        }

        public void UpdateNhapHang(NhapHang_DTO nhapHang)
        {
            ValidateNhapHang(nhapHang);
            dao.UpdateNhapHang(nhapHang); // Thực hiện cập nhật vào DAO
        }
        public void UpdateSLKho(string maSP, int soLuong)
        {
            if (string.IsNullOrWhiteSpace(maSP))
            {
                throw new ArgumentException("Mã sản phẩm không hợp lệ", nameof(maSP));
            }

            dao.UpdateKhoSoLuong(maSP, soLuong);
        }
        public void DeleteNhapHang(int maNhapHang)
        {
            if (maNhapHang <= 0)
            {
                throw new ArgumentException("Mã nhập hàng không hợp lệ", nameof(maNhapHang));
            }

            dao.DeleteNhapHang(maNhapHang);
        }
        public List<NhapHang_DTO> GetNhapHangByTenSP(string tenSP)
        {
            var nhapHangDAO = new NhapHang_DAO();
            return nhapHangDAO.GetNhapHangByTenSP(tenSP);
        }

        private void ValidateNhapHang(NhapHang_DTO nhapHang)
        {
            if (nhapHang == null)
            {
                throw new ArgumentNullException(nameof(nhapHang), "Thông tin nhập hàng không thể null");
            }

            if (string.IsNullOrWhiteSpace(nhapHang.MaSanPham))
            {
                throw new ArgumentException("Mã sản phẩm không thể rỗng hoặc null", nameof(nhapHang.MaSanPham));
            }

            if (nhapHang.SoLuong <= 0)
            {
                throw new ArgumentException("Số lượng nhập hàng phải lớn hơn 0", nameof(nhapHang.SoLuong));
            }

            if (nhapHang.DonGia <= 0)
            {
                throw new ArgumentException("Đơn giá phải lớn hơn 0", nameof(nhapHang.DonGia));
            }

            if (string.IsNullOrWhiteSpace(nhapHang.DonViTinh))
            {
                throw new ArgumentException("Đơn vị tính không thể rỗng hoặc null", nameof(nhapHang.DonViTinh));
            }
        }
        public List<NhapHang_DTO> GetNhapHangByMaNCC(string maNCC)
        {
            if (string.IsNullOrWhiteSpace(maNCC))
            {
                throw new ArgumentException("Mã nhà cung cấp không hợp lệ", nameof(maNCC));
            }

            return dao.GetNhapHangByMaNCC(maNCC);
        }

        public DataTable GetAllNCC()
        {
            return dao.GetAllNCC();
        }

        public DataTable GetAllLH()
        {
            return dao.GetAllLH();
        }
        public DataTable GetAllLH2(string malh)
        {
            return dao.GetAllLH2(malh);
        }

        public NhapHang_DTO GetTenSanPhamByMa(string maSanPham)
        {
            return dao.GetTenSanPhamByMa(maSanPham);
        }
        public DataTable GetAllSP()
        {
            return dao.GetAllSP();
        }
        public List<NhapHang_DTO> GetNhapHangByConditions(string maSanPham, string maLoaiHang, string maNhaCungCap)
        {
            return dao.GetNhapHangByConditions(maSanPham, maLoaiHang, maNhaCungCap);
        }
    }
}
