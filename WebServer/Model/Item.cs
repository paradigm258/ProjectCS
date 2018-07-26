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
        public int owner { get; set; }
        public bool isPublic { get; set; }
        public bool isFolder { get; set; }
        public long size { get; set; }
        public int parent { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}