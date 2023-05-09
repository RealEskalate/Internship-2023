using BlogApp.Application.Features.Authentication.CQRS.Commands;
using BlogApp.Application.Features.Authentication.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        
        [HttpPost("signup")]
        public async Task<ActionResult> Register(SignupFormDto signupFormDto)
        {
            var command = new SignupCommand { SignupFormDto = signupFormDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("signin")]
        public async Task<ActionResult> Login(SigninFormDto signinFormDto)
        {
            var command = new SigninCommand { SigninFormDto = signinFormDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
