using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CineFlex.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class SeatController : ControllerBase
{
    private readonly IMediator _mediator;

    public SeatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<SeatDto>>> Get()
    {
        var seats = await _mediator.Send(new GetSeatListQuery());
        return Ok(seats);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SeatDto>> Get(int id)
    {
        var seats = await _mediator.Send(new GetSeatDetailQuery { Id = id });
        return Ok(seats);
    }

    [HttpPost]
    public async Task<ActionResult<BaseCommandResponse<int>>> Post([FromBody] CreateSeatDto createSeatDto)
    {
        var command = new CreateSeatCommand { CreateSeatDto = createSeatDto };
        var repsonse = await _mediator.Send(command);
        return Ok(repsonse);
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UpdateSeatDto seatDto)
    {
        var command = new UpdateSeatCommand { UpdateSeatDto = seatDto };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSeatCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

