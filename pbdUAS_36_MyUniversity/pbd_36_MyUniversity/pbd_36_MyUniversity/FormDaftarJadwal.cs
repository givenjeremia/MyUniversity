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
    public partial class FormDaftarJadwal : Form
    {
        string kriteria = "";
        public FormDaftarJadwal()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahJadwal formTambahJadwal = new FormTambahJadwal();
            formTambahJadwal.Owner = this;
            formTambahJadwal.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormEditJadwal formEditJadwal = new FormEditJadwal();
            formEditJadwal.Owner = this;
            formEditJadwal.Show();
        }

        public void FormDaftarJadwal_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            listJadwal = Jadwal.BacaData("", "");
            TampilDataGrid();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormatDataGrid()
        {
            dataGridViewJadwal.Columns.Clear();
            dataGridViewJadwal.Columns.Add("id", "ID Jadwal");
            dataGridViewJadwal.Columns.Add("jam", "Jam");
            //
            dataGridViewJadwal.Columns.Add("hari", "Hari");
            dataGridViewJadwal.Columns.Add("id", "ID Kelas");
            
            dataGridViewJadwal.Columns.Add("nama_ruang", "Nama Kelas");
            dataGridViewJadwal.Columns.Add("id", "ID MataKuliah");
            dataGridViewJadwal.Columns.Add("nama", "Nama MataKuliah");


            dataGridViewJadwal.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJadwal.Columns["jam"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJadwal.Columns["hari"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJadwal.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJadwal.Columns["nama_ruang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJadwal.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJadwal.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewJadwal.AllowUserToAddRows = false;
            dataGridViewJadwal.ReadOnly = true;
        }
        public List<Jadwal> listJadwal = new List<Jadwal>();
        private void TampilDataGrid()
        {
            dataGridViewJadwal.Rows.Clear();
            if (listJadwal.Count > 0)
            {
                foreach (Jadwal j in listJadwal)
                {
                    dataGridViewJadwal.Rows.Add(j.Id, j.Jam , j.Hari , j.Kelas.IdKelas, j.Kelas.Nama , j.MataKuliah.Id , j.MataKuliah.Nama );

                }
            }
            else
            {
                dataGridViewJadwal.DataSource = null;
            }
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            try
            {
                Jadwal.CetakJadwal(kriteria, textBoxCari.Text, "jadwal.txt", new Font("Courier New", 12));
                MessageBox.Show("Jadwal telah tercetak");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Jadwal gagal dicetak. Pesan Kesalahan : " + ex.Message);
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxCari.Text == "Id Kelas")
            {
                kriteria = "J.kelas_id";
            }
            else if (comboBoxCari.Text == "Id Matakuliah")
            {
                kriteria = "J.mata_kuliah_id";
            }
            else if (comboBoxCari.Text == "Nama Ruang")
            {
                kriteria = "K.nama_ruang";
            }
            else if (comboBoxCari.Text == "Hari")
            {
                kriteria = "j.hari";
            }
            else if (comboBoxCari.Text == "Jam")
            {
                kriteria = "J.jam";
            }
            else if (comboBoxCari.Text == "Nama Matakuliah")
            {
                kriteria = "M.nama";
            }
            listJadwal = Jadwal.BacaData(kriteria, textBoxCari.Text);
            TampilDataGrid();
        }
    }
}
