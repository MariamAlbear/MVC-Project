using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
     class Category
    {
        public int id { get; set; }
        public string Type { get; set; }

        public virtual List<Shop> Shops { get; set; }
    }
}