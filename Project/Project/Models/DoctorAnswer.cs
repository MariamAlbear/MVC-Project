using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    class DoctorAnswer
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Answer")]
        public int AnswerID { get; set; }
        public virtual Answer Answer { get; set; }
    }
}