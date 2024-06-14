using System.Net;
using System.Runtime.CompilerServices;

using System.Security.Claims;
using CineFlex.API.AuthDto;
using CineFlex.API.Services;
using CineFlex.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineFlex.Application.Features.Seat.DTO;

namespace CineFlex.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly TokenService _tokenService;


        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(SignInManager<AppUser> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        private UserResponseDto CreateUserResponseObject(AppUser user, string token)
        {

            return new UserResponseDto
            {
                UserName = user.UserName,

                Token = token,
                Email = user.Email,
                // Role = AppRole.User
                // Tasks = user.Tasks != null ? user.Tasks.Select(task => new TasksDto
                // {
                //     // Map task properties to TasksDto
                //     Id = task.Id,
                //     Title = task.Title,
                //     Description = task.Description,
                //     // ...
                // }).ToList() : new List<TasksDto>()
            };
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserResponseDto>> Login(LoginDto loginDto)
        {
            var user = await _signInManager.UserManager.Users
                        .FirstOrDefaultAsync(x => x.Email == loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.UserManager.CheckPasswordAsync(user, loginDto.Password);
            if (result)
            {
                user.Role = AppRole.User;
                string token = _tokenService.CreateToken(user);

                return CreateUserResponseObject(user, token);
            }
            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
        {
            var existingUser = await _signInManager.UserManager.FindByNameAsync(registerDto.UserName);
            if (existingUser != null)
            {
                ModelState.AddModelError("Username", "Username taken");
                return ValidationProblem();
            }

            existingUser = await _signInManager.UserManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Email taken");
                return ValidationProblem();
            }

            var user = new AppUser
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
            };


            var result = await _signInManager.UserManager.CreateAsync(user, registerDto.Password);


            if (result.Succeeded)
            {
                return (user);
            }

            return BadRequest(result?.Errors);
            // return (user);
        }


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserResponseDto>> GetCurrentUser()
        {
            // check email from token is the same as the current user's email 
            var user = await _signInManager.UserManager.Users
            .FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

            if (user == null) return Unauthorized();



            string token = _tokenService.GetTokenFromRequest(_signInManager.Context);

            // check if the token is valid , user may loggedout but the token is not removed form the client
            bool isUserLoggedOut = _tokenService.IsTokenRevoked(user.Email, token);
            if (isUserLoggedOut)
            {
                return Unauthorized();
            }
            if (token != null)
            {
                return CreateUserResponseObject(user, token);
            }
            return Unauthorized();


        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()


        {

            var user = await _signInManager.UserManager.Users
                        .FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

            if (user == null) return Unauthorized();

            // get token from the httpContext

            string token = _tokenService.GetTokenFromRequest(_signInManager.Context);

            // check if the user is logged out 

            bool isUserLoggedOut = _tokenService.IsTokenRevoked(user.Email, token);

            if (isUserLoggedOut) return Unauthorized("you already loggedout ");



            await _signInManager.SignOutAsync();

            // remove token from chache
            _tokenService.RevokeToken(user.Email);




            return Content("logged out");
        }







    }
}