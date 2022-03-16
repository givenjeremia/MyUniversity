using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyUniversity_LIB
{
    public class KrsDetail
    {
        private Jadwal jadwal;
        private Krs krs;

        public Jadwal Jadwal { get => jadwal; set => jadwal = value; }
        public Krs Krs { get => krs; set => krs = value; }

        public KrsDetail(Jadwal jadwal)
        {
            Jadwal = jadwal;
        }
        public KrsDetail(Krs krs ,Jadwal jadwal)
        {
            Krs = krs;
            Jadwal = jadwal;
        }
        public KrsDetail(Krs krs)
        {
            Krs = krs;
        }

        #region METOD

        public static List<KrsDetail> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "SELECT mk.id AS IdMataKuliah , mk.nama AS NamaMataKuliah , ks.id AS IdKrs , ks.mahasiswa_nrp AS NrpMahasiswa , j.id " +
                      "FROM krs_details kd INNER JOIN jadwal j ON kd.id_jadwal = j.id " +
                      "INNER JOIN krs ks ON ks.id = kd.id_krs " +
                      "INNER JOIN mata_kuliah mk ON j.mata_kuliah_id = mk.id ";
            }
            else
            {
                sql = "SELECT mk.id AS IdMataKuliah , mk.nama AS NamaMataKuliah , ks.id AS IdKrs , ks.mahasiswa_nrp AS NrpMahasiswa , j.id " +
                      "FROM krs_details kd INNER JOIN jadwal j ON kd.id_jadwal = j.id " +
                      "INNER JOIN krs ks ON ks.id = kd.id_krs " +
                      "INNER JOIN mata_kuliah mk ON j.mata_kuliah_id = mk.id "+
                " where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<KrsDetail> listKrsDetails = new List<KrsDetail>();
            while (hasil.Read() == true)
            {
                MataKuliah mataKuliah = new MataKuliah(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString());
                Mahasiswa nrp = new Mahasiswa(hasil.GetValue(3).ToString());
                int idJadwal = int.Parse(hasil.GetValue(4).ToString());
                Krs krs = new Krs(int.Parse(hasil.GetValue(2).ToString()), nrp);
                Jadwal jadwal = new Jadwal(idJadwal,mataKuliah);
                KrsDetail krsNew = new KrsDetail(krs,jadwal);
                listKrsDetails.Add(krsNew);
            }
            return listKrsDetails;
        }


        #endregion

    }
}