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
    public partial class FormDaftarMahasiswa : Form
    {
        public List<Mahasiswa> listMahasiswa = new List<Mahasiswa>();
        public FormDaftarMahasiswa()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahMahasiswa formTambahMahasiswa = new FormTambahMahasiswa();
            formTambahMahasiswa.Owner = this;
            formTambahMahasiswa.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahMahasiswa formUbahMahasiswa = new FormUbahMahasiswa();
            formUbahMahasiswa.Owner = this;
            formUbahMahasiswa.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusMahasiswa formHapusMahasiswa = new FormHapusMahasiswa();
            formHapusMahasiswa.Owner = this;
            formHapusMahasiswa.Show();
        }
        public void FormatDataGrid()
        {
            dataGridViewMahasiswa.Columns.Add("nrp", "NRP");
            dataGridViewMahasiswa.Columns.Add("angkatan", "Angkatan");
            dataGridViewMahasiswa.Columns.Add("nama", "Nama Mahasiswa");
            dataGridViewMahasiswa.Columns.Add("alamat", "Alamat");
            dataGridViewMahasiswa.Columns.Add("tanggalLahir", "Tanggal Lahir");
            dataGridViewMahasiswa.Columns.Add("telepon", "Telepon");
            dataGridViewMahasiswa.Columns.Add("email", "Email");
            //FALKULTAS
            dataGridViewMahasiswa.Columns.Add("id", "Kode Falkutas");
            dataGridViewMahasiswa.Columns.Add("nama", "Nama Falkutas");
            //JURUSAN
            dataGridViewMahasiswa.Columns.Add("id", "Kode Jurusan");
            dataGridViewMahasiswa.Columns.Add("nama", "Nama Jurusan");
            //ORMAWA
            dataGridViewMahasiswa.Columns.Add("idormawa", "Kode Ormawa");
            dataGridViewMahasiswa.Columns.Add("nama", "Nama Ormawa");

            dataGridViewMahasiswa.Columns["nrp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMahasiswa.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMahasiswa.Columns["alamat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMahasiswa.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMahasiswa.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            dataGridViewMahasiswa.Columns["alamat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewMahasiswa.Columns["nama"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void TampilDataGird()
        {
            dataGridViewMahasiswa.Rows.Clear();
            if (listMahasiswa.Count > 0)
            {
                foreach (Mahasiswa m in listMahasiswa)
                {
                    dataGridViewMahasiswa.Rows.Add(m.Nrp,m.Angkatan , m.Nama , m.Alamat , m.TanggalLahir , m.Telepon , m.Email , m.Falkultas.IdFalkultas , m.Falkultas.Nama , m.Jurusan.IdJurusan , m.Jurusan.Nama , m.Ormawa.IdOrmawa , m.Ormawa.Nama);
                }
            }
        }
        public void FormDaftarMahasiswa_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            listMahasiswa = Mahasiswa.BacaData("", "");
            TampilDataGird();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxCari.Text == "NRP")
            {
                kriteria = "M.nrp";
            }
            else if (comboBoxCari.Text == "Angkatan")
            {
                kriteria = "M.angkatan";
            }
            else if (comboBoxCari.Text == "Nama")
            {
                kriteria = "M.nama";
            }
            else if (comboBoxCari.Text == "Tanggal Lahir")
            {
                kriteria = "M.tanggalLahir";
            }
            else if (comboBoxCari.Text == "Alamat")
            {
                kriteria = "M.alamat";
            }
            else if (comboBoxCari.Text == "Email")
            {
                kriteria = "M.email";
            }
            else if (comboBoxCari.Text == "Telepon")
            {
                kriteria = "M.telepon";
            }
            else if (comboBoxCari.Text == "Fakultas")
            {
                kriteria = "F.nama";
            }
            else if (comboBoxCari.Text == "Jurusan")
            {
                kriteria = "J.nama";
            }
            else if (comboBoxCari.Text == "Ormawa")
            {
                kriteria = "O.nama";
            }

            listMahasiswa = Mahasiswa.BacaData(kriteria, textBoxCari.Text);
            TampilDataGird();
        }
    }
}
