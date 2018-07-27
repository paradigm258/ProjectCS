using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Windows.Forms;
using System.Diagnostics;

namespace ClientApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://project.com");
            Process.Start(sInfo);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                string message = "Username can't be blank";
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    message += ", Password can't be blank";
                }
                MessageBox.Show(message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation );
            }
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
               { "username", textBox1.Text},
               { "password", textBox2.Text }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("http://localhost:52598/AppLogin.ashx", content);
            string s = await response.Content.ReadAsStringAsync();
            bool success = false;
            try
            {
                success = bool.Parse(s);
            }
            catch
            {
                success = false;
            }
            if (!success)
            {
                label3.Visible = true;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
