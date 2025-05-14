using CostControl.Application.DTOs.MonetaryFund;
using MediatR;

namespace CostControl.Application.Features.MonetaryFund.Requests.Queries
{
    public class GetMonetaryFundRequest : IRequest<MonetaryFundDto>
    {
        public int UserId { get; set; }
        public string MonetaryFoundName { get; set; }
    }
}
