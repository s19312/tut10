using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut10.Models;

namespace tut10.Configuration
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {

            builder.HasKey(e => e.IdPrescription)
                        .HasName("Prescription_pk");

            builder.Property(e => e.Date).HasColumnType("date");

            builder.Property(e => e.DueDate).HasColumnType("date");

            builder.HasOne(d => d.IdDoctorNavigation)
                        .WithMany(p => p.Prescription)
                        .HasForeignKey(d => d.IdDoctor)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Prescription_Doctor");

            builder.HasOne(d => d.IdPatientNavigation)
                        .WithMany(p => p.Prescription)
                        .HasForeignKey(d => d.IdPatient)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Prescription_Patient");
        }
    }
}
