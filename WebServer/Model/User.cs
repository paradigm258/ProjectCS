using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServer.Model
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public long UsedQuota { get; set; }
        public long MaxQuota { get; set; }
        public override string ToString()
        {
            return Username;
        }
    }
}