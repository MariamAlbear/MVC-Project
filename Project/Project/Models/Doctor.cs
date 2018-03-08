using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    class Doctor
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }

        public virtual List<Clinic> Clinics { get; set; }
        public virtual List<DoctorAnswer> DoctorAnswer { get; set; }
    }
}