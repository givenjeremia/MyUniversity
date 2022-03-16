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
    public partial class FormEditKelas : Form
    {
        public List<Kelas> listOfKelas = new List<Kelas>();
        public List<Falkultas> listOfFakultas = new List<Falkultas>();
        public FormEditKelas()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarKelas formDaftarKelas = (FormDaftarKelas)this.Owner;
            formDaftarKelas.FormDaftarKelas_Load(buttonKeluar, e);
            this.Close();
            formDaftarKelas.Enabled = true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxIdKelas.Clear();
            textBoxNamaKelas.Clear();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Falkultas falkultasPilihan = (Falkultas)comboBoxFalkultas.SelectedItem;
                Kelas k = new Kelas(textBoxIdKelas.Text, textBoxNamaKelas.Text, falkultasPilihan);
                Kelas.UbahData(k);
                MessageBox.Show("Data kelas Berhasil Di Ubah");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data kelas Gagal Di Ubah. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void textBoxIdKelas_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIdKelas.Text.Length <= textBoxIdKelas.MaxLength)
            {
                listOfKelas = Kelas.BacaData("K.id", textBoxIdKelas.Text);
                if (listOfKelas.Count > 0)
                {
                    textBoxNamaKelas.Text = listOfKelas[0].Nama;
                    comboBoxFalkultas.Text = listOfKelas[0].Falkultas.Nama;
                }
                else
                {
                    MessageBox.Show("ID Kelas Tidak Di Temukan");
                }
            }
        }

        private void FormEditKelas_Load(object sender, EventArgs e)
        {
            listOfFakultas = Falkultas.BacaData("", "");
            comboBoxFalkultas.DataSource = listOfFakultas;
            comboBoxFalkultas.DisplayMember = "nama";
            comboBoxFalkultas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFalkultas.Enabled = false;

            textBoxIdKelas.MaxLength = 20;
            textBoxNamaKelas.MaxLength = 45;

        }
    }
}
