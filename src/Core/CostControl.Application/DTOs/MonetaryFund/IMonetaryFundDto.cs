﻿namespace CostControl.Application.DTOs.MonetaryFund
{
    public interface IMonetaryFundDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal InitialBalance { get; set; }
    }
}
