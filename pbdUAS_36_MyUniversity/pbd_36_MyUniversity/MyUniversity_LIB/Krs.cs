using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

namespace MyUniversity_LIB
{
    public class Krs
    {
        private int idKrs;
        private DateTime tanggal;
        private Mahasiswa mahasiswa;
        List<KrsDetail> listKrsDetail;

        public DateTime Tanggal { get => tanggal; set => tanggal = value; }
        public Mahasiswa Mahasiswa { get => mahasiswa; set => mahasiswa = value; }
        public int IdKrs { get => idKrs; set => idKrs = value; }
        public List<KrsDetail> ListKrsDetail { get => listKrsDetail; private set => listKrsDetail = value; }



        public Krs(DateTime tanggal, Mahasiswa mahasiswa, int idKrs)
        {
            Tanggal = tanggal;
            Mahasiswa = mahasiswa;
            IdKrs = idKrs;
            ListKrsDetail = new List<KrsDetail>();
        }
        public Krs(int idKrs,Mahasiswa mahasiswa)
        {
            IdKrs = idKrs;
            Mahasiswa = mahasiswa;
            ListKrsDetail = new List<KrsDetail>();
        }
        public Krs(int idKrs)
        {
            IdKrs = idKrs;
            ListKrsDetail = new List<KrsDetail>();
        }
        public void TambahKrsDetail(Jadwal j)
        {
            KrsDetail detilKrs = new KrsDetail(j);
            this.ListKrsDetail.Add(detilKrs);
        }
        public void TambahKrsDetail(Krs krs)
        {
            KrsDetail detilKrs = new KrsDetail(krs);
            this.ListKrsDetail.Add(detilKrs);
        }
        public static void TambahData(Krs k)
        {
            using (TransactionScope transScope = new TransactionScope())
            {
                try
                {
                    Koneksi koneksi = new Koneksi();
                    koneksi.Connect();
                    string sql = "INSERT INTO krs(id, tanggal, mahasiswa_nrp) VALUES('" + k.IdKrs + "', '" + k.Tanggal.ToString("yyyy-MM-dd") + "', '" + k.Mahasiswa.Nrp + "')";
                    Koneksi.JalankanPerintah(sql);
                    foreach (KrsDetail detilKrs in k.ListKrsDetail)
                    {
                        koneksi.Connect();
                            string sql2 = "INSERT INTO krs_details(id_jadwal, id_krs) " +
                                    "VALUES('" + detilKrs.Jadwal.Id + "', '" + k.IdKrs + "')";
                            Koneksi.JalankanPerintah(sql2);

                    }
                    transScope.Complete();
                }
                catch (Exception ex)
                {
                    transScope.Dispose();
                    throw new Exception(ex.Message);
                }


            }
        }

        public static List<Krs> BacaData(string kriteria, string nilaiKriteria)
        {
            Koneksi koneksi = new Koneksi();
            koneksi.Connect();
            string sql1 = "";
          if (kriteria == "")
          {
                koneksi.Connect();
                sql1 = "SELECT k.id, k.tanggal, m.nrp FROM krs k INNER JOIN mahasiswa m on k.mahasiswa_nrp = m.nrp";

          }
          else
          {
                koneksi.Connect();
                sql1 = "SELECT k.id, k.tanggal, m.nrp FROM krs k INNER JOIN mahasiswa m on k.mahasiswa_nrp = m.nrp" + " where " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
          }
          MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql1);

          List<Krs> listOfKrs = new List<Krs>();
          while (hasil.Read() == true)
          {
                int idKrs = int.Parse(hasil.GetValue(0).ToString());
                Mahasiswa m = new Mahasiswa(hasil.GetValue(2).ToString());
                Krs k = new Krs((DateTime)hasil.GetValue(1) , m , idKrs);
                listOfKrs.Add(k);
                List<Jadwal> listJadwal = new List<Jadwal>();
                listJadwal = Jadwal.BacaData("J.id", "");
                foreach (Jadwal j in listJadwal)
                {
                    k.TambahKrsDetail(j);
                }
                
            }
            hasil.Close();
           return listOfKrs;
        }
        public static string GenerateCode()
        {
            Koneksi koneksi = new Koneksi();
            koneksi.Connect();
            string sql = "SELECT MAX(id) FROM krs";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            string idBaru = "";
            int baru = 0;
            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    baru = int.Parse(hasil.GetValue(0).ToString()) + 1;
                    idBaru = baru.ToString();
                }
                else
                {
                     baru = 1;
                     idBaru = baru.ToString();
                }
            }
            return idBaru;
            
        }
        public static void CetakKRS(string pKriteria, string pNilaiKriteria, string pNamaFile, Font pFont)
        {
            Koneksi koneksi = new Koneksi();
            koneksi.Connect();
            List<Krs> listOfKrs = new List<Krs>();
            listOfKrs = Krs.BacaData(pKriteria, pNilaiKriteria);
            StreamWriter file = new StreamWriter(pNamaFile);
            foreach (Krs krs in listOfKrs)
            {
                file.WriteLine("");
                file.WriteLine("MY UNIVERSITY");
                file.WriteLine("Jl. Cantik Surabaya");
                file.WriteLine("Telp. (031) - 12345678");
                file.WriteLine("=".PadRight(50, '='));

                file.WriteLine("ID KRS : " + krs.IdKrs);
                file.WriteLine("Tanggal : " + krs.Tanggal.Date);
                file.WriteLine("Mahasiswa : " + krs.Mahasiswa.Nrp);
                file.WriteLine("=".PadRight(50, '='));

                foreach (KrsDetail kd in krs.ListKrsDetail)
                {
                    string namaKelas = kd.Jadwal.Kelas.Nama;
                    string namaMatkul = kd.Jadwal.MataKuliah.Nama;
                    string hari = kd.Jadwal.Hari;
                    string jam = kd.Jadwal.Jam;
                    file.WriteLine("Details KRS");
                    file.WriteLine("Kelas : " + namaKelas);
                    file.WriteLine("Mata Kuliah : " + namaMatkul);
                    file.WriteLine("Hari : " + hari);
                    file.WriteLine("Jam : " + jam);
                    file.WriteLine("=".PadRight(50, '='));
                }
            }
            file.Close();
            Cetak c = new Cetak(pNamaFile, pFont, 20, 10, 10, 10);
            c.CetakKePrinter("text");
        }





    }
}