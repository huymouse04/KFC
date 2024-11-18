﻿using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DonDat_BUS
    {

        private DonDat_DAO dao = new DonDat_DAO();


        public string TaoDonDatMoi()
        {
            return dao.TaoDonDatMoi();
        }

        public bool CapNhatThongTinDonDat(DonDat_DTO donDat)
        {
            return dao.CapNhatDonDat(donDat);
        }

       

    }
}