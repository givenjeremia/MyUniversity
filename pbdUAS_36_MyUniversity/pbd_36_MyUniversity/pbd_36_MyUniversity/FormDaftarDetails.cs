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
    public partial class FormDaftarDetails : Form
    {
        public List<KrsDetail> listKrsDetails = new List<KrsDetail>();
        public FormDaftarDetails()
        {
            InitializeComponent();
            
        }
        private void FormatDataGrid()
        {
            dataGridViewDaftarNotaJual.Columns.Clear();
            dataGridViewDaftarNotaJual.Columns.Add("id", "ID Kelas");
            dataGridViewDaftarNotaJual.Columns.Add("nama_ruang", "Nama Ruang");
            //
            dataGridViewDaftarNotaJual.Columns.Add("id", "ID MataKuliah");
            dataGridViewDaftarNotaJual.Columns.Add("nama", "Mata Kuliah");
            //
            dataGridViewDaftarNotaJual.Columns.Add("id", "KRS ID");
            dataGridViewDaftarNotaJual.Columns.Add("nrp", "NRP");

            dataGridViewDaftarNotaJual.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDaftarNotaJual.Columns["nama_ruang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDaftarNotaJual.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDaftarNotaJual.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDaftarNotaJual.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewDaftarNotaJual.Columns["nrp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewDaftarNotaJual.AllowUserToAddRows = false;
            dataGridViewDaftarNotaJual.ReadOnly = true;
        }

        private void TampilDataGrid()
        {
            dataGridViewDaftarNotaJual.Rows.Clear();
            if (listKrsDetails.Count > 0)
            {
                foreach (KrsDetail kd in listKrsDetails)
                {
                    dataGridViewDaftarNotaJual.Rows.Add(kd.Jadwal.Kelas.IdKelas,kd.Jadwal.Kelas.Nama,kd.Jadwal.MataKuliah.Id,kd.Jadwal.MataKuliah.Nama , kd.Krs.IdKrs , kd.Krs.Mahasiswa.Nrp);

                }
            }
            else
            {
                dataGridViewDaftarNotaJual.DataSource = null;
            }
        }
        private void FormDaftarDetails_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            listKrsDetails = KrsDetail.BacaData("", "");
            TampilDataGrid();
        }
    }
}
