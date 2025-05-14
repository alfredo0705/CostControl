using CostControl.Application.DTOs.MonetaryFund;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.MonetaryFund.Requests.Commands
{
    public class AddMonetaryFundCommand : IRequest<BaseCommandResponse>
    {
        public MonetaryFundCreateDto MonetaryFundCreateDto { get; set; }
    }
}
