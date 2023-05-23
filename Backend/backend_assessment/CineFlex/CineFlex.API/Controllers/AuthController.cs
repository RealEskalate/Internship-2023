using MediatR;
using System.Net;
using CineFlex.Application.Features.Authentication.CQRS.Commands;
using CineFlex.Application.Features.Authentication.DTOs;
using CineFlex.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CineFlex.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class AuthController : BaseApiController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult<BaseCommandResponse<UserDTO>>> RegisterUser([FromBody] UserSignUpDTO userRegistration)
    {
        
        var result = await _mediator.Send(new UserSignUpCommand {SignUpDTO=userRegistration});

        var status = result.Success ? HttpStatusCode.Created: HttpStatusCode.BadRequest;
        return getResponse<BaseCommandResponse<UserDTO>>(status, result);
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<BaseCommandResponse<string>>> Authenticate([FromBody] UserSignInDTO credentials)
    {
        var result = await _mediator.Send(new UserSignInCommand {SignInDTO=credentials});

        var status = result.Success ? HttpStatusCode.Created: HttpStatusCode.Unauthorized;
        return getResponse<BaseCommandResponse<string>>(status, result);
    } 
}