using CostControl.Domain.Common;
using CostControl.Domain.ValueObjects.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostControl.Domain.Entity
{
    public class MonetaryFund : BaseEntity
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public string Type { get; set; }
        public decimal InitialBalance { get; set; }

        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Deposit> Deposits { get; set; }

        [NotMapped]
        public decimal CurrentBalance
        {
            get
            {
                var totalDeposits = Deposits?.Sum(d => d.Amount) ?? 0;
                var totalExpenses = Expenses?.Sum(expense =>
                    expense.Details?.Sum(detail => detail.Amount) ?? 0) ?? 0;
                return InitialBalance + totalDeposits - totalExpenses;
            }
        }
    }
}
