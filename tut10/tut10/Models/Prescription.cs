using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tut10.Models
{
    public class Prescription
    {
        [Key]
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueTime { get; set; }


        [ForeignKey("Doctor")]
        public int IdDoctor { get; set; }
        public virtual Doctor IdDoctorNavigation { get; set; }

        [ForeignKey("Patient")]
        public int IdPatient { get; set; }
        public virtual Patient IdPatientNavigation { get; set; }
    }
}
