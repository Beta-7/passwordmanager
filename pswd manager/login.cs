using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Data.SQLite;

namespace pswd_manager
{




    public partial class login : Form
    {
        public static string username;
        public static string password;
        private static string sharedsecret = "asdasdd";
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            System.IO.Directory.CreateDirectory(appdatafolder());
            //create a folder in %appdata% named password manager, in case it doesn't exist


        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Visible = checkBox1.Checked;  
            //if the checkbox is checked, show another textbox to input the password again
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string databasefajl = appdatafolder() + "\\" + textBox1.Text + ".sqlite";

            #region checked
            if (checkBox1.Checked)    //if they selected the register option
            {

                if (textBox2.Text == textBox3.Text)   //check if both of the passwords are the same
                {
                    if (textBox1.Text != "")            //check if the first password field is empty
                    {
                        if (textBox2.Text != "")        //check if the second password field is empty
                        {
                            if (!File.Exists(databasefajl)) //if the file doesn't exist already, as in the username hasn't been registered
                            {
                                sharedsecret = textBox2.Text;           
                                string enkriptirandavid = Cryptography.Encrypt(sharedsecret, textBox2.Text);  //encrypt the password with itself
                                SQLiteConnection.CreateFile(databasefajl);      //create a db file in %appdata% named username.sqlite
                                SQLiteConnection dbConnection;
                                dbConnection =
                                new SQLiteConnection("Data Source=" + databasefajl + ";Version=3;");
                                using (var myconnection = new SQLiteConnection(dbConnection))
                                {
                                    myconnection.Open();
                                    //open the .sqlite file

                                    try
                                    {
                                        
                                        
                                        
                                        string sqlinsert = "insert into passwords (url, name) values ('"+enkriptirandavid+ "','" + enkriptirandavid + "');";
                                        //    sqlinsert.Parameters.AddWithValue("@url", enkriptirandavid);
                                        SQLiteCommand sqlinsert1 = new SQLiteCommand(sqlinsert, myconnection);
                                        string komanda = "create table passwords (id integer primary key autoincrement,URL varchar(150), name varchar(150)"+
                                            ",username varchar(150), password varchar(150), notes varchar(1500), visible integer)";
                                        SQLiteCommand izvrsikomanda2 = new SQLiteCommand(komanda, myconnection);

                                        izvrsikomanda2.ExecuteNonQuery();
                                       //create a table named passwords
                                        sqlinsert1.ExecuteNonQuery();
                                        //fill the first record's first 2 fields with the encrypted password

                                        myconnection.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }

                                    checkBox1.Checked = false;
                                    MessageBox.Show("Успешна регистрација");
                                    //succesfull registration
                                }

                            }
                            else
                            {
                                MessageBox.Show("Корисничкото име веке постои");
                                //username already exists
                            }
                        }
                        else
                        {
                            MessageBox.Show("Немате внесено лозинка");
                            //no password entered
                        }
                    }
                    else
                    {
                        MessageBox.Show("Немате внесено корисничко име");
                        //no username entered
                    }
                }
                else
                {
                    MessageBox.Show("Лозинките не се исти");
                    //password mismatch
                }
            }
            #endregion 
            else
            {
                if (File.Exists(databasefajl))      //if the file exists already, when the username has been registered
                {
                    sharedsecret = textBox2.Text;
                    SQLiteConnection dbConnection;
                    dbConnection =
                    new SQLiteConnection("Data Source=" + databasefajl + ";Version=3;");
                    dbConnection.Open();
                    //connect to the .sqlite file
                    string sql = "SELECT * FROM passwords ORDER BY id ";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    //get the records inside
                    while (reader.Read())
                    {  // if (textBox2.Text == Cryptography.Decrypt(reader["URL"].ToString(), sharedsecret))
                        if (Cryptography.Encrypt(textBox2.Text, sharedsecret) == reader["URL"].ToString())
                       //encrypt the entered password with the one that is in the first record of the file
                        {
                            username = textBox1.Text;
                            password = textBox2.Text;


                            reader.Close();
                            dbConnection.Close();
                            mainform form2 = new mainform();
                            //close the SQLITE connection and open the main form.
                            form2.ShowDialog();
                            this.Close();
                            break;

                        }
                        else
                        {
                            MessageBox.Show("Погрешна лозинка");
                            //wrong password
                            reader.Close();
                            dbConnection.Close();

                        }

                    }
                }
                else
                {
                    MessageBox.Show("Корисничкото име не е регистрирано");
                    //username not registered
                }
            }
        }
        private string appdatafolder()
        {
            string AppData = Environment.ExpandEnvironmentVariables("%AppData%");

            //path to %appdata%
            string folder = AppData + "\\passwordmanager";
            return folder;
            //return the path to the passwordmanager folder
        }
        public string getuser()
        {

            return username;
            //return the entered username so it can be used in the next form
        }
        public string getpassword()
        {

            return password;
            //return the entered password so it can be used in the next form
        }
    }
    public static class Cryptography
    {
        #region Settings

        private static int _iterations = 2;
        private static int _keySize = 256;

        private static string _hash = "SHA1";
        private static string _salt = "aselrias38490a32"; // Random
        private static string _vector = "8947az34awl34kjq"; // Random

        #endregion

        public static string Encrypt(string value, string password)
        {
            return Encrypt<AesManaged>(value, password);
        }
        public static string Encrypt<T>(string value, string password)
                where T : SymmetricAlgorithm, new()
        {
            byte[] vectorBytes = ASCIIEncoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = ASCIIEncoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = ASCIIEncoding.ASCII.GetBytes(value);

            byte[] encrypted;
            using (T cipher = new T())
            {
                PasswordDeriveBytes _passwordBytes =
                    new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                using (ICryptoTransform encryptor = cipher.CreateEncryptor(keyBytes, vectorBytes))
                {
                    using (MemoryStream to = new MemoryStream())
                    {
                        using (CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
                        {
                            writer.Write(valueBytes, 0, valueBytes.Length);
                            writer.FlushFinalBlock();
                            encrypted = to.ToArray();
                        }
                    }
                }
                cipher.Clear();
            }
            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string value, string password)
        {
            return Decrypt<AesManaged>(value, password);
        }
        public static string Decrypt<T>(string value, string password) where T : SymmetricAlgorithm, new()
        {
            byte[] vectorBytes = ASCIIEncoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = ASCIIEncoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = Convert.FromBase64String(value);

            byte[] decrypted;
            int decryptedByteCount = 0;

            using (T cipher = new T())
            {
                PasswordDeriveBytes _passwordBytes = new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                try
                {
                    using (ICryptoTransform decryptor = cipher.CreateDecryptor(keyBytes, vectorBytes))
                    {
                        using (MemoryStream from = new MemoryStream(valueBytes))
                        {
                            using (CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
                            {
                                decrypted = new byte[valueBytes.Length];
                                decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return String.Empty;
                }

                cipher.Clear();
            }
            return Encoding.UTF8.GetString(decrypted, 0, decryptedByteCount);
        }

    }

}
