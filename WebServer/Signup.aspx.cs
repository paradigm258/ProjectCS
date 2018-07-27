using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServer.Dao;

namespace WebServer
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", true);
        }

        protected void buttonSignup_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblNoti.Text = "";
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (String.IsNullOrEmpty(username))
            {
                lblError.Text = "Username field is empty";
                return;
            }

            UserDAO userDao = new UserDAO();
            if (userDao.CheckUsername(username))
            {
                lblError.Text = "Username already exists";
                return;
            }

            if (String.IsNullOrEmpty(password))
            {
                lblError.Text = "Password field is empty";
                return;
            }
           
            if (userDao.AddUser(username, password))
            {
                lblNoti.Text = "Sign up succeeded";
                txtUsername.Text = "";
            }


        }
    }
}