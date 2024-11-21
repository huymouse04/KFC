using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DonDat_DAO
    {

        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);


   

        public string TaoDonDatMoi()
        {
            string filePath = LayDuongDanFile(); // Đường dẫn file trong bin\Debug
            string maDonDat;
            do
            {
                maDonDat = "DD" + Guid.NewGuid().ToString("N").Substring(0, 8); // Tạo mã random
            }
            while (KiemTraMaTrung(maDonDat, filePath)); // Kiểm tra trùng lặp

            // Tạo thực thể DonDat từ thông tin DTO
            var donDatEntity = new DonDat
            {
                MaDonDat = maDonDat,
                TongTien = 0,
                HinhThucThanhToan = null
            };

            // Thêm thực thể vào DB
            DB.DonDats.InsertOnSubmit(donDatEntity);
            DB.SubmitChanges();
            LuuMaVaoFile(maDonDat, filePath); // Lưu mã vào file nếu không trùng
            return maDonDat; // Trả về mã đơn đặt vừa tạo
        }


        public bool CapNhatDonDat(DonDat_DTO donDat)
        {
            var dd = DB.DonDats.FirstOrDefault(d => d.MaDonDat == donDat.MaDonDat);
            if (dd != null)
            {
                dd.MaBan = donDat.MaBan;
                dd.MaKhachHang = donDat.MaKhachHang;
                dd.MaKhuyenMai = donDat.MaKhuyenMai;
                dd.HinhThucThanhToan = donDat.HinhThucThanhToan;
                dd.TongTien = donDat.TongTien;
                dd.SoTienNhan = donDat.SoTienNhan;
                dd.SoTienTra = donDat.SoTienTra;
                DB.SubmitChanges();
                return true;
            }
            return false;
        }
        public List<DonDat_DTO> LayTatCaDonDat()
        {
            var danhSachDonDat = DB.DonDats.Select(d => new DonDat_DTO
            {
                MaDonDat = d.MaDonDat,
                MaBan = d.MaBan,
                MaKhachHang = d.MaKhachHang,
                MaKhuyenMai = d.MaKhuyenMai,
                HinhThucThanhToan = d.HinhThucThanhToan,
                TongTien = d.TongTien??0,
                SoTienNhan = d.SoTienNhan,
                SoTienTra = d.SoTienTra
            }).ToList();

            return danhSachDonDat;
        }
        public List<DonDat_DTO> GetDonDatByMa(string maDonDat)
        {
            if (string.IsNullOrEmpty(maDonDat))
                return new List<DonDat_DTO>();

            var danhSachDonDat = DB.DonDats
                .Where(d => d.MaDonDat == maDonDat)
                .Select(d => new DonDat_DTO
                {
                    MaDonDat = d.MaDonDat,
                    MaBan = d.MaBan,
                    MaKhachHang = d.MaKhachHang,
                    MaKhuyenMai = d.MaKhuyenMai,
                    HinhThucThanhToan = d.HinhThucThanhToan,
                    TongTien = d.TongTien ?? 0,
                    SoTienNhan = d.SoTienNhan,
                    SoTienTra = d.SoTienTra
                }).ToList();

            return danhSachDonDat;
        }



        private string LayDuongDanFile()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ma_dondat.txt");
        }

        private bool KiemTraMaTrung(string maDonDat, string filePath)
        {
            if (!File.Exists(filePath)) return false; // Nếu file chưa tồn tại, chắc chắn không trùng
            var danhSachMa = File.ReadAllLines(filePath);
            return danhSachMa.Contains(maDonDat);
        }

        private void LuuMaVaoFile(string maDonDat, string filePath)
        {
            File.AppendAllText(filePath, maDonDat + Environment.NewLine);
        }


    }
}
