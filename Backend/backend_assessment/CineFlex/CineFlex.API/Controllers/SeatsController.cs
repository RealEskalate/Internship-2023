using CineFlex.Application.Features.Movies.CQRS.Commands;
using CineFlex.Application.Features.Movies.CQRS.Queries;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Features.Seats.CQRS.Requests.Commands;
using CineFlex.Application.Features.Seats.CQRS.Requests.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers;

public class SeatsController: BaseApiController
{

    private readonly IMediator _mediator;
    
    public SeatsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("all")]
    public async Task<ActionResult<List<SeatDetailsDto>>> Get([FromBody] GetAllSeatsDto getAllSeatsDto)
    {
        return HandleResult(await _mediator.Send(new GetAllSeatsQuery(){GetAllSeatsDto = getAllSeatsDto}));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return HandleResult(await _mediator.Send(new GetSeatDetailsQuery { Id = id }));
    
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateSeatDto createSeatDto)
    {
        var command = new CreateSeatCommand() { CreateSeatDto = createSeatDto };
        return HandleResult(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateSeatDto updateSeatDto)
    {
        var command = new UpdateSeatCommand {  UpdateSeatDto = updateSeatDto};
        return HandleResult(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteSeatCommand { Id = id };
        return HandleResult(await _mediator.Send(command));
    }
}