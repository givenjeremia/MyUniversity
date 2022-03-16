using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

namespace MyUniversity_LIB
{
    public class Cetak
    {
        #region FIELDS
        private Font jenisFont;
        private StreamReader fileCetak;
        private float marginKiri, marginKanan, marginAtas, marginBawah;
        #endregion FIELDS

        #region CONSTRUCTOR
        public Cetak(string namaFile, Font jenisFont, float marginKiri, float marginKanan, float marginAtas, float marginBawah)
        {
            this.JenisFont = jenisFont;
            this.FileCetak = new StreamReader(namaFile);
            this.MarginKiri = marginKiri;
            this.MarginKanan = marginKanan;
            this.MarginAtas = marginAtas;
            this.MarginBawah = marginBawah;
        }
        #endregion CONSTRUCTOR

        #region PROPERTIES
        public Font JenisFont { get => jenisFont; set => jenisFont = value; }
        public StreamReader FileCetak { get => fileCetak; set => fileCetak = value; }
        public float MarginKiri { get => marginKiri; set => marginKiri = value; }
        public float MarginKanan { get => marginKanan; set => marginKanan = value; }
        public float MarginAtas { get => marginAtas; set => marginAtas = value; }
        public float MarginBawah { get => marginBawah; set => marginBawah = value; }
        #endregion PROPERTIES

        #region METHOD
        public void CetakTulisan(object sender, PrintPageEventArgs e)
        {
            int jumBarisPerHalaman = (int)((e.MarginBounds.Height - MarginBawah - MarginAtas) / jenisFont.GetHeight(e.Graphics));
            float y = MarginAtas;
            int jumBaris = 0;
            string tulisanCetak = FileCetak.ReadLine();
            while (jumBaris < jumBarisPerHalaman && tulisanCetak != null)
            {
                y = MarginAtas + (jumBaris * jenisFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(tulisanCetak, JenisFont, Brushes.Black, MarginKiri, y);
                jumBaris++;
                tulisanCetak = FileCetak.ReadLine();
            }
            if (tulisanCetak != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }
        public void CetakKePrinter(string pTipe)
        {
            PrintDocument p = new PrintDocument();
            if (pTipe == "text")
            {
                p.PrintPage += new PrintPageEventHandler(CetakTulisan);
            }
            p.Print();
            FileCetak.Close();
        }
        #endregion METHOD

    }
}
