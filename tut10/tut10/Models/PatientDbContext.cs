using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut10.Configuration;

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
        public DbSet<PrescriptionMedicament> Prescription_Medicament { get; set; }
        public DbSet<Prescription> Prescription { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new MedicamentConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionMedicamentConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
