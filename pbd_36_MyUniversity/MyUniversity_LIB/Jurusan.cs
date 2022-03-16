using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MyUniversity_LIB
{
    public class Jurusan
    {
        #region DATAMEMBER
        private string idJurusan;
        private string nama;
        private string ketuaJurusan;
        private string wakilKetua;
        private Falkultas falkultas;
        #endregion

        #region CONSTRUCTOR
        public Jurusan(string idJurusan, string nama, string ketuaJurusan, string wakilKetua, Falkultas falkultas)
        {
            this.IdJurusan = idJurusan;
            this.Nama = nama;
            this.KetuaJurusan = ketuaJurusan;
            this.WakilKetua = wakilKetua;
            this.Falkultas = falkultas;
        }
        public Jurusan(string idJurusan, string nama)
        {
            this.IdJurusan = idJurusan;
            this.Nama = nama;
        }
        #endregion

        #region PROPERTIES
        public string IdJurusan { get => idJurusan; set => idJurusan = value; }
        public string Nama { get => nama; set => nama = value; }
        public string KetuaJurusan { get => ketuaJurusan; set => ketuaJurusan = value; }
        public string WakilKetua { get => wakilKetua; set => wakilKetua = value; }
        public Falkultas Falkultas { get => falkultas; set => falkultas = value; }
        #endregion

        #region METHOD
        public static void TambahData(Jurusan j)
        {
            string sql = "insert into jurusan(id, nama, ketua_jurusan, wakil_ketua, falkutas_id) values " +
                "('" + j.IdJurusan + "','" + j.Nama.Replace("'", "\\'") +
                "','" + j.KetuaJurusan.Replace("'", "\\'") + "','" +
                j.WakilKetua.Replace("'", "\\'") + "','" +
               j.Falkultas.IdFalkultas + "')";
            Koneksi.JalankanPerintah(sql);
        }
        public static void UbahData(Jurusan j)
        {
            string sql = "update jurusan set nama='" + j.Nama.Replace("'", "\\'") + "', ketua_jurusan='" +
                j.KetuaJurusan.Replace("'", "\\'") + "', wakil_ketua='" + j.WakilKetua.Replace("'", "\\") +
                "', falkutas_id='" + j.Falkultas.IdFalkultas+ "' where id ='" + j.IdJurusan + "'";
            Koneksi.JalankanPerintah(sql);
        }
        public static void HapusData(Jurusan j)
        {
            string sql = "DELETE FROM jurusan WHERE id = '" + j.idJurusan + "'";
            Koneksi.JalankanPerintah(sql);
        }
        public static List<Jurusan> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "select J.id, J.nama, J.ketua_jurusan, J.wakil_ketua, J.falkutas_id, F.nama AS Fakultas " +
                    "from jurusan J inner join falkutas F on J.falkutas_id = F.id";

            }
            else
            {
                sql = "select J.id, J.nama, J.ketua_jurusan, J.wakil_ketua, J.falkutas_id, F.nama AS Fakultas " +
                    "from jurusan J inner join falkutas F on J.falkutas_id = F.id" + " where " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Jurusan> listOfJurusan = new List<Jurusan>();
            while (hasil.Read() == true)
            {
                Falkultas f = new Falkultas(hasil.GetValue(4).ToString(), hasil.GetValue(5).ToString());
                Jurusan j = new Jurusan(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString(), hasil.GetValue(2).ToString(), hasil.GetValue(3).ToString(), f);
                listOfJurusan.Add(j);
            }
            return listOfJurusan;
        }
        public static string GenerateNoNota()
        {
            string sql = "select RIGHT(nomor_order,3) as NoOrders" +
                        " from order " +
                        " where Date(tanggal) = Date(CURRENT_DATE)" +
                        " order by tanggal DESC limit 1";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            string nomorOrder = "";

            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {

                    int noUrutOrder = int.Parse(hasil.GetValue(0).ToString()) + 1;
                    nomorOrder = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + noUrutOrder.ToString().PadLeft(3, '0');
                }

            }
            else
            {
                nomorOrder = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + "001";
            }

            return nomorOrder; 
        }
        #endregion
    }
}