using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BETONARME
{
    public partial class Betonarme : Form
    {
        public Betonarme()
        {
            InitializeComponent();
        }
        #region DEGISKENLER
        double fcd; // N/mm²
        double fyd; // N/mm²
        double As; //mm²
        double a = 1; //mm
        double Fc;
        double Fs;
        double B;//mm
        double H;//mm
        double Mr;
        double Z;//mm
        double PP;//mm
        #endregion
        
        #region Fonksiyonlar

        void KolonCizMr()
        {
            Pen kalem = new Pen(Color.Black);
            Graphics cizim;



        }
        void KolonCizAs()
        {
            Pen kalem = new Pen(Color.Black);
            Graphics cizim;

            


        }
        private double MrHesap()
        {
            As = Convert.ToDouble(tbMrAs.Text);
            B = Convert.ToDouble(tbMrB.Text);
            H = Convert.ToDouble(tbMrH.Text);
            PP = Convert.ToDouble(tbMrPP.Text);
            Fc = 0.85 * fcd * B * a;
            Fs = As * fyd;
            while (true)
            {
                Fc = 0.85 * fcd * B * a;
                if (Fc > Fs)
                {
                    break;
                }
                else
                    a = a + 0.1;
            }
            Z = H - (a / 2) - PP;
            Mr = Fs * Z;
            return Mr;
        }
        private double AsHesap()
        {
            Mr = Convert.ToDouble(tbAsMr.Text);
            B = Convert.ToDouble(tbAsB.Text);
            H = Convert.ToDouble(tbAsH.Text);
            PP = Convert.ToDouble(tbAsPP.Text);
            a = 1;
            while (true)
            {
                Z = H - (a / 2) - PP;   
                if ((Fc*Z) >= Mr)
                {
                    break;
                }
                else
                    a = a + 0.1;
            }

            Z = H - (a / 2) - PP;
            As = Mr /(fyd * Z);
            return As;
        }

        #endregion

        #region FormIslemleri

        private void textBoxH_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (e.KeyChar == 13)
            {
                tbMrB.Select();
            }
        }
        private void textBoxB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (e.KeyChar == 13)
            {
                btnMrHesapla.Select();
            }
        }
        private void textBoxH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                tbMrB.Select();
            }
        }
        private void textBoxB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                tbMrH.Select();
            }
        }
        private void Betonarme_Load(object sender, EventArgs e)
        {
            cbBeton.SelectedIndex = 2;
            cbCelik.SelectedIndex = 1;
        }
        private void cbBeton_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBeton.Text == "C20")
            {
                fcd = 13;
                tbBeton.Text = Convert.ToString(fcd);
            }
            if (cbBeton.Text == "C25")
            {
                fcd = 17;
                tbBeton.Text = Convert.ToString(fcd);
            }
            if (cbBeton.Text == "C30")
            {
                fcd = 20;
                tbBeton.Text = Convert.ToString(fcd);
            }
            if (cbBeton.Text == "C35")
            {
                fcd = 23;
                tbBeton.Text = Convert.ToString(fcd);
            }
            if (cbBeton.Text == "C40")
            {
                fcd = 27;
                tbBeton.Text = Convert.ToString(fcd);
            }
            if (cbBeton.Text == "C45")
            {
                fcd = 30;
                tbBeton.Text = Convert.ToString(fcd);
            }
            if (cbBeton.Text == "C50")
            {
                fcd = 33;
                tbBeton.Text = Convert.ToString(fcd);
            }
        }
        private void cbCelik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCelik.Text == "S220")
            {
                fyd = 191;
                tbCelik.Text = Convert.ToString(fyd);
            }
            if (cbCelik.Text == "S420")
            {
                fyd = 365;
                tbCelik.Text = Convert.ToString(fyd);
            }
        }
        private void btnMrHesapla_Click(object sender, EventArgs e)
        {
            Mr = MrHesap();
            tbMrFc.Text = Convert.ToString(Fc);
            tbMrFs.Text = Convert.ToString(Fs);
            tbMra.Text = Convert.ToString(a);
            tbMrZ.Text = Convert.ToString(Z);
            tbMrMr.Text = Convert.ToString(Mr);
        }

        private void btnAsHesapla_Click(object sender, EventArgs e)
        {
            As = AsHesap();
            tbAsFc.Text = Convert.ToString(Fc);
            tbAsFs.Text = Convert.ToString(Fs);
            tbAsa.Text = Convert.ToString(a);
            tbAsZ.Text = Convert.ToString(Z);
            tbAsAs.Text = Convert.ToString(As);
        }
        #endregion
    }
}

