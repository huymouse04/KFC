using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class Combo_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

        public void XoaCombosHethan()
        {
            try
            {
                var currentDate = DateTime.Now;
                var expiringDateLimit = currentDate.AddDays(7); // Giới hạn ngày hết hạn trong 7 ngày tới

                // Lấy danh sách các combo hết hạn (Ngày kết thúc nhỏ hơn ngày hiện tại)
                var expiredCombos = DB.Combos.Where(c =>
                    c.NgayKetThuc.HasValue && c.NgayKetThuc.Value < currentDate
                ).ToList();

                // Lấy danh sách các combo sắp hết hạn (Ngày kết thúc trong vòng 7 ngày tới)
                var expiringCombos = DB.Combos.Where(c =>
                    c.NgayKetThuc.HasValue && c.NgayKetThuc.Value >= currentDate && c.NgayKetThuc.Value <= expiringDateLimit
                ).ToList();

                List<string> expiringComboNames = new List<string>();

                List<string> deletedComboNames = new List<string>(); // Danh sách lưu tên các combo đã xóa

                foreach (var combo in expiredCombos)
                {
                    // Lấy danh sách sản phẩm thuộc combo này (nếu có bảng ChiTietCombo)
                    var chiTietCombos = DB.ChiTietCombos.Where(ct => ct.MaCombo == combo.MaCombo).ToList();

                    // Xóa các sản phẩm thuộc combo
                    foreach (var chiTiet in chiTietCombos)
                    {
                        DB.ChiTietCombos.DeleteOnSubmit(chiTiet);
                    }

                    // Xóa combo
                    DB.Combos.DeleteOnSubmit(combo);

                    // Thêm tên combo đã xóa vào danh sách
                    deletedComboNames.Add(combo.TenCombo);
                }

                // Xử lý các combo sắp hết hạn (chỉ thông báo)
                foreach (var combo in expiringCombos)
                {
                    expiringComboNames.Add(combo.TenCombo);
                }

                // Commit các thay đổi vào cơ sở dữ liệu (xóa các combo đã hết hạn)
                DB.SubmitChanges();

                // Thông báo các combo đã hết hạn
                if (deletedComboNames.Count > 0)
                {
                    string expiredMessage = $"Các combo đã hết hạn và đã được xóa:\n" + string.Join("\n", deletedComboNames);
                    MessageBox.Show(expiredMessage, "Thông báo");
                }

                // Thông báo các combo sắp hết hạn
                if (expiringComboNames.Count > 0)
                {
                    string expiringMessage = $"Các combo sắp hết hạn trong vòng 7 ngày tới:\n" + string.Join("\n", expiringComboNames);
                    MessageBox.Show(expiringMessage, "Thông báo");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra và xóa combo hết hạn: " + ex.Message, "Lỗi");
            }
        }



        // Phương thức lấy thông tin combo từ MaCombo
        public Combo_DTO GetComboByMaCombo(string maCombo)
        {
            try
            {
                var combo = DB.Combos.SingleOrDefault(c => c.MaCombo == maCombo);
                if (combo != null)
                {
                    return new Combo_DTO
                    {
                        MaCombo = combo.MaCombo,
                        TenCombo = combo.TenCombo,
                        GiaCombo = (int)combo.GiaCombo,
                        SoLuong = (int)combo.SoLuong,
                        PhamTramGiam = (int)combo.PhanTramGiam,
                        NgayBatDau = combo.NgayBatDau,
                        NgayKetThuc = combo.NgayKetThuc
                    };
                }
                else
                {
                    return null; // Không tìm thấy combo với MaCombo
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                throw new Exception("Lỗi khi lấy combo: " + ex.Message);
            }
        }

        public void AddCombo(Combo_DTO comboDTO)
        {
            // Kiểm tra mã combo có trùng không
            if (IsComboExists(comboDTO.MaCombo))
            {
                throw new Exception("Mã combo đã tồn tại. Vui lòng chọn mã combo khác.");
            }

            // Kiểm tra tính hợp lệ của dữ liệu đầu vào
            ValidateComboData(comboDTO);

            var combo = new Combo
            {
                MaCombo = comboDTO.MaCombo,
                TenCombo = comboDTO.TenCombo,
                GiaCombo = comboDTO.GiaCombo,
                SoLuong = comboDTO.SoLuong,
                PhanTramGiam= comboDTO.PhamTramGiam,
                NgayBatDau = comboDTO.NgayBatDau,
                NgayKetThuc = comboDTO.NgayKetThuc
            };

            DB.Combos.InsertOnSubmit(combo);
            DB.SubmitChanges();
        }

        public void UpdateCombo(Combo_DTO comboDTO)
        {
            var combo = DB.Combos.FirstOrDefault(c => c.MaCombo == comboDTO.MaCombo);
            if (combo != null)
            {
                // Kiểm tra tính hợp lệ của dữ liệu đầu vào
                ValidateComboData(comboDTO);

                combo.TenCombo = comboDTO.TenCombo;
                combo.GiaCombo = comboDTO.GiaCombo;
                combo.SoLuong = comboDTO.SoLuong;
                combo.PhanTramGiam = comboDTO.PhamTramGiam;
                combo.NgayBatDau = comboDTO.NgayBatDau;
                combo.NgayKetThuc = comboDTO.NgayKetThuc;

                DB.SubmitChanges();
            }
            else
            {
                throw new Exception("Combo không tồn tại để cập nhật.");
            }
        }

        public void DeleteCombo(string maCombo)
        {
            var combo = DB.Combos.FirstOrDefault(c => c.MaCombo == maCombo);
            if (combo != null)
            {
                DB.Combos.DeleteOnSubmit(combo);
                DB.SubmitChanges();
            }
        }

        public List<Combo_DTO> LoadCombos()
        {
            var combos = (from combo in DB.Combos
                          select new Combo_DTO
                          {
                              MaCombo = combo.MaCombo,
                              TenCombo = combo.TenCombo,
                              GiaCombo = (int)combo.GiaCombo, // xử lý null cho giá trị float
                              SoLuong = (int)combo.SoLuong,    // xử lý null cho giá trị int
                              PhamTramGiam = (int)combo.PhanTramGiam,
                              NgayBatDau = combo.NgayBatDau.HasValue && combo.NgayBatDau.Value >= new DateTime(1753, 1, 1) ? combo.NgayBatDau.Value : (DateTime?)null,
                              NgayKetThuc = combo.NgayKetThuc.HasValue && combo.NgayKetThuc.Value >= new DateTime(1753, 1, 1) ? combo.NgayKetThuc.Value : (DateTime?)null,
                          }).ToList();

            return combos;
        }

        private bool IsComboExists(string maCombo)
        {
            return DB.Combos.Any(c => c.MaCombo == maCombo);
        }

        // Phương thức kiểm tra tính hợp lệ của dữ liệu đầu vào
        private void ValidateComboData(Combo_DTO comboDTO)
        {
            if (string.IsNullOrWhiteSpace(comboDTO.MaCombo) || comboDTO.MaCombo.Length > 30)
            {
                throw new Exception("Mã combo không hợp lệ. Độ dài tối đa là 30 ký tự.");
            }
            if (string.IsNullOrWhiteSpace(comboDTO.TenCombo) || comboDTO.TenCombo.Length > 250)
            {
                throw new Exception("Tên combo không hợp lệ. Độ dài tối đa là 250 ký tự.");
            }
            if (comboDTO.GiaCombo < 0)
            {
                throw new Exception("Giá combo không hợp lệ. Giá phải là số không âm.");
            }
            if (comboDTO.SoLuong < 0)
            {
                throw new Exception("Số lượng không hợp lệ. Số lượng phải là số không âm.");
            }
            // Kiểm tra ngày bắt đầu và ngày kết thúc
            if (comboDTO.NgayBatDau > comboDTO.NgayKetThuc)
            {
                throw new Exception("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.");
            }

        }
    }
}
