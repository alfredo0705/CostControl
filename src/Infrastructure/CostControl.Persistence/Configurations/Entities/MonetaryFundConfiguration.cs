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

            builder.HasMany(x => x.Expenses)
                   .WithOne(x => x.MonetaryFund)
                   .HasForeignKey(x => x.MonetaryFundId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Deposits)
                   .WithOne(x => x.MonetaryFund)
                   .HasForeignKey(x => x.MonetaryFundId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("MonetaryFunds");
        }
    }
}
