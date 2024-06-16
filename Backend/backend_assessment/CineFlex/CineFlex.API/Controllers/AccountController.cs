using System.Security.Claims;
using CineFlex.API.DTOs;
using CineFlex.API.Services;
using CineFlex.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CineFlex.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        private UserDto CreateUserObject(AppUser user)
        {
            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
                Email = user.Email
            };
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
                        .FirstOrDefaultAsync(x => x.Email == loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (result)
            {
                return CreateUserObject(user);
            }
            return Unauthorized();
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var existingUser = await _userManager.FindByNameAsync(registerDto.UserName);
            if (existingUser != null)
            {
                ModelState.AddModelError("Username", "Username taken");
                return ValidationProblem();
            }

            existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Email taken");
                return ValidationProblem();
            }

            var user = new AppUser
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);


            if (result.Succeeded)
            {
                return CreateUserObject(user);
            }

            return BadRequest(result?.Errors);
        }


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            Console.WriteLine(User.FindFirstValue(ClaimTypes.Email));
            var user = await _userManager.Users
            .FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

            if (user == null) return Unauthorized();

            return CreateUserObject(user);
        }

    }
}