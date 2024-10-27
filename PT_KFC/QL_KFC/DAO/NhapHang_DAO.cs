using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAO
{
    public class NhapHang_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

        public NhapHang_DAO() { }

        public bool IsMaNhapHangExists(int maNhapHang)
        {
            return DB.NhapHangs.Any(nh => nh.MaNhapHang == maNhapHang);
        }

        public List<NhapHang_DTO> GetAllNhapHang()
        {
            var nhapHangs = from nh in DB.NhapHangs
                            join k in DB.Khos on nh.MaSanPham equals k.MaSanPham
                            join j in DB.LoaiHangs on nh.MaLoaiHang equals j.MaLoaiHang
                            join m in DB.NhaCungCaps on nh.MaNhaCungCap equals m.MaNhaCungCap
                            select new NhapHang_DTO
                            {
                                MaNhapHang = nh.MaNhapHang,
                                MaSanPham = k.MaSanPham,
                                TenSanPham = k.TenSanPham,
                                DonViTinh = nh.DonViTinh,
                                SoLuong = nh.SoLuong,
                                NgayNhap = nh.NgayNhap,
                                MaLoaiHang = j.MaLoaiHang,
                                MaNhaCungCap = m.MaNhaCungCap,
                                DonGia=nh.DonGia

                            };

            return nhapHangs.ToList();
        }
       public List<NhapHang_DTO> GetNhapHangByConditions(string maSanPham, string maLoaiHang, string maNhaCungCap)
{
    var query = from nh in DB.NhapHangs
                join k in DB.Khos on nh.MaSanPham equals k.MaSanPham
                join j in DB.LoaiHangs on nh.MaLoaiHang equals j.MaLoaiHang
                join m in DB.NhaCungCaps on nh.MaNhaCungCap equals m.MaNhaCungCap
                select new NhapHang_DTO
                {
                    MaNhapHang = nh.MaNhapHang,
                    MaSanPham = k.MaSanPham,
                    TenSanPham = k.TenSanPham,
                    DonViTinh = nh.DonViTinh,
                    SoLuong = nh.SoLuong,
                    NgayNhap = nh.NgayNhap,
                    MaLoaiHang = j.MaLoaiHang,
                    MaNhaCungCap = m.MaNhaCungCap,
                    DonGia = nh.DonGia
                };

    if (!string.IsNullOrEmpty(maSanPham))
    {
        query = query.Where(nh => nh.MaSanPham == maSanPham);
    }
    if (!string.IsNullOrEmpty(maLoaiHang))
    {
        query = query.Where(nh => nh.MaLoaiHang == maLoaiHang);
    }
    if (!string.IsNullOrEmpty(maNhaCungCap))
    {
        query = query.Where(nh => nh.MaNhaCungCap == maNhaCungCap);
    }

    return query.ToList();
}


        public void AddNhapHang(NhapHang_DTO nhapHang)
        {
            var newNhapHang = new NhapHang
            {
                MaSanPham = nhapHang.MaSanPham,
                SoLuong = nhapHang.SoLuong,
                DonViTinh = nhapHang.DonViTinh,
                NgayNhap = nhapHang.NgayNhap,
                MaLoaiHang = nhapHang.MaLoaiHang,
                MaNhaCungCap = nhapHang.MaNhaCungCap,
                DonGia = nhapHang.DonGia
            };

            DB.NhapHangs.InsertOnSubmit(newNhapHang);
            DB.SubmitChanges();
            UpdateKhoSoLuong(nhapHang.MaSanPham, nhapHang.SoLuong, nhapHang.TenSanPham, nhapHang.DonViTinh, nhapHang.DonGia, nhapHang.MaLoaiHang);

        }

        public void UpdateKhoSoLuong(string maSanPham, int soLuong, string tenSanPham, string donViTinh, double? donGia, string maLoaiHang)
        {
            // Tìm kiếm sản phẩm trong bảng kho theo mã sản phẩm
            var existingKho = DB.Khos.FirstOrDefault(k => k.MaSanPham == maSanPham);

            // Kiểm tra nếu sản phẩm đã tồn tại trong kho
            if (existingKho != null)
            {
                // Cập nhật số lượng nếu sản phẩm tồn tại
                existingKho.SoLuong += soLuong;
            }
            else
            {
                // Nếu không tồn tại, tạo mới bản ghi kho với thông tin chi tiết
                var newKho = new Kho
                {
                    MaSanPham = maSanPham,
                    TenSanPham = tenSanPham,
                    SoLuong = soLuong,
                    DonViTinh = donViTinh,
                    DonGia = donGia,
                    MaLoaiHang = maLoaiHang
                };
                DB.Khos.InsertOnSubmit(newKho);
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            DB.SubmitChanges();
        }
        public List<NhapHang_DTO> GetNhapHangByTenSP(string tenSP)
        {
            var result = from nh in DB.NhapHangs
                         join k in DB.Khos on nh.MaSanPham equals k.MaSanPham
                         where k.TenSanPham.Contains(tenSP)
                         select new NhapHang_DTO
                         {
                             MaNhapHang = nh.MaNhapHang,
                             MaSanPham = nh.MaSanPham,
                             TenSanPham = k.TenSanPham,
                             DonViTinh = nh.DonViTinh,
                             SoLuong = nh.SoLuong,
                             NgayNhap = nh.NgayNhap,
                             MaLoaiHang = nh.MaLoaiHang,
                             MaNhaCungCap = nh.MaNhaCungCap,
                             DonGia = nh.DonGia
                         };

            return result.ToList();
        }
        public List<NhapHang_DTO> GetNhapHangByMa(int maNhapHang)
        {
            var result = from nh in DB.NhapHangs
                         join k in DB.Khos on nh.MaSanPham equals k.MaSanPham
                         where nh.MaNhapHang == maNhapHang
                         select new NhapHang_DTO

                         {
                             MaNhapHang = nh.MaNhapHang,
                             MaSanPham = nh.MaSanPham,
                             DonViTinh = nh.DonViTinh,
                             SoLuong = nh.SoLuong,
                             NgayNhap = nh.NgayNhap,
                             MaLoaiHang = nh.MaLoaiHang,
                             MaNhaCungCap = nh.MaNhaCungCap,
                             TenSanPham=k.TenSanPham,
                             DonGia = nh.DonGia
                         };

            return result.ToList();
        }

        public List<NhapHang_DTO> GetNhapHangByMaSP(string maSP)
        {
            var result = from nh in DB.NhapHangs
                         join k in DB.Khos on nh.MaSanPham equals k.MaSanPham
                         where nh.MaSanPham == maSP
                         select new NhapHang_DTO
                         {
                                MaNhapHang = nh.MaNhapHang,
                                MaSanPham = nh.MaSanPham,
                                DonViTinh = nh.DonViTinh,
                                SoLuong = nh.SoLuong,
                                NgayNhap = nh.NgayNhap,
                                MaLoaiHang = nh.MaLoaiHang,
                                MaNhaCungCap = nh.MaNhaCungCap,
                                TenSanPham = k.TenSanPham,
                             DonGia = nh.DonGia
                         };

            return result.ToList();  // Trả về danh sách
        }

        public List<NhapHang_DTO> GetNhapHangByMaLH(string maLH)
        {
            var result = from nh in DB.NhapHangs
                         join k in DB.Khos on nh.MaSanPham equals k.MaSanPham
                         where nh.MaLoaiHang == maLH
                         select new NhapHang_DTO
                         {
                             MaNhapHang = nh.MaNhapHang,
                             MaSanPham = nh.MaSanPham,
                             DonViTinh = nh.DonViTinh,
                             SoLuong = nh.SoLuong,
                             NgayNhap = nh.NgayNhap,
                             MaLoaiHang = nh.MaLoaiHang,
                             MaNhaCungCap = nh.MaNhaCungCap,
                             TenSanPham = k.TenSanPham,
                             DonGia = nh.DonGia
                         };

            return result.ToList();  // Trả về danh sách
        }
        public List<NhapHang_DTO> GetNhapHangByMaNCC(string maNCC)
        {
            var result = from nh in DB.NhapHangs
                         join k in DB.Khos on nh.MaSanPham equals k.MaSanPham
                         where nh.MaNhaCungCap == maNCC
                         select new NhapHang_DTO
                         {
                             MaNhapHang = nh.MaNhapHang,
                             MaSanPham = nh.MaSanPham,
                             DonViTinh = nh.DonViTinh,
                             SoLuong = nh.SoLuong,
                             NgayNhap = nh.NgayNhap,
                             MaLoaiHang = nh.MaLoaiHang,
                             MaNhaCungCap = nh.MaNhaCungCap,
                             TenSanPham = k.TenSanPham,
                             DonGia = nh.DonGia
                         };

            return result.ToList();  // Trả về danh sách
        }
        public void UpdateNhapHang(NhapHang_DTO nhapHang)
        {
            try
            {
                var existingNhapHang = DB.NhapHangs.FirstOrDefault(nh => nh.MaNhapHang == nhapHang.MaNhapHang);
                if (existingNhapHang != null)
                {
                    existingNhapHang.MaSanPham = nhapHang.MaSanPham;
                    existingNhapHang.SoLuong = nhapHang.SoLuong;
                    existingNhapHang.DonViTinh = nhapHang.DonViTinh;
                    existingNhapHang.NgayNhap = nhapHang.NgayNhap;
                    existingNhapHang.MaLoaiHang = nhapHang.MaLoaiHang;
                    existingNhapHang.MaNhaCungCap = nhapHang.MaNhaCungCap;
                    existingNhapHang.DonGia = nhapHang.DonGia;

                    DB.SubmitChanges();
                    Console.WriteLine("Cập nhật thành công."); // Ghi log thành công
                }
                else
                {
                    Console.WriteLine("Mã nhập hàng không tồn tại."); // Ghi log không tìm thấy
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật: {ex.Message}"); // Ghi log lỗi
            }
        }

        public void DeleteNhapHang(int maNhapHang)
        {
            var existingNhapHang = DB.NhapHangs.FirstOrDefault(nh => nh.MaNhapHang == maNhapHang);
            if (existingNhapHang != null)
            {
                DB.NhapHangs.DeleteOnSubmit(existingNhapHang);
                DB.SubmitChanges();
            }
        }

        public DataTable GetAllLH()
        {
            var query = from lh in DB.LoaiHangs
                        select new
                        {
                            lh.MaLoaiHang
                        };

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MaLoaiHang", typeof(string));

            foreach (var item in query)
            {
                dataTable.Rows.Add(item.MaLoaiHang);
            }

            return dataTable;
        }

        public DataTable GetAllNCC()
        {
            var query = from ncc in DB.NhaCungCaps
                        select new
                        {
                            ncc.MaNhaCungCap
                        };

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MaNhaCungCap", typeof(string));

            foreach (var item in query)
            {
                dataTable.Rows.Add(item.MaNhaCungCap);
            }

            return dataTable;
        }

        public DataTable GetAllSP()
        {
            var query = from sp in DB.Khos
                        select new
                        {
                            sp.MaSanPham
                        };

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MaSanPham", typeof(string));

            foreach (var item in query)
            {
                dataTable.Rows.Add(item.MaSanPham);
            }

            return dataTable;
        }

        public NhapHang_DTO GetTenSanPhamByMa(string maSanPham)
        {
            var result = (from kho in DB.Khos
                          join lh in DB.LoaiHangs on kho.MaLoaiHang equals lh.MaLoaiHang
                          where kho.MaSanPham == maSanPham
                          select new NhapHang_DTO
                          {
                              MaSanPham = kho.MaSanPham,
                              TenSanPham = kho.TenSanPham,
                              DonViTinh = kho.DonViTinh,
                              DonGia = kho.DonGia,
                              MaLoaiHang = kho.MaLoaiHang,

                          }).FirstOrDefault();

            return result;
        }

    }
}
