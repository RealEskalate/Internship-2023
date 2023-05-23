using System.Text;
using CineFlex.Domain.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using CineFlex.Application.Features.Authentication.DTOs;
using CineFlex.Application.Contracts.Persistence;

namespace CineFlex.Persistence.Repositories;

internal sealed class UserRepository : GenericRepository<AppUser>, IUserRepository
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;
    private AppUser? _user;

    public UserRepository(
    UserManager<AppUser> userManager, IConfiguration configuration, CineFlexDbContex dbContex): base(dbContex)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<IdentityResult> RegisterUserAsync(AppUser user)
    {
        var result = await _userManager.CreateAsync(user, user.Password);
        result = await _userManager.AddToRoleAsync(user, "User");
        return result;
    }


    public async Task<bool> ValidateUserAsync(UserSignInDTO loginDto)
    {
        _user = await _userManager.FindByNameAsync(loginDto.Username);
        var result = _user != null && await _userManager.CheckPasswordAsync(_user, loginDto.Password);
        return result;
    }

    public async Task<string> CreateTokenAsync() 
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private SigningCredentials GetSigningCredentials()
    {
        var jwtConfig = _configuration.GetSection("jwtConfig");
        var key = Encoding.UTF8.GetBytes(jwtConfig["Secret"]);
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, _user.UserName)
        };
        var roles = await _userManager.GetRolesAsync(_user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("JwtConfig");
        var tokenOptions = new JwtSecurityToken
        (
        issuer: jwtSettings["validIssuer"],
        audience: jwtSettings["validAudience"],
        claims: claims,
        expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expiresIn"])),
        signingCredentials: signingCredentials
        );
        return tokenOptions;
    }

    public async Task<bool> Exists(string id)
    {
        return await _userManager.FindByIdAsync(id) != null;

    }

    public async Task<AppUser?> Get(string id)
    {
        return await _userManager.FindByIdAsync(id);
    }
}
