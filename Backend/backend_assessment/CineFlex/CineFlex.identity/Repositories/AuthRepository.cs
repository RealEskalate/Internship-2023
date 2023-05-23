using AutoMapper;
using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Authentication.DTOs;
using CineFlex.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.identity.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly UserIdentityDbContext _context;

        public AuthRepository(UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              IMapper mapper, 
                              IConfiguration configuration,
                              UserIdentityDbContext context,
                              IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _configuration = configuration;
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        // Delete user
        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), userId);
            }
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<SignInResponse> SignInAsync(SigninFormDto signInFormDto)
        {


            var userExist = await _userManager.FindByEmailAsync(signInFormDto.Email);
            if (userExist != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(userExist, signInFormDto.Password, false);

                if (result.Succeeded)
                {
                    var token = await GenerateToken(userExist);

                    return new SignInResponse
                    {
                        Id = userExist.Id,
                        Email = userExist.Email,
                        FirstName = userExist.FirstName,
                        LastName = userExist.LastName,
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                    };
                }
                else
                    throw new BadRequestException("Email confiramtion is required");
            }
            throw new BadRequestException("Invalid Credential");

        }





        public async Task<SignUpResponse> SignUpAsync(SignupFormDto signUpFormDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var userExist = await _userManager.FindByEmailAsync(signUpFormDto.Email);
                    if (userExist != null)
                    {
                        throw new BadRequestException("Email is already used!");
                    }

                    var user = _mapper.Map<User>(signUpFormDto);
                    user.UserName = signUpFormDto.Email;
                    var result = await _userManager.CreateAsync(user, signUpFormDto.Password);

                    if (result.Succeeded)
                    {
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
    
                        var createdUser = await _userManager.FindByEmailAsync(user.Email);
                        var response = _mapper.Map<SignUpResponse>(createdUser);
                        await transaction.CommitAsync();
                        return response;
                    }
                    throw new BadRequestException("Unabe to creat user");


                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Something went wrong");
                }
            }
        }


        

        // get token
        private async Task<JwtSecurityToken> GenerateToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);


            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JwtSettings:Key")));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
               issuer: _configuration.GetValue<string>("JwtSettings:Issuer"),
               audience: _configuration.GetValue<string>("JwtSettings:Audience"),
               claims: claims,
               expires: DateTime.Now.AddMinutes(_configuration.GetValue<Int32>("JwtSettings:DurationInMinutes")),
               signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }


        // get user from token
        private async Task<string?> validateToken(string token)
        {
            if (token == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "id").Value;
                return userId;
            }
            catch
            {
                return null;
            }

        }

    }
}
