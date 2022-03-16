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
    public partial class FormDaftarKelas : Form
    {
        List<Kelas> listOfkelas = new List<Kelas>();
        List<Falkultas> listOfFakultas = new List<Falkultas>();
        public FormDaftarKelas()
        {
            InitializeComponent();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormEditKelas formEditKelas = new FormEditKelas();
            formEditKelas.Owner = this;
            formEditKelas.Show();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahKelas formTambahKelas = new FormTambahKelas();
            formTambahKelas.Owner = this;
            formTambahKelas.Show();
        }


        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FormDaftarKelas_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            listOfkelas = Kelas.BacaData("", "");
            TampilDataGrid();
        }
        public void FormatDataGrid()
        {
            dataGridViewKelas.Columns.Clear();
            dataGridViewKelas.Columns.Add("id", "ID Kelas");
            dataGridViewKelas.Columns.Add("nama", "Ruang Kelas");
            dataGridViewKelas.Columns.Add("id", "Fakultas");
            dataGridViewKelas.Columns.Add("nama", "ID Fakultas");


            dataGridViewKelas.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewKelas.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewKelas.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewKelas.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        public void TampilDataGrid()
        {
            dataGridViewKelas.Rows.Clear();
            if (listOfkelas.Count > 0)
            {
                foreach (Kelas k in listOfkelas)
                {
                    dataGridViewKelas.Rows.Add(k.IdKelas, k.Nama, k.Falkultas.IdFalkultas, k.Falkultas.Nama);
                }
            }
            else
            {
                dataGridViewKelas.DataSource = null;
            }
        }
        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxCari.Text == "Id Kelas")
            {
                kriteria = "K.id";
            }
            else if (comboBoxCari.Text == "Nama Kelas")
            {
                kriteria = "K.nama_ruang";
            }
            else if (comboBoxCari.Text == "Id Fakultas")
            {
                kriteria = "K.falkutas_id";
            }
            else if (comboBoxCari.Text == "Fakultas")
            {
                kriteria = "F.nama";
            }

            listOfkelas = Kelas.BacaData(kriteria, textBoxCari.Text);
            TampilDataGrid();
        }
    }
}
