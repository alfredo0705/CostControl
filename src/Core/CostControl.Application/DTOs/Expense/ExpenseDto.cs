namespace CostControl.Application.DTOs.Expense
{
    public class ExpenseDto : IExpenseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int MonetaryFundId { get; set; }
        public string StoreName { get; set; }
        public string DocumentType { get; set; }
        public string Notes { get; set; }
    }
}
