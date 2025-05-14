namespace CostControl.Application.DTOs.ExpenseType
{
    public class ExpenseTypeCreateDto : IExpenseTypeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
