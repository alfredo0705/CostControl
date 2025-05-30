using CostControl.Domain.Common;

namespace CostControl.Domain.Entity
{
    public class Budget : BaseEntity
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public DateTime Period { get; set; }
        public decimal Amount { get; set; }
    }
}
