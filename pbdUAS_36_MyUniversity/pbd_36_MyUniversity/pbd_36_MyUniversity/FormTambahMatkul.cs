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
    public partial class FormTambahMatkul : Form
    {
        public List<MataKuliah> listOfMk = new List<MataKuliah>();
        public List<Jurusan> listOfJurusan = new List<Jurusan>();
        public FormTambahMatkul()
        {
            InitializeComponent();
        }

        private void FormTambahMatkul_Load(object sender, EventArgs e)
        {
            textBoxIdMk.Enabled = false;

            listOfJurusan = Jurusan.BacaData("", "");
            comboBoxJurusan.DataSource = listOfJurusan;
            comboBoxJurusan.DisplayMember = "nama";
            comboBoxJurusan.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxIdMk.MaxLength = 20;
            textBoxNama.MaxLength = 45;
            textBoxJumlahSKS.MaxLength = 20;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarMataKuliah formDaftarMataKuliah = (FormDaftarMataKuliah)this.Owner;
            formDaftarMataKuliah.FormDaftarMataKuliah_Load(buttonKeluar, e);
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxIdMk.Clear();
            textBoxNama.Clear();
            textBoxJumlahSKS.Clear();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Jurusan j = (Jurusan)comboBoxJurusan.SelectedItem;
                MataKuliah mk = new MataKuliah(textBoxIdMk.Text, textBoxNama.Text, int.Parse(textBoxJumlahSKS.Text),
                    j);
                MataKuliah.TambahData(mk);
                MessageBox.Show("Data mata kuliah Telah Tersimpan.", "Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Penyimpanan Gagal. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void comboBoxJurusan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxJurusan.SelectedIndex != -1)
                {
                    Jurusan jurusanDipilih = (Jurusan)comboBoxJurusan.SelectedItem;
                    string kodeTerbaru = MataKuliah.GeneratorKode(jurusanDipilih);
                    textBoxIdMk.Text = kodeTerbaru;
                    textBoxNama.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal melakukan generate kode. Pesan Kesalahan : " + ex.Message);
            }
        }
    }
}
