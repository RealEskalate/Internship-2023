using AutoMapper;
using CineFlex.Application.Constants.Identity;
using CineFlex.Application.Models.Identity;
using CineFlex.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SendGrid;

namespace CineFlex.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMediator mediator, IMapper mapper)
        {
            _authService = authService;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginModel request)
        {
            var responce = await _authService.Login(request);
            return HandleResult(responce);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<Result<RegistrationResponse>>> Register([FromBody] RegisterModel registerRequest)
        {
            var response = await _authService.Register(_mapper.Map<RegisterModel>(registerRequest));

            if (!response.Success || response.Value == null)
                return HandleResult(response);

            await _authService.DeleteUser(registerRequest.Email);
            response.Success = false;
            return HandleResult(response);

        }

        [HttpGet]
        [Route("ResendConfirmLink")]
        public async Task<ActionResult<Result<string>>> ResendConfirmEmailLink(string email)
        {
            var response = await _authService.sendConfirmEmailLink(email);
            return HandleResult(response);
        }

        [HttpGet]
        [Route("Confirm")]
        public async Task<ActionResult<Result<string>>> ConfirmEmail(string email, string token)
        {
            var response = await _authService.ConfirmEmail(token, email);
            return HandleResult(response);

        }

        [HttpGet]
        [Route("ForgotPassword")]
        public async Task<ActionResult<Result<string>>> ForgotPassword(string email)
        {
            var response = await _authService.ForgotPassword(email);
            return HandleResult(response);

        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<ActionResult<Result<string>>> ResetPassword([FromBody] ResetPasswordModel resetPasswordModel)
        {
            var response = await _authService.ResetPassword(resetPasswordModel);
            return HandleResult(response);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<bool>> Delete(string email)
        {
            var response = await _authService.DeleteUser(email);
            return Ok(response);
        }
    }
}