namespace CostControl.Application.DTOs.ExpenseDetail
{
    public interface IExpenseDetailDto
    {
        public int ExpenseId { get; set; }
        public int ExpenseTypeId { get; set; }

        public decimal Amount { get; set; }
    }
}
