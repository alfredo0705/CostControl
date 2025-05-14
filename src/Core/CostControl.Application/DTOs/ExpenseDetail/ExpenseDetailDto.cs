namespace CostControl.Application.DTOs.ExpenseDetail
{
    public class ExpenseDetailDto : IExpenseDetailDto
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public int ExpenseTypeId { get; set; }

        public decimal Amount { get; set; }
    }
}
