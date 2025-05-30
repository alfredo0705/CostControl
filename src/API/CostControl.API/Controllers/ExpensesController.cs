using CostControl.API.Extensions;
using CostControl.Application.DTOs.Expense;
using CostControl.Application.DTOs.Movement;
using CostControl.Application.Features.Expense.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CostControl.API.Controllers
{
    [Authorize]
    public class ExpensesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("addExpense")]
        public async Task<ActionResult> AddExpense(ExpenseCreateDto expenseCreateDto)
        {
            expenseCreateDto.UserId = User.GetUserId();
            var resul = await _mediator.Send(new AddExpenseCommand { ExpenseCreateDto = expenseCreateDto });
            if (resul.Success)
                return NoContent();

            return BadRequest(new {message = resul.Message});
        }
    }
}
