using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class Connection_DAO
    {
        private static string dataName;
        private static string severName;
        private static KFCDataContext db;
        private static string connectionString;
        public bool ktDuongdan(string serverName, string databaseName)
        {
            ConnectionString = $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
        public static void resetData()
        {
            db = new KFCDataContext($"Data Source={severName};Initial Catalog={dataName};Integrated Security=True");
        }
        public void setDatabase()
        {
            try
            {
                db = new KFCDataContext(ConnectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static string DataName { get => dataName; set => dataName = value; }
        public static string SeverName { get => severName; set => severName = value; }
        public static string ConnectionString { get => connectionString; set => connectionString = value; }
    }
}
