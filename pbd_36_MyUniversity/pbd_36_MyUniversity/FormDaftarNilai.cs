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
    public partial class FormDaftarNilai : Form
    {
        List<Nilai> listNilai = new List<Nilai>();
        public FormDaftarNilai()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahNilai formTambahNilai = new FormTambahNilai();
            formTambahNilai.Owner = this;
            formTambahNilai.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormEditNilai formEditNilai = new FormEditNilai();
            formEditNilai.Owner = this;
            formEditNilai.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormDeleteNilai formDeleteNilai = new FormDeleteNilai();
            formDeleteNilai.Owner = this;
            formDeleteNilai.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormatDataGrid()
        {
            dataGridViewNilai.Columns.Clear();
            dataGridViewNilai.Columns.Add("id", "idNilai");
            dataGridViewNilai.Columns.Add("nilai", "Nilai");
            //
            dataGridViewNilai.Columns.Add("id", "KRS ID");
            dataGridViewNilai.Columns.Add("nrp", "NRP");
            //

            //
            dataGridViewNilai.Columns.Add("id", "Id Jadwal");



            dataGridViewNilai.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNilai.Columns["nilai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNilai.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewNilai.Columns["nrp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewNilai.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewNilai.AllowUserToAddRows = false;
            dataGridViewNilai.ReadOnly = true;
        }

        private void TampilDataGrid()
        {
            dataGridViewNilai.Rows.Clear();
            if (listNilai.Count > 0)
            {
                foreach (Nilai n in listNilai)
                {
                    dataGridViewNilai.Rows.Add(n.Id,n.InputNilai,n.KrsDetail.Krs.IdKrs,n.KrsDetail.Krs.Mahasiswa.Nrp , n.KrsDetail.Jadwal.Id);

                }
            }
            else
            {
                dataGridViewNilai.DataSource = null;
            }
        }

        public void FormDaftarNilai_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            listNilai = Nilai.BacaData("", "");
            TampilDataGrid();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxCari.Text == "ID Nilai")
            {
                kriteria = "n.id";
            }
            else if (comboBoxCari.Text == "Nilai")
            {
                kriteria = "n.nilai";
            }
            else if (comboBoxCari.Text == "ID KRS")
            {
                kriteria = "ks.id";
            }
            else if (comboBoxCari.Text == "NRP")
            {
                kriteria = "ks.mahasiswa_nrp";
            }
            else if (comboBoxCari.Text == "ID Jadwal")
            {
                kriteria = "j.id";
            }
            listNilai = Nilai.BacaData(kriteria, textBoxCari.Text);
            TampilDataGrid();
        }
    
    }
}
