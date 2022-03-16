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
    public partial class FormDeleteNilai : Form
    {
        List<KrsDetail> listKrsDetails = new List<KrsDetail>();
        List<Jadwal> listJadwal = new List<Jadwal>();
        List<Krs> listKrs = new List<Krs>();
        List<Nilai> listNilai = new List<Nilai>();
        public FormDeleteNilai()
        {
            InitializeComponent();
        }

        private void FormDeleteNilai_Load(object sender, EventArgs e)
        {
            listJadwal = Jadwal.BacaData("", "");
            comboBoxJadwal.DataSource = listJadwal;
            comboBoxJadwal.DisplayMember = "id";
            comboBoxJadwal.DropDownStyle = ComboBoxStyle.DropDownList;
            //CB KRS
            listKrs = Krs.BacaData("", "");
            comboBoxKrs.DataSource = listKrs;
            comboBoxKrs.DisplayMember = "idKrs";
            comboBoxKrs.DropDownStyle = ComboBoxStyle.DropDownList;
            //LOCK CB
            comboBoxJadwal.Enabled = false;
            comboBoxKrs.Enabled = false;
            textBoxNilai.Enabled = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int idNilai = int.Parse(textBoxIdNilai.Text);
                Nilai n = new Nilai(idNilai);
                Nilai.HapusData(n);
                MessageBox.Show("Data Nilai Berhasil Di Hapus");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Nilai Gagal Di Hapus. Pesan Kesalahan : " + ex.Message, "Kesalahan");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxIdNilai.Clear();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormDaftarNilai formDaftarNilai = (FormDaftarNilai)this.Owner;
            formDaftarNilai.FormDaftarNilai_Load(buttonKeluar, e);
            this.Close();
        }

        private void textBoxIdNilai_TextChanged(object sender, EventArgs e)
        {
            listNilai = Nilai.BacaData("n.id", textBoxIdNilai.Text);
            if (listNilai.Count > 0)
            {
                comboBoxJadwal.Text = listNilai[0].KrsDetail.Jadwal.Id.ToString();
                comboBoxKrs.Text = listNilai[0].KrsDetail.Krs.IdKrs.ToString();
                textBoxNilai.Text = listNilai[0].InputNilai.ToString();
            }
            else
            {
                MessageBox.Show("ID Nilai tidak ditemukan.", "Kesalahan");
                textBoxIdNilai.Focus();
            }
        }
    }
}
