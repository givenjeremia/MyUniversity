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
using System.Diagnostics;

namespace pbd_36_MyUniversity
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void keluarSistemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult userSelection = MessageBox.Show("Yakin Ingin Keluar ?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (userSelection == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            this.IsMdiContainer = true;

            this.Enabled = false;
            FormLogin formLogin = new FormLogin();
            formLogin.Owner = this;
            formLogin.Show();
        }

        private void fakultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarFakultas"];
            if (form == null)
            {
                FormDaftarFakultas formDaftarFakultas = new FormDaftarFakultas();
                formDaftarFakultas.MdiParent = this;
                formDaftarFakultas.Show();

            }
            else
            {
                form.Show();
                form.BringToFront(); 
            }
        }

        private void jurusanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarJurusan"];
            if (form == null)
            {
                FormDaftarJurusan formDaftarJurusan = new FormDaftarJurusan();
                formDaftarJurusan.MdiParent = this;
                formDaftarJurusan.Show();

            }
            else
            {
                form.Show();
                form.BringToFront(); 
            }
        }

        private void mahasiswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarMataKuliah"];
            if (form == null)
            {
                FormDaftarMataKuliah formDaftarMataKuliah = new FormDaftarMataKuliah();
                formDaftarMataKuliah.MdiParent = this;
                formDaftarMataKuliah.Show();

            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void karyawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarKaryawan"];
            if (form == null)
            {
                FormDaftarKaryawan formDaftarKaryawan = new FormDaftarKaryawan();
                formDaftarKaryawan.MdiParent = this;
                formDaftarKaryawan.Show();

            }
            else
            {
                form.Show();
                form.BringToFront(); 
            }
        }

        private void organisasiMahasiswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarOrmawa"];
            if (form == null)
            {
                FormDaftarOrmawa formDaftarOrmawa = new FormDaftarOrmawa();
                formDaftarOrmawa.MdiParent = this;
                formDaftarOrmawa.Show();

            }
            else
            {
                form.Show();
                form.BringToFront(); //AGAR FROM DI TAMPILKAN PALING DEPAN
            }
        }

        private void mahasiswaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarMahasiswa"];
            if (form == null)
            {
                FormDaftarMahasiswa formDaftarMahasiswa = new FormDaftarMahasiswa();
                formDaftarMahasiswa.MdiParent = this;
                formDaftarMahasiswa.Show();

            }
            else
            {
                form.Show();
                form.BringToFront(); //AGAR FROM DI TAMPILKAN PALING DEPAN
            }
        }

        private void jabatanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarJabatan"];
            if (form == null)
            {
                FormDaftarJabatan formDaftarJabatan = new FormDaftarJabatan();
                formDaftarJabatan.MdiParent = this;
                formDaftarJabatan.Show();

            }
            else
            {
                form.Show();
                form.BringToFront(); //AGAR FROM DI TAMPILKAN PALING DEPAN
            }
        }

        private void kelasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarKelas"];
            if (form == null)
            {
                FormDaftarKelas formDaftarKelas = new FormDaftarKelas();
                formDaftarKelas.MdiParent = this;
                formDaftarKelas.Show();

            }
            else
            {
                form.Show();
                form.BringToFront(); //AGAR FROM DI TAMPILKAN PALING DEPAN
            }
        }

        private void jadwalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarJadwal"];
            if (form == null)
            {
                FormDaftarJadwal formDaftarJadwal = new FormDaftarJadwal();
                formDaftarJadwal.MdiParent = this;
                formDaftarJadwal.Show();

            }
            else
            {
                form.Show();
                form.BringToFront(); //AGAR FROM DI TAMPILKAN PALING DEPAN
            }
        }

        private void kartuStudiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarKRS"];
            if (form == null)
            {
                FormDaftarKRS formDaftarKRS = new FormDaftarKRS();
                formDaftarKRS.MdiParent = this;
                formDaftarKRS.Show();

            }
            else
            {
                form.Show();
                form.BringToFront(); //AGAR FROM DI TAMPILKAN PALING DEPAN
            }
        }

        private void nilaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarNilai"];
            if (form == null)
            {
                FormDaftarNilai formDaftarNilai = new FormDaftarNilai();
                formDaftarNilai.MdiParent = this;
                formDaftarNilai.Show();

            }
            else
            {
                form.Show();
                form.BringToFront(); //AGAR FROM DI TAMPILKAN PALING DEPAN
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarDetails"];
            if (form == null)
            {
                FormDaftarDetails formDaftarDetails = new FormDaftarDetails();
                formDaftarDetails.MdiParent = this;
                formDaftarDetails.Show();

            }
            else
            {
                form.Show();
                form.BringToFront(); //AGAR FROM DI TAMPILKAN PALING DEPAN
            }
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("www.ubaya.ac.id");
        }

        private void instagramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("www.instagram.com/ubayaofficial");
        }
    }
}
