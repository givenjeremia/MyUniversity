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
    public partial class FormUbahJurusan : Form
    {
        public List<Jurusan> listOfJurusan = new List<Jurusan>();
        public List<Falkultas> listOfFakultas = new List<Falkultas>();
        public FormUbahJurusan()
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

        
        private void FormUbahJurusan_Load(object sender, EventArgs e)
        {
            listOfFakultas = Falkultas.BacaData("", "");
            comboBoxFakultas.DataSource = listOfFakultas;
            comboBoxFakultas.DisplayMember = "nama";
            comboBoxFakultas.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxIdJurusan.MaxLength = 20;
            textBoxNamaJurusan.MaxLength = 45;
            textBoxKetuaJurusan.MaxLength = 45;
            textBoxWakilKetua.MaxLength = 45;
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
            try
            {
                Falkultas falkultasPilihan = (Falkultas)comboBoxFakultas.SelectedItem;
                Jurusan j = new Jurusan(textBoxIdJurusan.Text, textBoxNamaJurusan.Text, textBoxKetuaJurusan.Text, textBoxWakilKetua.Text, falkultasPilihan);
                Jurusan.UbahData(j);
                MessageBox.Show("Data jurusan Berhasil Di Ubah");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data jurusan Gagal Di Ubah. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }
    }
}
