using CostControl.API.Extensions;
using CostControl.Application.DTOs.Deposit;
using CostControl.Application.Features.Deposit.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CostControl.API.Controllers
{
    [Authorize]
    public class DepositsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public DepositsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("addDeposit")]
        public async Task<ActionResult> AddDeposit(DepositCreateDto depositCreateDto)
        {
            depositCreateDto.UserId = User.GetUserId();
            var result = await _mediator.Send(new AddDepositCommand { DepositCreateDto = depositCreateDto });
            if (result.Success)
                return NoContent();

            return BadRequest(new { message = result.Message });
        }
    }
}
