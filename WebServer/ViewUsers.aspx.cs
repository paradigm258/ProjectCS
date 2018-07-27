using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch(e.CommandName)
            {
                case "Select":
                    Response.Redirect("./User.aspx?username=" + e.CommandArgument);
                    break;
                case "Edit":

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
    }
}