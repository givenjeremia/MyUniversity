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
    public partial class FormDaftarKRS : Form
    {
        public List<Krs> listKrs = new List<Krs>();
        string kriteria = "";
        public FormDaftarKRS()
        {
            InitializeComponent();
        }

        public void FormDaftarKRS_Load(object sender, EventArgs e)
        {
            Koneksi koneksi = new Koneksi();
            koneksi.Connect();
            FormatDataGrid();
            listKrs = Krs.BacaData("", "");
            TampilDataGrid();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            Koneksi koneksi = new Koneksi();
            koneksi.Connect();
            FormTambahKRS formTambahKRS = new FormTambahKRS();
            formTambahKRS.Owner = this;
            formTambahKRS.Show();
        }

        private void FormatDataGrid()
        {
            dataGridViewKrs.Columns.Clear();
            dataGridViewKrs.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewKrs.Columns.Add("id", "ID");
            dataGridViewKrs.Columns.Add("tanggal", "Tanggal");
            dataGridViewKrs.Columns.Add("nrp", "NRP");


            dataGridViewKrs.AllowUserToAddRows = false;
            dataGridViewKrs.ReadOnly = true;
        }
        private void TampilDataGrid()
        {
            dataGridViewKrs.Rows.Clear();
            if (listKrs.Count > 0)
            {
                foreach (Krs krs in listKrs)
                {
                    dataGridViewKrs.Rows.Add(krs.IdKrs, krs.Tanggal.ToString("yyyy-MM-dd"), krs.Mahasiswa.Nrp);
                }
            }
            else
            {
                dataGridViewKrs.DataSource = null;
            }
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi koneksi = new Koneksi();
                koneksi.Connect();
                Krs.CetakKRS(kriteria, textBoxCari.Text, "krs.txt", new Font("Courier New", 12));
                MessageBox.Show("Krs telah tercetak");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Krs gagal dicetak. Pesan Kesalahan : " + ex.Message);
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            Koneksi koneksi = new Koneksi();
            koneksi.Connect();
            string kriteria = "";
            if (comboBoxCari.Text == "Id")
            {
                kriteria = "k.id";
            }
            else if (comboBoxCari.Text == "Tanggal")
            {
                kriteria = "k.tanggal";
            }
            else if (comboBoxCari.Text == "NRP")
            {
                kriteria = "m.nrp";
            }
            listKrs = Krs.BacaData(kriteria, textBoxCari.Text);
            TampilDataGrid();
        }
    }
}
