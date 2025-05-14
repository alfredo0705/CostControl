using CostControl.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CostControl.Persistence.Configurations.Entities
{
    public class ExpenseDetailConfiguration : IEntityTypeConfiguration<ExpenseDetail>
    {
        public void Configure(EntityTypeBuilder<ExpenseDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Expense)
                   .WithMany(x => x.Details)
                   .HasForeignKey(x => x.ExpenseId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ExpenseType)
                   .WithMany()
                   .HasForeignKey(x => x.ExpenseTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Amount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.ToTable("ExpenseDetails");
        }
    }
}
