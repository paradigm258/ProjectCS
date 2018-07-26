using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServer.Model
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public long size { get; set; }
        public string owner { get; set; }
        public string privacy { get; set; }
    }
}