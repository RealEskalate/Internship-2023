using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using App.Application.Models.Identity;
using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Authentication.DTOs;
using CineFlex.Identity.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CineFlex.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IOptions<JwtSettings> jwtSettingsOptions)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettingsOptions.Value;
        }

        public async Task<SigninResponse> LoginUserAsync(SigninFormDto signinForm)
        {
            var user = await _userManager.FindByEmailAsync(signinForm.Email);
            
            if (user == null)
            {
               throw new BadRequestException("Invalid Email or Password");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, signinForm.Password, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new BadRequestException("Invalid Email or Password");
            }

            var token = GenerateJwtToken(user);
            
            var response = new SigninResponse
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Token = token
            };

            return response;
        }

        public async Task<SignupResponse> RegisterUserAsync(SignupFromDto signupForm)
        {
            var user = new AppUser
            {
                UserName = signupForm.Email,
                Email = signupForm.Email,
                FullName = signupForm.FullName
            };

            var result = await _userManager.CreateAsync(user, signupForm.Password);
            if (!result.Succeeded)
            {
                throw new BadRequestException("Server error exception");
            }

            var response = new SignupResponse
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email
            };

            return response;
        }

        private string GenerateJwtToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
