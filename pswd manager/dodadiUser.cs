using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SQLite;

namespace pswd_manager
{
    public partial class dodadiUser : Form
    {
        public static string masterusername;
        public static string masterpassword;
        public static string dburl;
        public static string dbname;
        public static string dbusername;
        public static string dbpassword;
        public static string dbnotes;
        public dodadiUser()
        {
            InitializeComponent();
            login formalogin = new login();
        
            masterpassword = formalogin.getpassword();
            MessageBox.Show(masterpassword);
            
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
            
            dburl = Cryptography.Encrypt(masterpassword, dburl);
            dbname = Cryptography.Encrypt(masterpassword,dbname );
            dbusername = Cryptography.Encrypt(dbusername, dbusername);
            dbpassword = Cryptography.Encrypt(dbpassword, dbpassword);
            dbnotes = Cryptography.Encrypt(dbnotes, dbnotes);

            SQLiteConnection.ClearAllPools();
            SQLiteConnection dbConnection;
            dbConnection =
            new SQLiteConnection("Data Source=" + fajl() + ";Version=3;");
            using (var myconnection = new SQLiteConnection(dbConnection))
            {
                myconnection.Open();
                try
                {
                    
                    string komanda = "insert into passwords (url, name, username, password, notes) values ('" + dburl + "', '" + dbname + "', '" + dbusername + "', '" + dbpassword + "', '" + dbnotes + "');";
                    SQLiteCommand izvrsikomanda = new SQLiteCommand(komanda, myconnection);
                                        izvrsikomanda.ExecuteNonQuery();
                    myconnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
























                
            }
        }
        private void URL_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
