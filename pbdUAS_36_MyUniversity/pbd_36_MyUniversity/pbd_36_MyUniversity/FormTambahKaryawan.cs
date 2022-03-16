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
    public partial class FormTambahKaryawan : Form
    {
        public FormTambahKaryawan()
        {
            InitializeComponent();
        }
        List<Falkultas> listOfFakultas = new List<Falkultas>();
        List<Jurusan> listOfJurusan = new List<Jurusan>();
        List<Jabatan> listOfJabatan = new List<Jabatan>();
        private void FormTambahKaryawan_Load(object sender, EventArgs e)
        {
            listOfFakultas = Falkultas.BacaData("", "");
            listOfJabatan = Jabatan.BacaData("", "");

            comboBoxFakultas.DataSource = listOfFakultas;
            comboBoxFakultas.DisplayMember = "nama";
            comboBoxJabatan.DataSource = listOfJabatan;
            comboBoxJabatan.DisplayMember = "nama";

            textBoxID.MaxLength = 20;
            textBoxNama.MaxLength = 45;
            textBoxAlamat.MaxLength = 45;
            textBoxTelepon.MaxLength = 45;
            textBoxEmail.MaxLength = 45;
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxID.Clear();
            textBoxNama.Clear();
            textBoxAlamat.Clear();
            textBoxEmail.Clear();
            textBoxTelepon.Clear();
            textBoxID.Focus();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Falkultas fDipilih = (Falkultas)comboBoxFakultas.SelectedItem;
                Jurusan juDipilih = (Jurusan)comboBoxJurusan.SelectedItem;
                Jabatan jDipilih = (Jabatan)comboBoxJabatan.SelectedItem;
                Karyawan k = new Karyawan(textBoxID.Text, textBoxNama.Text, textBoxAlamat.Text, dateTimePickerTglLahir.Value, textBoxTelepon.Text, textBoxEmail.Text, jDipilih, fDipilih, juDipilih);
                Karyawan.TambahData(k);
                MessageBox.Show("Data berhasil ditambahkan", "Informasi");
                buttonKosongi_Click(buttonSimpan, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambahkan data. Pesan kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarKaryawan formDaftarKaryawan = (FormDaftarKaryawan)this.Owner;
            formDaftarKaryawan.FormDaftarKaryawan_Load(buttonKeluar, e);
            this.Close();
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

        private void comboBoxJurusan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Jurusan jurusanDipilih = (Jurusan)comboBoxJurusan.SelectedItem;
            string kodeTerbaru = Karyawan.GeneratorKode(jurusanDipilih);
            textBoxID.Text = kodeTerbaru;
            textBoxID.Enabled = false;
        }
    }
}
