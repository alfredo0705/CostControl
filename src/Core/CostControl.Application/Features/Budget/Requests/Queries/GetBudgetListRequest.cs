using CostControl.Application.DTOs.Budget;
using MediatR;

namespace CostControl.Application.Features.Budget.Requests.Queries
{
    public class GetBudgetListRequest : IRequest<List<BudgetDto>>
    {
        public int UserId { get; set; }
        public DateTime Period { get; set; }
    }
}
