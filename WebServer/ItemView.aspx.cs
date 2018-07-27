using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServer.Dao;
using WebServer.Model;

namespace WebServer
{
    public partial class ItemView : System.Web.UI.Page
    {
        Item i;

        public bool isOwner;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx", true);
                return;
            }
            lblActiveUser.Text = (String)Session["username"];
            String id = Request.QueryString["id"];
            i = (new ItemDAO()).GetItem(int.Parse(id));

            Name.Text = i.name;
            isOwner = i.owner.Equals((String)Session["username"]);
            if (!isOwner)
            {
                if (!i.isPublic)
                {
                    if(!(new PermitDAO()).CheckPermit(i.id, (String)Session["username"])){
                        Response.Redirect("Home.aspx", true);
                    }
                }
                return;
            }
            if (i.isPublic)
            {
                buttonSwitchPrivacy.Text = "Switch to Private";
            }
            else
            {
                buttonSwitchPrivacy.Text = "Switch to Public";
            }
        }

        protected void buttonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", true);
        }

        protected void buttonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["admin"] = null;
            Response.Redirect("Login.aspx", true);
        }

        protected void Filter_TextChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
            string filter = Filter.Text.Trim();
            if (String.IsNullOrEmpty(filter))
            {
                lblError.Text = "Type in something to filter";
            }
            else
            {
                List<string> users = (new UserDAO()).Top20ShareableUsers(i.id, filter);
                DropDownList1.DataSource = users;
                DropDownList1.DataBind();
            }

        }

        protected void buttonSwitchPrivacy_Click(object sender, EventArgs e)
        {
            string buttonAction = buttonSwitchPrivacy.Text;
            switch (buttonAction)
            {
                case "Switch to Private":
                    (new ItemDAO()).UpdateItem(i.id, i.name, !i.isPublic, i.size, i.parent);
                    buttonSwitchPrivacy.Text = "Switch to Public";
                    break;
                case "Switch to Public":
                    (new ItemDAO()).UpdateItem(i.id, i.name, !i.isPublic, i.size, i.parent);
                    buttonSwitchPrivacy.Text = "Switch to Private";
                    break;
            }
        }

        protected void buttonShare_Click(object sender, EventArgs e)
        {
            lblNoti.Text = "";
            (new PermitDAO()).AddPermit(i.id, DropDownList1.SelectedItem.ToString());
            lblNoti.Text = "Permission Shared";
        }

        protected void buttonDelete_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblError.Text = "delete";
        }

        protected void buttonDownload_Click(object sender, EventArgs e)
        {
            Response.Redirect("Download.ashx?id="+i.id, true);
        }
    }
}