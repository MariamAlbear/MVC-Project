using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    class Answer
    {
        public int id { get; set; }
        public string answer { get; set; }

        [ForeignKey("Question")]
        public virtual int Question_ID { get; set; }
        public virtual Question Question { get; set; }

        public virtual List<DoctorAnswer> DoctorAnswer { get; set; }
    }
}