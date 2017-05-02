using System;
using System.Drawing;
using System.Windows.Forms;

namespace pswd_manager
{
    public partial class GeneratePWForm : Form
    {
        const string GOLEMI = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string MALI = "abcdefghijklmnopqrstuvwxyz";
        const string CIFRI = "0123456789";
        const string SPECIJALNI = @"~!@#$%^&*():;[]{}<>,.?/\|";
        int maxKarakteri = 0;
        Random rnd = new Random(Guid.NewGuid().GetHashCode()); //SUUUUUUUUUUPER BEZBEDEN RANDOM SEED
        private DodadiUser dodadiUser;

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
            // If (trackBar1.Value > maxKarakteri) { trackBar1.Value = maxKarakteri; izbranaGolemina.Text = trackBar1.Value.ToString(); }
            // nemam pojma zs ustvari go staviv toj del vo kodot, i onaka si raboti kako sto treba bez nego
            while (rezultat.Length < passwordLenSlider.Value)
            {
                rezultat += paleta.Substring(
            rnd.Next(0, paleta.Length), 1);
            }
            return rezultat;
        }

        public GeneratePWForm()
        {
            InitializeComponent();
        }

        public GeneratePWForm(DodadiUser dodadiUser)
        {
            this.dodadiUser = dodadiUser;
            InitializeComponent();
        }

        private void GenerirajPassword_Click(object sender, EventArgs e)
        {
            string password = RandomPassword();
            dodadiUser.password.Text = password;
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textbox1.Text = RandomPassword();
        }

        private void TrackBar1_Scroll_1(object sender, EventArgs e)
        {
            passwordLenLB.ForeColor = passwordLenSlider.Value > 7 ? Color.Green : Color.Red; // Make the label that's shows the selected passwords length red (Insecure) if it's length is lower then 7 otherwise show it as green (Secure).
            passwordLenLB.Text = "Selected password length is " + passwordLenSlider.Value.ToString();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GeneratePassword_Load(object sender, EventArgs e)
        {
            passwordLenLB.Text = "Selected password length is " + passwordLenSlider.Value.ToString();
        }
    }
}
