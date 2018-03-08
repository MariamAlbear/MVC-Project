using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    class Product
    {
        public int id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        public virtual List<ShopProducts> ShopProducts { get; set; }

        [ForeignKey("ProductType")]
        public virtual int ProjectType_ID { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}