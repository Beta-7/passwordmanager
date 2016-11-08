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
    public partial class Form2 : Form
    {
        public static string username;
        public static string password;
        
                

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 fasdorm1 = new Form1();
            username=fasdorm1.getuser();
            password = fasdorm1.getpassword();
        }
    }
}
