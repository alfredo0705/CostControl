using CostControl.Domain.Common;

namespace CostControl.Domain.Entity
{
    public class Expense : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public DateTime Date { get; set; }
        public int MonetaryFundId { get; set; }
        public MonetaryFund MonetaryFund { get; set; }

        public string StoreName { get; set; }
        public string DocumentType { get; set; }  // e.g., Invoice, Receipt, Other
        public string Notes { get; set; }

        public ICollection<ExpenseDetail> Details { get; set; } = new List<ExpenseDetail>();
    }
}
