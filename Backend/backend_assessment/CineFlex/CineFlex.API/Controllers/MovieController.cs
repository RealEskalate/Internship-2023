using CineFlex.Application.Features.Movies.CQRS.Commands;
using CineFlex.Application.Features.Movies.CQRS.Queries;
using CineFlex.Application.Features.Movies.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class MovieController : BaseApiController
{
    private readonly IMediator _mediator;

    public MovieController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult<List<MovieDto>>> Get(string? title)
    {
        return HandleResult(await _mediator.Send(new GetMovieListQuery { query = title }));
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> Get(int id)
    {
        return HandleResult(await _mediator.Send(new GetMovieDetailQuery { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateMovieDto createMovie)
    {
        var command = new CreateMovieCommand { MovieDto = createMovie };
        return HandleResult(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateMovieDto movieDto)
    {
        var command = new UpdateMovieCommand { MovieDto = movieDto };
        return HandleResult(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteMovieCommand { Id = id };
        return HandleResult(await _mediator.Send(command));
    }
}