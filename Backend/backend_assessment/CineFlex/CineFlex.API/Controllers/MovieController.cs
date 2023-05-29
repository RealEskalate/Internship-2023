using CineFlex.Application.Features.Movies.CQRS.Commands;
using CineFlex.Application.Features.Movies.CQRS.Queries;
using CineFlex.Application.Features.Movies.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MovieController : BaseApiController
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<MovieDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetMovieListQuery()));
        }
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetMovieDetailQuery { Id = id }));

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMovieDto createMovie)
        {
            var command = new CreateMovieCommand { MovieDto = createMovie };
            return HandleResult(await _mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateMovieDto movieDto)
        {


            var command = new UpdateMovieCommand { MovieDto = movieDto };
            return HandleResult(await _mediator.Send(command));
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMovieCommand { Id = id };
            return HandleResult(await _mediator.Send(command));
        }
    }
}
