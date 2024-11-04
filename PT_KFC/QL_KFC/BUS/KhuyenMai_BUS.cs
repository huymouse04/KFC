using DAO;
using DTO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BUS
{
    public class KhuyenMai_BUS
    {
        private KhuyenMai_DAO khuyenMaiDAO = new KhuyenMai_DAO();

        public List<KhuyenMai_DTO> GetAllKhuyenMai()
        {
            return khuyenMaiDAO.GetAllKhuyenMai();
        }
        public bool ThemKhuyenMai(KhuyenMai_DTO khuyenMai)
        {
            return khuyenMaiDAO.ThemKhuyenMai(khuyenMai);
        }

      
        public KhuyenMai_DTO LayKhuyenMaiTheoMa(string maKM)
        {
            return khuyenMaiDAO.LayKhuyenMaiTheoMa(maKM);
        }
        public bool XoaKM(string maKM)
        {
            return khuyenMaiDAO.XoaKhuyenMai(maKM);
        }
        public bool CapNhatKM(KhuyenMai_DTO km)
        {
            return khuyenMaiDAO.CapNhatKhuyenMai(km);
        }
        public string TaoMa()
        {
            return khuyenMaiDAO.GenerateUniqueMaKhuyenMai();
        }
        public List<KhuyenMai_DTO> TimKiemKhuyenMaiTheoMa(string maKM)
        {
            return khuyenMaiDAO.TimKiemKhuyenMaiTheoMa(maKM);
        }

    }
}
