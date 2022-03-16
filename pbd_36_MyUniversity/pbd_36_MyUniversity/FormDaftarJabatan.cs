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
    public partial class FormDaftarJabatan : Form
    {
        public List<Jabatan> listOfJabatan = new List<Jabatan>();
        public FormDaftarJabatan()
        {
            InitializeComponent();
        }

        private void FormDaftarJabatan_Load(object sender, EventArgs e)
        {
            listOfJabatan = Jabatan.BacaData("", "");
            if (listOfJabatan.Count > 0)
            {
                dataGridViewJabatan.DataSource = listOfJabatan;
            }
            else
            {
                dataGridViewJabatan.DataSource = null;
            }
        }


        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {

            if (comboBoxCari.Text == "ID Jabatan")
            {
                listOfJabatan = Jabatan.BacaData("id", textBoxCari.Text);
            }
            else if (comboBoxCari.Text == "Nama Jabatan")
            {
                listOfJabatan = Jabatan.BacaData("nama", textBoxCari.Text);
            }
            if (listOfJabatan.Count > 0)
            {
                dataGridViewJabatan.DataSource = listOfJabatan;
            }
            else
            {
                dataGridViewJabatan.DataSource = null;
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
