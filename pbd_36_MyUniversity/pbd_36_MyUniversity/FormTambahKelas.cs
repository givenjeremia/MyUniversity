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
    public partial class FormTambahKelas : Form
    {
        public List<Kelas> listOfKelas = new List<Kelas>();
        public List<Falkultas> listOfFakultas = new List<Falkultas>();
        public FormTambahKelas()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarKelas formDaftarKelas = (FormDaftarKelas)this.Owner;
            formDaftarKelas.FormDaftarKelas_Load(buttonKeluar, e);
            this.Close();
            formDaftarKelas.Enabled = true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxIdKelas.Clear();
            textBoxNamaKelas.Clear();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Falkultas f = (Falkultas)comboBoxFalkultas.SelectedItem;
                Kelas k = new Kelas(textBoxIdKelas.Text, textBoxNamaKelas.Text, f);
                Kelas.TambahData(k);
                MessageBox.Show("Data Kelas Telah Tersimpan.", "Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Penyimpanan Gagal. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void comboBoxFalkultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxFalkultas.SelectedIndex != -1)
                {
                    Falkultas fakultasDipilih = (Falkultas)comboBoxFalkultas.SelectedItem;
                    string kodeTerbaru = Kelas.GeneratorKode(fakultasDipilih);
                    textBoxIdKelas.Text = kodeTerbaru;
                    textBoxNamaKelas.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal melakukan generate kode. Pesan Kesalahan : " + ex.Message);
            }
        }

        private void FormTambahKelas_Load(object sender, EventArgs e)
        {
            textBoxIdKelas.Enabled = false;
            listOfFakultas = Falkultas.BacaData("", "");
            comboBoxFalkultas.DataSource = listOfFakultas;
            comboBoxFalkultas.DisplayMember = "nama";
            comboBoxFalkultas.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxIdKelas.MaxLength = 20;
            textBoxNamaKelas.MaxLength = 45;
          
        }
    }
}
