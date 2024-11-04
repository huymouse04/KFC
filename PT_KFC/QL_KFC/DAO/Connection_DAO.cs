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

        // Kiểm tra nếu đang ở chế độ thiết kế
        private static bool IsInDesignMode()
        {
            return System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;
        }

        public bool ktDuongdan(string serverName, string databaseName)
        {
            // Sử dụng chuỗi kết nối giả nếu đang ở chế độ thiết kế
            ConnectionString = IsInDesignMode() ? "" : $"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True";

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
            // Sử dụng chuỗi kết nối giả nếu đang ở chế độ thiết kế
            db = IsInDesignMode() ? null : new KFCDataContext($"Data Source={severName};Initial Catalog={dataName};Integrated Security=True");
        }

        public void setDatabase()
        {
            try
            {
                // Sử dụng chuỗi kết nối giả nếu đang ở chế độ thiết kế
                db = IsInDesignMode() ? null : new KFCDataContext(ConnectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string DataName { get => dataName; set => dataName = value; }
        public static string SeverName { get => severName; set => severName = value; }
        public static string ConnectionString
        {
            get => connectionString;
            set => connectionString = value;
        }
    }
}
