using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyUniversity_LIB;

namespace pbd_36_MyUniversity
{
    public partial class FormTambahKRS : Form
    {
        List<Mahasiswa> listMahasiswa = new List<Mahasiswa>();
        List<Jadwal> listJadwal = new List<Jadwal>();
        Krs krs;
        public FormTambahKRS()
        {
            InitializeComponent();
        }

        private void FormTambahKRS_Load(object sender, EventArgs e)
        {
            Koneksi koneksi = new Koneksi();
            koneksi.Connect();
            //TAMBAH BUTTON MAHASISWA
            listMahasiswa = Mahasiswa.BacaData("", "");
            comboBoxNRP.DataSource = listMahasiswa;
            comboBoxNRP.DisplayMember = "nrp";
            comboBoxNRP.DropDownStyle = ComboBoxStyle.DropDownList;
            //JADWAL CB
            listJadwal = Jadwal.BacaData("", "");
            comboBoxJadwal.DataSource = listJadwal;
            comboBoxJadwal.DisplayMember = "id";
            comboBoxJadwal.DropDownStyle = ComboBoxStyle.DropDownList;
            //AUTO ID 
            textBoxIdKrs.Enabled = false;
            string idBaru = Krs.GenerateCode();
            textBoxIdKrs.Text = idBaru;
            comboBoxNRP.Focus();
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi koneksi = new Koneksi();
                koneksi.Connect();
                Mahasiswa mahasiswaPilihan = (Mahasiswa)comboBoxNRP.SelectedItem;
                int krsID = int.Parse(textBoxIdKrs.Text);
                krs = new Krs(dateTimePickerTanggal.Value.Date, mahasiswaPilihan, krsID);
                listJadwal = Jadwal.BacaData("J.id", comboBoxJadwal.Text);
            krs.TambahKrsDetail(listJadwal[0]);
                Krs.TambahData(krs);
                MessageBox.Show("Data Nilai Berhasil Di Tambahkan");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Nilai Gagal Di Tambahkan. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Koneksi koneksi = new Koneksi();
            koneksi.Connect();
            FormDaftarKRS formDaftarKrs = (FormDaftarKRS)this.Owner;
            formDaftarKrs.FormDaftarKRS_Load(buttonKeluar, e);
            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxJadwal.SelectedIndex = 1;
            comboBoxNRP.SelectedIndex = 1;
        }
    }
}
