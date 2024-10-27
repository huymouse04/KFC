using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Serializable]
    public class Connection_DTO
    {
        string servername, database, username, passwd;

        public Connection_DTO(string servername, string database, string username, string passwd)
        {
            this.servername = servername;
            this.database = database;
            this.username = username;
            this.passwd = passwd;
        }
        public Connection_DTO(string servername, string database)
        {
            this.servername = servername;
            this.database = database;

        }

        public string Servername { get => servername; set => servername = value; }
        public string Database { get => database; set => database = value; }
        public string Username { get => username; set => username = value; }
        public string Passwd { get => passwd; set => passwd = value; }

        public void ConnectData(string filename)
        {
            if (File.Exists("connectdb.dba"))
                File.Delete("connectdb.dba");
            FileStream fs = File.Open(filename, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();

        }

    }
}
