using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Data.SQLite;

namespace pswd_manager
{
    public partial class LoginForm : Form
    {
        public static string username;
        public static string password;
        private static string sharedSecret = "asdasdd";
  
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(Appdatafolder()); //Create a folder in %appdata% named password manager, in case it doesn't exist
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            confirmPWTB.Visible = newUserCB.Checked; //If the checkbox is checked, show another textbox to input the password again
            continueBtn.Text = newUserCB.Checked ? "&Create user" : "&Login"; // If the new user checkbox is checked rename the login button to create user, otherwise keep it at login.
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string databasefajl = Appdatafolder() + "\\" + usernameTB.Text + ".sqlite";

            #region checked
            if (newUserCB.Checked) //If they selected the register option
            {
                if (passwordTB.Text == confirmPWTB.Text) //Check if both of the passwords are the same
                {
                    if (usernameTB.Text != "") //Check if the first password field is empty
                    {
                        if (passwordTB.Text != "") //Check if the second password field is empty
                        {
                            if (!File.Exists(databasefajl)) //If the file doesn't exist already, as in the username hasn't been registered
                            {
                                sharedSecret = passwordTB.Text;
                                string enkriptirandavid = Cryptography.Encrypt(sharedSecret, passwordTB.Text); //encrypt the password with itself
                                SQLiteConnection.CreateFile(databasefajl); //Create a db file in %appdata% named username.sqlite
                                SQLiteConnection dbConnection;
                                dbConnection =
                                new SQLiteConnection("Data Source=" + databasefajl + ";Version=3;");
                                using (var myconnection = new SQLiteConnection(dbConnection))
                                {
                                    myconnection.Open(); //Open the .sqlite file

                                    try
                                    {
                                        string sqlinsert = "insert into passwords (url, name) values ('" + enkriptirandavid + "','" + enkriptirandavid + "');";
                                        //sqlinsert.Parameters.AddWithValue("@url", enkriptirandavid);
                                        SQLiteCommand sqlinsert1 = new SQLiteCommand(sqlinsert, myconnection);
                                        string komanda = "create table passwords (id integer primary key autoincrement,URL varchar(150), name varchar(150)" +
                                            ",username varchar(150), password varchar(150), notes varchar(1500), visible integer)";
                                        SQLiteCommand izvrsikomanda2 = new SQLiteCommand(komanda, myconnection);
                                        izvrsikomanda2.ExecuteNonQuery(); //Create a table named passwords
                                        sqlinsert1.ExecuteNonQuery(); //Fill the first record's first 2 fields with the encrypted password
                                        myconnection.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }

                                    newUserCB.Checked = false;
                                    MessageBox.Show("Успешна регистрација"); //Successful registration
                                }
                            }
                            else
                            {
                                MessageBox.Show("Корисничкото име веке постои"); //Username already exists
                            }
                        }
                        else
                        {
                            MessageBox.Show("Немате внесено лозинка"); //No password entered
                        }
                    }
                    else
                    {
                        MessageBox.Show("Немате внесено корисничко име"); //No username entered
                    }
                }
                else
                {
                    MessageBox.Show("Лозинките не се исти"); //Password mismatch
                }
            }
            #endregion 
            else
            {
                if (File.Exists(databasefajl)) //If the file exists already, when the username has been registered
                {
                    sharedSecret = passwordTB.Text;
                    SQLiteConnection dbConnection;
                    dbConnection =
                    new SQLiteConnection("Data Source=" + databasefajl + ";Version=3;");
                    dbConnection.Open(); //Connect to the .sqlite file
                    string sql = "SELECT * FROM passwords ORDER BY id ";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader(); //Get the records inside
                    while (reader.Read())
                    { //If (textBox2.Text == Cryptography.Decrypt(reader["URL"].ToString(), sharedsecret))
                        if (Cryptography.Encrypt(passwordTB.Text, sharedSecret) == reader["URL"].ToString())
                        //Encrypt the entered password with the one that is in the first record of the file
                        {
                            username = usernameTB.Text;
                            password = passwordTB.Text;
                            reader.Close();
                            dbConnection.Close();
                            MainForm form2 = new MainForm(); //Close the SQLITE connection and open the main form.
                            Hide();
                            form2.ShowDialog(this);
                            Close();
                            break;

                        }
                        else
                        {
                            MessageBox.Show("Погрешна лозинка"); //Wrong password
                            reader.Close();
                            dbConnection.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Корисничкото име не е регистрирано"); //Username not registered
                }
            }
        }

        private string Appdatafolder()
        {
            string AppData = Environment.ExpandEnvironmentVariables("%AppData%"); //path to %appdata%
            string folder = AppData + "\\passwordmanager";
            return folder; //Return the path to the password manager folder
        }

        public string Getuser()
        {
            return username; //Return the entered username so it can be used in the next form
        }

        public string Getpassword()
        {
            return password; //Return the entered password so it can be used in the next form
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowPWCB_CheckedChanged(object sender, EventArgs e)
        {
            // Show the entered passwords if the show password checkbox is checked, otherwise hide them.
            passwordTB.PasswordChar = showPWCB.Checked ? '\0' : '*';
            confirmPWTB.PasswordChar = showPWCB.Checked ? '\0' : '*';
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
