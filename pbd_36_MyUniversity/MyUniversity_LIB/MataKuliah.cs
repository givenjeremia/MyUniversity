using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyUniversity_LIB
{
    public class MataKuliah
    {
        #region DATAMEMBER
        private string id;
        private string nama;
        private int jumlahSKS;
        private Jurusan jurusan;
        #endregion

        #region CONSTRUCTOR
        public MataKuliah(string id, string nama, int jumlahSKS, Jurusan jurusan)
        {
            this.Id = id;
            this.Nama = nama;
            this.JumlahSKS = jumlahSKS;
            this.Jurusan = jurusan;
        }
        public MataKuliah(string id, string nama)
        {
            this.Id = id;
            this.Nama = nama;
        }
        public MataKuliah(string id)
        {
            this.Id = id;
            
        }
        #endregion

        #region PROPERTIES
        public string Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public int JumlahSKS { get => jumlahSKS; set => jumlahSKS = value; }
        public Jurusan Jurusan { get => jurusan; set => jurusan = value; }
        #endregion

        #region METHOD
        public static void TambahData(MataKuliah mk)
        {
            string sql = "insert into mata_kuliah(id, nama, jumlah_sks, jurusan_id) values " +
                "('" + mk.Id + "','" + mk.Nama.Replace("'", "\\'") +
                "','" + mk.JumlahSKS + "','" +
                mk.Jurusan.IdJurusan  +
                "')";
            Koneksi.JalankanPerintah(sql);
        }
        public static void UbahData(MataKuliah mk)
        {
            string sql = "update mata_kuliah set nama='" + mk.nama.Replace("'", "\\'") + "', jumlah_sks='" +
                mk.JumlahSKS + "', jurusan_id='" + mk.Jurusan.IdJurusan + "' where id ='" + mk.Id + "'";
            Koneksi.JalankanPerintah(sql);
        }
        public static void HapusData(MataKuliah mk)
        {
            string sql = "DELETE FROM mata_kuliah WHERE id = '" + mk.Id + "'";
            Koneksi.JalankanPerintah(sql);
        }

        public static List<MataKuliah> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select Mk.id, Mk.nama, Mk.jumlah_sks, Mk.jurusan_id, J.nama AS Jurusan " +
                    "from mata_kuliah Mk inner join jurusan J on Mk.jurusan_id = J.id";

            }
            else
            {
                sql = "select Mk.id, Mk.nama, Mk.jumlah_sks, Mk.jurusan_id, J.nama AS Jurusan " +
                       "from mata_kuliah Mk inner join jurusan J on Mk.jurusan_id = J.id " + " where "
                       + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<MataKuliah> listOfMatakuliah = new List<MataKuliah>();
            while (hasil.Read() == true)
            {

                Jurusan j = new Jurusan(hasil.GetValue(3).ToString(), hasil.GetValue(4).ToString());
                MataKuliah mk = new MataKuliah(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString(), int.Parse(hasil.GetValue(2).ToString()), j);
                listOfMatakuliah.Add(mk);
            }
            return listOfMatakuliah;
        }
        public static string GeneratorKode(Jurusan j)
        {
            string sql = "select max(right(id,1)) from mata_kuliah where jurusan_id = '" + j.IdJurusan + "'";
            string hasilKode = "";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    int kodeTerbaru = int.Parse(hasil.GetValue(0).ToString()) + 1;
                    hasilKode = j.IdJurusan + kodeTerbaru.ToString().PadLeft(1, '0');
                }
                else
                {
                    hasilKode = j.IdJurusan + "1";
                }
            }

            return hasilKode;
        }
        #endregion

    }
}