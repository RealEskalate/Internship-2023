using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using CineFlex.Domain;
using CineFlex.API.Models;
using CineFlex.API.Services;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly TokenService _tokenService;
        public readonly UserManager<AppUser> _userManager;
        public AccountsController(UserManager<AppUser> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto logiDto)
        {
            var user = await _userManager.FindByEmailAsync(logiDto.Email);
            if (user == null) return BadRequest("Wrong Credentials");

            var result = await _userManager.CheckPasswordAsync(user, logiDto.Password);
            if (result) return CreateUser(user);

            return BadRequest("Wrong Credentials");

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                ModelState.AddModelError("Email", "Email is taken");
                return ValidationProblem();
            }
            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.UserName))
            {
                ModelState.AddModelError("UserName", "UserName is taken");
                return ValidationProblem();
            }
            var user = new AppUser
            {
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            await _userManager.AddToRoleAsync(user, "User");

            if (result.Succeeded)
            {
                return CreateUser(user);
            }
            return BadRequest(result.Errors);
        }


       
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentuser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return CreateUser(user);
        }


        private UserDto CreateUser(AppUser user)
        {
            return new UserDto
            {
                FullName = user.FullName,
                Email = user.Email,
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
    }
}