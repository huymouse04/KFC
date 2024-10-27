using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KFC
{
    internal class DBKetNoi
    {
        public SqlDataAdapter da;
        public DataTable dt;
        public SqlCommand cmd;
        SqlConnection conn;
        public SqlConnection LayKetNoi()
        {
            string sql = "Data Source=MOUSE\\TESTDB\\MSSQLSERVER02;Initial Catalog=kfc;Integrated Security=True";
            return new SqlConnection(sql);
        }
        public DataTable LayBang(string sql)
        {
            DataTable dt = null;
            try
            {
                conn = LayKetNoi();
                conn.Open();
                dt = new DataTable();
                cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}
