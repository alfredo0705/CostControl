using CostControl.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CostControl.Persistence.Configurations.Entities
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.MonetaryFund)
                   .WithMany()
                   .HasForeignKey(x => x.MonetaryFundId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Details)
                   .WithOne(x => x.Expense)
                   .HasForeignKey(x => x.ExpenseId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.StoreName)
                   .HasMaxLength(100);

            builder.Property(x => x.DocumentType)
                   .HasMaxLength(50);

            builder.Property(x => x.Notes)
                   .HasMaxLength(500);

            builder.Property(x => x.Date)
                   .IsRequired();

            builder.ToTable("Expenses");
        }
    }

}
