using CostControl.Application.DTOs.ExpenseType;
using MediatR;

namespace CostControl.Application.Features.ExpenseType.Requests.Queries
{
    public class ExpenseTypeListRequest : IRequest<List<ExpenseTypeDto>>
    {
    }
}
