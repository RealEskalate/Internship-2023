using CineFlex.Application.Features.Authentication.CQRS.Commands;
using CineFlex.Application.Features.Authentication.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CineFlex.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("signup")]
        public async Task<ActionResult> Register(SignupFormDto signupFormDto)
        {
            var command = new SignUpCommand { SignupFormDto = signupFormDto };
            var response = await _mediator.Send(command);
            return HandleResult(response);
        }
        
        [HttpPost("signin")]
        public async Task<ActionResult> Login(SigninFormDto signinFormDto)
        {
            var command = new SigninCommand { SigninFormDto = signinFormDto };
            var response = await _mediator.Send(command);
            return HandleResult(response);
        }

        

    }
}
