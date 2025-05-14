using CostControl.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CostControl.Persistence.Configurations.Entities
{
    public class MonetaryFundConfiguration : IEntityTypeConfiguration<MonetaryFund>
    {
        public void Configure(EntityTypeBuilder<MonetaryFund> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name, name =>
            {
                name.Property(n => n.Value)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(100);
            });

            builder.Property(x => x.Type)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.CurrentBalance)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.ToTable("MonetaryFunds");
        }
    }
}
