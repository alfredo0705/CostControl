using CostControl.Application.DTOs.ExpenseType;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.ExpenseType.Requests.Commands
{
    public class AddExpenseTypeCommand : IRequest<BaseCommandResponse>
    {
        public ExpenseTypeCreateDto ExpenseTypeCreateDto { get; set; }
    }
}
