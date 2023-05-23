using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;
using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Models.Identity;
using CineFlex.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Responses;

namespace CineFlex.Identity.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<CineFlexUser> _userManager;
    private readonly SignInManager<CineFlexUser> _signInManager;
    private readonly JwtSettings _jwtSettings;

    public AuthenticationService(UserManager<CineFlexUser> userManager,
                       SignInManager<CineFlexUser> signInManager,
                       IOptions<JwtSettings> jwtSettings
                       )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<BaseCommandResponse<LoginResponse>> Login(LoginModel request)
    {
        var response = new BaseCommandResponse<LoginResponse>();

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            response.Success = false;
            response.Message = "User Not Found";
            response.Errors.Add($"User with email {request.Email} doesn't Exist");
            return response;
        }

        var res = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
        if (!res.Succeeded)
        {
            response.Success = false;
            response.Message = "Incorrect Password";
            response.Errors.Add($"the email and password combination is not correct");
            return response;
        }

        JwtSecurityToken token = await GenerateToken(user);

        var result = new LoginResponse()
        {
            UserId = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            Token = new JwtSecurityTokenHandler().WriteToken(token)
        };

        response.Value = result;
        response.Success = true;
        response.Message = "Successfully Logged In!";

        return response;
    }


    private async Task<JwtSecurityToken> GenerateToken(CineFlexUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        var Claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        }.Union(userClaims)
         .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: Claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredential
        );

        return token;
    }

    public async Task<BaseCommandResponse<RegistrationResponse>> Register(RegistrationModel request)
    {
        var response = new BaseCommandResponse<RegistrationResponse>();

        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        if (existingUser != null)
        {
            response.Success = false;
            response.Message = "User Already Exists";
            response.Errors.Add($"User with email {request.Email} Already Exists");
            return response;
        }

        var user = new CineFlexUser
        {
            UserName = request.UserName,
            FullName = request.FullName,
            Email = request.Email,
            EmailConfirmed = false
        };

        var createResult = await _userManager.CreateAsync(user, request.Password);

        if (!createResult.Succeeded)
        {
            response.Success = false;
            response.Message = "User Already Exists";
            foreach (var Error in createResult.Errors)
            {
                response.Errors.Add(Error.Description);
            }
            return response;
        }

        var createdUser = await _userManager.FindByNameAsync(request.UserName);
        await _userManager.AddToRoleAsync(createdUser, "User");

        response.Success = true;
        response.Message = "Successfully Registered!";
        response.Value =  new RegistrationResponse
        {
            UserId = createdUser.Id,
            email = createdUser.Email
        };

        return response;

    }



}
