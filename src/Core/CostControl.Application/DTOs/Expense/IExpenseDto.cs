namespace CostControl.Application.DTOs.Expense
{
    public interface IExpenseDto
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int MonetaryFundId { get; set; }
        public string StoreName { get; set; }
        public string DocumentType { get; set; }
        public string Notes { get; set; }
    }
}
