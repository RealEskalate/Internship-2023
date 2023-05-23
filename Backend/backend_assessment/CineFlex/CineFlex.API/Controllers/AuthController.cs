using Microsoft.AspNetCore.Mvc;
using CineFlex.Application.Models.Identity;
using CineFlex.Application.Contracts.Identity;
using MediatR;
using AutoMapper;

namespace CineFlex.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseApiController
{
    private readonly IAuthenticationService _authService;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthController(IAuthenticationService authService, IMediator mediator, IMapper mapper)
    {
        _authService = authService;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult> Login([FromBody] LoginModel request)
    {
        var response =  await _authService.Login(request);
        return HandleResult(response);
    }

    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult> Register([FromBody] RegistrationModel registrationModel)
    {
        var response = await _authService.Register(registrationModel);
        return HandleResult(response);
    }

}