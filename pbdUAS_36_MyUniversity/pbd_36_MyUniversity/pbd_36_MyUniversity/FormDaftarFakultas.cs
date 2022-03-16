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
    public partial class FormDaftarFakultas : Form
    {
        public FormDaftarFakultas()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahFakultas formTambahFakultas = new FormTambahFakultas();
            formTambahFakultas.Owner = this;
            formTambahFakultas.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahFakultas formUbahFakultas = new FormUbahFakultas();
            formUbahFakultas.Owner = this;
            formUbahFakultas.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusFakultas formHapusFakultas = new FormHapusFakultas();
            formHapusFakultas.Owner = this;
            formHapusFakultas.Show();
        }

        public List<Falkultas> listFalkultas = new List<Falkultas>();
        public void FormDaftarFakultas_Load(object sender, EventArgs e)
        {
            listFalkultas = Falkultas.BacaData("", "");
            if (listFalkultas.Count > 0)
            {
                dataGridViewFakultas.DataSource = listFalkultas;
            }
            else
            {
                dataGridViewFakultas.DataSource = null;
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxCari.Text == "Id Falkultas")
            {
                listFalkultas = Falkultas.BacaData("id", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "Nama")
            {
                listFalkultas = Falkultas.BacaData("nama", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "Dekan")
            {
                listFalkultas = Falkultas.BacaData("dekan", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "Wakil Dekan")
            {
                listFalkultas = Falkultas.BacaData("wakil_dekan", textBoxCari.Text);
            }
            if (listFalkultas.Count > 0)
            {
                dataGridViewFakultas.DataSource = listFalkultas;
            }
            else
            {
                dataGridViewFakultas.DataSource = null;
            }
        }
    }
}
