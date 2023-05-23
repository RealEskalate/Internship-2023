using System.Security.Claims;
using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Features.Movies.CQRS.Commands;
using CineFlex.Application.Features.Movies.CQRS.Queries;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CineFlex.API.Controllers
{
    [Authorize]
    [Route("api/[Controller]")]
    [ApiController]
    public class MovieController : BaseApiController
    {
        private readonly IMediator _mediator;

        private readonly IUserService _userServise;

        public MovieController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userServise = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetMovieListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetMovieDetailQuery { Id = id }));

        }

        [Route("Search")]
        [HttpGet()]
        public async Task<IActionResult> Get(string SearchString)
        {
            return HandleResult(await _mediator.Send(new SearchMovieQuery { SearchString = SearchString }));

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMovieDto createMovie)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (await _userServise.IsAdmin(userId) == false)
                return HandleResult(new BaseCommandResponse<int>{
                    Success = false,
                    Message = "Only admins Allowed"
                });

            var command = new CreateMovieCommand { MovieDto = createMovie };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateMovieDto movieDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (await _userServise.IsAdmin(userId) == false)
                return HandleResult(new BaseCommandResponse<int>{
                    Success = false,
                    Message = "Only admins Allowed"
                });

            var command = new UpdateMovieCommand { MovieDto = movieDto };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (await _userServise.IsAdmin(userId) == false)
                return HandleResult(new BaseCommandResponse<int>{
                    Success = false,
                    Message = "Only admins Allowed"
                });

            var command = new DeleteMovieCommand { Id = id };
            return HandleResult(await _mediator.Send(command));
        }
    }
}
