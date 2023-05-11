using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlogApp.Application.Constants;
using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Models.Identity;
using BlogApp.Application.Responses;
using BlogApp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BlogApp.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
        }

        public async Task<Result<AuthResponse>> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new BadRequestException("Invalid email or password.");

            var result =
                await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false,
                    lockoutOnFailure: false);
            if (!result.Succeeded)
                throw new BadRequestException("Invalid email or password.");

            var jwtSecurityToken = await GenerateToken(user);

            var response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                Username = user.UserName,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
            };

            return new Result<AuthResponse>()
            {
                Success = true,
                Message = "Login successful.",
                Value = response
            };
        }

        public async Task<Result<RegistrationResponse>> Register(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.Username);

            if (existingUser != null)
                throw new BadRequestException($"Username '{request.Username}' already exists.");

            var user = new ApplicationUser
            {
                Email = request.Email,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                UserName = request.Username,
                EmailConfirmed = true
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existingEmail != null)
                throw new BadRequestException($"User with email '{request.Email} already exists.");

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new IdentityException("An error occured while creating the user.", result.Errors.ToList());

            await _userManager.AddToRoleAsync(user, "User");
            return new Result<RegistrationResponse>()
            {
                Success = true, Message = "User created successfully.",
                Value = new RegistrationResponse() { UserId = user.Id }
            };
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role, "string")).ToList();

            var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(CustomClaimTypes.Uid, user.Id.ToString())
                }
                .Union(userClaims)
                .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}