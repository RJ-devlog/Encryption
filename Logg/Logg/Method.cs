using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logg
{
    public partial class Method : Form
    {
        public Method()
        {
            InitializeComponent();
        }
        public string connectionString = "Data Source=DESKTOP-0P7Q68D\\SQLEXPRESS;Initial Catalog=GameAccounts;Integrated Security=True;";
        private const string CHARSET = "!@#$%^&*()-_=+[]{}|;:',.<>?/`~\"\\ abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private string dataBaseData;
        private void btnPassdata_Click(object sender, EventArgs e)
        {
            dataBaseData = txtEncryptData.Text.ToString();
            lblDatabaseData.Text = $"Database Data:\n{dataBaseData}";
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            string input = txtData.Text;
            string encryptData = ManipulationTwistLock69Encyption(input);
            txtEncryptData.Text = encryptData;

        }
        private string encryptData;
        private string decryptData;
        private void btnData_Click(object sender, EventArgs e)
        {
            string rawData = txtData.Text;
            txtRawData.Text = rawData;

            encryptData = ManipulationTwistLock69Encyption(rawData);
            decryptData = ManipulationTwistLock69Decrypt(encryptData);

            txtEncrypt.Text = encryptData;
        }

        private void btnMatched_Click(object sender, EventArgs e)
        {

            lblResult.Text = txtEncrypt.Text.ToString() == dataBaseData ? "True" : "False";
        }

        private void Method_Load(object sender, EventArgs e)
        {

        }
    }
}
