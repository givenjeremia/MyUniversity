using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyUniversity_LIB
{
    public class Ormawa
    {
        #region DATAMEMBER
        private string idOrmawa;
        private string nama;
        private string ketuaOrmawa;
        private Falkultas falkultas;
        #endregion

        #region PROPERTIES
        public string IdOrmawa { get => idOrmawa; set => idOrmawa = value; }
        public string Nama { get => nama; set => nama = value; }
        public string KetuaOrmawa { get => ketuaOrmawa; set => ketuaOrmawa = value; }
        public Falkultas Falkultas
        {
            get => falkultas;
            set
            {
                falkultas = value;
            }
        }
        #endregion

        #region CONSTRUCTOR
        public Ormawa(string idOrmawa, string nama, string ketuaOrmawa, Falkultas falkultas)
        {
            IdOrmawa = idOrmawa;
            Nama = nama;
            KetuaOrmawa = ketuaOrmawa;
            Falkultas = falkultas;
        }
        public Ormawa(string idOrmawa, string nama)
        {
            IdOrmawa = idOrmawa;
            Nama = nama;
        }
        #endregion

        #region METHOD
        public static void TambahData(Ormawa o)
        {
            string sql = "insert into ormawa(idormawa,nama,ketua_ormawa,falkutas_id) values('" + o.IdOrmawa + "','" + o.Nama.Replace("'", "\\") + "','" + o.KetuaOrmawa + "','" + o.Falkultas.IdFalkultas + "')";
            Koneksi.JalankanPerintah(sql);
        }

        public static void UbahData(Ormawa o)
        {
            string sql = "update ormawa set nama='" + o.Nama.Replace("'", "\\") + "' , ketua_ormawa ='" + o.KetuaOrmawa + "' , falkutas_id ='" + o.Falkultas.IdFalkultas + "' where idormawa ='" + o.IdOrmawa + "'";
            Koneksi.JalankanPerintah(sql);
        }

        public static void HapusData(Ormawa o)
        {
            string sql = "delete from ormawa where idormawa ='" + o.IdOrmawa + "'";
            Koneksi.JalankanPerintah(sql);
        }

        public static string GeneratorKode(Falkultas f)
        {
            string sql = "select max(right(idormawa,1)) from ormawa where falkutas_id = '" + f.IdFalkultas + "'";
            string hasilKode = "";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    int kodeTerbaru = int.Parse(hasil.GetValue(0).ToString()) + 1;
                    hasilKode = f.IdFalkultas + kodeTerbaru.ToString().PadLeft(1, '0');
                }
                else
                {
                    hasilKode = f.IdFalkultas + "1";
                }
            }

            return hasilKode;
        }

        public static List<Ormawa> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select O.idormawa, O.nama, O.ketua_ormawa , F.id AS IdFalkutas , F.Nama AS NamaFalkultas  from ormawa O inner join falkutas F on O.falkutas_id = F.id";
            }
            else
            {
                sql = "select O.idormawa, O.nama, O.ketua_ormawa , F.id AS IdFalkutas , F.Nama AS NamaFalkultas from ormawa O inner join falkutas F on O.falkutas_id = F.id " + " where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Ormawa> listBarang = new List<Ormawa>();
            while (hasil.Read() == true)
            {
                Falkultas fa = new Falkultas(hasil.GetValue(3).ToString(), hasil.GetValue(4).ToString());
                Ormawa o = new Ormawa(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString(), hasil.GetValue(2).ToString(), fa);
                listBarang.Add(o);
            }
            return listBarang;

        }
        #endregion

    }
}