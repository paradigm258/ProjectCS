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
            Interface.IUserDAO user = new Dao.UserDAO();
            GridView1.DataSource = user.GetAllUsers();
        }
    }
}