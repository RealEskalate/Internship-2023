using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Models.Identity;
using BlogApp.Application.Models.Mail;
using BlogApp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BlogApp.Identity.Services;

public class AuthService
{
    private readonly UserManager<BlogUser> _userManager;
    private readonly SignInManager<BlogUser> _signInManager;
    private readonly IEmailSender _emailSender;
    private readonly JwtSettings _jwtSettings;

    public AuthService(UserManager<BlogUser> userManager,
                       SignInManager<BlogUser> signInManager,
                       IOptions<JwtSettings> jwtSettings,
                       IEmailSender emailSender)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailSender = emailSender;
        _jwtSettings = jwtSettings.Value;
    }
    public async Task<ConfirmEmailResponse> ConfirmEmail(string token, string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            throw new Exception("user not found");
        var result = await _userManager.ConfirmEmailAsync(user, token);
        return new ConfirmEmailResponse
        {
            Succeeded = result.Succeeded
        };
    }

    public async Task<LoginResponse> Login(LoginModel request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            throw new Exception($"User {request.Email} not found");

        var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
        if(!result.Succeeded)
            throw new Exception($"Invalid Password");

        JwtSecurityToken token = await GenerateToken(user);

        LoginResponse response = new LoginResponse
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            Token = new JwtSecurityTokenHandler().WriteToken(token)
        };

        return response;
    }


    private async Task<JwtSecurityToken> GenerateToken(BlogUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = new List<Claim>();
        foreach(var role in roles)
        {
            roleClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        var Claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
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

    public async Task<RegistrationResponse> Register(RegistrationModel request)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        if(existingUser != null)
            throw new Exception("user already exists");

        var user = new BlogUser{
            UserName = request.UserName,
            Email = request.Email,
            EmailConfirmed = false
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if(!result.Succeeded)
            throw new Exception($"something went wrong {result.Errors}");

        var createdUser = await _userManager.FindByEmailAsync(request.Email);
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(createdUser);

        string connectionLink = "#todo";

        var message = new Email{
            To = request.Email,
            Subject = "Email Confirmation",
            Body = $"Email Confirmation link: {connectionLink}"
        };
        
        try
        {
            await _emailSender.sendEmail(message);

        }
        catch(Exception e){
            //todo
        }

        await _userManager.AddToRolesAsync(createdUser, request.Roles);
        
        return new RegistrationResponse{
            Id = createdUser.Id
        };

    }

    public async Task<ForgotPasswordResponse> ForgotPassword(string Email)
    {
        var user = await _userManager.FindByEmailAsync(Email);
        if (user == null)
            throw new Exception("user not found");
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        string resetLink = "#todo";
        var message = new Email{
            To =Email,
            Subject = "Password Reset",
            Body = $"Password Reset link: {resetLink}"
        };
        await _emailSender.sendEmail(message);
        return new ForgotPasswordResponse
        {

        };
    }

    public async Task<ResetPasswordResponse> ResetPassword(ResetPasswordModel resetPasswordModel)
    {
        var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
        if (user == null)
            throw new Exception("user not found");

        var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
        if(!resetPassResult.Succeeded)
        {
            foreach (var error in resetPassResult.Errors)
            {
                //add err
            }
            return new ResetPasswordResponse{};
        }
        return new ResetPasswordResponse{};
    }

    public async Task<bool> DeleteUser(string Email)
    {
        var user = _userManager.FindByEmailAsync(Email);
        if (user == null)
            return False;

        var result = await _userManager.DeleteAsync(user);
        return result.Succeeded;
    }


}
