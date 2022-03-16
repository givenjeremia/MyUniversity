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
    public partial class FormHapusFakultas : Form
    {
        public FormHapusFakultas()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Falkultas f = new Falkultas(textBoxIdFalkultas.Text, textBoxNamaFakultas.Text, textBoxDekan.Text, textBoxWakilDekan.Text);
                Falkultas.HapusData(f);
                MessageBox.Show("Data Falkultas Telah Di Hapus");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Penyimpanan Gagal. Pesan Kesalahan : " + ex.Message + " Kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxIdFalkultas.Clear();
            textBoxNamaFakultas.Clear();
            textBoxDekan.Clear();
            textBoxWakilDekan.Clear();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarFakultas formDaftarFakultas = (FormDaftarFakultas)this.Owner;
            formDaftarFakultas.FormDaftarFakultas_Load(buttonKeluar, e);
            this.Close();
        }

        private void FormHapusFakultas_Load(object sender, EventArgs e)
        {
            textBoxIdFalkultas.MaxLength = 2;
        }
        public List<Falkultas> listFalkultas = new List<Falkultas>();
        private void textBoxIdFalkultas_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIdFalkultas.Text.Length <= textBoxIdFalkultas.MaxLength)
            {
                listFalkultas = Falkultas.BacaData("id", textBoxIdFalkultas.Text);
                if (listFalkultas.Count > 0)
                {
                    textBoxNamaFakultas.Text = listFalkultas[0].Nama;
                    textBoxDekan.Text = listFalkultas[0].Dekan;
                    textBoxWakilDekan.Text = listFalkultas[0].WakilDekan;
                    textBoxNamaFakultas.Enabled = false;
                    textBoxDekan.Enabled = false;
                    textBoxWakilDekan.Enabled = false;
                    buttonSimpan.Focus();
                }
                else
                {
                    MessageBox.Show("ID Falkultas Tidak Di Temukan");
                    textBoxNamaFakultas.Clear();
                    textBoxDekan.Clear();
                    textBoxWakilDekan.Clear();
                }
            }
        }
    }
}
