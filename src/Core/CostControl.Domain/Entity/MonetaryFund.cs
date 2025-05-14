using CostControl.Domain.Common;
using CostControl.Domain.ValueObjects.Common;

namespace CostControl.Domain.Entity
{
    public class MonetaryFund : BaseEntity
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public string Type { get; set; }
        public int AppUserId { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
