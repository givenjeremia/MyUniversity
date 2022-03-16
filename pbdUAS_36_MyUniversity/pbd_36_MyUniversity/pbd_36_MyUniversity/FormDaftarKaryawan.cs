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
    public partial class FormDaftarKaryawan : Form
    {
        public List<Karyawan> listOfKaryawan = new List<Karyawan>();
        public FormDaftarKaryawan()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahKaryawan formTambahKaryawan = new FormTambahKaryawan();
            formTambahKaryawan.Owner = this;
            formTambahKaryawan.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahKaryawan formUbahKaryawan = new FormUbahKaryawan();
            formUbahKaryawan.Owner = this;
            formUbahKaryawan.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusKaryawan formHapusKaryawan = new FormHapusKaryawan();
            formHapusKaryawan.Owner = this;
            formHapusKaryawan.Show();
        }
        
        private void TampilDataGrid()
        {
            dataGridViewKaryawan.Rows.Clear();
            if (listOfKaryawan.Count > 0)
            {
                foreach (Karyawan k in listOfKaryawan)
                {
                    dataGridViewKaryawan.Rows.Add(k.IdKaryawan, k.Nama, k.Alamat, k.TanggalLahir, k.Telepon, k.Email, k.Jabatan.IdJabatan, k.Jabatan.Nama, k.Fakultas.IdFalkultas, k.Fakultas.Nama, k.Jurusan.IdJurusan, k.Jurusan.Nama);
                }

            }
            else
            {
                dataGridViewKaryawan.DataSource = null;
            }
        }

        private void FormatDataGrid()
        {
            dataGridViewKaryawan.Columns.Clear();
            dataGridViewKaryawan.Columns.Add("id", "ID Karyawan");
            dataGridViewKaryawan.Columns.Add("nama", "Nama Karyawan");
            dataGridViewKaryawan.Columns.Add("alamat", "Alamat");
            dataGridViewKaryawan.Columns.Add("tanggalLahir", "Tanggal Lahir");
            dataGridViewKaryawan.Columns.Add("telepon", "Telepon");
            dataGridViewKaryawan.Columns.Add("email", "Email");

            dataGridViewKaryawan.Columns.Add("id", "ID Jabatan");
            dataGridViewKaryawan.Columns.Add("nama", "Nama Jabatan");

            dataGridViewKaryawan.Columns.Add("id", "ID Fakultas");
            dataGridViewKaryawan.Columns.Add("nama", "Nama Jabatan");

            dataGridViewKaryawan.Columns.Add("id", "ID Jurusan");
            dataGridViewKaryawan.Columns.Add("nama", "nama Jabatan");
        }

        public void FormDaftarKaryawan_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            listOfKaryawan = Karyawan.BacaData("", "");
            TampilDataGrid();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxCari.Text == "ID")
            {
                kriteria = "k.id";
            }
            else if (comboBoxCari.Text == "Nama")
            {
                kriteria = "k.nama";
            }
            else if (comboBoxCari.Text == "Alamat")
            {
                kriteria = "k.alamat";
            }
            else if (comboBoxCari.Text == "Tanggal Lahir")
            {
                kriteria = "k.tanggalLahir";
            }
            else if (comboBoxCari.Text == "Telepon")
            {
                kriteria = "k.telepon";
            }
            else if (comboBoxCari.Text == "Email")
            {
                kriteria = "k.email";
            }
            else if (comboBoxCari.Text == "Jabatan")
            {
                kriteria = "j.nama";
            }
            else if (comboBoxCari.Text == "Fakultas")
            {
                kriteria = "f.nama";
            }
            else if (comboBoxCari.Text == "Jurusan")
            {
                kriteria = "ju.nama";
            }
            listOfKaryawan = Karyawan.BacaData(kriteria, textBoxCari.Text);
            TampilDataGrid();
        }
    }
}
