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
    public partial class DodadiUser : Form
    {
        public static string masterusername;
        public static string masterpassword;
        public static string dburl;
        public static string dbname;
        public static string dbusername;
        public static string dbpassword;
        public static string dbnotes;
        public mainform caller;

        public DodadiUser()
        {
            Init();
        }

        public void Init()
        {
            InitializeComponent();
            Login formalogin = new Login();
            masterpassword = formalogin.Getpassword();
        }

        public DodadiUser(mainform caller)
        {
            this.caller = caller;
            Init();
        }

        public void SetPassword(string password)
        {
            this.password.Text = password;
        }

        private string Fajl()
        {
            Login fasdorm1 = new Login();
            return Environment.ExpandEnvironmentVariables("%AppData%") + "\\passwordmanager" + "\\" + fasdorm1.Getuser() + ".sqlite";
        }

        private void AddEntry()
        {
            if (URL.Text != "" && ime.Text != "" && username.Text != "" && password.Text != "")
            {
                dburl = URL.Text;
                dbname = ime.Text;
                dbusername = username.Text;
                dbpassword = password.Text;
                dbnotes = notes.Text;
                dburl = Cryptography.Encrypt(dburl, masterpassword);
                dbname = Cryptography.Encrypt(dbname, masterpassword);
                dbusername = Cryptography.Encrypt(dbusername, masterpassword);
                dbpassword = Cryptography.Encrypt(dbpassword, masterpassword);
                dbnotes = Cryptography.Encrypt(dbnotes, masterpassword);

                SQLiteConnection.ClearAllPools();
                SQLiteConnection dbConnection;
                dbConnection =
                new SQLiteConnection("Data Source=" + Fajl() + ";Version=3;");
                using (var myconnection = new SQLiteConnection(dbConnection))
                {
                    myconnection.Open();
                    try
                    {
                        SQLiteCommand command = new SQLiteCommand(myconnection);
                        command.CommandText =
                        "insert into passwords (url, name, username, password, notes, visible) values (@url, @name, @username, @password, @notes, @visible);";
                        command.Parameters.AddWithValue("@url", dburl);
                        command.Parameters.AddWithValue("@name", dbname);
                        command.Parameters.AddWithValue("@username", dbusername);
                        command.Parameters.AddWithValue("@password", dbpassword);
                        command.Parameters.AddWithValue("@notes", dbnotes);
                        command.Parameters.AddWithValue("@visible", 1);


                        // string komanda = "insert into passwords (url, name, username, password, notes) values ('" + dburl + "', '" + dbname + "', '" + dbusername + "', '" + dbpassword + "', '" + dbnotes + "');";
                        // SQLiteCommand izvrsikomanda = new SQLiteCommand(komanda, myconnection);
                        // izvrsikomanda.ExecuteNonQuery();
                        command.ExecuteNonQuery();
                        myconnection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                this.caller?.UpdateGrid();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AddEntry();
        }

        private void URL_TextChanged(object sender, EventArgs e)
        {}

        private void Button2_Click(object sender, EventArgs e)
        {
            GeneratePassword asd = new GeneratePassword(this);
            asd.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            AddEntry();
            this.Close();
        }
    }
}
