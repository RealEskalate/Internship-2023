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
using BlogApp.Persistence;
using System.Security.Policy;
using BlogApp.Application.Contracts.Infrastructure;

namespace BlogApp.Identity.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly UserIdentityDbContext _context;
        private readonly IEmailSender _emailSender;

        public AuthRepository(UserManager<User> userManager, 
                              SignInManager<User> signInManager, 
                              IMapper mapper, IConfiguration configuration, 
                              UserIdentityDbContext context,
                              IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _configuration = configuration;
            _context = context;
            _emailSender = emailSender;
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
                        }else
                            throw new BadRequestException("Email confiramtion is required");
                    }
                    throw new BadRequestException("Invalid Credential");

        }
            
            
        
    

        public async Task<SignUpResponse> SignUpAsync(SignupFormDto signUpFormDto)
        {
            using( var transaction = _context.Database.BeginTransaction())
            {
                try 
                {
                    var userExist = await _userManager.FindByEmailAsync(signUpFormDto.Email);
                    if (userExist == null)
                    {
                        var user = _mapper.Map<User>(signUpFormDto);
                        user.UserName = signUpFormDto.Email;
                        var result = await _userManager.CreateAsync(user, signUpFormDto.Password);
                        
                        if (result.Succeeded)
                        {
                            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                            var confirmationLink = _configuration["AppUrl"] + "/api/auth/confirmemail?userid=" + user.Id + "&token=" + token;
                            await _emailSender.SendEmail(signUpFormDto.Email, "Email Confirmation", confirmationLink);
                            await _userManager.AddToRoleAsync(user, "User");
                            var createdUser = await _userManager.FindByEmailAsync(user.Email);
                            var response = _mapper.Map<SignUpResponse>(createdUser);

                            return response;
                            await transaction.CommitAsync();
                        }
                        throw new BadRequestException("Email already exists");
                    }
                    throw new BadRequestException("Email is already used!");
                }
                catch(Exception e)
                {
                    transaction.Rollback();
                    throw new Exception("Something went wrong");
                }
            }
        }


        //confirm email
        public async Task<Unit> ConfirmEmailAsync(ConfirmEmailDto confirmEmailDto)
        {
            var user = await _userManager.FindByIdAsync(confirmEmailDto.UserId);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), confirmEmailDto.UserId);
            }
            var result = await _userManager.ConfirmEmailAsync(user, confirmEmailDto.Token);
            if (result.Succeeded)
            {
                return Unit.Value;
            }
            throw new BadRequestException("Invalid Token");
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
