using CostControl.Application.DTOs.Budget;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.Budget.Requests.Commands
{
    public class UpdateBudgetCommand : IRequest<BaseCommandResponse>
    {
        public BudgetUpdateDto BudgetUpdateDto { get; set; }
    }
}
