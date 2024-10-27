using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace KFC
{
    public partial class Connection : Form
    {
        public Connection()
        {
            InitializeComponent();
        }

        Connection_BUS busData = new Connection_BUS();
        string sever = "MOUSE\\TESTDB";

        private void btnKetnoi_Click(object sender, EventArgs e)
        {
            string sql = "Data Source=" + txtSever.Text + ";Initial Catalog=" + cbbDatabase.Text + ";Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            if (cbbDatabase.Text != "" && txtSever.Text != "")
            {


                try
                {
                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                    connectionStringsSection.ConnectionStrings["QLKFC.Properties.Settings.QLKFCConnectionString"].ConnectionString = sql;
                    config.Save();
                    ConfigurationManager.RefreshSection("connectionStrings");
                    using (SqlConnection conn = new SqlConnection(sql))
                    {
                        try
                        {
                            conn.Open();


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Có lỗi xảy ra khi cố gắng mở kết nối: " + ex.Message);
                        }
                    }

                    busData.setSeverName(txtSever.Text);
                    busData.setdataName(cbbDatabase.Text);
                    if (busData.ktDuongDan(txtSever.Text, cbbDatabase.Text))
                    {
                        busData.setDataBase();
                        DangNhap frmDN = new DangNhap();
                        MessageBox.Show("Kết nối thành công!!", "Thoát", MessageBoxButtons.OK);
                        this.Hide();
                        frmDN.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Tên sever không đúng hoặc database không tồn tại!");
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Xảy ra lỗi: " + ex.Message + "Lỗi kết nối database!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult thoat;
            thoat = MessageBox.Show("bạn chắc chắn muốn thoát ứng dụng chứ", "THOÁT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "chọn tập tin";
            op.Filter = "Text Files (*.dba)|*.dba| AllFiles(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.Open(op.FileName, FileMode.Open, FileAccess.Read);
                Connection_DTO con = (Connection_DTO)bf.Deserialize(fs);
                string srv = Encryptor.Decrypt(con.Servername, "fsfuoufsd8935@!", true);
                string db = Encryptor.Decrypt(con.Database, "fsfuoufsd8935@!", true);
                txtSever.Text = srv;
                cbbDatabase.Text = db;
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            string svEncrypt = Encryptor.Encrypt(txtSever.Text, "fsfuoufsd8935@!", true);
            string dbEncrypt = Encryptor.Encrypt(cbbDatabase.Text, "fsfuoufsd8935@!", true);
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Chọn nơi lưu trữ";
            sf.Filter = "Text Files (*.dba)|*.dba| AllFiles(*.*)|*.*";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                Connection_DTO cn = new Connection_DTO(svEncrypt, dbEncrypt);
                cn.ConnectData(sf.FileName);
                MessageBox.Show("luu thanh cong");
            }
        }

        private void cbbDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                cbbDatabase.Items.Clear();

                string conn = "server=" + txtSever.Text + ";Integrated Security=True;";


                SqlConnection con = new SqlConnection(conn);
                con.Open();
                string qr = "SELECT NAME FROM SYS.DATABASES";
                SqlCommand cmd = new SqlCommand(qr, con);
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbbDatabase.Items.Add(dr[0].ToString());
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Vui long nhap ten server", "LOI");
            }
        }

        private void Connection_Load(object sender, EventArgs e)
        {
            txtSever.Text = sever;
        }
    }
}
