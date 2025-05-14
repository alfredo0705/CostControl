using CostControl.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CostControl.Persistence.Configurations.Entities
{
    public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
    {
        public void Configure(EntityTypeBuilder<Deposit> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.MonetaryFund)
                   .WithMany()
                   .HasForeignKey(x => x.MonetaryFundId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Amount)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Date)
                   .IsRequired();

            builder.ToTable("Deposits");
        }
    }
}
