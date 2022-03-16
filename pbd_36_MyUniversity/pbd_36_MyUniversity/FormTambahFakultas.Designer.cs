namespace pbd_36_MyUniversity
{
    partial class FormTambahFakultas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNamaFakultas = new System.Windows.Forms.TextBox();
            this.textBoxDekan = new System.Windows.Forms.TextBox();
            this.textBoxWakilDekan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.textBoxIdFalkultas = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Fakultas :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama Fakultas :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dekan :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Wakil Dekan :";
            // 
            // textBoxNamaFakultas
            // 
            this.textBoxNamaFakultas.Location = new System.Drawing.Point(109, 46);
            this.textBoxNamaFakultas.Name = "textBoxNamaFakultas";
            this.textBoxNamaFakultas.Size = new System.Drawing.Size(129, 20);
            this.textBoxNamaFakultas.TabIndex = 5;
            // 
            // textBoxDekan
            // 
            this.textBoxDekan.Location = new System.Drawing.Point(109, 72);
            this.textBoxDekan.Name = "textBoxDekan";
            this.textBoxDekan.Size = new System.Drawing.Size(129, 20);
            this.textBoxDekan.TabIndex = 6;
            // 
            // textBoxWakilDekan
            // 
            this.textBoxWakilDekan.Location = new System.Drawing.Point(109, 98);
            this.textBoxWakilDekan.Name = "textBoxWakilDekan";
            this.textBoxWakilDekan.Size = new System.Drawing.Size(129, 20);
            this.textBoxWakilDekan.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.IndianRed;
            this.label5.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(277, 39);
            this.label5.TabIndex = 9;
            this.label5.Text = "TAMBAH FAKULTAS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxIdFalkultas);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxWakilDekan);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxDekan);
            this.panel1.Controls.Add(this.textBoxNamaFakultas);
            this.panel1.Location = new System.Drawing.Point(9, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 137);
            this.panel1.TabIndex = 10;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.IndianRed;
            this.buttonKeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonKeluar.Location = new System.Drawing.Point(210, 194);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(75, 23);
            this.buttonKeluar.TabIndex = 19;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // buttonKosongi
            // 
            this.buttonKosongi.BackColor = System.Drawing.Color.IndianRed;
            this.buttonKosongi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKosongi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonKosongi.Location = new System.Drawing.Point(90, 194);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(75, 23);
            this.buttonKosongi.TabIndex = 18;
            this.buttonKosongi.Text = "KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            this.buttonKosongi.Click += new System.EventHandler(this.buttonKosongi_Click);
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.BackColor = System.Drawing.Color.IndianRed;
            this.buttonSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimpan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSimpan.Location = new System.Drawing.Point(9, 194);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(75, 23);
            this.buttonSimpan.TabIndex = 17;
            this.buttonSimpan.Text = "SIMPAN";
            this.buttonSimpan.UseVisualStyleBackColor = false;
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // textBoxIdFalkultas
            // 
            this.textBoxIdFalkultas.Location = new System.Drawing.Point(109, 15);
            this.textBoxIdFalkultas.Name = "textBoxIdFalkultas";
            this.textBoxIdFalkultas.Size = new System.Drawing.Size(67, 20);
            this.textBoxIdFalkultas.TabIndex = 9;
            // 
            // FormTambahFakultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(295, 224);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Name = "FormTambahFakultas";
            this.Text = "Tambah Fakultas";
            this.Load += new System.EventHandler(this.FormTambahFakultas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNamaFakultas;
        private System.Windows.Forms.TextBox textBoxDekan;
        private System.Windows.Forms.TextBox textBoxWakilDekan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.TextBox textBoxIdFalkultas;
    }
}