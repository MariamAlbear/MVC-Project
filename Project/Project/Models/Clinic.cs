using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    class Clinic
    {
        public int id { get; set; }
        public string ClinicName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [ForeignKey("Doctor")]
        public virtual int Doctor_ID { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}