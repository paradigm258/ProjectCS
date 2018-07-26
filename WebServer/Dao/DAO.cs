using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebServer.Dao
{
    public class DAO
    {
        public static string ConnectionString = WebConfigurationManager.ConnectionStrings["CSProject"].ConnectionString;
    }
}