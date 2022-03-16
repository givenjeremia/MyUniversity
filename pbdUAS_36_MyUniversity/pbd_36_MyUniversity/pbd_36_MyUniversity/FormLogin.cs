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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void linkLabelPengaturan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Height = 50 + panelLogin.Height + panelPengaturan.Height;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.Height = 50 + panelLogin.Height;
            textBoxServer.Text = "localhost";
            textBoxDatabase.Text = "myuniversity";
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (textBoxServer.Text != "" && textBoxDatabase.Text != "")
            {
                this.Height = 50 + panelLogin.Height;
            }
            else
            {
                MessageBox.Show("Nama server dan nama database tidak boleh dikosongi!", "Kesalahan");
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxUsername.Text != "")
                {
                    Koneksi koneksi = new Koneksi(textBoxServer.Text, textBoxDatabase.Text, textBoxUsername.Text, textBoxPassword.Text);
                    Koneksi koneksi2 = new Koneksi();
                    MessageBox.Show("Koneksi Berhasil , Selamat Menggunakan Aplikasi ");
                    this.Owner.Enabled = true;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi Gagal . Kesalahan " + ex.Message);
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
