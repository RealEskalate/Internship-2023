using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Models.Identity;
using BlogApp.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers
{
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
        public async Task<ActionResult<Result<AuthResponse>>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<Result<RegistrationResponse>>> Register(RegistrationRequest request)
        {
            return Ok(await _authenticationService.Register(request));
        }
    }
}