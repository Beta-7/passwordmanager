using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SQLite;
using System.Text;
using System.IO;
namespace pswd_manager
{
    public partial class mainform : Form
    {
        public static string masterusername;
        public static string masterpassword;
        public static string dbid;
        public static string dburl;
        public static string dbname;
        public static string dbusername;
        public static string dbpassword;
        public static string dbnotes;
        public mainform()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            login fasdorm1 = new login();
            masterusername = fasdorm1.getuser();
            masterpassword = fasdorm1.getpassword();

            SQLiteConnection dbConnection;
            dbConnection =
            new SQLiteConnection("Data Source=" + fajl() + ";Version=3;");
            dbConnection.Open();
            string sql = "SELECT * FROM passwords ORDER BY id ";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["id"].ToString() != "1")
                {
                    dbid = reader["id"].ToString();
                    dburl = reader["URL"].ToString();
                    dbname = reader["name"].ToString();
                    dbusername = reader["username"].ToString();
                    dbpassword = reader["password"].ToString();
                    dbnotes = reader["notes"].ToString();
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[int.Parse(dbid) - 2].Cells[0].Value = (int.Parse(dbid) - 1).ToString();
                    dataGridView1.Rows[int.Parse(dbid) - 2].Cells[1].Value = dburl;
                    dataGridView1.Rows[int.Parse(dbid) - 2].Cells[2].Value = dbname;
                    dataGridView1.Rows[int.Parse(dbid) - 2].Cells[3].Value = dbusername;
                    dataGridView1.Rows[int.Parse(dbid) - 2].Cells[4].Value = dbpassword;
                    dataGridView1.Rows[int.Parse(dbid) - 2].Cells[5].Value = dbnotes;

                }
            }


        }
        private string fajl()
        {
            login fasdorm1 = new login();
            return Environment.ExpandEnvironmentVariables("%AppData%") + "\\passwordmanager" + "\\" + fasdorm1.getuser() + ".sqlite";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dodadiUser asd = new dodadiUser();
            asd.Show();
        }
    }
}
