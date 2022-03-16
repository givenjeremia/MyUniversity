namespace pbd_36_MyUniversity
{
    partial class FormTambahKaryawan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxJurusan = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxFakultas = new System.Windows.Forms.ComboBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxJabatan = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxNama = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.dateTimePickerTglLahir = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxAlamat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTelepon = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.IndianRed;
            this.label5.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(308, 39);
            this.label5.TabIndex = 27;
            this.label5.Text = "TAMBAH KARYAWAN";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.IndianRed;
            this.buttonKeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonKeluar.Location = new System.Drawing.Point(242, 348);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(75, 23);
            this.buttonKeluar.TabIndex = 29;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // buttonKosongi
            // 
            this.buttonKosongi.BackColor = System.Drawing.Color.IndianRed;
            this.buttonKosongi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKosongi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonKosongi.Location = new System.Drawing.Point(91, 348);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(75, 23);
            this.buttonKosongi.TabIndex = 26;
            this.buttonKosongi.Text = "KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            this.buttonKosongi.Click += new System.EventHandler(this.buttonKosongi_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.comboBoxJurusan);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBoxFakultas);
            this.panel1.Controls.Add(this.textBoxID);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.comboBoxJabatan);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textBoxNama);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBoxEmail);
            this.panel1.Controls.Add(this.dateTimePickerTglLahir);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBoxAlamat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxTelepon);
            this.panel1.Location = new System.Drawing.Point(10, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 292);
            this.panel1.TabIndex = 28;
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.BackColor = System.Drawing.Color.IndianRed;
            this.buttonSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimpan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSimpan.Location = new System.Drawing.Point(10, 348);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(75, 23);
            this.buttonSimpan.TabIndex = 25;
            this.buttonSimpan.Text = "SIMPAN";
            this.buttonSimpan.UseVisualStyleBackColor = false;
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(64, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Jurusan :";
            // 
            // comboBoxJurusan
            // 
            this.comboBoxJurusan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxJurusan.FormattingEnabled = true;
            this.comboBoxJurusan.Location = new System.Drawing.Point(120, 40);
            this.comboBoxJurusan.Name = "comboBoxJurusan";
            this.comboBoxJurusan.Size = new System.Drawing.Size(151, 21);
            this.comboBoxJurusan.TabIndex = 44;
            this.comboBoxJurusan.SelectedIndexChanged += new System.EventHandler(this.comboBoxJurusan_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Fakultas :";
            // 
            // comboBoxFakultas
            // 
            this.comboBoxFakultas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFakultas.FormattingEnabled = true;
            this.comboBoxFakultas.Location = new System.Drawing.Point(120, 13);
            this.comboBoxFakultas.Name = "comboBoxFakultas";
            this.comboBoxFakultas.Size = new System.Drawing.Size(151, 21);
            this.comboBoxFakultas.TabIndex = 42;
            this.comboBoxFakultas.SelectedIndexChanged += new System.EventHandler(this.comboBoxFakultas_SelectedIndexChanged);
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(120, 67);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(76, 20);
            this.textBoxID.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(63, 261);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Jabatan :";
            // 
            // comboBoxJabatan
            // 
            this.comboBoxJabatan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxJabatan.FormattingEnabled = true;
            this.comboBoxJabatan.Location = new System.Drawing.Point(120, 258);
            this.comboBoxJabatan.Name = "comboBoxJabatan";
            this.comboBoxJabatan.Size = new System.Drawing.Size(151, 21);
            this.comboBoxJabatan.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(73, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Nama :";
            // 
            // textBoxNama
            // 
            this.textBoxNama.Location = new System.Drawing.Point(120, 94);
            this.textBoxNama.Name = "textBoxNama";
            this.textBoxNama.Size = new System.Drawing.Size(151, 20);
            this.textBoxNama.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(76, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Email :";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(120, 232);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(151, 20);
            this.textBoxEmail.TabIndex = 35;
            // 
            // dateTimePickerTglLahir
            // 
            this.dateTimePickerTglLahir.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTglLahir.Location = new System.Drawing.Point(120, 180);
            this.dateTimePickerTglLahir.Name = "dateTimePickerTglLahir";
            this.dateTimePickerTglLahir.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerTglLahir.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Tanggal Lahir :";
            // 
            // textBoxAlamat
            // 
            this.textBoxAlamat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAlamat.Location = new System.Drawing.Point(120, 120);
            this.textBoxAlamat.Multiline = true;
            this.textBoxAlamat.Name = "textBoxAlamat";
            this.textBoxAlamat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxAlamat.Size = new System.Drawing.Size(151, 51);
            this.textBoxAlamat.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "No. Telepon :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Alamat :";
            // 
            // textBoxTelepon
            // 
            this.textBoxTelepon.Location = new System.Drawing.Point(120, 206);
            this.textBoxTelepon.Name = "textBoxTelepon";
            this.textBoxTelepon.Size = new System.Drawing.Size(151, 20);
            this.textBoxTelepon.TabIndex = 30;
            // 
            // FormTambahKaryawan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(325, 377);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonSimpan);
            this.Name = "FormTambahKaryawan";
            this.Text = "Tambah Karyawan";
            this.Load += new System.EventHandler(this.FormTambahKaryawan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxJurusan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxFakultas;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxJabatan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxNama;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.DateTimePicker dateTimePickerTglLahir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAlamat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTelepon;
    }
}