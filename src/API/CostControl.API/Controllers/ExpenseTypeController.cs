using CostControl.Application.DTOs.ExpenseType;
using CostControl.Application.Features.ExpenseType.Requests.Commands;
using CostControl.Application.Features.ExpenseType.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CostControl.API.Controllers
{
    [Authorize]
    public class ExpenseTypeController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ExpenseTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getExpenseTypes")]
        public async Task<ActionResult<List<ExpenseTypeDto>>> GetExpenseTypes()
        {
            return Ok(await _mediator.Send(new ExpenseTypeListRequest()));
        }

        [HttpGet("getExpenseType")]
        public async Task<ActionResult<ExpenseTypeDto>> GetExpenseType(int id)
        {
            return Ok(await _mediator.Send(new ExpenseTypeRequest { Id = id }));
        }

        [HttpPost("addExpenseType")]
        public async Task<ActionResult> AddExpenseType(ExpenseTypeCreateDto expenseTypeCreateDto)
        {
            var result = await _mediator.Send(new AddExpenseTypeCommand { ExpenseTypeCreateDto = expenseTypeCreateDto });
            if (result.Success)
                return NoContent();

            return BadRequest(new { message = result.Message });
        }

        [HttpPut("updateExpenseType")]
        public async Task<ActionResult> UpdateExpenseType(ExpenseTypeUpdateDto expenseTypeUpdateDto)
        {
            var result = await _mediator.Send(new UpdateExpenseTypeCommand { ExpenseTypeUpdateDto = expenseTypeUpdateDto });

            if (result.Success)
                return NoContent();

            return BadRequest(new { message = result.Message });
        }

        [HttpDelete("deleteExpenseType")]
        public async Task<ActionResult> DeleteExpenseType(int id)
        {
            var result = await _mediator.Send(new DeleteExpenseTypeCommand { Id = id });

            if (result.Success)
                return NoContent();

            return BadRequest(new { message = result.Message });
        }
    }
}
