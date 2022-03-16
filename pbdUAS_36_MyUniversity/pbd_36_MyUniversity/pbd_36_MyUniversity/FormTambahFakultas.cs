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
    public partial class FormTambahFakultas : Form
    {
        public FormTambahFakultas()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarFakultas formDaftarFakultas = (FormDaftarFakultas)this.Owner;
            formDaftarFakultas.FormDaftarFakultas_Load(buttonKeluar, e);
            this.Close();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Falkultas f = new Falkultas(textBoxIdFalkultas.Text, textBoxNamaFakultas.Text , textBoxDekan.Text , textBoxWakilDekan.Text);
                Falkultas.TambahData(f);
                MessageBox.Show("Data Falkultas Telah Di Simpan");
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

        private void FormTambahFakultas_Load(object sender, EventArgs e)
        {
            string kodeTerbaru = Falkultas.GeneratorKode();
            textBoxIdFalkultas.Text = kodeTerbaru;
            textBoxIdFalkultas.Enabled = false;
            textBoxNamaFakultas.Focus();
        }
    }
}
