namespace CostControl.Application.DTOs.Budget
{
    public interface IBudgetDto
    {
        public int AppUserId { get; set; }
        public int ExpenseTypeId { get; set; }
        public DateTime Period { get; set; }
        public decimal Amount { get; set; }
    }
}
