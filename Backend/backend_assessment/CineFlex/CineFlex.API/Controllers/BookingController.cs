using CineFlex.Application.Features.Bookings.CQRS.Commands;
using CineFlex.Application.Features.Bookings.CQRS.Queries;
using CineFlex.Application.Features.Bookings.DTO;
using CineFlex.Application.Features.Bookings.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{
    public class BookingController : BaseApiController
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<BookingDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetBookingListQuery()));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDto>> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetBookingQuery { Id = id }));
        }

        [Authorize]
        [HttpPost("CreateBooking")]
        public async Task<ActionResult> Post([FromBody] CreateBookingDto createBookingDto)
        {
            var command = new CreateBookingCommand { BookingDto = createBookingDto };
            return HandleResult(await _mediator.Send(command));
        }

        [Authorize]
        [HttpPut("UpdateBooking")]
        public async Task<ActionResult> Put([FromBody] UpdateBookingDto updateBookingDto)
        {
            var command = new UpdateBookingCommand { UpdateBookingDto = updateBookingDto };
            return HandleResult(await _mediator.Send(command));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteBookingCommand { Id = id };
            return HandleResult(await _mediator.Send(command));
        }

    }
}

