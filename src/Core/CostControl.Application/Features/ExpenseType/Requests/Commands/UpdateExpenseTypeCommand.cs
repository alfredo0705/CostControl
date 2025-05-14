using CostControl.Application.DTOs.ExpenseType;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.ExpenseType.Requests.Commands
{
    public class UpdateExpenseTypeCommand : IRequest<BaseCommandResponse>
    {
        public ExpenseTypeUpdateDto ExpenseTypeUpdateDto { get; set; }
    }
}
