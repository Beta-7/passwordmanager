using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pswd_manager
{
    public partial class generatePassword : Form
    {
        const string GOLEMI = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string MALI = "abcdefghijklmnopqrstuvwxyz";
        const string CIFRI = "0123456789";
        const string SPECIJALNI = @"~!@#$%^&*():;[]{}<>,.?/\|";
        string korisnickipromenliva = "";
        
        int maxKarakteri = 0;
        Random rnd = new Random(Guid.NewGuid().GetHashCode()); //SUUUUUUUUUUPER BEZBEDEN RANDOM SEED
        private string RandomPassword()
        {
            string paleta = "";
            string rezultat = "";
            if (mali.Checked)
            {
                paleta += MALI;
                maxKarakteri += 26;

            }
            if (golemi.Checked)
            {
                paleta += GOLEMI;
                maxKarakteri += 26;
            }
            if (cifri.Checked)
            {
                paleta += CIFRI;
                maxKarakteri += 10;
            }
            if (specijalni.Checked)
            {
                paleta += SPECIJALNI;
                maxKarakteri += 26;
            }
            if (korisnicki.Checked)
            {
                paleta += korisnickitext.Text;
                maxKarakteri += korisnickitext.TextLength;
            }
            // if (trackBar1.Value > maxKarakteri) { trackBar1.Value = maxKarakteri; izbranaGolemina.Text = trackBar1.Value.ToString(); }
            // nemam pojma zs ustvari go staviv toj del vo kodot, i onaka si raboti kako sto treba bez nego
            while (rezultat.Length < trackBar1.Value)
            {
                rezultat += paleta.Substring(
            rnd.Next(0, paleta.Length), 1);
            }
            dodadiUser asd = new dodadiUser();
            asd.password.Text = rezultat;
            generiranPassword.Text = rezultat;
            return rezultat;
        }

        public generatePassword()
        {
            InitializeComponent();
        }

        private void generirajPassword_Click(object sender, EventArgs e)
        {
            RandomPassword();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            generiranPassword.Text = RandomPassword();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            korisnickipromenliva = korisnickitext.Text;
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            izbranaGolemina.Text = trackBar1.Value.ToString();
        }

        private void korisnickitext_TextChanged(object sender, EventArgs e)
        {
            korisnickipromenliva = korisnickitext.Text;
        }
    }
}
