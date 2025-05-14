using CostControl.Domain.Common;

namespace CostControl.Domain.Entity
{
    public class ExpenseDetail : BaseEntity
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public Expense Expense { get; set; }

        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }

        public decimal Amount { get; set; }
    }
}