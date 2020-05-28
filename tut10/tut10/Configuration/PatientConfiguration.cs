using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut10.Models;

namespace tut10.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.IdPatient)
                    .HasName("Patient_pk");

            builder.Property(e => e.Birthdate).HasColumnType("date");

            builder.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
        }
    }
}
