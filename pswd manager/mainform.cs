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
        public static bool debug=true;
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
        private void dmessage(string message)
        {
            if (debug)
                MessageBox.Show(message);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            login fasdorm1 = new login();
            masterusername = fasdorm1.getuser();
            masterpassword = fasdorm1.getpassword();
            //zemi gi glavnite kredincijali od formata 1
            dataGridView1.Rows.Clear();
            SQLiteConnection dbConnection;
            dbConnection =
            new SQLiteConnection("Data Source=" + fajl() + ";Version=3;");
            try
            {
                dbConnection.Open();
                int idbroj = 1;          //promenliva za skladiranje na id brojot od posledniot rekord
                string maxid = "SELECT MAX(ID) FROM passwords;";        //komanda za selektiranje na posledniot rekord
                string sql = "SELECT * FROM passwords ORDER BY id ";
                SQLiteCommand maxidkomanda = new SQLiteCommand(maxid, dbConnection);
                SQLiteDataReader reader1 = maxidkomanda.ExecuteReader();
                while (reader1.Read())
                {
                    idbroj = reader1.GetInt32(0);
                    break;
                }
                reader1.Close();
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                int offset = 2;
                while (reader.Read())
                {
                    if (int.Parse(reader["id"].ToString()) <= idbroj)
                    {
                        if (reader["id"].ToString() != "1")
                        {
                            dbid = reader["id"].ToString();
                            dburl = reader["URL"].ToString();
                            dbname = reader["name"].ToString();
                            dbusername = reader["username"].ToString();
                            dbpassword = reader["password"].ToString();
                            dbnotes = reader["notes"].ToString();
                            dmessage("dekriptiram");
                            
                            dburl = Cryptography.Decrypt(dburl, masterpassword);
                            dbname = Cryptography.Decrypt(dbname, masterpassword);
                            dbusername = Cryptography.Decrypt(dbusername, masterpassword);
                            dbpassword = Cryptography.Decrypt(dbpassword, masterpassword);
                            dbnotes = Cryptography.Decrypt(dbid, masterpassword);
                            dmessage("dekriptirav");
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[int.Parse(dbid) - offset].Cells[0].Value = (int.Parse(dbid) - offset).ToString();
                            dataGridView1.Rows[int.Parse(dbid) - offset].Cells[1].Value = dburl;
                            dataGridView1.Rows[int.Parse(dbid) - offset].Cells[2].Value = dbname;
                            dataGridView1.Rows[int.Parse(dbid) - offset].Cells[3].Value = dbusername;
                            dataGridView1.Rows[int.Parse(dbid) - offset].Cells[4].Value = dbpassword;
                            dataGridView1.Rows[int.Parse(dbid) - offset].Cells[5].Value = dbnotes;

                        }
                    }
                    else
                    {
                        dbid = reader["id"].ToString();
                        dburl = reader["URL"].ToString();
                        dbname = reader["name"].ToString();
                        dbusername = reader["username"].ToString();
                        dbpassword = reader["password"].ToString();
                        dbnotes = reader["notes"].ToString();
                        
                        dburl = Cryptography.Decrypt(dburl, masterpassword);
                        dbname = Cryptography.Decrypt(dbname, masterpassword);
                        dbusername = Cryptography.Decrypt(dbusername, masterpassword);
                        dbpassword = Cryptography.Decrypt(dbpassword, masterpassword);
                        dbnotes = Cryptography.Decrypt(dbid, masterpassword);
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[int.Parse(dbid) - offset].Cells[0].Value = (int.Parse(dbid) - offset).ToString();
                        dataGridView1.Rows[int.Parse(dbid) - offset].Cells[1].Value = dburl;
                        dataGridView1.Rows[int.Parse(dbid) - offset].Cells[2].Value = dbname;
                        dataGridView1.Rows[int.Parse(dbid) - offset].Cells[3].Value = dbusername;
                        dataGridView1.Rows[int.Parse(dbid) - offset].Cells[4].Value = dbpassword;
                        dataGridView1.Rows[int.Parse(dbid) - offset].Cells[5].Value = dbnotes;
                        MessageBox.Show("last record");
                        break;
                    }
                    
                }
                dbConnection.Dispose();
                dbConnection.Close();
                reader.Close();


            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
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

          private void button2_Click(object sender, EventArgs e)
          {
              login fasdorm1 = new login();
              masterusername = fasdorm1.getuser();
              masterpassword = fasdorm1.getpassword();
              //zemi gi glavnite kredincijali od formata 1
              dataGridView1.Rows.Clear();
              SQLiteConnection dbConnection;
              dbConnection =
              new SQLiteConnection("Data Source=" + fajl() + ";Version=3;");
              try
              {
                  dbConnection.Open();
                  int idbroj = 1;          //promenliva za skladiranje na id brojot od posledniot rekord
                  string maxid = "SELECT MAX(ID) FROM passwords;";        //komanda za selektiranje na posledniot rekord
                  string sql = "SELECT * FROM passwords ORDER BY id ";
                  SQLiteCommand maxidkomanda = new SQLiteCommand(maxid, dbConnection);
                  SQLiteDataReader reader1 = maxidkomanda.ExecuteReader();
                  while (reader1.Read())
                  {
                      idbroj = reader1.GetInt32(0);
                      break;
                  }
                  reader1.Close();
                  SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                  SQLiteDataReader reader = command.ExecuteReader();
                  while (reader.Read())
                  {
                      if (int.Parse(reader["id"].ToString()) != idbroj)
                      {
                          if (reader["id"].ToString() != "1")
                          {
                              dbid = reader["id"].ToString();
                              dburl = reader["URL"].ToString();
                              dbname = reader["name"].ToString();
                              dbusername = reader["username"].ToString();
                              dbpassword = reader["password"].ToString();
                              dbnotes = reader["notes"].ToString();
                       
                            dburl = Cryptography.Decrypt(dburl, masterpassword);
                            dbname = Cryptography.Decrypt(dbname, masterpassword);
                            dbusername = Cryptography.Decrypt(dbusername, masterpassword);
                            dbpassword = Cryptography.Decrypt(dbpassword, masterpassword);
                            dbnotes = Cryptography.Decrypt(dbid, masterpassword);
                            MessageBox.Show(dbid);
                            dataGridView1.Rows.Add();
                              dataGridView1.Rows[int.Parse(dbid) - 2].Cells[0].Value = (int.Parse(dbid) - 1).ToString();
                              dataGridView1.Rows[int.Parse(dbid) - 2].Cells[1].Value = dburl;
                              dataGridView1.Rows[int.Parse(dbid) - 2].Cells[2].Value = dbname;
                              dataGridView1.Rows[int.Parse(dbid) - 2].Cells[3].Value = dbusername;
                              dataGridView1.Rows[int.Parse(dbid) - 2].Cells[4].Value = dbpassword;
                              dataGridView1.Rows[int.Parse(dbid) - 2].Cells[5].Value = dbnotes;

                          }
                      }
                      else
                      {
                          dbid = reader["id"].ToString();
                          dburl = reader["URL"].ToString();
                          dbname = reader["name"].ToString();
                          dbusername = reader["username"].ToString();
                          dbpassword = reader["password"].ToString();
                          dbnotes = reader["notes"].ToString();
                      
                        dburl = Cryptography.Decrypt(dburl, masterpassword);
                        dbname = Cryptography.Decrypt(dbname, masterpassword);
                        dbusername = Cryptography.Decrypt(dbusername, masterpassword);
                        dbpassword = Cryptography.Decrypt(dbpassword, masterpassword);
                        dbnotes = Cryptography.Decrypt(dbid, masterpassword);
                        MessageBox.Show(dbid);
                        dataGridView1.Rows.Add();
                          dataGridView1.Rows[int.Parse(dbid) - 2].Cells[0].Value = (int.Parse(dbid) - 1).ToString();
                          dataGridView1.Rows[int.Parse(dbid) - 2].Cells[1].Value = dburl;
                          dataGridView1.Rows[int.Parse(dbid) - 2].Cells[2].Value = dbname;
                          dataGridView1.Rows[int.Parse(dbid) - 2].Cells[3].Value = dbusername;
                          dataGridView1.Rows[int.Parse(dbid) - 2].Cells[4].Value = dbpassword;
                          dataGridView1.Rows[int.Parse(dbid) - 2].Cells[5].Value = dbnotes;
                          break;
                      }
                  }
                  dbConnection.Dispose();
                  dbConnection.Close();
                  reader.Close();


              }
              catch (Exception ex)
              {
                  // MessageBox.Show(ex.Message);
              }

          } 
          

          private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
          {

          }
       
    }
}
