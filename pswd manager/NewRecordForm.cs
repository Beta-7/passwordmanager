using System;
using System.Windows.Forms;
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
        public OverviewForm caller;

        public DodadiUser()
        {
            Init();
        }

        public void Init()
        {
            InitializeComponent();
            LoginForm formalogin = new LoginForm();
            masterpassword = formalogin.Getpassword();
        }

        public DodadiUser(OverviewForm caller)
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
            LoginForm fasdorm1 = new LoginForm();
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
                caller?.UpdateGrid();
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
            GeneratePWForm asd = new GeneratePWForm(this);
            asd.ShowDialog(this);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            AddEntry();
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
