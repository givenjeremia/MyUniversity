using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyUniversity_LIB
{
    public class Nilai
    {
        private int id;
        private double inputNilai;
        private KrsDetail krsDetail;

        public int Id { get => id; set => id = value; }
        public double InputNilai { get => inputNilai; set => inputNilai = value; }
        public KrsDetail KrsDetail { get => krsDetail; set => krsDetail = value; }

        public Nilai(KrsDetail krsDetail , int id, double inputNilai )
        {
            Id = id;
            InputNilai = inputNilai;
            KrsDetail = krsDetail;
        }
        public Nilai(int id)
        {
            Id = id;
        }

        public static void TambahData(Nilai n)
        {
            string sql = "INSERT INTO nilai (id,nilai,krs_details_id_jadwal,krs_details_id_krs) values('" + n.Id + "','" + n.InputNilai + "','" + n.KrsDetail.Jadwal.Id + "','" + n.KrsDetail.Krs.IdKrs + "')";
            Koneksi.JalankanPerintah(sql);
        }

        public static void UbahData(Nilai n)
        {
            string sql = "update nilai set nilai='" + n.InputNilai + "' , krs_details_id_jadwal='" + n.KrsDetail.Jadwal.Id + "' , krs_details_id_krs ='" + n.KrsDetail.Krs.IdKrs + "' where id='" + n.Id + "'";
            Koneksi.JalankanPerintah(sql);
        }

        public static void HapusData(Nilai n)
        {
            string sql = "delete from nilai where id ='" + n.Id + "'";
            Koneksi.JalankanPerintah(sql);
        }

        public static string GeneratorKode()
        {
            string sql = "select max(id) from nilai";
            string hasilKode = "";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    int kodeTerbaru = int.Parse(hasil.GetValue(0).ToString()) + 1;
                    hasilKode = kodeTerbaru.ToString().PadLeft(1, '0');
                }
                else
                {
                    hasilKode = "1";
                }
            }

            return hasilKode;
        }

        public static List<Nilai> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "SELECT n.id AS IdNilai, n.nilai AS Nilai, ks.id AS IdKrs , ks.mahasiswa_nrp AS NrpMahasiswa , j.id AS IdJadwal " +
                       "FROM nilai n INNER JOIN jadwal j ON n.krs_details_id_jadwal = j.id " +
                       "INNER JOIN krs ks ON ks.id = n.krs_details_id_krs" ;
            }
            else
            {
                sql = "SELECT n.id AS IdNilai, n.nilai AS Nilai, ks.id AS IdKrs , ks.mahasiswa_nrp AS NrpMahasiswa , j.id AS IdJadwal " +
                       "FROM nilai n INNER JOIN jadwal j ON n.krs_details_id_jadwal = j.id " +
                       "INNER JOIN krs ks ON ks.id = n.krs_details_id_krs " +
                       "where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Nilai> listNilai = new List<Nilai>();  
            while (hasil.Read() == true)
            {
                int idNilai = int.Parse(hasil.GetValue(0).ToString());
                double nilai = double.Parse(hasil.GetValue(1).ToString());
                Mahasiswa nrp = new Mahasiswa(hasil.GetValue(3).ToString());
                Krs krs = new Krs(int.Parse(hasil.GetValue(2).ToString()) ,nrp);
                Jadwal j = new Jadwal(int.Parse(hasil.GetValue(4).ToString()));
                
                KrsDetail krsNew = new KrsDetail(krs, j);
                //
                Nilai n = new Nilai(krsNew, idNilai, nilai);
                listNilai.Add(n);
            }
            return listNilai;

        }

    }
}                                                                        