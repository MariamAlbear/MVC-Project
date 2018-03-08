using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    class ProductType
    {
        public int id { get; set; }
        public string Type { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}