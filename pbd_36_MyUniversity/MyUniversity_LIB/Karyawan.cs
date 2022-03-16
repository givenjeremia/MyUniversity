using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyUniversity_LIB
{
    public class Karyawan
    {
        #region FIELDS
        private string idKaryawan;
        private string nama;
        private string alamat;
        private DateTime tanggalLahir;
        private string telepon;
        private string email;
        private Jabatan jabatan;
        private Falkultas fakultas;
        private Jurusan jurusan;
        #endregion

        #region CONSTRUCTOR
        public Karyawan(string idKaryawan, string nama, string alamat, DateTime tanggalLahir, string telepon, string email, Jabatan jabatan, Falkultas fakultas, Jurusan jurusan)
        {
            this.IdKaryawan = idKaryawan;
            this.Nama = nama;
            this.Alamat = alamat;
            this.TanggalLahir = tanggalLahir;
            this.Telepon = telepon;
            this.Email = email;
            this.Jabatan = jabatan;
            this.Fakultas = fakultas;
            this.Jurusan = jurusan;
        }
        #endregion

        #region PROPERTIES
        public string IdKaryawan { get => idKaryawan; set => idKaryawan = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public DateTime TanggalLahir { get => tanggalLahir; set => tanggalLahir = value; }
        public string Telepon { get => telepon; set => telepon = value; }
        public string Email { get => email; set => email = value; }
        public Jabatan Jabatan { get => jabatan; set => jabatan = value; }
        public Falkultas Fakultas { get => fakultas; set => fakultas = value; }
        public Jurusan Jurusan { get => jurusan; set => jurusan = value; }
        #endregion

        #region METHOD
        public static void TambahData(Karyawan k)
        {
            string sql = "INSERT INTO karyawan(id, nama, alamat, tanggalLahir, telepon, " +
                "email, jabatan_id, falkutas_id, jurusan_id) VALUES('" + k.IdKaryawan + "', '" +
                k.Nama.Replace("'", "\\'") + "', '" + k.Alamat.Replace("'", "\\'") + "', '" +
                k.TanggalLahir.ToString("yyyy-MM-dd") + "', '" + k.Telepon + "', '" + k.Email.Replace("'", "\\'") + "', '" +
                k.Jabatan.IdJabatan + "', '" + k.Fakultas.IdFalkultas + "', '" + k.Jurusan.IdJurusan + "')";
            Koneksi.JalankanPerintah(sql);
        }
        public static void UbahData(Karyawan k)
        {
            string sql = "UPDATE karyawan SET nama = '" + k.Nama.Replace("'", "\\'") + "', alamat = '" +
                k.Alamat.Replace("'", "\\'") + "', tanggalLahir = '" + k.TanggalLahir.ToString("yyyy-MM-dd") + "', telepon = '" + k.Telepon +
                "', email = '" + k.Email.Replace("'", "\\'") + "', jabatan_id = '" + k.Jabatan.IdJabatan + "', falkutas_id = '" +
                k.Fakultas.IdFalkultas + "', jurusan_id = '" + k.Jurusan.IdJurusan + "' WHERE id = '" + k.IdKaryawan + "'";
            Koneksi.JalankanPerintah(sql);
        }
        public static void DeleteData(Karyawan k)
        {
            string sql = "DELETE FROM karyawan WHERE id = '" + k.IdKaryawan + "'";
            Koneksi.JalankanPerintah(sql);
        }
        public static List<Karyawan> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "SELECT k.id, k.nama, k.alamat, k.tanggalLahir, k.telepon, k.email, j.id AS IdJabatan, j.nama AS NamaJabatan, f.id AS IdFalkultas, f.nama AS NamaFakultas, ju.id AS IdJurusan, ju.nama AS NamaJurusan " +
                    "FROM karyawan k INNER JOIN jurusan ju on k.jurusan_id = ju.id INNER JOIN falkutas f on k.falkutas_id = f.id INNER JOIN jabatan j on k.jabatan_id = j.id";

            }
            else
            {
                sql = "SELECT k.id, k.nama, k.alamat, k.tanggalLahir, k.telepon, k.email, j.id AS IdJabatan, j.nama AS NamaJabatan, f.id AS IdFalkultas, f.nama AS NamaFakultas, ju.id AS IdJurusan, ju.nama AS NamaJurusan " +
                    "FROM((karyawan k INNER JOIN jurusan ju on k.jurusan_id = ju.id) INNER JOIN falkutas f on k.falkutas_id = f.id) INNER JOIN jabatan j on k.jabatan_id = j.id" + " where " + kriteria + " LIKE '%" + nilaiKriteria + "%'"; ;
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Karyawan> listOfKaryawan = new List<Karyawan>();
            while (hasil.Read() == true)
            {
                Jabatan jaba = new Jabatan(hasil.GetValue(6).ToString(), hasil.GetValue(7).ToString());
                Falkultas fal = new Falkultas(hasil.GetValue(8).ToString(), hasil.GetValue(9).ToString());
                Jurusan juru = new Jurusan(hasil.GetValue(10).ToString(), hasil.GetValue(11).ToString());
                Karyawan k = new Karyawan(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString(), hasil.GetValue(2).ToString(), (DateTime)hasil.GetValue(3), hasil.GetValue(4).ToString(), hasil.GetValue(5).ToString(), jaba, fal, juru);
                listOfKaryawan.Add(k);
            }
            return listOfKaryawan;
        }
        public static string GeneratorKode(Jurusan j)
        {
            string sql = "select max(right(id,1)) from karyawan where jurusan_id = '" + j.IdJurusan + "'";
            string hasilKode = "";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    int kodeTerbaru = int.Parse(hasil.GetValue(0).ToString()) + 1;
                    hasilKode = j.IdJurusan + kodeTerbaru.ToString().PadLeft(3, '0');
                }
                else
                {
                    hasilKode = j.IdJurusan + "001";
                }
            }
            return hasilKode;
        }
        #endregion

    }
}