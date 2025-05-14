using CostControl.API.Extensions;
using CostControl.Application.DTOs.Budget;
using CostControl.Application.DTOs.BudgetVsExecute;
using CostControl.Application.Features.Budget.Requests.Commands;
using CostControl.Application.Features.Budget.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CostControl.API.Controllers
{
    public class BudgetsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public BudgetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getBudgets")]
        public async Task<ActionResult<List<BudgetDto>>> GetBudgets(int year, int month)
        {
            return Ok(await _mediator.Send(new GetBudgetListRequest { UserId = User.GetUserId(), Year = year, Month = month }));
        }

        [HttpGet("getBudget")]
        public async Task<ActionResult<BudgetDto>> GetBudget(int id)
        {
            return Ok(await _mediator.Send(new GetBudgetRequest { Id = id }));
        }

        [HttpPost("addBudget")]
        public async Task<ActionResult> AddBudget(BudgetCreateDto budgetCreateDto)
        {
            var result = await _mediator.Send(new AddBudgetCommand { BudgetCreateDto = budgetCreateDto });
            if (result.Success)
                return NoContent();

            return BadRequest(result.Message);
        }

        [HttpPut("updateBudget")]
        public async Task<ActionResult> UpdateBudget(BudgetUpdateDto budgetUpdateDto)
        {
            var result = await _mediator.Send(new UpdateBudgetCommand { BudgetUpdateDto = budgetUpdateDto });
            if (result.Success)
                return NoContent();

            return BadRequest(result.Message);
        }

        [HttpDelete("deleteBudget")]
        public async Task<ActionResult> DeleteBudget(int id)
        {
            var result = await _mediator.Send(new DeleteBudgetCommand { Id = id });
            if (result.Success)
                return NoContent();

            return BadRequest(result.Message);
        }

        [HttpPost("budget-vs-executed")]
        public async Task<IActionResult> GetBudgetVsExecuted([FromBody] BudgetExecutionFilterDto filter)
        {
            var userId = User.GetUserId();
            return Ok(await _mediator.Send(new GetBudgetVsExecutedRequest { UserId = userId, BudgetExecutionFilterDto = filter }));
        }
    }
}
