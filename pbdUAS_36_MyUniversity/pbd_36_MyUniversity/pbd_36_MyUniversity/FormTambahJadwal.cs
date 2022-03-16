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
    public partial class FormTambahJadwal : Form
    {
        List<Kelas> listKelas = new List<Kelas>();
        List<MataKuliah> listMataKuliah = new List<MataKuliah>();

        public FormTambahJadwal()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Kelas k = (Kelas)comboBoxKelas.SelectedItem;
                MataKuliah mk = (MataKuliah)comboBoxMataKuliah.SelectedItem;
                Jadwal j = new Jadwal(int.Parse(textBoxId.Text), textBoxJam.Text, comboBoxHari.Text, k ,mk);
                Jadwal.TambahData(j);
                MessageBox.Show("Data Jadwal Telah Tersimpan.", "Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Penyimpanan Gagal. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxJam.Clear();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarJadwal formDaftarJadwal = (FormDaftarJadwal)this.Owner;
            formDaftarJadwal.FormDaftarJadwal_Load(buttonKeluar, e);
            this.Close();
        }

        private void FormTambahJadwal_Load(object sender, EventArgs e)
        {
            textBoxJam.MaxLength = 45;
            //CB KELAS
            listKelas = Kelas.BacaData("", "");
            comboBoxKelas.DataSource = listKelas;
            comboBoxKelas.DisplayMember = "nama";
            comboBoxKelas.DropDownStyle = ComboBoxStyle.DropDownList;
            //CB MATAKULIAH
            listMataKuliah = MataKuliah.BacaData("", "");
            comboBoxMataKuliah.DataSource = listMataKuliah;
            comboBoxMataKuliah.DisplayMember = "nama";
            comboBoxMataKuliah.DropDownStyle = ComboBoxStyle.DropDownList;
            //ID
            textBoxId.Enabled = false;
            textBoxId.Text = Jadwal.GeneratorKode();
        }


    }
}
