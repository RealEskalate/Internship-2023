using CineFlex.Application.Features.Book.CQRS.Commands;
using CineFlex.Application.Features.Book.CQRS.Queries;
using CineFlex.Application.Features.Book.DTOs;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BookingController: BaseApiController
    {
        
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> Get()
        {
            return Ok(await _mediator.Send(new ()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetBookDetailQuery {  }));

        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post(CreateBookCommand seat)
        {
            var response = await _mediator.Send(seat);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Put(UpdateBookCommand seat)
        {
            await _mediator.Send(seat);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand { };
            await _mediator.Send(command);
            return NoContent();
        }
    }
 }
