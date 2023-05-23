using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Models.Identity;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using CineFlex.Application.Features.User.DTOs;
using CineFlex.Application.Profiles;

namespace CineFlex.API.Controllers;

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
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {
        var response = await _authService.Login(request);
        return Ok(response);
        
    }

    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult<Result<RegistrationResponse>>> Register([FromBody] RegisterDto registerDto)
    {
          var user = _mapper.Map<RegistrationRequest>(registerDto);

            try
            {
                _authService.Register(user);
                return Ok("Registration successful!");
            }
            catch (Exception ex)
            {
                return BadRequest("Registration failed: " + ex.Message);
            }

    }
    [HttpDelete]
    [Route("Delete")]

    public async Task<ActionResult<bool>> Delete(string email)
    {
        var response = await _authService.DeleteUser(email);
        return Ok(response);  
    }
}
