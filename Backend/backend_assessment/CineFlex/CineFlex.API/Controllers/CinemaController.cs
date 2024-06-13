using CineFlex.Application.Features.Cinema.CQRS.Commands;
using CineFlex.Application.Features.Cinema.CQRS.Queries;
using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Features.Cinema.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CineFlex.API.Controllers
{
    public class CinemaController: BaseApiController
    {
        private readonly IMediator _mediator;

        public CinemaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CinemaDto>>> Get()
        {
            return Ok(await _mediator.Send(new GetCinemaListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CinemaDto>> Get(int id)
        {
             return Ok(await _mediator.Send(new GetCinemaQuery { Id = id }));
        }
        [HttpPost("CreateCinema")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post(CreateCinemaCommand cinima)
        {
            var response = await _mediator.Send(cinima);
            return CreatedAtAction(nameof(Get), new { id = response });
        }
        [HttpPut("UpdateCinema")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Put([FromBody] UpdateCinemaDto updateCinemaDto)
        {
            var command = new UpdateCinemaCommand { updateCinemaDto = updateCinemaDto };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCinemaCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}

