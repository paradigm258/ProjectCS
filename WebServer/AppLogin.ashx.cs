using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServer
{
    /// <summary>
    /// Summary description for AppLogin
    /// </summary>
    public class AppLogin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string username = context.Request.Form["username"];
            string password = context.Request.Form["password"];
            Interface.IUserDAO dAO = new Dao.UserDAO();
            System.Diagnostics.Debug.WriteLine(username + "" + password);
            context.Response.Write(dAO.CheckUser(username, password).ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}