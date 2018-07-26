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
            context.Response.Write(username);
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