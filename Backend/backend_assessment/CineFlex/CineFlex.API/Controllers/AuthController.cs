using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CineFlex.Application.Responses;
using CineFlex.Application.Features.Authentication.DTOs;
using CineFlex.Application.Features.Authentication.CQRS.Commands;

namespace CineFlex.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SigninFormDto signinForm)
        {
            var command = new SigninCommand { SigninForm = signinForm };
            var response = await _mediator.Send(command);
            return HandleResult(response);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignupFromDto signupForm)
        {
            var command = new SignupCommand { SignupForm = signupForm };
            var response = await _mediator.Send(command);
            return HandleResult(response);
        }
    }
}
