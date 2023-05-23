using CineFlex.Application.Features.Movies.CQRS.Commands;
using CineFlex.Application.Features.Movies.CQRS.Queries;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers;

public class SeatsController : BaseApiController
{
    private readonly IMediator _mediator;

    public SeatsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetSeatListQuery() ));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _mediator.Send(new GetSeatDetailQuery { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateSeatDto createSeatDto)
    {
        var command = new CreateSeatCommand { CreateSeatDto = createSeatDto };
        return Ok(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateSeatDto updateSeatDto)
    {
        var command = new UpdateSeatCommand { UpdateSeatDto = updateSeatDto };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteSeatCommand { Id = id };
        await _mediator.Send(command);
        return NoContent() ;
    }
}
