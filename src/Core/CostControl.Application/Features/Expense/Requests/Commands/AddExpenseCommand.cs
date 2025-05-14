using CostControl.Application.DTOs.Expense;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.Expense.Requests.Commands
{
    public class AddExpenseCommand : IRequest<BaseCommandResponse>
    {
        public ExpenseCreateDto ExpenseCreateDto { get; set; }
    }
}
