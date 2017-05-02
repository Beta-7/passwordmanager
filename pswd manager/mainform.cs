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
        public static bool debug = true;
        public static string masterpassword;
        public static string dbid;
        public static string dburl;
        public static string dbname;
        public static string dbusername;
        public static string dbpassword;
        public static string dbnotes;
        int offset = 0; //se koristi za namaluvanje na id broevite za 2 bidejki id 1 ne se pokazuva zs tamu se cuva master passwordot

        public mainform()
        {
            InitializeComponent();
        }

        private void Dmessage(string message)
        {
            if (debug)
                MessageBox.Show(message);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private string Fajl()
        {
            Login fasdorm1 = new Login();
            return Environment.ExpandEnvironmentVariables("%AppData%") + "\\passwordmanager" + "\\" + fasdorm1.Getuser() + ".sqlite"; //Get the username variable from the login form and get the path to the file from it
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DodadiUser asd = new DodadiUser(this);
            asd.Show();
            UpdateGrid();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            UpdateGrid();

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { }

        public void UpdateGrid()
        {
            int brojac = -1; //Counter used to count the id of the datagridview field
            Login fasdorm1 = new Login();
            masterusername = fasdorm1.Getuser();
            masterpassword = fasdorm1.Getpassword(); //Get the username and password of the user
            dataGridView1.Rows.Clear(); //Clear all the rows
            SQLiteConnection dbConnection;
            dbConnection =
            new SQLiteConnection("Data Source=" + Fajl() + ";Version=3;");

            try
            {
                //Connect to the file
                dbConnection.Open();
                int idbroj = 1;          //promenliva za skladiranje na id brojot od posledniot rekord
                string maxid = "SELECT MAX(ID) FROM passwords;";        //komanda za selektiranje na posledniot rekord
                string sql = "SELECT * FROM passwords ORDER BY id ";
                SQLiteCommand maxidkomanda = new SQLiteCommand(maxid, dbConnection);
                SQLiteDataReader reader1 = maxidkomanda.ExecuteReader();

                while (reader1.Read())
                {
                    idbroj = reader1.GetInt32(0);
                    break; //Get the highest ID number from the records, as in the last record entered
                }

                reader1.Close();
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // if (int.Parse(reader["id"].ToString()) <= idbroj )
                    // {
                    if (reader["id"].ToString() != "1") //If the record's ID isn't 1, because the first record is used to store the encrypted password
                    {
                        if (reader["visible"].ToString() == "1") //if the record's visible field is set to 1, because the "deleted" record's IDs are set to 0
                        {
                            brojac++; //Increment the counter (move to the next row of dataGridView)
                            dbid = reader["id"].ToString();
                            dburl = reader["URL"].ToString();
                            dbname = reader["name"].ToString();
                            dbusername = reader["username"].ToString();
                            dbpassword = reader["password"].ToString();
                            dbnotes = reader["notes"].ToString(); //Get the record's data and turn it into strings
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[brojac].Cells[0].Value = (int.Parse(dbid)).ToString();
                            dataGridView1.Rows[brojac].Cells[1].Value = Cryptography.Decrypt(dburl, masterpassword);
                            dataGridView1.Rows[brojac].Cells[2].Value = Cryptography.Decrypt(dbname, masterpassword);
                            dataGridView1.Rows[brojac].Cells[3].Value = Cryptography.Decrypt(dbusername, masterpassword);
                            dataGridView1.Rows[brojac].Cells[4].Value = Cryptography.Decrypt(dbpassword, masterpassword);
                            dataGridView1.Rows[brojac].Cells[5].Value = Cryptography.Decrypt(dbnotes, masterpassword); //Input the record's data into the dataGridView table after it gets decrypted with the password gotten from the login form     
                        }
                    }
                }
                dbConnection.Dispose();
                dbConnection.Close();
                reader.Close(); //Close the connection
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows.Count < 2)
                {
                    //if only one row has been selected from the dataGridView table
                    int selectedid = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["id"].Value.ToString()); //Get the selected row's ID from the hidden ID column
                    SQLiteConnection dbConnection;
                    dbConnection =
                    new SQLiteConnection("Data Source=" + Fajl() + ";Version=3;");
                    try
                    {
                        //Connect to the file
                        dbConnection.Open();
                        string sql = "SELECT * FROM passwords WHERE ID=" + selectedid + ";"; //Select the record with the ID gotten from before
                        SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                        SQLiteDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            textBox1.Text = Cryptography.Decrypt(reader["URL"].ToString(), masterpassword);
                            textBox2.Text = Cryptography.Decrypt(reader["name"].ToString(), masterpassword);
                            textBox3.Text = Cryptography.Decrypt(reader["username"].ToString(), masterpassword);
                            textBox4.Text = Cryptography.Decrypt(reader["password"].ToString(), masterpassword);
                            textBox5.Text = Cryptography.Decrypt(reader["notes"].ToString(), masterpassword);
                        }
                        //Fill the textboxes with the decrypted values of the record
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //Make the textfields visible
                    #region visible
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;
                    #endregion
                }



            }
            else
            {
                //Make the text fields invisible
                #region invisible
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                #endregion
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int selectedid = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["id"].Value.ToString()); //Get the selected row's ID from the hidden ID column
            SQLiteConnection dbConnection;
            dbConnection =
            new SQLiteConnection("Data Source=" + Fajl() + ";Version=3;");
            try
            {
                //Connect to the file
                dbConnection.Open();
                SQLiteCommand command = new SQLiteCommand(dbConnection);
                command.CommandText =
              "UPDATE passwords SET url = @url, name= @name, username= @username, password= @password, notes =@notes WHERE id= @id;";
                command.Parameters.AddWithValue("@url", Cryptography.Encrypt(textBox1.Text, masterpassword));
                command.Parameters.AddWithValue("@name", Cryptography.Encrypt(textBox2.Text, masterpassword));
                command.Parameters.AddWithValue("@username", Cryptography.Encrypt(textBox3.Text, masterpassword));
                command.Parameters.AddWithValue("@password", Cryptography.Encrypt(textBox4.Text, masterpassword));
                command.Parameters.AddWithValue("@notes", Cryptography.Encrypt(textBox5.Text, masterpassword));
                command.Parameters.AddWithValue("@id", selectedid); //Update the record with the strings that are in the textboxes used for editing
                command.ExecuteNonQuery();
                dbConnection.Close();
                UpdateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            int selectedid = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["id"].Value.ToString());
            SQLiteConnection dbConnection;
            dbConnection =
            new SQLiteConnection("Data Source=" + Fajl() + ";Version=3;");
            try
            {
                dbConnection.Open();
                SQLiteCommand command = new SQLiteCommand(dbConnection);
                command.CommandText =
              "UPDATE passwords SET url = @url, name= @name, username= @username, password= @password, notes =@notes, visible= @visible WHERE id= @id;";
                command.Parameters.AddWithValue("@url", Cryptography.Encrypt(textBox1.Text, masterpassword));
                command.Parameters.AddWithValue("@name", Cryptography.Encrypt(textBox2.Text, masterpassword));
                command.Parameters.AddWithValue("@username", Cryptography.Encrypt(textBox3.Text, masterpassword));
                command.Parameters.AddWithValue("@password", Cryptography.Encrypt(textBox4.Text, masterpassword));
                command.Parameters.AddWithValue("@notes", Cryptography.Encrypt(textBox5.Text, masterpassword));
                command.Parameters.AddWithValue("@id", selectedid);
                command.Parameters.AddWithValue("@visible", 0); //Do the same as before, but also set the visible field to 0
                command.ExecuteNonQuery();
                dbConnection.Close();
                UpdateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows.Count < 2)
                {
                    int selectedid = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["id"].Value.ToString());
                    SQLiteConnection dbConnection;
                    dbConnection =
                    new SQLiteConnection("Data Source=" + Fajl() + ";Version=3;");
                    try
                    {
                        dbConnection.Open();
                        string sql = "SELECT * FROM passwords WHERE ID=" + selectedid + ";";
                        SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                        SQLiteDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            textBox1.Text = Cryptography.Decrypt(reader["URL"].ToString(), masterpassword);
                            textBox2.Text = Cryptography.Decrypt(reader["name"].ToString(), masterpassword);
                            textBox3.Text = Cryptography.Decrypt(reader["username"].ToString(), masterpassword);
                            textBox4.Text = Cryptography.Decrypt(reader["password"].ToString(), masterpassword);
                            textBox5.Text = Cryptography.Decrypt(reader["notes"].ToString(), masterpassword);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                #region invisible
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                #endregion
            }
        }
    }
}
