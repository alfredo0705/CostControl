using CostControl.Application.DTOs.Budget;
using MediatR;

namespace CostControl.Application.Features.Budget.Requests.Queries
{
    public class GetBudgetRequest : IRequest<BudgetDto>
    {
        public int Id { get; set; }
    }
}
