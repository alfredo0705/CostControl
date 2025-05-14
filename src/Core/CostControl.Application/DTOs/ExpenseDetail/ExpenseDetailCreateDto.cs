namespace CostControl.Application.DTOs.ExpenseDetail
{
    public class ExpenseDetailCreateDto : IExpenseDetailDto
    {
        public int ExpenseId { get; set; }
        public int ExpenseTypeId { get; set; }

        public decimal Amount { get; set; }
    }
}
