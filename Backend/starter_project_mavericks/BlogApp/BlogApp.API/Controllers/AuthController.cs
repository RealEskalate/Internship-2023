using BlogApp.Application.Features.Authentication.CQRS.Commands;
using BlogApp.Application.Features.Authentication.CQRS.Queries;
using BlogApp.Application.Features.Authentication.DTO;
using BlogApp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlogApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseApiController
    {
        public AuthController(IMediator mediator):base(mediator)
        {
        }
        
        
        [HttpPost("signup")]
        public async Task<ActionResult> Register(SignupFormDto signupFormDto)
        {
            var command = new SignupCommand { SignupFormDto = signupFormDto };
            var response = await _mediator.Send(command);
            var status = response.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return getResponse<BaseResponse<SignUpResponse>>(status, response);
        }

        [HttpPost("signin")]
        public async Task<ActionResult> Login(SigninFormDto signinFormDto)
        {
            var command = new SigninCommand { SigninFormDto = signinFormDto };
            var response = await _mediator.Send(command);
            var status = response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return getResponse<BaseResponse<SignInResponse>>(status, response);
        }

        // confirm email
        [HttpGet("/auth/confirmemail")]
        public async Task<ActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string token)
        {
            var dto = new ConfirmEmailDto { UserId = userId, Token = token };
            var response = await _mediator.Send(new ConfirmEmailQuery { ConfirmEmailDto = dto });
            var status = response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return getResponse<BaseResponse<Unit>>(status, response);
        }

    }
}
