using CineFlex.Application.Features.MovieBookings.CQRS.Commands;
using CineFlex.Application.Features.MovieBookings.CQRS.Queries;
using CineFlex.Application.Features.MovieBookings.DTO;
using CineFlex.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineFlex.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieBookingController : BaseApiController
    {
        private readonly IMediator _mediator;

        public MovieBookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<MovieBookingDto>>> GetAll()
        {
            var query = new GetMovieBookingListQuery();
            var response = await _mediator.Send(query);
            return HandleResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetMovieBookingQuery { Id = id };
            var response = await _mediator.Send(query);
            return HandleResult(response);
        }

        [HttpPost("CreateMovieBooking")]
        public async Task<IActionResult> Create([FromBody] CreateMovieBookingDto createMovieBookingDto)
        {
            var command = new CreateMovieBookingCommand { MovieBookingDto = createMovieBookingDto };
            var response = await _mediator.Send(command);
            return HandleResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMovieBookingCommand { Id = id };
            var response = await _mediator.Send(command);
            return HandleResult(response);
        }
    }
}
