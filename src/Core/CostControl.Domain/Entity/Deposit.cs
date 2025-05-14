using CostControl.Domain.Common;

namespace CostControl.Domain.Entity
{
    public class Deposit : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int MonetaryFundId { get; set; }
        public MonetaryFund MonetaryFund { get; set; }
        public decimal Amount { get; set; }
    }
}
