﻿using System;
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
        public List<Item> items { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx", true);
                return;
            }
            lblActiveUser.Text = (String)Session["username"];
            string sParent = Request.QueryString["id"];
            int parent;
            if (String.IsNullOrEmpty(sParent))
            {
                parent = 0;
            }
            else
            {
                parent = int.Parse(sParent);
            }
            loadItemsWithParent(parent);
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
                    loadSharedItems();
                    buttonItemCategories.Text = "My Items";
                    break;
                default:
                    break;
            }
        }

        public void loadItemsWithNullParent()
        {
            items = (new ItemDAO()).GetAllItemsWithNullParent((String)Session["username"]);
        }

        public void loadItemsWithParent(int parent)
        {
            items = (new ItemDAO()).GetAllItemsWithParent((String)Session["username"], parent);
        }

        public void loadSharedItems()
        {
            items = (new ItemDAO()).GetAllSharedItems((String)Session["username"]);
        }

        protected void buttonAdd_Click(object sender, EventArgs e)
        {
            string sParent = Request.QueryString["id"];
            int parent;
            if (String.IsNullOrEmpty(sParent))
            {
                parent = 0;
            }
            else
            {
                parent = int.Parse(sParent);
            }
            Response.Redirect("AddItem.aspx?id="+parent, true);
        }
    }
}