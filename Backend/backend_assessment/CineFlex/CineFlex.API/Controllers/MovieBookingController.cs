using CineFlex.Application.Features.MoviesBooking.CQRS.Commands;
using CineFlex.Application.Features.MoviesBooking.CQRS.Queries;
using CineFlex.Application.Features.MoviesBooking.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers;

    [Route("api/[Controller]")]
    [ApiController]
    public class MovieBookingController : BaseApiController
    {
        private readonly IMediator _mediator;

        public MovieBookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<MovieBookingDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetMovieBookingListQuery()));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetMovieBookingDetailQuery { Id = id }));

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMovieBookingDto createMovieBookingDto)
        {
            var command = new CreateMovieBookingCommand { CreateMovieBookingDto = createMovieBookingDto };
            return HandleResult(await _mediator.Send(command));
        }

        // [Authorize]
        // [HttpPut]
        // public async Task<IActionResult> Put([FromBody] UpdateMovieBookingDto updateMovieBookingDto)
        // {
        //     var command = new UpdateMovieBookingCommand { UpdateMovieBookingDto = updateMovieBookingDto };
        //     return HandleResult(await _mediator.Send(command));
        // }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMovieBookingCommand { Id = id };
            return HandleResult(await _mediator.Send(command));
        }
    }

