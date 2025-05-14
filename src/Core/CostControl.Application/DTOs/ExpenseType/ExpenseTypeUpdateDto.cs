namespace CostControl.Application.DTOs.ExpenseType
{
    public class ExpenseTypeUpdateDto : IExpenseTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
