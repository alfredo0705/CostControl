namespace CostControl.Application.DTOs.MonetaryFund
{
    public class MonetaryFundDto : IMonetaryFundDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        //public int AppUserId { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
