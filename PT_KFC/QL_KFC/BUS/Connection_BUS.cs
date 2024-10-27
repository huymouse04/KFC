using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class Connection_BUS
    {
        Connection_DAO connection_DAO = new Connection_DAO();

        public void setSeverName(string severName)
        {
            Connection_DAO.SeverName = severName;
        }
        public void setdataName(string dataName)
        {
            Connection_DAO.DataName = dataName;
        }
        public bool ktDuongDan(string serverName, string databaseName)
        {
            return connection_DAO.ktDuongdan(serverName, databaseName);
        }
        public void setDataBase()
        {
            connection_DAO.setDatabase();
        }
    }
}
