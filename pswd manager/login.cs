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
            //najdi go %appdata%  folderot


        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Visible = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string databasefajl = appdatafolder() + "\\" + textBox1.Text + ".sqlite";

            #region checked
            if (checkBox1.Checked)
            {

                if (textBox2.Text == textBox3.Text)
                {
                    if (textBox1.Text != "")
                    {
                        if (textBox2.Text != "")
                        {
                            if (!File.Exists(databasefajl))
                            {
                                sharedsecret = textBox2.Text;
                                string enkriptirandavid = Cryptography.Encrypt(sharedsecret, textBox2.Text);
                                //enkriptiraj "david" so passwordot na fajlot
                                SQLiteConnection.CreateFile(databasefajl);
                                //kreiraj fajl so ime username.sqlite sto se naoga vo appdata folderot
                                SQLiteConnection dbConnection;
                                dbConnection =
                                new SQLiteConnection("Data Source=" + databasefajl + ";Version=3;");
                                using (var myconnection = new SQLiteConnection(dbConnection))
                                {
                                    myconnection.Open();


                                    try
                                    {
                                        
                                        MessageBox.Show("konekcija");
                                        SQLiteCommand sqlinsert = new SQLiteCommand(dbConnection);
                                        sqlinsert.CommandText = "insert into passwords (url, name) values (@url, @url)";
                                        sqlinsert.Parameters.AddWithValue("@url", enkriptirandavid);
                                        
                                        string komanda = "create table passwords (id integer primary key autoincrement,URL varchar(150), name varchar(150), username varchar(150), password varchar(150), notes varchar(1500))";
                                        SQLiteCommand izvrsikomanda2 = new SQLiteCommand(komanda, myconnection);

                                        izvrsikomanda2.ExecuteNonQuery();
                                        sqlinsert.ExecuteNonQuery();
                                        
                                        myconnection.Close();
                                    }
                                    catch (Exception ex)
                                    {

                                    }

                                    checkBox1.Checked = false;
                                    MessageBox.Show("Успешна регистрација");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Корисничкото име веке постои");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Немате внесено лозинка");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Немате внесено корисничко име");
                    }
                }
                else
                {
                    MessageBox.Show("Лозинките не се исти");
                }
            }
            #endregion 
            else
            {
                if (File.Exists(databasefajl))
                {
                    sharedsecret = textBox2.Text;
                    SQLiteConnection dbConnection;
                    dbConnection =
                    new SQLiteConnection("Data Source=" + databasefajl + ";Version=3;");
                    dbConnection.Open();
                    string sql = "SELECT * FROM passwords ORDER BY id ";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {  // if (textBox2.Text == Cryptography.Decrypt(reader["URL"].ToString(), sharedsecret))
                        if (Cryptography.Encrypt(textBox2.Text, sharedsecret) == reader["URL"].ToString())
                        {
                            username = textBox1.Text;
                            password = textBox2.Text;


                            reader.Close();
                            dbConnection.Close();
                            mainform form2 = new mainform();

                            form2.ShowDialog();
                            this.Close();
                            break;

                        }
                        else
                        {
                            MessageBox.Show("Погрешна лозинка");

                        }

                    }
                }
                else
                {
                    MessageBox.Show("Корисничкото име не е регистрирано");
                }
            }
        }
        private string appdatafolder()
        {
            string AppData = Environment.ExpandEnvironmentVariables("%AppData%");

            //pateka do %appdata%/common/passwordmanager folderot
            string folder = AppData + "\\passwordmanager";
            return folder;
        }
        public string getuser()
        {

            return username;
        }
        public string getpassword()
        {

            return password;
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
