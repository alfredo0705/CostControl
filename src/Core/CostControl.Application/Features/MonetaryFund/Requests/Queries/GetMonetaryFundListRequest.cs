using CostControl.Application.DTOs.MonetaryFund;
using MediatR;

namespace CostControl.Application.Features.MonetaryFund.Requests.Queries
{
    public class GetMonetaryFundListRequest : IRequest<List<MonetaryFundDto>>
    {
    }
}
