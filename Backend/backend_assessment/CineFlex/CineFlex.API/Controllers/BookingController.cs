using CineFlex.Application.Features.Bookings.CQRS.Commands;
using CineFlex.Application.Features.Bookings.CQRS.Queries;
using CineFlex.Application.Features.Bookings.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CineFlex.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BookingController : BaseApiController
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookingDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetBookingListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetBookingDetailQuery { Id = id }));

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookingDto createBooking)
        {
            var command = new CreateBookingCommand { BookingDto = createBooking };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateBookingDto BookingDto)
        {

            var command = new UpdateBookingCommand { BookingDto = BookingDto };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBookingCommand { Id = id };
            return HandleResult(await _mediator.Send(command));
        }
    }
}
