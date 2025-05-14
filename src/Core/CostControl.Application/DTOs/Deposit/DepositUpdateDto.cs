namespace CostControl.Application.DTOs.Deposit
{
    public class DepositUpdateDto : IDepositDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int MonetaryFundId { get; set; }
        public decimal Amount { get; set; }
    }
}
