using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tut10.Models
{
    public partial class PatientDbContext : DbContext
    {
        public PatientDbContext()
        {
        }

        public PatientDbContext(DbContextOptions<PatientDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medicament> Medicament { get; set; }

        public DbSet<Prescription> Prescription { get; set; }
    }
}
