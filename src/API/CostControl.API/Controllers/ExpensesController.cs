using CostControl.API.Extensions;
using CostControl.Application.DTOs.Expense;
using CostControl.Application.DTOs.Movement;
using CostControl.Application.Features.Expense.Requests.Commands;
using CostControl.Application.Features.Expense.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CostControl.API.Controllers
{
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

            return BadRequest(resul.Message);
        }

        [HttpGet("movements")]
        public async Task<ActionResult> GetMovements([FromQuery] MovementFilterDto filter)
        {
            return Ok(await _mediator.Send(new GetUserMovementsRequest { MovementFilterDto = filter, UserId = User.GetUserId() }));
        }

    }
}
