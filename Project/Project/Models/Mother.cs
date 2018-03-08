using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    class Mother
    {
        public int id { get; set; }
        public string Name { get; set; }

        public virtual List<Question> Questions { get; set; }
    }
}