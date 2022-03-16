using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Transactions;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

namespace MyUniversity_LIB
{
    public class Jadwal
    {
        #region DATAMEMBER
        private string jam;
        private string hari;
        private int id;
        private Kelas kelas;
        private MataKuliah mataKuliah;

        #endregion

        #region CONSTRUCTOR 
        public Jadwal(int id ,string jam, string hari, Kelas kelas, MataKuliah mataKuliah)
        {
            this.Jam = jam;
            this.Hari = hari;
            this.Id = id;
            this.Kelas = kelas;
            this.MataKuliah = mataKuliah;
        }
        public Jadwal(int id, string jam, string hari)
        {
            this.Jam = jam;
            this.Hari = hari;
            this.Id = id;
            this.Kelas = kelas;
            this.MataKuliah = mataKuliah;
        }
        public Jadwal(int id)
        {
            this.Id = id;
        }
        public Jadwal(int id , MataKuliah mataKuliah)
        {
            this.Id = id;
            this.MataKuliah = mataKuliah;
        }

        public Jadwal(Kelas kelas, MataKuliah mataKuliah)
        {
            this.Kelas = kelas;
            this.MataKuliah = mataKuliah;
        }
        public Jadwal(MataKuliah mataKuliah)
        {
            this.MataKuliah = mataKuliah;
        }



        #endregion

        #region PROPERTIES
        public string Jam { get => jam; set => jam = value; }
        public string Hari { get => hari; set => hari = value; }
        public int Id { get => id; set => id = value; }
        public Kelas Kelas { get => kelas; set => kelas = value; }
        public MataKuliah MataKuliah { get => mataKuliah; set => mataKuliah = value; }
        #endregion

        #region METHOD
        public static void TambahData(Jadwal j)
        {
            string sql1 = "insert into jadwal(id, kelas_id, mata_kuliah_id, jam, hari) values " +
                "('" + j.Id + "','" + j.Kelas.IdKelas + "','" + j.MataKuliah.Id + "','"
                + j.Jam.Replace("'", "\\'") + "','" + j.Hari.Replace("'", "\\'") + "')";

            Koneksi.JalankanPerintah(sql1);
        }
        public static void UbahData(Jadwal j)
        {
            string sql = "update jadwal set jam='" + j.Jam.Replace("'", "\\'") + "', hari='" +
               j.Hari.Replace("'", "\\'") + "' where id ='" + j.Id + "'";
            Koneksi.JalankanPerintah(sql);
        }
        public static List<Jadwal> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select J.id, J.jam, J.hari, J.kelas_id, K.nama_ruang AS Kelas, J.mata_kuliah_id, M.nama AS Matakuliah " +
                    "from jadwal J inner join kelas K on J.kelas_id = K.id inner join mata_kuliah M on J.mata_kuliah_id = M.id";

            }
            else
            {
                sql = "select J.id, J.jam, J.hari, J.kelas_id, K.nama_ruang AS Kelas, J.mata_kuliah_id, M.nama AS Matakuliah " +
                    "from jadwal J inner join kelas K on J.kelas_id = K.id inner join mata_kuliah M on J.mata_kuliah_id = M.id" + " where " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Jadwal> listOfJadwal = new List<Jadwal>();
            while (hasil.Read() == true)
            {
                int id = int.Parse(hasil.GetValue(0).ToString()) ;
                string jam = hasil.GetValue(1).ToString();
                string hari = hasil.GetValue(2).ToString();
                Kelas k = new Kelas(hasil.GetValue(3).ToString(), hasil.GetValue(4).ToString());
                MataKuliah m = new MataKuliah(hasil.GetValue(5).ToString(), hasil.GetValue(6).ToString());
                Jadwal j = new Jadwal(id, jam, hari, k, m);
                listOfJadwal.Add(j);
            }
            return listOfJadwal;
        }
        public static string GeneratorKode()
        {
            Koneksi koneksi = new Koneksi();
            koneksi.Connect();
            string sql = "select max(id) from jadwal";
            string hasilKode = "";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                int kodeTerbaru = int.Parse(hasil.GetValue(0).ToString()) + 1;
                hasilKode = kodeTerbaru.ToString();
            }
            else
            {
                hasilKode = "1";
            }
            return hasilKode;
        }

        public static void CetakJadwal(string pKriteria, string pNilaiKriteria, string pNamaFile, Font font)
        {
            List<Jadwal> listOfJadwal = new List<Jadwal>();
            listOfJadwal = Jadwal.BacaData(pKriteria, pNilaiKriteria);
            StreamWriter file = new StreamWriter(pNamaFile);
            foreach (Jadwal jadwal in listOfJadwal)
            {
                file.WriteLine("");
                file.WriteLine("MY UNIVERSITY");
                file.WriteLine("Jl. Cantik Surabaya");
                file.WriteLine("Telp. (031) - 12345678");
                file.WriteLine("=".PadRight(50, '='));

                file.WriteLine("ID Jadwal : " + jadwal.Id);
                file.WriteLine("Hari : " + jadwal.Hari);
                file.WriteLine("Jam : " + jadwal.Jam);
                file.WriteLine("Matakuliah : " + jadwal.MataKuliah.Id + " - " + jadwal.MataKuliah.Nama);
                file.WriteLine("=".PadRight(50, '='));
            }
            file.Close();
            Cetak c = new Cetak(pNamaFile, font, 20, 10, 10, 10);
            c.CetakKePrinter("text");
        }

        #endregion
    }
}