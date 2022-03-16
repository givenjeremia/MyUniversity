namespace pbd_36_MyUniversity
{
    partial class FormDaftarDetails
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
            this.dataGridViewDaftarNotaJual = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDaftarNotaJual)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDaftarNotaJual
            // 
            this.dataGridViewDaftarNotaJual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDaftarNotaJual.Location = new System.Drawing.Point(46, 61);
            this.dataGridViewDaftarNotaJual.Name = "dataGridViewDaftarNotaJual";
            this.dataGridViewDaftarNotaJual.Size = new System.Drawing.Size(533, 265);
            this.dataGridViewDaftarNotaJual.TabIndex = 24;
            // 
            // FormDaftarDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 423);
            this.Controls.Add(this.dataGridViewDaftarNotaJual);
            this.Name = "FormDaftarDetails";
            this.Text = "FormDaftarDetails";
            this.Load += new System.EventHandler(this.FormDaftarDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDaftarNotaJual)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDaftarNotaJual;
    }
}