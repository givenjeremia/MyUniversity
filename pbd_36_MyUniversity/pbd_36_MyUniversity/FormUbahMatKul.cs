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
    public partial class FormUbahMatKul : Form
    {
        public FormUbahMatKul()
        {
            InitializeComponent();
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
        public List<Jurusan> listJurusan = new List<Jurusan>();
        private void FormUbahMatKul_Load(object sender, EventArgs e)
        {
            listJurusan = Jurusan.BacaData("", "");
            comboBoxJurusan.DataSource = listJurusan;
            comboBoxJurusan.DisplayMember = "nama";
            comboBoxJurusan.DropDownStyle = ComboBoxStyle.DropDownList;
            textBoxIdMk.MaxLength = 10;
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Jurusan j = (Jurusan)comboBoxJurusan.SelectedItem;
                MataKuliah mk = new MataKuliah(textBoxIdMk.Text, textBoxNama.Text, int.Parse(textBoxJumlahSKS.Text),
                    j);
                MataKuliah.UbahData(mk);
                MessageBox.Show("Data mata kuliah Telah Di Ubah.", "Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pengubahan Gagal. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }
        public List<MataKuliah> listMataKuliah = new List<MataKuliah>();
        private void textBoxIdMk_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIdMk.Text.Length <= textBoxIdMk.MaxLength)
            {
                listMataKuliah = MataKuliah.BacaData("Mk.id", textBoxIdMk.Text);
                if (listMataKuliah.Count > 0)
                {
                    textBoxNama.Text = listMataKuliah[0].Nama;
                    textBoxJumlahSKS.Text = listMataKuliah[0].JumlahSKS.ToString();
                    comboBoxJurusan.Text = listMataKuliah[0].Jurusan.Nama;
                }
                else
                {
                    MessageBox.Show("ID Tidak Di Temukan");
                }
            }
        }
    }
}
