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
            ProcessStartInfo sInfo = new ProcessStartInfo("http://www.google.com");
            Process.Start(sInfo);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
               { "username", "hello" },
               { "password", "world" }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("http://localhost:52598/AppLogin.ashx", content);
            string s = await response.Content.ReadAsStringAsync();
            bool success = bool.Parse(s);
            if (success)
            {
                
            }
        }

    }
}
