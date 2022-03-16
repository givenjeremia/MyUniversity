using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MyUniversity_LIB
{
    public class Koneksi
    {
        #region DATAMEMBER
        private MySqlConnection koneksiDB;
        #endregion

        #region PROPERTIES
        public MySqlConnection KoneksiDB { get => koneksiDB; private set => koneksiDB = value; }
        #endregion

        #region CONSTRUCTOR
        public Koneksi()
        {
            KoneksiDB = new MySqlConnection();
            KoneksiDB.ConnectionString = ConfigurationManager.ConnectionStrings["namakoneksi"].ConnectionString;
            Connect();
        }
        #endregion

        #region METHOD
        public static void JalankanPerintah(string sql)
        {
            Koneksi k = new Koneksi();
            MySqlCommand c = new MySqlCommand(sql, k.koneksiDB);
            c.ExecuteNonQuery();
        }
        public static MySqlDataReader JalankanPerintahQuery(string sql)
        {
            Koneksi k = new Koneksi();
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            return c.ExecuteReader();
            
        }
        public Koneksi(string pServer, string pDataBase, string p_username, string pPassword)
        {
            string strConnect = "server=" + pServer + ";database=" + pDataBase + ";uid=" + p_username + ";password=" + pPassword ;
            KoneksiDB = new MySqlConnection();
            KoneksiDB.ConnectionString = strConnect.ToString();
            KoneksiDB = new MySqlConnection();
            KoneksiDB.ConnectionString = strConnect;
            Connect();
            UpdateAppConfig(strConnect);
        }    
        public void Connect()
        {
            //JIKA KONEKSI SUDAH TERBUKA MAKA TUTUP DAHULU
            if (KoneksiDB.State == System.Data.ConnectionState.Open)
            {
                KoneksiDB.Close();
            }
            KoneksiDB.Open();
        }
        public void UpdateAppConfig(string con)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.ConnectionStrings.ConnectionStrings["namakoneksi"].ConnectionString = con;
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");

        }
        #endregion
    }
}
