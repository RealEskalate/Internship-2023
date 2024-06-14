using CineFlex.Application.Features.Cinema.CQRS.Commands;
using CineFlex.Application.Features.Cinema.CQRS.Queries;
using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
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

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CinemaDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetAllSeatsQuery()));
        }

        
        [HttpPost("CreateSeat")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Post([FromBody] CreateSeatDto createSeatDto)
        {
            var command = new CreateSeatCommand { SeatDto = createSeatDto };
            return HandleResult(await _mediator.Send(command));
        }
        
        
        [HttpPut("UpdateSeat")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put([FromBody] UpdateSeatDto updateSeatDto)
        {
            var command = new UpdateSeatCommand { updateSeatDto = updateSeatDto };
            await _mediator.Send(command);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteSeatCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
