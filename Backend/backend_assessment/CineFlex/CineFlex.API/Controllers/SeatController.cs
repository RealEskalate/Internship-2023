using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        public async Task<IActionResult> Post([FromBody] CreateSeatDto createSeat)
        {
            var command = new CreateSeatCommand { SeatDto = createSeat };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateSeatDto seatDto)
        {


            var command = new UpdateSeatCommand { SeatDto = seatDto };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteSeatCommand { Id = id };
            return HandleResult(await _mediator.Send(command));
        }
    }
}
