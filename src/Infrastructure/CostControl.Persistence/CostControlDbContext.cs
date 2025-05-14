using CostControl.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CostControl.Persistence
{
    public class CostControlDbContext : AuditableDbContext
    {
        public CostControlDbContext(DbContextOptions<CostControlDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Llamar las configuraciones de cada entidad
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CostControlDbContext).Assembly);
        }

        public DbSet<MonetaryFund> MonetaryFunds { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseDetail> ExpenseDetails { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
    }
}
