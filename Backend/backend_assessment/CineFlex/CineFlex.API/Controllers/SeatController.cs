using CineFlex.Application.Features.Movies.CQRS.Commands;
using CineFlex.Application.Features.Movies.CQRS.Queries;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CineFlex.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SeatController: BaseApiController
    {
        private readonly IMediator _mediator;

        public SeatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<SeatDto>>> Get()
        {
            return Ok(await _mediator.Send(new GetSeatListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetSeatDetailQuery { Id = id }));

        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post(CreateSeatCommand seat)
        {
            var response = await _mediator.Send(seat);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Put(UpdateSeatCommand seat)
        {
            await _mediator.Send(seat);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteSeatCommand { SeatId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
