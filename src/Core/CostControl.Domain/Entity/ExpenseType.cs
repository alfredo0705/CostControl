using CostControl.Domain.Common;
using CostControl.Domain.ValueObjects.Common;

namespace CostControl.Domain.Entity
{
    public class ExpenseType : BaseEntity
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public Description Description { get; set; }
        public string Code { get; set; }
    }
}
