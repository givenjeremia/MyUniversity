using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MyUniversity_LIB
{
    public class Jabatan
    {
        #region DATA MEMBER
        private string idJabatan;
        private string nama;
        #endregion

        #region CONSTRUCTOR
        public Jabatan(string idJabatan, string nama)
        {
            IdJabatan = idJabatan;
            Nama = nama;
        }
        #endregion

        #region PROPERTIES
        public string IdJabatan { get => idJabatan; set => idJabatan = value; }
        public string Nama { get => nama; set => nama = value; }
        #endregion

        #region METHOD
        public static void UbahData(Jabatan j)
        {
            string sql = "update jabatan set id='" + j.IdJabatan + "' , nama = '" + j.Nama.Replace("'", "\\") + "'";
            Koneksi.JalankanPerintah(sql);
        }
        public static List<Jabatan> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "SELECT * FROM jabatan";

            }
            else
            {
                sql = "SELECT * FROM jabatan" + " where " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Jabatan> listOfJabatan = new List<Jabatan>();
            while (hasil.Read() == true)
            {
                Jabatan j = new Jabatan(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString());
                listOfJabatan.Add(j);
            }
            return listOfJabatan;
        }
        #endregion
    }
}