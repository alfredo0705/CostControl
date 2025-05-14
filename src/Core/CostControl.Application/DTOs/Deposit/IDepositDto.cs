namespace CostControl.Application.DTOs.Deposit
{
    public interface IDepositDto
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int MonetaryFundId { get; set; }
        public decimal Amount { get; set; }
    }
}
