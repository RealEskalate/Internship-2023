using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Models.Identity;
using CineFlex.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly IAuthService _authenticationService;
        public UserController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<Result<AuthResponse>>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }
        [HttpPost("signUp")]
        public async Task<ActionResult<Result<RegistrationResponse>>> Registor(RegistrationRequest request)
        {
            return Ok(await _authenticationService.Registor(request));
        }
    }
}
