using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{
    public class SeatController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SeatController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<SeatDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetSeatListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeatDto>> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetSeatQuery { Id = id }));
        }
        [HttpPost("CreateSeat")]
        public async Task<ActionResult> Post([FromBody] CreateSeatDto createSeatDto)
        {
            var command = new CreateSeatCommand { SeatDto = createSeatDto };
            return HandleResult(await _mediator.Send(command));
        }
        [HttpPut("UpdateSeat")]
        public async Task<ActionResult> Put([FromBody] UpdateSeatDto updateSeatDto)
        {
            var command = new UpdateSeatCommand { updateSeatDto = updateSeatDto };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteSeatCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}

