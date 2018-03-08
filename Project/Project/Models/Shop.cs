using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    class Shop
    {
        public int id { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [ForeignKey("SalesPerson")]
        public virtual int SalesPerson_ID { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }

        [ForeignKey("Category")]
        public virtual int Category_ID { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<ShopProducts> ShopProducts { get; set; }
    }
}