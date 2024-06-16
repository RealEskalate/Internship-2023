using AutoMapper;
using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Exceptions;
using CineFlex.Domain;
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
using TaskManagementSystem.Application.Models.Identity;

namespace CineFlex.Identity.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly CineFlexDbContext _context;

    public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper, IConfiguration configuration, CineFlexDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _configuration = configuration;
        _context = context;
    }

    public async Task<bool> DeleteUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new NotFoundException(nameof(ApplicationUser), userId);
        }
        var result = await _userManager.DeleteAsync(user);
        return result.Succeeded;
    }

    public async Task<AuthResponse> LoginAsync(AuthRequest model)
    {
        var userExist = await _userManager.FindByEmailAsync(model.Email);
        if (userExist != null)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(userExist, model.Password, false);

            if (result.Succeeded)
            {
                var token = await GenerateToken(userExist);
                return new AuthResponse
                {
                    Id = userExist.Id,
                    Email = userExist.Email,
                    UserName = userExist.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                };
            }
        }
        throw new BadRequestException("Invalid Credential");
    }

    public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest model)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var userExist = await _userManager.FindByEmailAsync(model.Email);
                if (userExist == null)
                {
                    var user = _mapper.Map<ApplicationUser>(model);
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "User");

                        var createdUser = await _userManager.FindByNameAsync(user.UserName);
                        var response = _mapper.Map<RegistrationResponse>(createdUser);
                        await transaction.CommitAsync();
                        return response;
                    }
                }
                throw new BadRequestException("Email is already used!");
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                throw e;
            }
        }
    }

    private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
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
