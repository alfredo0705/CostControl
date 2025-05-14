using CostControl.Application.DTOs.Deposit;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.Deposit.Requests.Commands
{
    public class AddDepositCommand : IRequest<BaseCommandResponse>
    {
        public DepositCreateDto DepositCreateDto { get; set; }
    }
}
