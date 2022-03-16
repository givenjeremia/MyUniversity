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
    public partial class FormHapusJurusan : Form
    {
        List<Falkultas> listOfFakultas = new List<Falkultas>();
        List<Jurusan> listOfJurusan = new List<Jurusan>();
        public FormHapusJurusan()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarJurusan formDaftarJurusan = (FormDaftarJurusan)this.Owner;
            formDaftarJurusan.FormDaftarJurusan_Load(buttonKeluar, e);
            this.Close();
            formDaftarJurusan.Enabled = true;
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKetuaJurusan.Clear();
            textBoxNamaJurusan.Clear();
            textBoxWakilKetua.Clear();
            textBoxIdJurusan.Clear();
        }

        private void FormHapusJurusan_Load(object sender, EventArgs e)
        {
            listOfFakultas = Falkultas.BacaData("", "");
            comboBoxFakultas.DataSource = listOfFakultas;
            comboBoxFakultas.DisplayMember = "nama";
            comboBoxFakultas.DropDownStyle = ComboBoxStyle.DropDownList;

            
            textBoxKetuaJurusan.Enabled = false;
            textBoxNamaJurusan.Enabled = false;
            textBoxWakilKetua.Enabled = false;

        }

        private void textBoxIdJurusan_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIdJurusan.Text.Length <= textBoxIdJurusan.MaxLength)
            {
                listOfJurusan = Jurusan.BacaData("J.id", textBoxIdJurusan.Text);
                if (listOfJurusan.Count > 0)
                {
                    textBoxNamaJurusan.Text = listOfJurusan[0].Nama;
                    textBoxKetuaJurusan.Text = listOfJurusan[0].KetuaJurusan;
                    textBoxWakilKetua.Text = listOfJurusan[0].WakilKetua;
                    comboBoxFakultas.Text = listOfJurusan[0].Falkultas.Nama;
                }
                else
                {
                    MessageBox.Show("ID Jurusan Tidak Di Temukan");
                }
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Data Jurusan akan dihapus. apakah anda yakin?", "konfirmasi", MessageBoxButtons.YesNo);
            if (konfirmasi == DialogResult.Yes)
            {
                try
                {
                    Falkultas f = (Falkultas)comboBoxFakultas.SelectedItem;
                    Jurusan j = new Jurusan(textBoxIdJurusan.Text, textBoxNamaJurusan.Text, textBoxKetuaJurusan.Text, textBoxWakilKetua.Text, f);
                    Jurusan.HapusData(j);
                    MessageBox.Show("Data jurusan berhasil dihapus.", "Information");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Penghapusan Gagal. Pesan Kesalahan : " + ex.Message, "Kesalahan");
                }
            }
        }
    }
}
