using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServer.Model
{
    public class File
    {
        public int id { get; set; }
        public String name { get; set; }
        public long size { get; set; }
        public string ownerId { get; set; }
        public string privacy { get; set; }
    }
}