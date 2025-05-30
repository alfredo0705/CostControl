namespace CostControl.Application.DTOs.Budget
{
    public class BudgetDto : IBudgetDto
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int ExpenseTypeId { get; set; }
        public DateTime Period { get; set; }
        public decimal Amount { get; set; }
    }
}
