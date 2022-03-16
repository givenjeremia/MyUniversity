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
    public partial class FormDaftarMataKuliah : Form
    {
        public List<MataKuliah> listOfMk = new List<MataKuliah>();
        public FormDaftarMataKuliah()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahMatkul formTambahMatkul = new FormTambahMatkul();
            formTambahMatkul.Owner = this;
            formTambahMatkul.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahMatKul formUbahMatKul = new FormUbahMatKul();
            formUbahMatKul.Owner = this;
            formUbahMatKul.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusMatkul formHapusMatkul = new FormHapusMatkul();
            formHapusMatkul.Owner = this;
            formHapusMatkul.Show();
        }

        public void FormatDataGrid()
        {
            dataGridViewMatkul.Columns.Clear();
            dataGridViewMatkul.Columns.Add("id", "ID MataKuliah");
            dataGridViewMatkul.Columns.Add("nama", "Mata Kuliah");
            dataGridViewMatkul.Columns.Add("jumlah_sks", "Jumlah SKS");
            dataGridViewMatkul.Columns.Add("id", "ID Jurusan");
            dataGridViewMatkul.Columns.Add("nama", "Jurusan");


            dataGridViewMatkul.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMatkul.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMatkul.Columns["jumlah_sks"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMatkul.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMatkul.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        public void TampilDataGrid()
        {
            dataGridViewMatkul.Rows.Clear();
            if (listOfMk.Count > 0)
            {
                foreach (MataKuliah mk in listOfMk)
                {
                    dataGridViewMatkul.Rows.Add(mk.Id, mk.Nama, mk.JumlahSKS, mk.Jurusan.IdJurusan, mk.Jurusan.Nama);
                }
            }
            else
            {
                dataGridViewMatkul.DataSource = null;
            }
        }
    

        public void FormDaftarMataKuliah_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            listOfMk= MataKuliah.BacaData("", "");
            TampilDataGrid();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxCari.Text == "ID MataKuliah")
            {
                kriteria = "Mk.id";
            }
            else if (comboBoxCari.Text == "MataKuliah")
            {
                kriteria = "Mk.nama";
            }
            else if (comboBoxCari.Text == "Jumlah SKS")
            {
                kriteria = "Mk.jumlah_sks";
            }
            else if (comboBoxCari.Text == "Jurusan")
            {
                kriteria = "J.nama";
            }
            else if (comboBoxCari.Text == "ID Jurusan")
            {
                kriteria = "J.id";
            }

            listOfMk = MataKuliah.BacaData(kriteria, textBoxCari.Text);
            TampilDataGrid();
        }
    }
}
