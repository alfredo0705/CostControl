using CostControl.Application.DTOs.ExpenseType;
using MediatR;

namespace CostControl.Application.Features.ExpenseType.Requests.Queries
{
    public class ExpenseTypeRequest : IRequest<ExpenseTypeDto>
    {
        public int Id { get; set; }
    }
}
