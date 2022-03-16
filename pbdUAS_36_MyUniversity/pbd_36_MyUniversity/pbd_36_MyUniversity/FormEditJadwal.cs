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
    public partial class FormEditJadwal : Form
    {
        List<Kelas> listKelas = new List<Kelas>();
        List<MataKuliah> listMataKuliah = new List<MataKuliah>();
        List<Jadwal> listJadwal = new List<Jadwal>();
        public FormEditJadwal()
        {
            InitializeComponent();
        }

        private void FormEditJadwal_Load(object sender, EventArgs e)
        {
            textBoxId.MaxLength = 3;
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
            //
            comboBoxMataKuliah.Enabled = false;
            comboBoxKelas.Enabled = false;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarJadwal formDaftarJadwal = (FormDaftarJadwal)this.Owner;
            formDaftarJadwal.FormDaftarJadwal_Load(buttonKeluar, e);
            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxId.Clear();
            comboBoxHari.SelectedItem = 1;
            textBoxJam.Clear();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Jadwal j = new Jadwal(int.Parse(textBoxId.Text), textBoxJam.Text, comboBoxHari.Text);
                Jadwal.UbahData(j);
                MessageBox.Show("Data Jadwal Telah Tersimpan.", "Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Edit Gagal. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            if (textBoxId.Text.Length <= textBoxId.MaxLength)
            {
                listJadwal = Jadwal.BacaData("J.id", textBoxId.Text);
                if (listJadwal.Count > 0)
                {
                    comboBoxKelas.Text = listJadwal[0].Kelas.Nama;
                    comboBoxMataKuliah.Text = listJadwal[0].MataKuliah.Nama;
                    comboBoxHari.Text = listJadwal[0].Hari;
                    textBoxJam.Text = listJadwal[0].Jam;
                }
                else
                {
                    MessageBox.Show("ID Jadwal Tidak Di Temukan");
                }
            }
        }
    }
}
