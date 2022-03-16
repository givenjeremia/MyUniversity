using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MyUniversity_LIB
{
    public class Kelas
    {
        #region DATAMEMBER
        private string idKelas;
        private string nama;
        private Falkultas falkultas;
        #endregion

        #region CONSTRUCTOR
        public Kelas(string idKelas, string nama, Falkultas falkultas)
        {
            IdKelas = idKelas;
            Nama = nama;
            Falkultas = falkultas;
        }
        public Kelas(string idKelas, string nama)
        {
            IdKelas = idKelas;
            Nama = nama;
        }
        public Kelas(string idKelas)
        {
            IdKelas = idKelas;
        }
        #endregion

        #region PROPERTIES
        public string IdKelas { get => idKelas; set => idKelas = value; }
        public string Nama { get => nama; set => nama = value; }
        public Falkultas Falkultas { get => falkultas; set => falkultas = value; }
        #endregion

        #region METHOD
        public static void TambahData(Kelas k)
        {
            string sql = "insert into kelas(id, nama_ruang, falkutas_id) values " +
                "('" + k.IdKelas + "','" + k.Nama.Replace("'", "\\'") +
                "','" +k.Falkultas.IdFalkultas + "')";
            Koneksi.JalankanPerintah(sql);
        }
        public static void UbahData(Kelas k)
        {
            string sql = "update kelas set nama_ruang='" + k.Nama.Replace("'", "\\'") + "', falkutas_id='" +
                k.Falkultas.IdFalkultas + "' where id ='" + k.IdKelas + "'";
            Koneksi.JalankanPerintah(sql);
        }
        public static List<Kelas> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select K.id, K.nama_ruang, K.falkutas_id, F.nama AS Fakultas " +
                    "from kelas K inner join falkutas F on K.falkutas_id = F.id";

            }
            else
            {
                sql = "select K.id, K.nama_ruang, K.falkutas_id, F.nama AS Fakultas " +
                    "from kelas K inner join falkutas F on K.falkutas_id = F.id" + " where " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Kelas> listOfKelas = new List<Kelas>();
            while (hasil.Read() == true)
            {
                Falkultas f = new Falkultas(hasil.GetValue(2).ToString(), hasil.GetValue(3).ToString());
                Kelas k = new Kelas(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString(),f);
                listOfKelas.Add(k);
            }
            return listOfKelas;
        }
        public static string GeneratorKode(Falkultas f)
        {
            string sql = "select max(right(id,1)) from kelas where falkutas_id = '" + f.IdFalkultas + "'";
            string hasilKode = "";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    int kodeTerbaru = int.Parse(hasil.GetValue(0).ToString()) + 1;
                    hasilKode = f.IdFalkultas + kodeTerbaru.ToString().PadLeft(2, '0');
                }
                else
                {
                    hasilKode = f.IdFalkultas + "01";
                }
            }

            return hasilKode;
        }
        #endregion
    }
}