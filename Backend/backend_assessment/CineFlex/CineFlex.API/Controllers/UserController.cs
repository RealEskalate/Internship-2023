namespace CineFlex.API.Controllers;
using CineFlex.Application.Responses;
using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAuthService _authenticationService;

    public AccountController(IAuthService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<BaseCommandResponse<AuthResponse>>> Login(AuthRequest request)
    {
        return Ok(await _authenticationService.Login(request));
    }

    [HttpPost("register")]
    public async Task<ActionResult<BaseCommandResponse<RegistrationResponse>>> Register(RegistrationRequest request)
    {
        return Ok(await _authenticationService.Register(request));
    }
}
