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
    public partial class FormTambahMahasiswa : Form
    {
        public FormTambahMahasiswa()
        {
            InitializeComponent();
        }
        public List<Falkultas> listFalkultas = new List<Falkultas>();
        public List<Jurusan> listJurusan = new List<Jurusan>();
        public List<Ormawa> listOrmawa = new List<Ormawa>();
        private void FormTambahMahasiswa_Load(object sender, EventArgs e)
        {
            //
            listFalkultas = Falkultas.BacaData("", "");
            comboBoxFakultas.DataSource = listFalkultas;
            comboBoxFakultas.DisplayMember = "nama";
            comboBoxFakultas.DropDownStyle = ComboBoxStyle.DropDownList;


            textBoxNrp.Enabled = false;

        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Falkultas falkultasPilihan = (Falkultas)comboBoxFakultas.SelectedItem;
                Jurusan jurusanPilihan = (Jurusan)comboBoxJurusan.SelectedItem;
                Ormawa ormawaPilihan = (Ormawa)comboBoxOrmawa.SelectedItem;
                Mahasiswa m = new Mahasiswa(textBoxNrp.Text, int.Parse(textBoxAngkatan.Text), textBoxNama.Text, textBoxAlamat.Text, dateTimePickerTglLahir.Value, textBoxTelepon.Text, textBoxEmail.Text, falkultasPilihan, jurusanPilihan, ormawaPilihan);
                Mahasiswa.TambahData(m);
                MessageBox.Show("Data Mahasiswa Berhasil Di Tambahkan");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Mahasiswa Gagal Di Tambahkan. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }


        private void comboBoxJurusan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Jurusan j = (Jurusan)comboBoxJurusan.SelectedItem;
            string kodeBarang = Mahasiswa.GeneratorKode(j);
            textBoxNrp.Text = kodeBarang;
            textBoxNama.Focus();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarMahasiswa formDaftarMahasiswa = (FormDaftarMahasiswa)this.Owner;
            formDaftarMahasiswa.FormDaftarMahasiswa_Load(buttonKeluar, e);
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNrp.Clear();
            textBoxAngkatan.Clear();
            textBoxNama.Clear();
            textBoxAlamat.Clear();
            dateTimePickerTglLahir.Refresh();
            textBoxTelepon.Clear();
            textBoxEmail.Clear();
        }

        private void comboBoxFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = "";
            foreach (Falkultas f in listFalkultas)
            {
                if (comboBoxFakultas.Text == f.Nama)
                {
                    id = f.IdFalkultas;
                }
            }

            listJurusan = Jurusan.BacaData("falkutas_id", id);

            comboBoxJurusan.DataSource = listJurusan;
            comboBoxJurusan.DisplayMember = "nama";
            comboBoxJurusan.DropDownStyle = ComboBoxStyle.DropDownList;

            listOrmawa = Ormawa.BacaData("falkutas_id", id);
            comboBoxOrmawa.DataSource = listOrmawa;
            comboBoxOrmawa.DisplayMember = "nama";
            comboBoxOrmawa.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
