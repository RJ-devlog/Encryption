using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace Logg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Transparent;
            Form form = new Form();
            
            //login Button Properties
            btnLogin.BackColor = Color.FromArgb(0, 113, 189);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
           
            //TExtbox Properties
            TextBox textbox = new TextBox();
            textbox.ForeColor = Color.FromArgb(6,35,75);
        }

        public string username = string.Empty;
        public string password = string.Empty;
        // LOGIN
        public string connectionString = "Data Source=DESKTOP-0P7Q68D\\SQLEXPRESS;Initial Catalog=GameAccounts;Integrated Security=True;";
        private void button1_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            password = txtPassword.Text;
            using (SqlConnection sqlCon  = new SqlConnection(connectionString))
            {
                if (!string.IsNullOrWhiteSpace(username) || !string.IsNullOrWhiteSpace(password))
                {
                    try
                    {
                        sqlCon.Open();
                        int count = 0;
                        string querySelection = $"SELECT COUNT(1) FROM CFAccounts WHERE username = @username AND passwordd = @passwordd";
                        using (SqlCommand sqlCmd = new SqlCommand(querySelection, sqlCon))
                        {
                            sqlCmd.Parameters.AddWithValue("@username", username);
                            sqlCmd.Parameters.AddWithValue("@passwordd", password);
                            count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                            string accMessage = count > 0 ? "Account Found\nWelcome!!" : "Account not Found\nPlease register";
                            MessageBox.Show(accMessage);
                            string encryptMessage = ManipulationTwistLock69Encyption(password);
                            string decryptMessage = ManipulationTwistLock69Decrypt(encryptMessage);
                            MessageBox.Show($"Encrpyt: {encryptMessage}\nDecrypt: {decryptMessage}");
                        }
                        sqlCon.Close();
                    }
                    catch (Exception errorMsg)
                    {
                        MessageBox.Show(errorMsg.Message);
                    }

                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Original Encryption Method
        private const string CHARSET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_=+[]{}|;:',.<>?/`~\"\\ ";
        public static string ManipulationTwistLock69Encyption(string input) 
        {
            int shift = 69;
            StringBuilder result = new StringBuilder();
            int len = CHARSET.Length;

            foreach (char c in input)
            {
                int index = CHARSET.IndexOf(c);
                if (index >= 0)
                {
                    // Normalize shift so it's within charset bounds
                    int newIndex = (index + shift) % len;
                    result.Append(CHARSET[newIndex]);
                }
                else
                {
                    // If not found in CHARSET, keep the character as is
                    result.Append(c);
                }
            }

            return result.ToString();
        }
        //Original Decryption Method
        private string ManipulationTwistLock69Decrypt(string input)
        {
            int shift = 69;
            StringBuilder result = new StringBuilder();
            int len = CHARSET.Length;

            foreach (char c in input)
            {
                int index = CHARSET.IndexOf(c);
                if (index >= 0)
                {
                    // Use modulo to wrap around in case of negative result
                    int newIndex = (index - shift + len) % len;
                    result.Append(CHARSET[newIndex]);
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }
        //REGISTER
        private void btnRegist_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            password = txtPassword.Text;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
                {
                    try
                    {
                        sqlCon.Open();
                        string querySelector = "SELECT COUNT(1) FROM CFAccounts WHERE username = @username";
                        using (SqlCommand sqlCmd = new SqlCommand(querySelector, sqlCon))
                        {
                            sqlCmd.Parameters.AddWithValue("@username", username);
                            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                            bool accountExist = count > 0 ? true : false;
                            if (accountExist)
                            {
                                MessageBox.Show("Account Already Exist");
                            }
                            else
                            {
                                string queryInsertVal = "INSERT INTO CFAccounts (username,passwordd) VALUES (@username,@passwordd)";
                                using (SqlCommand sqlInsertVal = new SqlCommand(queryInsertVal, sqlCon))
                                {
                                    sqlInsertVal.Parameters.AddWithValue("@username", username);
                                    sqlInsertVal.Parameters.AddWithValue("@passwordd", password);
                                    sqlInsertVal.ExecuteNonQuery();
                                }
                                MessageBox.Show("Register Successfully");
                            }
                        }
                        sqlCon.Close();
                        username = string.Empty;
                        password = string.Empty;
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }

                }
            }
        }
    }
}
