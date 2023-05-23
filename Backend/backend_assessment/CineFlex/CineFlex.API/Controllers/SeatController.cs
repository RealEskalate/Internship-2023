
using CineFlex.Application.Features.Common;
using CineFlex.Application.Features.Seat.CQRS.Commands;
using CineFlex.Application.Features.Seat.CQRS.Queries;
using CineFlex.Application.Features.Seat.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SeatController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SeatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<SeatDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetSeatListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetSeatDetailQuery { Id = id }));

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSeatDto createSeatDto)
        {
            var command = new CreateSeatCommand { createSeatDto = createSeatDto };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateSeatDto updateSeatDto)
        {
            var command = new UpdateSeatCommand { updateSeatDto = updateSeatDto };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] BaseDto baseDto)
        {
            var command = new DeleteSeatCommand {  baseDto = baseDto };
            return HandleResult(await _mediator.Send(command));
        }
    }
}
