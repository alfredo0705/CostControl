using CostControl.Application.DTOs.Budget;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.Budget.Requests.Commands
{
    public class AddBudgetCommand : IRequest<BaseCommandResponse>
    {
        public List<BudgetCreateDto> BudgetCreateDto { get; set; }
        public int UserId { get; set; }
    }
}
