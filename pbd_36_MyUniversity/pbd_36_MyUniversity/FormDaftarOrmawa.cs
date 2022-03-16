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
    public partial class FormDaftarOrmawa : Form
    {
        public List<Ormawa> listOrmawa = new List<Ormawa>();
        public FormDaftarOrmawa()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahOrmawa formTambahOrmawa = new FormTambahOrmawa();
            formTambahOrmawa.Owner = this;
            formTambahOrmawa.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahOrmawa formUbahOrmawa = new FormUbahOrmawa();
            formUbahOrmawa.Owner = this;
            formUbahOrmawa.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusOrmawa formHapusOrmawa = new FormHapusOrmawa();
            formHapusOrmawa.Owner = this;
            formHapusOrmawa.Show();
        }

        public void FormDaftarOrmawa_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            listOrmawa = Ormawa.BacaData("", "");
            TampilDataGird();
        }

        public void FormatDataGrid()
        {
            dataGridViewOrmawa.Columns.Add("idormawa", "ID Ormawa");
            dataGridViewOrmawa.Columns.Add("nama", "Nama ormawa");
            dataGridViewOrmawa.Columns.Add("ketua_ormana", "Ketua Ormawa");
            dataGridViewOrmawa.Columns.Add("id", "Kode Falkutas");
            dataGridViewOrmawa.Columns.Add("nama", "Nama Falkutas");

            dataGridViewOrmawa.Columns["idormawa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewOrmawa.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewOrmawa.Columns["ketua_ormana"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewOrmawa.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewOrmawa.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            dataGridViewOrmawa.Columns["ketua_ormana"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewOrmawa.Columns["nama"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void TampilDataGird()
        {
            dataGridViewOrmawa.Rows.Clear();
            if (listOrmawa.Count > 0)
            {
                foreach (Ormawa o in listOrmawa)
                {
                    dataGridViewOrmawa.Rows.Add(o.IdOrmawa, o.Nama, o.KetuaOrmawa , o.Falkultas.IdFalkultas , o.Falkultas.Nama);
                }
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxCari.Text == "ID Ormawa")
            {
                kriteria = "O.idormawa";
            }
            else if (comboBoxCari.Text == "Nama Ormawa")
            {
                kriteria = "O.nama";
            }
            else if (comboBoxCari.Text == "Ketua Ormawa")
            {
                kriteria = "O.ketua_ormana";
            }
            else if (comboBoxCari.Text == "Fakultas")
            {
                kriteria = "F.nama";
            }
            else if (comboBoxCari.Text == "ID Fakultas")
            {
                kriteria = "F.id";
            }

            listOrmawa = Ormawa.BacaData(kriteria, textBoxCari.Text);
            TampilDataGird();
        }
    }
}
