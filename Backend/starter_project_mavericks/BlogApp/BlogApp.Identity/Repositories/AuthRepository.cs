using AutoMapper;
using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Models.Identity;
using BlogApp.Application.Features.Authentication.DTO;
using BlogApp.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Application.Exceptions;

namespace BlogApp.Identity.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthRepository(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<SignInResponse> SignInAsync(SigninFormDto signInFormDto)
        {
            var userExist = await _userManager.FindByEmailAsync(signInFormDto.Email);
            Console.WriteLine(userExist.ToString() + " " + signInFormDto.Email + "****************************************8");
            if (userExist != null)
            {
                //var result = await _signInManager.PasswordSignInAsync(userExist, signInFormDto.Password, false, false);
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
                        Token = token.ToString()
                    };
                }
                
            }
            throw new BadRequestException("Invalid Credentials");
        }
    

        public async Task<SignUpResponse> SignUpAsync(SignupFormDto signUpFormDto)
        {
            var userExist = await _userManager.FindByEmailAsync(signUpFormDto.Email);
            if (userExist == null) {
                var user = _mapper.Map<User>(signUpFormDto);
                user.UserName = signUpFormDto.Email;
                var result = await _userManager.CreateAsync(user, signUpFormDto.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    var createdUser = await _userManager.FindByEmailAsync(user.Email);
                    var response = _mapper.Map<SignUpResponse>(createdUser);
                 
                    return response;
                }
                throw new Exception("Something went wrong! " + result.Errors.FirstOrDefault().Description);
            }
            throw new Exception("Email is already used!");
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

    }
}
