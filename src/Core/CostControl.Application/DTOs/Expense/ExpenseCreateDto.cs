using CostControl.Application.DTOs.ExpenseDetail;

namespace CostControl.Application.DTOs.Expense
{
    public class ExpenseCreateDto : IExpenseDto
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int MonetaryFundId { get; set; }
        public string StoreName { get; set; }
        public string DocumentType { get; set; }
        public string Notes { get; set; }
        public ICollection<ExpenseDetailCreateDto> Details { get; set; } = new List<ExpenseDetailCreateDto>();
    }
}
