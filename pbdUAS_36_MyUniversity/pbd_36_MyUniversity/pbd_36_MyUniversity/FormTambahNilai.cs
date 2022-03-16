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
    public partial class FormTambahNilai : Form
    {
        List<KrsDetail> listKrsDetails = new List<KrsDetail>();
        List<Jadwal> listJadwal = new List<Jadwal>();
        List<Krs> listKrs = new List<Krs>();
        public FormTambahNilai()
        {
            InitializeComponent();
        }

        private void FormTambahNilai_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            listKrsDetails = KrsDetail.BacaData("", "");
            TampilDataGrid();
            //AMBIL NRP
            listJadwal = Jadwal.BacaData("", "");
            comboBoxJadwal.DataSource = listJadwal;
            comboBoxJadwal.DisplayMember ="id";
            comboBoxJadwal.DropDownStyle = ComboBoxStyle.DropDownList;
            //CB KRS
            listKrs = Krs.BacaData("", "");
            comboBoxKrs.DataSource = listKrs;
            comboBoxKrs.DisplayMember = "idKrs";
            comboBoxKrs.DropDownStyle = ComboBoxStyle.DropDownList;
            //AUTO ID
            textBoxIdNilai.Enabled = false;
            string idBaru = Nilai.GeneratorKode();
            textBoxIdNilai.Text = idBaru;
            comboBoxJadwal.Focus();
            //
            

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Krs newKrs = (Krs)comboBoxKrs.SelectedItem;
                Jadwal idJadwal = (Jadwal)comboBoxJadwal.SelectedItem;
                int idNilai = int.Parse(textBoxIdNilai.Text);
                double nilai = double.Parse(textBoxNilai.Text);

                KrsDetail kd = new KrsDetail(newKrs, idJadwal);
                Nilai n = new Nilai(kd, idNilai, nilai);
                Nilai.TambahData(n);
                MessageBox.Show("Data Nilai Berhasil Di Tambahkan");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Nilai Gagal Di Tambahkan. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxNilai.Clear();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarNilai formDaftarNilai = (FormDaftarNilai)this.Owner;
            formDaftarNilai.FormDaftarNilai_Load(buttonKeluar, e);
            this.Close();
        }
        private void FormatDataGrid()
        {
            dataGridViewKrsDetails.Columns.Clear();
            dataGridViewKrsDetails.Columns.Add("id", "ID MataKuliah");
            dataGridViewKrsDetails.Columns.Add("nama", "Mata Kuliah");
            dataGridViewKrsDetails.Columns.Add("id", "ID Krs");
            dataGridViewKrsDetails.Columns.Add("nrp", "nrp");
            dataGridViewKrsDetails.Columns.Add("id", "ID Jadwal");
            //


            //
            dataGridViewKrsDetails.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewKrsDetails.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewKrsDetails.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewKrsDetails.Columns["nrp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewKrsDetails.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewKrsDetails.AllowUserToAddRows = false;
            dataGridViewKrsDetails.ReadOnly = true;
        }

        private void TampilDataGrid()
        {
            dataGridViewKrsDetails.Rows.Clear();
            if (listKrsDetails.Count > 0)
            {
                foreach (KrsDetail kd in listKrsDetails)
                {
                    dataGridViewKrsDetails.Rows.Add(kd.Jadwal.MataKuliah.Id,kd.Jadwal.MataKuliah.Nama , kd.Krs.IdKrs , kd.Krs.Mahasiswa.Nrp , kd.Jadwal.Id);
                }
            }
            else
            {
                dataGridViewKrsDetails.DataSource = null;
            }
        }


    }
}
