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
            context.Response.Write("True");
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