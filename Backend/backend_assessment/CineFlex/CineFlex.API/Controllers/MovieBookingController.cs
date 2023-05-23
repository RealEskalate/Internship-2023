using CineFlex.Application.Features.MovieBooking.CQRS.Commands;
using CineFlex.Application.Features.MovieBooking.DTOs;
using CineFlex.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
[Authorize]
public class MovieBookingController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly UserManager<AppUser> _userManager;


    public MovieBookingController(IMediator mediator, UserManager<AppUser> userManager)
    {
        _mediator = mediator;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateMovieBookingDto createMovieBooking)
    {
        var command = new CreateMovieBookingCommand
        {
            CreateMovieBookingDto = createMovieBooking,
            UserId = _userManager.GetUserId(User)!
        };
        return HandleResult(await _mediator.Send(command));
    }
}