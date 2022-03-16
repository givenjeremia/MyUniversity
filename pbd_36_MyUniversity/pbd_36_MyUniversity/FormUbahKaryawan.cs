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
    public partial class FormUbahKaryawan : Form
    {
        List<Karyawan> listOfKaryawan = new List<Karyawan>();
        List<Falkultas> listOfFakultas = new List<Falkultas>();
        List<Jurusan> listOfJurusan = new List<Jurusan>();
        List<Jabatan> listOfJabatan = new List<Jabatan>();
        public FormUbahKaryawan()
        {
            InitializeComponent();
        }

        private void FormUbahKaryawan_Load(object sender, EventArgs e)
        {
            listOfFakultas = Falkultas.BacaData("", "");
            listOfJabatan = Jabatan.BacaData("", "");

            comboBoxFakultas.DataSource = listOfFakultas;
            comboBoxFakultas.DisplayMember = "nama";
            comboBoxJabatan.DataSource = listOfJabatan;
            comboBoxJabatan.DisplayMember = "nama";

            textBoxId.MaxLength = 20;
            textBoxNama.MaxLength = 45;
            textBoxAlamat.MaxLength = 45;
            textBoxTelepon.MaxLength = 45;
            textBoxEmail.MaxLength = 45;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarKaryawan formDaftarKaryawan = (FormDaftarKaryawan)this.Owner;
            formDaftarKaryawan.FormDaftarKaryawan_Load(buttonKeluar, e);
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxId.Clear();
            textBoxNama.Clear();
            textBoxAlamat.Clear();
            textBoxEmail.Clear();
            textBoxTelepon.Clear();
            textBoxId.Focus();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Falkultas fDipilih = (Falkultas)comboBoxFakultas.SelectedItem;
                Jurusan juDipilih = (Jurusan)comboBoxJurusan.SelectedItem;
                Jabatan jDipilih = (Jabatan)comboBoxJabatan.SelectedItem;
                Karyawan k = new Karyawan(textBoxId.Text, textBoxNama.Text, textBoxAlamat.Text, dateTimePickerTglLahir.Value, textBoxTelepon.Text, textBoxEmail.Text, jDipilih, fDipilih, juDipilih);
                Karyawan.UbahData(k);
                MessageBox.Show("Data berhasil diubah", "Informasi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Perubahan gagal. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }



        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            listOfKaryawan = Karyawan.BacaData("k.id", textBoxId.Text);
            if (listOfKaryawan.Count > 0)
            {
                textBoxNama.Text = listOfKaryawan[0].Nama;
                textBoxAlamat.Text = listOfKaryawan[0].Alamat;
                dateTimePickerTglLahir.Value = listOfKaryawan[0].TanggalLahir;
                textBoxTelepon.Text = listOfKaryawan[0].Telepon;
                textBoxEmail.Text = listOfKaryawan[0].Email;
                comboBoxJabatan.Text = listOfKaryawan[0].Jabatan.Nama;
                comboBoxFakultas.Text = listOfKaryawan[0].Fakultas.Nama;
                comboBoxJurusan.Text = listOfKaryawan[0].Jurusan.Nama;
            }
            else
            {
                MessageBox.Show("ID Karyawan tidak ditemukan.", "Kesalahan");
                textBoxId.Clear();
                textBoxNama.Clear();
                textBoxAlamat.Clear();
                textBoxEmail.Clear();
                textBoxTelepon.Clear();
                textBoxId.Focus();
            }
        }

        private void comboBoxFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = "";
            foreach (Falkultas f in listOfFakultas)
            {
                if (comboBoxFakultas.Text == f.Nama)
                {
                    id = f.IdFalkultas;
                }
            }

            listOfJurusan = Jurusan.BacaData("falkutas_id", id);

            comboBoxJurusan.DataSource = listOfJurusan;
            comboBoxJurusan.DisplayMember = "nama";
            comboBoxJurusan.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
