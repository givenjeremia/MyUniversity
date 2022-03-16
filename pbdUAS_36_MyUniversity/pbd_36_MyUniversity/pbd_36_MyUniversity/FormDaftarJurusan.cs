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
    public partial class FormDaftarJurusan : Form
    {
        public List<Jurusan> listOfJurusan = new List<Jurusan>();
        public FormDaftarJurusan()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusJurusan formHapusJurusan = new FormHapusJurusan();
            formHapusJurusan.Owner = this;
            formHapusJurusan.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahJurusan formUbahJurusan = new FormUbahJurusan();
            formUbahJurusan.Owner = this;
            formUbahJurusan.Show();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahJurusan formTambahJurusan = new FormTambahJurusan();
            formTambahJurusan.Owner = this;
            formTambahJurusan.Show();
        }

        public void FormDaftarJurusan_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            listOfJurusan = Jurusan.BacaData("", "");
            TampilDataGrid();
        }

        public void FormatDataGrid()
        {
            dataGridViewJurusan.Columns.Clear();
            dataGridViewJurusan.Columns.Add("id","ID Jurusan");
            dataGridViewJurusan.Columns.Add("nama", "Jurusan");
            dataGridViewJurusan.Columns.Add("ketua_jurusan", "Ketua Jurusan");
            dataGridViewJurusan.Columns.Add("wakil_jurusan", "Wakil Ketua");
            dataGridViewJurusan.Columns.Add("id", "Fakultas");
            dataGridViewJurusan.Columns.Add("nama", "ID Fakultas");


            dataGridViewJurusan.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJurusan.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJurusan.Columns["ketua_jurusan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJurusan.Columns["wakil_jurusan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJurusan.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJurusan.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            dataGridViewJurusan.Columns["ketua_jurusan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewJurusan.Columns["wakil_jurusan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            
        }
        public void TampilDataGrid()
        {
            dataGridViewJurusan.Rows.Clear();
            if (listOfJurusan.Count > 0)
            {
                foreach (Jurusan j in listOfJurusan)
                {
                    dataGridViewJurusan.Rows.Add(j.IdJurusan, j.Nama, j.KetuaJurusan, j.WakilKetua, j.Falkultas.IdFalkultas, j.Falkultas.Nama);
                }
            }
            else
            {
                dataGridViewJurusan.DataSource = null;
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxCari.Text == "ID Jurusan")
            {
                kriteria = "J.id";
            }
            else if (comboBoxCari.Text == "Jurusan")
            {
                kriteria = "J.nama";
            }
            else if (comboBoxCari.Text == "Ketua Jurusan")
            {
                kriteria = "J.ketua_jurusan";
            }
            else if (comboBoxCari.Text == "Wakil Ketua")
            {
                kriteria = "J.wakil_ketua";
            }
            else if (comboBoxCari.Text == "ID Fakultas")
            {
                kriteria = "J.falkutas_id";
            }
            else if (comboBoxCari.Text == "Fakultas")
            {
                kriteria = "F.nama";
            }
            
            listOfJurusan = Jurusan.BacaData(kriteria, textBoxCari.Text);
            TampilDataGrid();
        }
    }
}
