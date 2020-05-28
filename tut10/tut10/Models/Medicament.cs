﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tut10.Models
{
    public partial class Medicament
    {
        public Medicament()
        {
            PrescriptionMedicament = new HashSet<PrescriptionMedicament>();
        }
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicament { get; set; }
    }
}
