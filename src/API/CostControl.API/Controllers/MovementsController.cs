using CostControl.API.Extensions;
using CostControl.Application.DTOs.BudgetVsExecute;
using CostControl.Application.DTOs.Movement;
using CostControl.Application.Features.Movement.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CostControl.API.Controllers
{
    [Authorize]
    public class MovementsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public MovementsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("budget-vs-executed")]
        public async Task<IActionResult> GetBudgetVsExecuted([FromBody] BudgetExecutionFilterDto filter)
        {
            var userId = User.GetUserId();
            return Ok(await _mediator.Send(new GetBudgetVsExecutedRequest { UserId = userId, BudgetExecutionFilterDto = filter }));
        }

        [HttpPost("get-movements")]
        public async Task<IActionResult> GetMovements([FromBody] MovementFilterDto filter)
        {
            var userId = User.GetUserId();
            return Ok(await _mediator.Send(new GetMovementsRequest { UserId = userId, BudgetExecutionFilterDto = filter }));
        }
    }
}
