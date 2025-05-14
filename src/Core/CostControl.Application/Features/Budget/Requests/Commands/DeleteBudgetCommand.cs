using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.Budget.Requests.Commands
{
    public class DeleteBudgetCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
