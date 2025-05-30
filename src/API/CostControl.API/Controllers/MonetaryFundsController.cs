using CostControl.API.Extensions;
using CostControl.Application.DTOs.MonetaryFund;
using CostControl.Application.Features.MonetaryFund.Requests.Commands;
using CostControl.Application.Features.MonetaryFund.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CostControl.API.Controllers
{
    [Authorize]
    public class MonetaryFundsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public MonetaryFundsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getMonetaryFunds")]
        public async Task<ActionResult<List<MonetaryFundDto>>> GetMonetaryFunds()
        {
            return Ok(await _mediator.Send(new GetMonetaryFundListRequest()));
        }

        [HttpGet("getMonetaryFund")]
        public async Task<ActionResult<MonetaryFundDto>> GetMonetaryFund(string monetaryFoundName)
        {
            return Ok(await _mediator.Send(new GetMonetaryFundRequest { MonetaryFoundName = monetaryFoundName }));
        }
        
        [HttpGet("getMonetaryFundById")]
        public async Task<ActionResult<MonetaryFundDto>> GetMonetaryFundById(int id)
        {
            return Ok(await _mediator.Send(new GetMonetaryFundByIdRequest { Id = id }));
        }

        [HttpPost("addMonetaryFund")]
        public async Task<ActionResult> AddMonetaryFund(MonetaryFundCreateDto monetaryFundCreateDto)
        {
            var result = await _mediator.Send(new AddMonetaryFundCommand { MonetaryFundCreateDto = monetaryFundCreateDto });

            if (result.Success)
                return NoContent();

            return BadRequest(new { message = result.Message });
        }

        [HttpPut("updateMonetaryFund")]
        public async Task<ActionResult> UpdateMonetaryFund(MonetaryFundUpdateDto monetaryFundUpdateDto)
        {
            var result = await _mediator.Send(new UpdateMonetaryFundCommand { MonetaryFundUpdateDto = monetaryFundUpdateDto });
            if (result.Success)
                return NoContent();

            return BadRequest(new { message = result.Message });
        }

        [HttpDelete("deleteMonetaryFund")]
        public async Task<ActionResult> DeleteMonetaryFund(int id)
        {
            var result = await _mediator.Send(new DeleteMonetaryFundCommand { Id = id });
            if (result.Success)
                return NoContent();

            return BadRequest(new { message = result.Message });
        }
    }
}
