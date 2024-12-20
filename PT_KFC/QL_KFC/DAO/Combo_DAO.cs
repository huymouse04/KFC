﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Combo_DAO
    {
        private KFCDataContext DB = new KFCDataContext(Connection_DAO.ConnectionString);

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
