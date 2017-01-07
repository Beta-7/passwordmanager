using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace pswd_manager
{
    public partial class dodadiUser : Form
    {
        public static string masterusername;
        public static string masterpassword;
        public static string dbid;
        public static string dburl;
        public static string dbname;
        public static string dbusername;
        public static string dbpassword;
        public static string dbnotes;
        public dodadiUser()
        {
            InitializeComponent();
        }

        private void dodadiUser_Load(object sender, EventArgs e)
        {

        }
        private string fajl()
        {
            login fasdorm1 = new login();
            return Environment.ExpandEnvironmentVariables("%AppData%") + "\\passwordmanager" + "\\" + fasdorm1.getuser() + ".sqlite";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dburl = URL.Text;
            dbname = ime.Text;
            dbusername = username.Text;
            dbpassword = password.Text;
            dbnotes = notes.Text;
            SQLiteConnection dbConnection;
            dbConnection =
            new SQLiteConnection("Data Source=" + fajl() + ";Version=3;");
            dbConnection.Open();
            string komanda = "insert into passwords (url, name, username, password, notes) values ('" + dburl + "', '" + dbname + "', '" + dbusername + "', '" + dbpassword+ "', '" + dbnotes+ "');";
            SQLiteCommand izvrsikomanda = new SQLiteCommand(komanda, dbConnection);
            izvrsikomanda.ExecuteNonQuery();
            dbConnection.Close();
        }

        private void URL_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
