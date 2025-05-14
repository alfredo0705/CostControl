using CostControl.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CostControl.Persistence.Configurations.Entities
{
    public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
    {
        public void Configure(EntityTypeBuilder<Budget> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.Month)
                .IsRequired();

            builder.Property(x => x.Year)
                .IsRequired();

            builder.HasOne(x => x.ExpenseType)
                .WithMany()
                .HasForeignKey(x => x.ExpenseTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Budgets");
        }
    }

}
