using System.Threading.Tasks;

using CineFlex.Application.Features.Booking.CQRS.Command;
using CineFlex.Application.Features.Booking.DTOs;
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
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<ActionResult> Post([FromBody] CreateBookingDto createBookingDto)
        {
            
            var command = new CreateBookingCommand { createBookingDto = createBookingDto };
            return HandleResult(await _mediator.Send(command));
        }
}
}