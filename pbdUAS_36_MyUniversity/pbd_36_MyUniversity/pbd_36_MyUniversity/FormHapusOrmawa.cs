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
    public partial class FormHapusOrmawa : Form
    {
        public FormHapusOrmawa()
        {
            InitializeComponent();
        }
        private void FormHapusOrmawa_Load(object sender, EventArgs e)
        {
            textBoxIdOrmawa.MaxLength = 2;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarOrmawa formDaftarOrmawa = (FormDaftarOrmawa)this.Owner;
            formDaftarOrmawa.FormDaftarOrmawa_Load(buttonKeluar, e);
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxIdOrmawa.Clear();
            textBoxNama.Clear();
            textBoxKetua.Clear();
        }
        public List<Ormawa> listOrmawa = new List<Ormawa>();


        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Falkultas falkultasPilihan = (Falkultas)comboBoxFakultas.SelectedItem;
                Ormawa o = new Ormawa(textBoxIdOrmawa.Text, textBoxNama.Text, textBoxKetua.Text, falkultasPilihan);
                Ormawa.HapusData(o);
                MessageBox.Show("Data Ormawa Berhasil Di Hapus");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Ormawa Gagal Di Hapus. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }

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
                    textBoxNama.Enabled = false;
                    textBoxKetua.Enabled = false;
                    comboBoxFakultas.Enabled = false;
                }
                else
                {
                    MessageBox.Show("ID Ormawa Tidak Di Temukan");
                }
            }
        }

        private void comboBoxFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
