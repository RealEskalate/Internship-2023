using Microsoft.AspNetCore.Mvc;
using BlogApp.Application.Models.Identity;
using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Features._Indices.CQRS.Commands;
using BlogApp.Application.Features._Indices.CQRS.Queries;
using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Features.Users.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using AutoMapper;


namespace BlogApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
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
        return Ok(response);
        
    }

    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegisterDto registerDto)
    {
        var registrationResponse = await _authService.Register(_mapper.Map<RegistrationModel>(registerDto));
        var command = new Create_UserCommand {_UserDto = _mapper.Map<Create_UserDto>(registerDto)};
        command._UserDto.AccountId = registrationResponse.Id;
        try
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch(Exception e)
        {
            await _authService.DeleteUser(registerDto.Email);
        }
        
    }

    [HttpGet]
    [Route("Confirm")]
    public async Task<ActionResult<ConfirmEmailResponse>> ConfirmEmail(string token, string email)
    {
        var response = await _authService.ConfirmEmail(token, email);
        return Ok(response);
        
    }
}
