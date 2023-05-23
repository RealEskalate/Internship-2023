using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Net;
using CineFlex.Application.Responses;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using Microsoft.AspNetCore.Authorization;

namespace CineFlex.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class SeatsController : BaseApiController
{
    public SeatsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<BaseCommandResponse<int>>> Post([FromBody] CreateSeatDto createSeatDto)
    {
        var result = await _mediator.Send(new CreateSeatCommand {CreateSeatDto=createSeatDto});

        var status = result.Success ? HttpStatusCode.Created: HttpStatusCode.BadRequest;
        return getResponse<BaseCommandResponse<int>>(status, result);
    }

    [HttpGet]
    [Authorize(Roles = "User, Admin")]
    public async Task<ActionResult<BaseCommandResponse<List<SeatListDto>>>> Get([FromQuery] int cinema_id)
    {
        BaseCommandResponse<List<SeatListDto>> result;
        result = await _mediator.Send(new GetCinemaSeatsQuery{ CinemaID=cinema_id});
        
        var status = result.Success ? HttpStatusCode.OK: HttpStatusCode.BadRequest;
        return getResponse<BaseCommandResponse<List<SeatListDto>>>(status, result);
    }

    [HttpPatch]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Patch([FromBody] UpdateSeatDto updateSeatDto)
    {
        var result = await _mediator.Send(new UpdateSeatCommand { UpdateSeatDto = updateSeatDto });

        var status = result.Success ? HttpStatusCode.OK: HttpStatusCode.BadRequest;
        return getResponse<BaseCommandResponse<Unit>>(status, result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteSeatCommand { SeatID = id });

        var status = result.Success ? HttpStatusCode.NoContent: HttpStatusCode.BadRequest;
        return getResponse<BaseCommandResponse<Unit>>(status, result);
    }
}
