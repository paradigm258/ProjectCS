using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServer.Model
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public bool IsFolder { get; set; }
        public long Size { get; set; }
        public int Parent { get; set; }
    }
}