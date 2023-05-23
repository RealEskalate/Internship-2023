using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class SeatController : BaseApiController
{
    private readonly IMediator _mediator;

    public SeatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateSeatDto createSeat)
    {
        var command = new CreateSeatCommand { CreateSeatDto = createSeat };
        return HandleResult(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateSeatDto updateSeat)
    {
        var command = new UpdateSeatCommand { UpdateSeatDto = updateSeat };
        return HandleResult(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteSeatCommand { Id = id };
        return HandleResult(await _mediator.Send(command));
    }

    [HttpGet]
    public async Task<IActionResult> Get(int cinemaId)
    {
        var command = new GetSeatsByCinemaQuery() { CinemaId = cinemaId };
        return HandleResult(await _mediator.Send(command));
    }
}