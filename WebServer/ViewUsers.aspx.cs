using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServer.Interface;

namespace WebServer
{
    public partial class ViewUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("Login.aspx", true);
                return;
            }
            lblActiveUser.Text = (String)Session["admin"];
            Label2.Visible = false;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            IUserDAO dao = new Dao.UserDAO();
            Model.User user = dao.GetUser((string)e.CommandArgument);
            switch (e.CommandName)
            {
                case "Select":                  
                    Session["username"] = user.Username;
                    Response.Redirect("Home");
                    break;
                case "Edit":
                    Label2.Text = user.Username;
                    TextBox1.Text = user.MaxQuota+"";
                    Label2.Visible = true;
                    break;
                case "Delete":
                    dao.DeleteUser(user.Username);
                    break;
                default:
                    break;
            }
        }

        protected void buttonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["admin"] = null;
            Response.Redirect("Login.aspx", true);
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int newQuota = int.Parse(TextBox1.Text);
            new Dao.UserDAO().UpdateMaxQuota(Label2.Text, newQuota);
        }
    }
}