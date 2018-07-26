using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServer.Dao;
using WebServer.Interface;

namespace WebServer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void buttonSignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx", true);
        }

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (String.IsNullOrEmpty(username))
            {
                lblError.Text = "Username field is empty";
                return;
            }

            if (String.IsNullOrEmpty(password))
            {
                lblError.Text = "Password field is empty";
                return;
            }

            UserDAO userDao = new UserDAO();
            if((new UserDAO()).CheckUser(username, password))
            {
                lblError.Text = "Username or password is wrong";
                //txtPassword.Text = "";
                return;
            }
        }
    }
}