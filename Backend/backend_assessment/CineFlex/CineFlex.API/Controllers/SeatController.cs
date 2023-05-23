using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTO;
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

        

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetSeatRequest { Id = id }));

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSeatDto createSeatDto)
        {
            var command = new CreateSeatCommand { CreateSeatDto = createSeatDto };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateSeatDto updateSeatDto)
        {


            var command = new UpdateSeatCommand { UpdateSeatDto = updateSeatDto };
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
