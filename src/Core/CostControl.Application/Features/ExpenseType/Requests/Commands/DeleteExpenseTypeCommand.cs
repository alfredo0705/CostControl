using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.ExpenseType.Requests.Commands
{
    public class DeleteExpenseTypeCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
