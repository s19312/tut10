using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tut10.Models;

namespace tut10.Configuration
{
    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {

            builder.HasKey(e => e.IdMedicament)
                    .HasName("Medicament_pk");

            builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);
        }
    }
}
