namespace CostControl.Application.DTOs.MonetaryFund
{
    public class MonetaryFundCreateDto : IMonetaryFundDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        //public int AppUserId { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
