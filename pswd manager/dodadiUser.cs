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
            
            dburl = Cryptography.Encrypt(dburl,masterpassword);
            dbname = Cryptography.Encrypt(dbname, masterpassword);
            dbusername = Cryptography.Encrypt(dbusername, masterpassword);
            dbpassword = Cryptography.Encrypt(dbpassword, masterpassword);
            dbnotes = Cryptography.Encrypt(dbnotes, masterpassword);

            SQLiteConnection.ClearAllPools();
            SQLiteConnection dbConnection;
            dbConnection =
            new SQLiteConnection("Data Source=" + fajl() + ";Version=3;");
            using (var myconnection = new SQLiteConnection(dbConnection))
            {
                myconnection.Open();
                try
                {
                    SQLiteCommand command = new SQLiteCommand(myconnection);
                    command.CommandText =
                  "insert into passwords (url, name, username, password, notes) values (@url, @name, @username, @password, @notes);";
                    command.Parameters.AddWithValue("@url", dburl);
                    command.Parameters.AddWithValue("@name", dbname);
                    command.Parameters.AddWithValue("@username", dbusername);
                    command.Parameters.AddWithValue("@password", dbpassword);
                    command.Parameters.AddWithValue("@notes", dbnotes);
                    


               //     string komanda = "insert into passwords (url, name, username, password, notes) values ('" + dburl + "', '" + dbname + "', '" + dbusername + "', '" + dbpassword + "', '" + dbnotes + "');";
              //      SQLiteCommand izvrsikomanda = new SQLiteCommand(komanda, myconnection);
                    command.ExecuteNonQuery();
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
