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
    public partial class FormUbahOrmawa : Form
    {
        public FormUbahOrmawa()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarOrmawa formDaftarOrmawa = (FormDaftarOrmawa)this.Owner;
            formDaftarOrmawa.FormDaftarOrmawa_Load(buttonKeluar, e);
            this.Close();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Falkultas falkultasPilihan = (Falkultas)comboBoxFakultas.SelectedItem;
                Ormawa o = new Ormawa(textBoxIdOrmawa.Text, textBoxNama.Text, textBoxKetua.Text, falkultasPilihan);
                Ormawa.UbahData(o);
                MessageBox.Show("Data Ormawa Berhasil Di Ubah");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Ormawa Gagal Di Ubah. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxIdOrmawa.Clear();
            textBoxNama.Clear();
            textBoxKetua.Clear();
        }
        public List<Falkultas> listFalkultas = new List<Falkultas>();
        private void FormUbahOrmawa_Load(object sender, EventArgs e)
        {
            listFalkultas = Falkultas.BacaData("", "");
            comboBoxFakultas.DataSource = listFalkultas;
            comboBoxFakultas.DisplayMember = "nama";
            comboBoxFakultas.DropDownStyle = ComboBoxStyle.DropDownList;
            textBoxIdOrmawa.MaxLength = 2;
        }
        public List<Ormawa> listOrmawa = new List<Ormawa>();
        private void textBoxIdOrmawa_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIdOrmawa.Text.Length <= textBoxIdOrmawa.MaxLength)
            {
                listOrmawa = Ormawa.BacaData("idormawa", textBoxIdOrmawa.Text);
                if (listOrmawa.Count > 0)
                {
                    textBoxNama.Text = listOrmawa[0].Nama;
                    textBoxKetua.Text = listOrmawa[0].KetuaOrmawa;
                    comboBoxFakultas.Text = listOrmawa[0].Falkultas.Nama;
                }
                else
                {
                    MessageBox.Show("ID Ormawa Tidak Di Temukan");
                }
            }
        }
    }
}
