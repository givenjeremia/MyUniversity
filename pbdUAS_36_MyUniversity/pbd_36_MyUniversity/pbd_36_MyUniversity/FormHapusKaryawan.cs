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
    public partial class FormHapusKaryawan : Form
    {
        public FormHapusKaryawan()
        {
            InitializeComponent();
        }
        public List<Karyawan> listOfKaryawan = new List<Karyawan>();

        private void FormHapusKaryawan_Load(object sender, EventArgs e)
        {
            textBoxId.MaxLength = 10;
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
                Falkultas f = (Falkultas)comboBoxFalkutas.SelectedItem;
                Jurusan ju = (Jurusan)comboBoxJurusan.SelectedItem;
                Jabatan j = (Jabatan)comboBoxJabatan.SelectedItem;
                Karyawan k = new Karyawan(textBoxId.Text, textBoxNama.Text, textBoxAlamat.Text, dateTimePickerTglLahir.Value, textBoxTelepon.Text, textBoxEmail.Text, j, f, ju);
                Karyawan.DeleteData(k);
                MessageBox.Show("Data karyawan berhasil dihapus.", "Informasi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Penghapusan Gagal. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            if (textBoxId.MaxLength <= textBoxId.MaxLength)
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
                    comboBoxFalkutas.Text = listOfKaryawan[0].Fakultas.Nama;
                    comboBoxJurusan.Text = listOfKaryawan[0].Jurusan.Nama;

                    textBoxNama.Enabled = false;
                    textBoxAlamat.Enabled = false;
                    textBoxTelepon.Enabled = false;
                    textBoxEmail.Enabled = false;
                    dateTimePickerTglLahir.Enabled = false;
                    comboBoxJabatan.Enabled = false;
                    comboBoxFalkutas.Enabled = false;
                    comboBoxJurusan.Enabled = false;
                }
                else
                {
                    MessageBox.Show("ID Karyawan Tidak Di Temukan");
                }
            }
        }
    }
}
