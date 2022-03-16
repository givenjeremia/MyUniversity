using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyUniversity_LIB
{
    public class Mahasiswa
    {
        #region DATAMEMBER
        private string nrp;
        private int angkatan;
        private string nama;
        private string alamat;
        private DateTime tanggalLahir;
        private string telepon;
        private string email;
        private Jurusan jurusan;
        private Falkultas falkultas;
        private Ormawa ormawa;
        #endregion

        #region PROPERTIES
        public Jurusan Jurusan
        {
            get => jurusan;
            set
            {
                jurusan = value;
            }
        }

        public Falkultas Falkultas
        {
            get => falkultas;
            set
            {
                falkultas = value;
            }
        }

        public Ormawa Ormawa
        {
            get => ormawa;
            set
            {
                ormawa = value;  
            }
        }

        public string Nrp { get => nrp; set => nrp = value; }
        public int Angkatan { get => angkatan; set => angkatan = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public DateTime TanggalLahir { get => tanggalLahir; set => tanggalLahir = value; }
        public string Telepon { get => telepon; set => telepon = value; }
        public string Email { get => email; set => email = value; }
        #endregion

        #region CONSTRUCTOR
        public Mahasiswa(string nrp, int angkatan, string nama, string alamat, DateTime tanggalLahir, string telepon, string email, Falkultas falkultas, Jurusan jurusan, Ormawa ormawa)
        {
            Jurusan = jurusan;
            Falkultas = falkultas;
            Ormawa = ormawa;
            Nrp = nrp;
            Angkatan = angkatan;
            Nama = nama;
            Alamat = alamat;
            TanggalLahir = tanggalLahir;
            Telepon = telepon;
            Email = email;
        }
        public Mahasiswa(string nrp)
        {
            Nrp = nrp;
        }
        public Mahasiswa()
        {
            Jurusan = null;
            Falkultas = null;
            Ormawa = null;
            Nrp = "";
            Angkatan = 0;
            Nama = "";
            Alamat = "";
            TanggalLahir = DateTime.Now;
            Telepon = "";
            Email = "";
        }
        #endregion

        #region METHOD
        public static void TambahData(Mahasiswa m)
        {
            string sql = "insert into mahasiswa(nrp,angkatan,nama,alamat,tanggalLahir,telepon,email,falkutas_id,jurusan_id,ormawa_idormawa) values('" + m.Nrp + "','" + m.Angkatan + "','" + m.Nama.Replace("'", "\\") + "','" + m.Alamat + "','" + m.TanggalLahir.ToString("yyyy-MM-dd") + "','" + m.Telepon + "','" + m.Email + "','" + m.Falkultas.IdFalkultas + "','" + m.Jurusan.IdJurusan + "','" + m.Ormawa.IdOrmawa + "')";
            Koneksi.JalankanPerintah(sql);
        }
        public static void UbahData(Mahasiswa m)
        {
            string sql = "update mahasiswa set angkatan='" + m.Angkatan  + "' , nama ='" + m.Nama.Replace("'", "\\") + "' , alamat ='" + m.Alamat + "' , tanggalLahir ='" + m.TanggalLahir.ToString("yyyy-MM-dd") + "' , telepon ='" + m.Telepon + "' , email ='" + m.Email + "' , falkutas_id ='" + m.Falkultas.IdFalkultas + "' , jurusan_id ='" + m.Jurusan.IdJurusan + "' , ormawa_idormawa ='" + m.Ormawa.IdOrmawa + "' where nrp ='" + m.Nrp + "'";
            Koneksi.JalankanPerintah(sql);
            
        }
        public static void HapusData(Mahasiswa m)
        {
            string sql = "delete from mahasiswa where nrp ='" + m.Nrp + "'";
            Koneksi.JalankanPerintah(sql);
        }

        public static string GeneratorKode(Jurusan j)
        {
            string sql = "select max(right(nrp,3)) from mahasiswa where jurusan_id = '" + j.IdJurusan + "'";
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

        public static List<Mahasiswa> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "Select M.nrp , M.angkatan , M.nama , M.alamat , M.tanggalLahir , M.telepon , M.email , F.id As IdFalkultas , F.nama AS NamaFalkultas , J.id AS IdJurusan , J.nama AS NamaJurusan , O.idormawa AS IdOrmawa , O.nama AS NamaOrmawa FROM mahasiswa M inner join falkutas F ON M.falkutas_id = F.id  inner join jurusan J ON J.id = M.jurusan_id inner join ormawa O on O.idormawa = M.ormawa_idormawa";
            }
            else
            {
                sql = "Select M.nrp , M.angkatan , M.nama , M.alamat , M.tanggalLahir , M.telepon , M.email , F.id As IdFalkultas , F.nama AS NamaFalkultas , J.id AS IdJurusan , J.nama AS NamaJurusan , O.idormawa AS IdOrmawa , O.nama AS NamaOrmawa FROM mahasiswa M inner join falkutas F ON M.falkutas_id = F.id  inner join jurusan J ON J.id = M.jurusan_id inner join ormawa O on O.idormawa = M.ormawa_idormawa " + " where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Mahasiswa> listMahasiswa = new List<Mahasiswa>();
            while (hasil.Read() == true)
            {
                Falkultas fa = new Falkultas(hasil.GetValue(7).ToString(), hasil.GetValue(8).ToString());
                Jurusan ju = new Jurusan(hasil.GetValue(9).ToString(), hasil.GetValue(10).ToString());
                Ormawa or = new Ormawa(hasil.GetValue(11).ToString(), hasil.GetValue(12).ToString());
                Mahasiswa m = new Mahasiswa(hasil.GetValue(0).ToString(), int.Parse(hasil.GetValue(1).ToString()), hasil.GetValue(2).ToString(), hasil.GetValue(3).ToString(), (DateTime)hasil.GetValue(4) , hasil.GetValue(5).ToString(), hasil.GetValue(6).ToString() , fa,ju,or);
                listMahasiswa.Add(m);
            }
            return listMahasiswa;

        }
        #endregion
    }
}