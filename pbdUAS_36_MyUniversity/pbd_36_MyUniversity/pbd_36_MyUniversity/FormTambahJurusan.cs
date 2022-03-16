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
    public partial class FormTambahJurusan : Form
    {
        List<Falkultas> listOfFakultas = new List<Falkultas>();
        public FormTambahJurusan()
        {
            InitializeComponent();
        }

        private void FormTambahJurusan_Load(object sender, EventArgs e)
        {
            textBoxIdJurusan.Enabled = false;
            listOfFakultas = Falkultas.BacaData("", "");
            comboBoxFakultas.DataSource = listOfFakultas;
            comboBoxFakultas.DisplayMember = "nama";
            comboBoxFakultas.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxIdJurusan.MaxLength = 20;
            textBoxNamaJurusan.MaxLength = 45;
            textBoxKetuaJurusan.MaxLength = 45;
            textBoxWakilKetua.MaxLength = 45;

           
        }

        private void comboBoxFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxFakultas.SelectedIndex != -1)
                {
                    Falkultas fakultasDipilih = (Falkultas)comboBoxFakultas.SelectedItem;
                    string kodeTerbaru = Jurusan.GeneratorKode(fakultasDipilih);
                    textBoxIdJurusan.Text = kodeTerbaru;
                    textBoxNamaJurusan.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal melakukan generate kode. Pesan Kesalahan : " + ex.Message);
            }
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
            textBoxNamaJurusan.Clear();
            textBoxKetuaJurusan.Clear();
            textBoxIdJurusan.Clear();
            textBoxWakilKetua.Clear();
            
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Falkultas f = (Falkultas)comboBoxFakultas.SelectedItem;
                Jurusan j = new Jurusan(textBoxIdJurusan.Text, textBoxNamaJurusan.Text, textBoxKetuaJurusan.Text,
                    textBoxWakilKetua.Text, f);
                Jurusan.TambahData(j);
                MessageBox.Show("Data Jurusan Telah Tersimpan.", "Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Penyimpanan Gagal. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }
    }
}
