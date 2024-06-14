using CineFlex.Application.Features.Authentication.CQRS.Commands;
using CineFlex.Application.Features.Authentication.DTOs;
using CineFlex.Application.Features.Booking.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : BaseApiController
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("book")]
        [Authorize]
        public async Task<IActionResult> Book([FromBody] CreateBookingCommand bookCommand)
        {
            bookCommand.createBookingDto.UserId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
            var response = await _mediator.Send(bookCommand);
            return Ok(response);
        }



    }
}
