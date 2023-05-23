using System.Net;
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
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : BaseApiController
    {
        public MovieController(IMediator mediator): base(mediator)
        {
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<List<MovieDto>>> Get()
        {
            var result = await _mediator.Send(new GetMovieListQuery());
            
            var status = result.Success ? HttpStatusCode.OK: HttpStatusCode.NotFound;
            return getResponse<BaseCommandResponse<List<MovieDto>>>(status, result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetMovieDetailQuery { Id = id });
            
            var status = result.Success ? HttpStatusCode.OK: HttpStatusCode.NotFound;
            return getResponse<BaseCommandResponse<MovieDto>>(status, result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] CreateMovieDto createMovie)
        {
            var result = await _mediator.Send(new CreateMovieCommand { MovieDto = createMovie });
            
            var status = result.Success ? HttpStatusCode.Created: HttpStatusCode.BadRequest;
            return getResponse<BaseCommandResponse<int>>(status, result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] UpdateMovieDto movieDto)
        {
            var result = await _mediator.Send(new UpdateMovieCommand { MovieDto = movieDto });
            
            var status = result.Success ? HttpStatusCode.NoContent: HttpStatusCode.BadRequest;
            return getResponse<BaseCommandResponse<Unit>>(status, result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]        
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteMovieCommand { Id = id });
            
            var status = result.Success ? HttpStatusCode.OK: HttpStatusCode.BadRequest;
            return getResponse<BaseCommandResponse<int>>(status, result);
        }
    }
}
