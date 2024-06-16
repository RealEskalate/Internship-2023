using CineFlex.Application.Features.Auth.CQRS.Commands;
using CineFlex.Application.Features.Auth.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class AuthController : BaseApiController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginUserDto loginDto)
    {
        var command = new LoginUserCommand { LoginUserDto = loginDto };
        return HandleResult(await _mediator.Send(command));
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterUserDto registerDto)
    {
        var command = new RegisterUserCommand { RegisterUserDto = registerDto };
        return HandleResult(await _mediator.Send(command));
    }
}