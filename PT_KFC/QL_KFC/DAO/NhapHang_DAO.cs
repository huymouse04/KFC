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
                                NgaySanXuat = nh.NgaySanXuat,
                                NgayHetHan = nh.NgayHetHan,
                                MaLoaiHang = j.MaLoaiHang,
                                MaNhaCungCap = m.MaNhaCungCap,
                                DonGia = nh.DonGia

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
                            NgaySanXuat = nh.NgaySanXuat,
                            NgayHetHan = nh.NgayHetHan,
                            MaLoaiHang = j.MaLoaiHang,
                            MaNhaCungCap = m.MaNhaCungCap,
                            DonGia = nh.DonGia,
                            
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
        public List<NhapHang_DTO> GetNhapHangByMonth(int month, int year)
        {
            var nhapHangs = from nh in DB.NhapHangs
                            join k in DB.Khos on nh.MaSanPham equals k.MaSanPham
                            where nh.NgayNhap.Month == month && nh.NgayNhap.Year == year
                            select new NhapHang_DTO
                            {
                                MaNhapHang = nh.MaNhapHang,
                                MaSanPham = k.MaSanPham,
                                TenSanPham = k.TenSanPham,
                                DonViTinh = nh.DonViTinh,
                                SoLuong = nh.SoLuong,
                                NgayNhap = nh.NgayNhap,
                                NgaySanXuat = nh.NgaySanXuat,
                                NgayHetHan = nh.NgayHetHan,
                                MaLoaiHang = nh.MaLoaiHang,
                                MaNhaCungCap = nh.MaNhaCungCap,
                                DonGia = nh.DonGia
                            };

            return nhapHangs.ToList();
        }
        public List<NhapHang_DTO> GetProductsNearExpiration()
        {
            var currentDate = DateTime.Now;  // Lấy ngày hiện tại
            var nearExpirationDate = currentDate.AddDays(2);  // Ngày hết hạn trong 2 ngày tới

            var nhapHangs = from nh in DB.NhapHangs
                            join k in DB.Khos on nh.MaSanPham equals k.MaSanPham
                            where nh.NgayHetHan <= nearExpirationDate // Bao gồm sản phẩm đã hết hạn và sắp hết hạn
                            select new NhapHang_DTO
                            {
                                MaNhapHang = nh.MaNhapHang,
                                MaSanPham = k.MaSanPham,
                                TenSanPham = k.TenSanPham,
                                DonViTinh = nh.DonViTinh,
                                SoLuong = nh.SoLuong,
                                NgayNhap = nh.NgayNhap,
                                NgaySanXuat = nh.NgaySanXuat,
                                NgayHetHan = nh.NgayHetHan,
                                MaLoaiHang = nh.MaLoaiHang,
                                MaNhaCungCap = nh.MaNhaCungCap,
                                DonGia = nh.DonGia
                            };

            return nhapHangs.ToList();
        }
        public void AddNhapHang(NhapHang_DTO nhapHang)
        {
            try
            {
                if (nhapHang.NgaySanXuat > nhapHang.NgayNhap)
                {
                    throw new ArgumentException("Lỗi: Ngày sản xuất phải nhỏ hơn hoặc bằng Ngày nhập.");
                }
                if (nhapHang.NgayNhap >= nhapHang.NgayHetHan)
                {
                    throw new ArgumentException("Lỗi: Ngày nhập phải nhỏ hơn Ngày hết hạn.");
                }

                var newNhapHang = new NhapHang
                {
                    MaSanPham = nhapHang.MaSanPham,
                    TenSanPham=nhapHang.TenSanPham,
                    SoLuong = nhapHang.SoLuong,
                    DonViTinh = nhapHang.DonViTinh,
                    NgaySanXuat = nhapHang.NgaySanXuat,
                    NgayNhap = nhapHang.NgayNhap,
                    NgayHetHan = nhapHang.NgayHetHan,
                    MaLoaiHang = nhapHang.MaLoaiHang,
                    MaNhaCungCap = nhapHang.MaNhaCungCap,
                    DonGia = nhapHang.DonGia
                };

                DB.NhapHangs.InsertOnSubmit(newNhapHang);
                DB.SubmitChanges();
                UpdateKhoSoLuong(nhapHang.MaSanPham, nhapHang.SoLuong,nhapHang.NgaySanXuat,nhapHang.NgayHetHan);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);  // Xuất lỗi chi tiết
            }
        }


        public void UpdateKhoSoLuong(string maSanPham, int soLuongMoi,DateTime? ngaySX,DateTime? ngayHH)
        {
            // Tìm kiếm sản phẩm trong bảng Kho
            var existingKho = DB.Khos.FirstOrDefault(k => k.MaSanPham == maSanPham);

            if (existingKho != null)
            {
                // Lấy số lượng hiện tại trong bảng Kho
                int soLuongKhoHienTai = existingKho.SoLuong;

                // Cập nhật số lượng mới trong Kho dựa trên số lượng nhập hàng mới
                existingKho.SoLuong = soLuongKhoHienTai + soLuongMoi;
                existingKho.NgaySanXuat = ngaySX;
                existingKho.NgayHetHan=ngayHH;
                // Lưu thay đổi vào cơ sở dữ liệu
                DB.SubmitChanges();
            }
            else
            {
                throw new InvalidOperationException("Sản phẩm không tồn tại trong kho, không thể cập nhật số lượng.");
            }
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
                             NgaySanXuat = nh.NgaySanXuat,
                             NgayHetHan = nh.NgayHetHan,
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
                             NgaySanXuat = nh.NgaySanXuat,
                             NgayHetHan = nh.NgayHetHan,
                             MaLoaiHang = nh.MaLoaiHang,
                             MaNhaCungCap = nh.MaNhaCungCap,
                             TenSanPham = k.TenSanPham,
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
                             NgaySanXuat = nh.NgaySanXuat,
                             NgayHetHan = nh.NgayHetHan,
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
                             NgaySanXuat = nh.NgaySanXuat,
                             NgayHetHan = nh.NgayHetHan,
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
                             NgaySanXuat = nh.NgaySanXuat,
                             NgayHetHan = nh.NgayHetHan,
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
                if (existingNhapHang == null)
                {
                    throw new ArgumentException("Lỗi: Mã nhập hàng không tồn tại.");
                }

                if (nhapHang.NgaySanXuat > nhapHang.NgayNhap)
                {
                    throw new ArgumentException("Lỗi: Ngày sản xuất phải nhỏ hơn hoặc bằng Ngày nhập.");
                }
                if (nhapHang.NgayNhap >= nhapHang.NgayHetHan)
                {
                    throw new ArgumentException("Lỗi: Ngày nhập phải nhỏ hơn Ngày hết hạn.");
                }

                existingNhapHang.MaSanPham = nhapHang.MaSanPham;
                existingNhapHang.SoLuong = nhapHang.SoLuong;
                existingNhapHang.DonViTinh = nhapHang.DonViTinh;
                existingNhapHang.NgaySanXuat = nhapHang.NgaySanXuat;
                existingNhapHang.NgayNhap = nhapHang.NgayNhap;
                existingNhapHang.NgayHetHan = nhapHang.NgayHetHan;
                existingNhapHang.MaLoaiHang = nhapHang.MaLoaiHang;
                existingNhapHang.MaNhaCungCap = nhapHang.MaNhaCungCap;
                existingNhapHang.DonGia = nhapHang.DonGia;
                existingNhapHang.TenSanPham = nhapHang.TenSanPham;

                DB.SubmitChanges();
                Console.WriteLine("Cập nhật thành công.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);  // Xuất lỗi chi tiết
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi không xác định: {ex.Message}");  // Lỗi hệ thống hoặc ngoại lệ khác
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
                            lh.MaLoaiHang,
                            lh.TenLoaiHang
                        };

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MaLoaiHang", typeof(string));
            dataTable.Columns.Add("TenLoaiHang", typeof(string));

            foreach (var item in query)
            {
                dataTable.Rows.Add(item.MaLoaiHang, item.TenLoaiHang);
            }

            return dataTable;
        }


        public DataTable GetAllNCC()
        {
            var query = from ncc in DB.NhaCungCaps
                        select new
                        {
                            ncc.MaNhaCungCap,
                            ncc.TenNhaCungCap
                        };

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MaNhaCungCap", typeof(string));
            dataTable.Columns.Add("TenNhaCungCap", typeof(string));
            foreach (var item in query)
            {
                dataTable.Rows.Add(item.MaNhaCungCap, item.TenNhaCungCap);
            }

            return dataTable;
        }

        public DataTable GetAllSP()
        {
            var query = from sp in DB.Khos
                        select new
                        {
                            sp.TenSanPham,
                            sp.MaSanPham
                        };

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("TenSanPham", typeof(string));
            dataTable.Columns.Add("MaSanPham", typeof(string));
            foreach (var item in query)
            {
                dataTable.Rows.Add(item.TenSanPham, item.MaSanPham);
            }

            return dataTable;
        }
        public DataTable GetAllLH2(string maLoaiHang)
        {
            // Thực hiện truy vấn với điều kiện lọc theo maLoaiHang
            var query = from k in DB.Khos
                        join lh in DB.LoaiHangs on k.MaLoaiHang equals lh.MaLoaiHang
                        where k.MaLoaiHang == maLoaiHang // Điều kiện lọc
                        select new
                        {
                            k.MaLoaiHang,
                            TenLoaiHang = lh.TenLoaiHang
                        };

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MaLoaiHang", typeof(string));
            dataTable.Columns.Add("TenLoaiHang", typeof(string));

            foreach (var item in query)
            {
                dataTable.Rows.Add(item.MaLoaiHang, item.TenLoaiHang);
            }

            return dataTable;
        }

        public NhapHang_DTO GetTenSanPhamByMa(string tensp)
        {
            var result = (from kho in DB.Khos
                          join lh in DB.LoaiHangs on kho.MaLoaiHang equals lh.MaLoaiHang
                          where kho.TenSanPham == tensp
                          select new NhapHang_DTO
                          {
                              MaSanPham = kho.MaSanPham,

                              DonViTinh = kho.DonViTinh,
                              DonGia = kho.DonGia,
                              MaLoaiHang = kho.MaLoaiHang,

                          }).FirstOrDefault();

            return result;
        }

       

    }
}