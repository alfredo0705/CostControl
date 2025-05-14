using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.MonetaryFund.Requests.Commands
{
    public class DeleteMonetaryFundCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
