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
    public partial class FormTambahOrmawa : Form
    {
        
        public FormTambahOrmawa()
        {
            InitializeComponent();
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

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Falkultas falkultasPilihan = (Falkultas)comboBoxFakultas.SelectedItem;
                Ormawa o = new Ormawa(textBoxIdOrmawa.Text, textBoxNama.Text, textBoxKetua.Text,  falkultasPilihan);
                Ormawa.TambahData(o);
                MessageBox.Show("Data Ormawa Berhasil Di Tambahkan");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Ormawa Gagal Di Tambahkan. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }
        public List<Falkultas> listFalkultas = new List<Falkultas>();
        private void FormTambahOrmawa_Load(object sender, EventArgs e)
        {
            listFalkultas = Falkultas.BacaData("", "");
            comboBoxFakultas.DataSource = listFalkultas;
            comboBoxFakultas.DisplayMember = "nama";
            comboBoxFakultas.DropDownStyle = ComboBoxStyle.DropDownList;
            textBoxIdOrmawa.Enabled = false;
        }

        private void comboBoxFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Falkultas f = (Falkultas)comboBoxFakultas.SelectedItem;
            string kodeBarang = Ormawa.GeneratorKode(f);
            textBoxIdOrmawa.Text = kodeBarang;
            textBoxNama.Focus();
        }


    }
}
