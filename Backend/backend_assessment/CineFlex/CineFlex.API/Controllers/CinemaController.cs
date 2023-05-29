using CineFlex.Application.Features.Cinema.CQRS.Commands;
using CineFlex.Application.Features.Cinema.CQRS.Queries;
using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Features.Cinema.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{
    public class CinemaController: BaseApiController
    {
        private readonly IMediator _mediator;

        public CinemaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CinemaDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetCinemaListQuery()));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<CinemaDto>> Get(int id)
        {
             return HandleResult(await _mediator.Send(new GetCinemaQuery { Id = id }));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CreateCinema")]
        public async Task<ActionResult> Post([FromBody] CreateCinemaDto createCinemaDto)
        {
            var command = new CreateCinemaCommand { CinemaDto = createCinemaDto };
            return HandleResult(await _mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateCinema")]
        public async Task<ActionResult> Put([FromBody] UpdateCinemaDto updateCinemaDto)
        {
            var command = new UpdateCinemaCommand { updateCinemaDto = updateCinemaDto };
            await _mediator.Send(command);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCinemaCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}

