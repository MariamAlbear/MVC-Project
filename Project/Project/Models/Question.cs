using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    class Question
    {
        public int id { get; set; }
        public string question { get; set; }

        [ForeignKey("Mother")]
        public virtual int Mother_ID { get; set; }
        public virtual Mother Mother { get; set; }

        public virtual List<Answer> Answers { get; set; }

    }
}