using CineFlex.Application.Features.Bookings.CQRS.Commands;
using CineFlex.Application.Features.Bookings.CQRS.Queries;
using CineFlex.Application.Features.Bookings.DTO;
using CineFlex.Application.Features.Bookings.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{

      [Authorize]
    public class BookingController: BaseApiController
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<BookingDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetBookingListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDto>> Get(int id)
        {
             return HandleResult(await _mediator.Send(new GetBookingQuery { Id = id }));
        }
        [HttpPost("CreateBooking")]
        public async Task<ActionResult> Post([FromBody] CreateBookingDTO createBookingDto)
        {
            var command = new CreateBookingCommand { BookingDto = createBookingDto };
            return HandleResult(await _mediator.Send(command));
        }
        
}
}

