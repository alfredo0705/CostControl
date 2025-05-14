using CostControl.Application.DTOs.MonetaryFund;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.MonetaryFund.Requests.Commands
{
    public class UpdateMonetaryFundCommand : IRequest<BaseCommandResponse>
    {
        public MonetaryFundUpdateDto MonetaryFundUpdateDto { get; set; }
    }
}
