using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyUniversity_LIB
{
    public class Falkultas
    {
        #region DATAMEMBER
        private string idFalkultas;
        private string nama;
        private string dekan;
        private string wakilDekan;
        #endregion

        #region PROPERTIES
        public string IdFalkultas { get => idFalkultas; set => idFalkultas = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Dekan { get => dekan; set => dekan = value; }
        public string WakilDekan { get => wakilDekan; set => wakilDekan = value; }
        #endregion

        #region CONSTRUCTOR
        public Falkultas(string idFalkultas, string nama, string dekan, string wakilDekan)
        {
            IdFalkultas = idFalkultas;
            Nama = nama;
            Dekan = dekan;
            WakilDekan = wakilDekan;
        }
        public Falkultas(string idFalkultas, string nama)
        {
            IdFalkultas = idFalkultas;
            Nama = nama;
        }
        #endregion

        #region METHOD
        public static void TambahData(Falkultas f)
        {
            string sql = "insert into falkutas(id,nama,dekan,wakil_dekan) values('" + f.IdFalkultas + "','" + f.Nama.Replace("'", "\\")  +"','" + f.Dekan + "','" + f.WakilDekan + "')";
            Koneksi.JalankanPerintah(sql);
        }

        public static void UbahData(Falkultas f)
        {
            string sql = "update falkutas set nama='" + f.Nama.Replace("'", "\\") + "' , dekan = '" + f.dekan + "' , wakil_dekan = '" + f.WakilDekan + "' where id ='" + f.IdFalkultas + "'";
            Koneksi.JalankanPerintah(sql);
        }

        public static void HapusData(Falkultas f)
        {
            string sql = "delete from falkutas where id='" + f.IdFalkultas + "'";
            Koneksi.JalankanPerintah(sql);
        }

        public static List<Falkultas> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select * from falkutas";
            }
            else
            {
                sql = "select * from falkutas where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Falkultas> listFalkultas = new List<Falkultas>();
            while (hasil.Read() == true)
            {
                Falkultas k = new Falkultas(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString(), hasil.GetValue(2).ToString(), hasil.GetValue(3).ToString());
                listFalkultas.Add(k);
            }
            return listFalkultas;

        }
        public static string GeneratorKode()
        {
            string sql = "select max(id) from falkutas";
            string hasilKode = "";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                int kodeTerbaru = int.Parse(hasil.GetValue(0).ToString()) + 1;
                hasilKode = kodeTerbaru.ToString().PadLeft(1, '0');
            }
            else
            {
                hasilKode = "1";
            }
            return hasilKode;
        }
        #endregion
    }
}