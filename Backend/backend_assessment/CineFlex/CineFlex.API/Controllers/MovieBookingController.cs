using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Features.MovieBookings.CQRS.Commands;
using CineFlex.Application.Features.MovieBookings.CQRS.Queries;
using CineFlex.Application.Features.MovieBookings.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CineFlex.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MovieBookingController : BaseApiController
    {
        private readonly IMediator _mediator;

        private readonly IUserService _userServise;

        public MovieBookingController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userServise = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieBookingDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetMovieBookingListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetMovieBookingDetailQuery { Id = id }));

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMovieBookingDto createMovieBooking)
        {
            var command = new CreateMovieBookingCommand { MovieBookingDto = createMovieBooking };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateMovieBookingDto MovieBookingDto)
        {


            var command = new UpdateMovieBookingCommand { MovieBookingDto = MovieBookingDto };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMovieBookingCommand { Id = id };
            return HandleResult(await _mediator.Send(command));
        }
    }
}
