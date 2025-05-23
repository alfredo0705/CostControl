using CostControl.Application.DTOs.MonetaryFund;
using MediatR;

namespace CostControl.Application.Features.MonetaryFund.Requests.Queries
{
    public class GetMonetaryFundRequest : IRequest<MonetaryFundDto>
    {
        public string MonetaryFoundName { get; set; }
    }
}
