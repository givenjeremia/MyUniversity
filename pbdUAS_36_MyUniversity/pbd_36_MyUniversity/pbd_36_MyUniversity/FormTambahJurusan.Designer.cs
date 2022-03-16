namespace pbd_36_MyUniversity
{
    partial class FormTambahJurusan
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
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxIdJurusan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxFakultas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxWakilKetua = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxKetuaJurusan = new System.Windows.Forms.TextBox();
            this.textBoxNamaJurusan = new System.Windows.Forms.TextBox();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.IndianRed;
            this.buttonKeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonKeluar.Location = new System.Drawing.Point(211, 216);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(75, 23);
            this.buttonKeluar.TabIndex = 16;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxIdJurusan);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBoxFakultas);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxWakilKetua);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxKetuaJurusan);
            this.panel1.Controls.Add(this.textBoxNamaJurusan);
            this.panel1.Location = new System.Drawing.Point(10, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 160);
            this.panel1.TabIndex = 14;
            // 
            // textBoxIdJurusan
            // 
            this.textBoxIdJurusan.Location = new System.Drawing.Point(109, 48);
            this.textBoxIdJurusan.Name = "textBoxIdJurusan";
            this.textBoxIdJurusan.Size = new System.Drawing.Size(129, 20);
            this.textBoxIdJurusan.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Fakultas :";
            // 
            // comboBoxFakultas
            // 
            this.comboBoxFakultas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFakultas.FormattingEnabled = true;
            this.comboBoxFakultas.Location = new System.Drawing.Point(109, 16);
            this.comboBoxFakultas.Name = "comboBoxFakultas";
            this.comboBoxFakultas.Size = new System.Drawing.Size(129, 21);
            this.comboBoxFakultas.TabIndex = 10;
            this.comboBoxFakultas.SelectedIndexChanged += new System.EventHandler(this.comboBoxFakultas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Jurusan :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama Jurusan :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ketua Jurusan :";
            // 
            // textBoxWakilKetua
            // 
            this.textBoxWakilKetua.Location = new System.Drawing.Point(109, 126);
            this.textBoxWakilKetua.Name = "textBoxWakilKetua";
            this.textBoxWakilKetua.Size = new System.Drawing.Size(129, 20);
            this.textBoxWakilKetua.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Wakil Ketua :";
            // 
            // textBoxKetuaJurusan
            // 
            this.textBoxKetuaJurusan.Location = new System.Drawing.Point(109, 100);
            this.textBoxKetuaJurusan.Name = "textBoxKetuaJurusan";
            this.textBoxKetuaJurusan.Size = new System.Drawing.Size(129, 20);
            this.textBoxKetuaJurusan.TabIndex = 6;
            // 
            // textBoxNamaJurusan
            // 
            this.textBoxNamaJurusan.Location = new System.Drawing.Point(109, 74);
            this.textBoxNamaJurusan.Name = "textBoxNamaJurusan";
            this.textBoxNamaJurusan.Size = new System.Drawing.Size(129, 20);
            this.textBoxNamaJurusan.TabIndex = 5;
            // 
            // buttonKosongi
            // 
            this.buttonKosongi.BackColor = System.Drawing.Color.IndianRed;
            this.buttonKosongi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKosongi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonKosongi.Location = new System.Drawing.Point(91, 216);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(75, 23);
            this.buttonKosongi.TabIndex = 15;
            this.buttonKosongi.Text = "KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            this.buttonKosongi.Click += new System.EventHandler(this.buttonKosongi_Click);
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.BackColor = System.Drawing.Color.IndianRed;
            this.buttonSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimpan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSimpan.Location = new System.Drawing.Point(10, 216);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(75, 23);
            this.buttonSimpan.TabIndex = 12;
            this.buttonSimpan.Text = "SIMPAN";
            this.buttonSimpan.UseVisualStyleBackColor = false;
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.IndianRed;
            this.label5.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(277, 39);
            this.label5.TabIndex = 13;
            this.label5.Text = "TAMBAH JURUSAN";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormTambahJurusan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(297, 248);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.label5);
            this.Name = "FormTambahJurusan";
            this.Text = "Tambah Jurusan";
            this.Load += new System.EventHandler(this.FormTambahJurusan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxWakilKetua;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxKetuaJurusan;
        private System.Windows.Forms.TextBox textBoxNamaJurusan;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxFakultas;
        private System.Windows.Forms.TextBox textBoxIdJurusan;
    }
}