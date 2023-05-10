using Microsoft.AspNetCore.Mvc;
using BlogApp.Application.Models.Identity;
using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Features.Users.CQRS.Commands;
using BlogApp.Application.Features.Users.CQRS.Queries;
using BlogApp.Application.Features.Users.DTOs;
using BlogApp.Application.Features.Users.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using AutoMapper;
using BlogApp.Api.Controllers;

namespace BlogApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
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
        var response = await _authService.Login(request);
        return HandleResult(response);
        
    }

    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult<Result<RegistrationResponse>>> Register([FromBody] RegisterDto registerDto)
    {
        var response = await _authService.Register(_mapper.Map<RegistrationModel>(registerDto));
        var command = new Create_UserCommand {Create_UserDto = _mapper.Map<Create_UserDto>(registerDto)};
        if (!response.Success || response.Value == null)
            return HandleResult(response);

        command.Create_UserDto.AccountId = response.Value.UserId;
        try
        {
            var userResponse = await _mediator.Send(command);
            return HandleResult(response);
        }
        catch(Exception e)
        {
            await _authService.DeleteUser(registerDto.Email);
            response.Success = false;
            response.Errors.Add(e.Message);
            return HandleResult(response);
        }
        
    }

    [HttpGet]
    [Route("Confirm")]
    public async Task<ActionResult<Result<string>>> ConfirmEmail(string token, string email)
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