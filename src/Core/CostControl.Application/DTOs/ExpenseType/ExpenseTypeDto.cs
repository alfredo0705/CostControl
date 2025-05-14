namespace CostControl.Application.DTOs.ExpenseType
{
    public class ExpenseTypeDto : IExpenseTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}
