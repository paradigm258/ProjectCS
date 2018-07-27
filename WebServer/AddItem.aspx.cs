using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServer.Dao;
using WebServer.Model;

namespace WebServer
{
    public partial class AddItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx", true);
                return;
            }
            lblActiveUser.Text = (String)Session["username"];
        }

        protected void buttonAdd_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblNoti.Text = "";
            HttpFileCollection uploadedFiles = Request.Files;
            string filepath = Server.MapPath("~/Storage/");
            bool hasFile = false;
            bool isPublic = IsPublic.Checked;
            long totalSize = 0;
            User user = (new UserDAO()).GetUser((String)Session["username"]);
            bool outOfQuota = false;
            for (int i = 0; i < uploadedFiles.Count; i++)
            {
                HttpPostedFile userPostedFile = uploadedFiles[i];
                try
                {
                    if (userPostedFile.ContentLength > 0)
                    {
                        hasFile = true;
                        long size = userPostedFile.ContentLength;
                        totalSize += size;
                        if (user.UsedQuota+size > user.MaxQuota)
                        {
                            outOfQuota = true;
                            break;
                        }
                        if (!(new ItemDAO()).CheckItem(user.Username, userPostedFile.FileName))
                        {
                            (new UserDAO()).UpdateUsedQuota(user.Username, user.UsedQuota + size);
                            (new ItemDAO()).AddItem(userPostedFile.FileName, user.Username,
                                isPublic, false, size, 0);
                            Item item = (new ItemDAO()).GetItem(user.Username, userPostedFile.FileName);
                            (new PermitDAO()).AddPermit(item.id, item.owner);
                        }
                        userPostedFile.SaveAs(filepath + Path.GetFileName(userPostedFile.FileName));
                    }
                }
                catch (Exception Ex)
                {
                }
            }
            if (!hasFile)
            {
                lblError.Text = "Please select some item(s)";
                return;
            }
            if (outOfQuota)
            {
                //lblError.Text = "Upload incomplete! Out of quota";
                lblError.Text = totalSize + " " + user.MaxQuota;
                return;
            }
            lblNoti.Text = "Upload succeeded";


            //if (FileUploadControl.HasFiles)
            //{
            //    try
            //    {
            //        FileUploadControl.
            //        string filename = Path.GetFileName(FileUploadControl.FileName);
            //        FileUploadControl.SaveAs(Server.MapPath("~/Storage/") + filename);
            //        lblError.Text = Server.MapPath("~/Storage/") + filename;
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //}
            //else
            //{
            //    lblError.Text = "Please choose file";
            //}
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
    }
}