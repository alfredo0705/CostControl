using CostControl.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CostControl.Persistence.Configurations.Entities
{
    public class ExpenseTypeConfiguration : IEntityTypeConfiguration<ExpenseType>
    {
        public void Configure(EntityTypeBuilder<ExpenseType> builder)
        {
            builder.HasKey(x => x.Id);

            // Value Object: Name
            builder.OwnsOne(x => x.Name, name =>
            {
                name.Property(n => n.Value)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(100);
            });

            // Value Object: Description
            builder.OwnsOne(x => x.Description, desc =>
            {
                desc.Property(d => d.Value)
                    .HasColumnName("Description")
                    .HasMaxLength(300);
            });

            // Código generado automáticamente (puedes hacerlo en un servicio o trigger, pero aquí solo mapeamos)
            builder.Property(x => x.Code)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.HasIndex(x => x.Code)
                   .IsUnique();

            builder.ToTable("ExpenseTypes");
        }
    }
}
