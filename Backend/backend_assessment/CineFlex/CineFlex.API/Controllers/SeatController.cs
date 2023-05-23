using CineFlex.Application.Features.Seat.CQRS.Commands;
using CineFlex.Application.Features.Seat.CQRS.Queries;
using CineFlex.Application.Features.Seat.DTO;
using CineFlex.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineFlex.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SeatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<SeatDto>>> GetAll()
        {
            var query = new GetSeatListQuery();
            var response = await _mediator.Send(query);
            return HandleResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetSeatQuery { Id = id };
            var response = await _mediator.Send(query);
            return HandleResult(response);
        }

        [HttpPost("CreateSeat")]
        public async Task<IActionResult> Create([FromBody] CreateSeatDto createSeatDto)
        {
            var command = new CreateSeatCommand { SeatDto = createSeatDto };
            var response = await _mediator.Send(command);
            return HandleResult(response);
        }

        [HttpPut("UpdateSeat")]
        public async Task<IActionResult> Update([FromBody] UpdateSeatDto updateSeatDto)
        {
            var command = new UpdateSeatCommand { updateSeatDto = updateSeatDto };
            var response = await _mediator.Send(command);
            return HandleResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteSeatCommand { Id = id };
            var response = await _mediator.Send(command);
            return HandleResult(response);
        }
    }
}
