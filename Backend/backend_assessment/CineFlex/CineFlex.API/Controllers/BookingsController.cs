using CineFlex.Application.Features.Bookings.CQRS.Handlers;
using CineFlex.Application.Features.Bookings.CQRS.Requests.Commands;
using CineFlex.Application.Features.Bookings.CQRS.Requests.Queries;
using CineFlex.Application.Features.Bookings.DTOs;
using CineFlex.Application.Features.Movies.CQRS.Commands;
using CineFlex.Application.Features.Movies.CQRS.Queries;
using CineFlex.Application.Features.Movies.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers;

public class BookingsController : BaseApiController
{
    private readonly IMediator _mediator;

    public BookingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return HandleResult(await _mediator.Send(new GetBookingDetailQuery() { Id = id }));
    
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateBookingDto createBookingDto)
    {
        var command = new CreateBookingCommand() {CreateBookingDto  = createBookingDto };
        return HandleResult(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteBookingCommand() { Id = id };
        return HandleResult(await _mediator.Send(command));
    }
}   
