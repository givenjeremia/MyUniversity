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
    public partial class FormUbahMahasiswa : Form
    {
        public FormUbahMahasiswa()
        {
            InitializeComponent();
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

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Falkultas falkultasPilihan = (Falkultas)comboBoxFakultas.SelectedItem;
                Jurusan jurusanPilihan = (Jurusan)comboBoxJurusan.SelectedItem;
                Ormawa ormawaPilihan = (Ormawa)comboBoxOrmawa.SelectedItem;
                Mahasiswa m = new Mahasiswa(textBoxNrp.Text, int.Parse(textBoxAngkatan.Text), textBoxNama.Text, textBoxAlamat.Text, dateTimePickerTglLahir.Value, textBoxTelepon.Text, textBoxEmail.Text, falkultasPilihan, jurusanPilihan, ormawaPilihan);
                Mahasiswa.UbahData(m);
                MessageBox.Show("Data Mahasiswa Berhasil Di Ubah");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Mahasiswa Gagal Di Ubah. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }
        public List<Falkultas> listFalkultas = new List<Falkultas>();
        public List<Jurusan> listJurusan = new List<Jurusan>();
        public List<Ormawa> listOrmawa = new List<Ormawa>();
        private void FormUbahMahasiswa_Load(object sender, EventArgs e)
        {
            //
            listFalkultas = Falkultas.BacaData("", "");
            comboBoxFakultas.DataSource = listFalkultas;
            comboBoxFakultas.DisplayMember = "nama";
            comboBoxFakultas.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            listJurusan = Jurusan.BacaData("", "");
            comboBoxJurusan.DataSource = listJurusan;
            comboBoxJurusan.DisplayMember = "nama";
            comboBoxJurusan.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            //
            listOrmawa = Ormawa.BacaData("", "");
            comboBoxOrmawa.DataSource = listOrmawa;
            comboBoxOrmawa.DisplayMember = "nama";
            comboBoxOrmawa.DropDownStyle = ComboBoxStyle.DropDownList;
            textBoxNrp.MaxLength = 10;
        }
        public List<Mahasiswa> listMahasiswa = new List<Mahasiswa>();
        private void textBoxNrp_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNrp.Text.Length <= textBoxNrp.MaxLength)
            {
                listMahasiswa = Mahasiswa.BacaData("nrp", textBoxNrp.Text);
                if (listMahasiswa.Count > 0)
                {
                    textBoxAngkatan.Text = listMahasiswa[0].Angkatan.ToString();
                    textBoxNama.Text = listMahasiswa[0].Nama;
                    textBoxAlamat.Text = listMahasiswa[0].Alamat;
                    dateTimePickerTglLahir.Value = listMahasiswa[0].TanggalLahir;
                    textBoxTelepon.Text = listMahasiswa[0].Telepon;
                    textBoxEmail.Text = listMahasiswa[0].Email;
                    comboBoxFakultas.Text = listMahasiswa[0].Falkultas.Nama;
                    comboBoxJurusan.Text = listMahasiswa[0].Jurusan.Nama;
                    comboBoxOrmawa.Text = listMahasiswa[0].Ormawa.Nama;
                }
                else
                {
                    MessageBox.Show("NRP Tidak Di Temukan");
                }
            }
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
