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

public class AuthService: IAuthService
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
        var response = new LoginResponse();
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            response.Success = false;
            response.Errors.Add($"User with given Email({request.Email}) doesn't exist");
            return response;
        }

        var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
        if(!result.Succeeded)
        {
            response.Success = false;
            response.Errors.Add($"Incorrect password");
            return response;
        }

        JwtSecurityToken token = await GenerateToken(user);

        response.Success = true;
        response.UserId = user.Id;
        response.UserName = user.UserName;
        response.Email = user.Email;
        response.Token = new JwtSecurityTokenHandler().WriteToken(token);

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
        var response = new RegistrationResponse();
        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        if(existingUser != null)
        {
            response.Success = false;
            response.Errors.Add($"User with given Email({request.Email}) already exists");
            return response;
        }

        var user = new BlogUser{
            UserName = request.UserName,
            Email = request.Email,
            EmailConfirmed = false
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if(!result.Succeeded)
        {
            response.Success = false;
            response.Errors.Add(result.ToString());
            return response;
        }

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
            response.Errors.Add(e.Message);
        }

        await _userManager.AddToRolesAsync(createdUser, request.Roles);
        
        response.Success = true;
        response.UserId = createdUser.Id;
        return response;

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
        var user = await _userManager.FindByEmailAsync(Email);
        if (user == null)
            return false;

        var result = await _userManager.DeleteAsync(user);
        return result.Succeeded;
    }


}
