using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServer.Dao;
using WebServer.Model;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace WebServer
{
    public partial class Home : System.Web.UI.Page
    {
        OpenFileDialog file = new OpenFileDialog();
        public Item item { get; set; }
        public List<Item> test { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx", true);
                return;
            }
            lblActiveUser.Text = (String)Session["username"];
            test = (new ItemDAO()).GetAllItemsWithNullParent((String)Session["username"]);
            loadItemsWithNullParent();
        }

        protected void buttonLogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["admin"] = null;
            Response.Redirect("Login.aspx", true);
        }

        protected void buttonItemCategories_Click(object sender, EventArgs e)
        {
            string itemCategories = buttonItemCategories.Text;
            switch (itemCategories)
            {
                case "My Items":
                    loadItemsWithNullParent();
                    buttonItemCategories.Text = "Shared To Me";
                    break;
                case "Shared To Me":


                    buttonItemCategories.Text = "My Items";
                    break;
                default:
                    break;
            }
        }

        public void loadItemsWithNullParent()
        {
            ItemDAO itemDao = new ItemDAO();
            string username = (String)Session["username"];
            List<Item> myItems = itemDao.GetAllItemsWithNullParent(username);
            GridView1.DataSource = myItems;
            GridView1.DataBind();
        }

        

        protected void buttonAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddItem.aspx", true);
        }
    }
}