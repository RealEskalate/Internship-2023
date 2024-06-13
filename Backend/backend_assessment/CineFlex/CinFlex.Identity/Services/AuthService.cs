using CineFlex.Application.Constants.Identity;
using CineFlex.Application.Constants.Infrustructure;
using CineFlex.Application.Models.Identity;
using CineFlex.Application.Responses;
using CinFlex.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CinFlex.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AuthUser> _userManager;
        private readonly SignInManager<AuthUser> _signInManager;
        private readonly ServerSettings _serverSettings;
        private readonly IEmailSender _emailSender;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<AuthUser> userManager,
                           SignInManager<AuthUser> signInManager,
                           IOptions<JwtSettings> jwtSettings,
                           IOptions<ServerSettings> serverSettings,
                           IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _serverSettings = serverSettings.Value;
            _emailSender = emailSender;
            _jwtSettings = jwtSettings.Value;
        }


        public async Task<Result<string>> ConfirmEmail(string token, string email)
        {
            var result = new Result<string>();
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                result.Success = false;
                result.Errors.Add($"User with email ({email}) not found");
                return result;
            }

            var confirmResult = await _userManager.ConfirmEmailAsync(user, token);
            if (!confirmResult.Succeeded)
            {
                result.Success = false;
                foreach (var Error in confirmResult.Errors)
                {
                    result.Errors.Add(Error.Description);
                }
                return result;
            }

            result.Success = true;
            result.Value = email;
            return result;

        }

        public async Task<Result<LoginResponse>> Login(LoginModel request)
        {
            Result<LoginResponse> result = new Result<LoginResponse>();
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                result.Success = false;
                result.Errors.Add($"User with given Email({request.Email}) doesn't exist");
                return result;
            }

            var res = await _signInManager.PasswordSignInAsync(user.Email, request.Password, false, lockoutOnFailure: false);
            if (!res.Succeeded)
            {
                result.Success = false;
                result.Errors.Add($"Incorrect password");
                return result;
            }

            JwtSecurityToken token = await GenerateToken(user);

            var response = new LoginResponse()
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            result.Value = response;
            return result;
        }


        private async Task<JwtSecurityToken> GenerateToken(AuthUser user)
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
        public async Task<Result<RegistrationResponse>> Register(RegisterModel request)
        {
            var result = new Result<RegistrationResponse>();
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                result.Success = false;
                result.Errors.Add($"User with given Email({request.Email}) already exists");
                return result;
            }

            var user = new AuthUser
            {
                UserName = request.Email,
                Email = request.Email,
                EmailConfirmed = false
            };

            var createResult = await _userManager.CreateAsync(user, request.Password);

            if (!createResult.Succeeded)
            {
                result.Success = false;
                foreach (var Error in createResult.Errors)
                {
                    result.Errors.Add(Error.Description);
                }
                return result;
            }

            var createdUser = await _userManager.FindByEmailAsync(request.Email);
            await _userManager.AddToRolesAsync(createdUser, request.Roles);

            var confirmResult = await sendConfirmEmailLink(createdUser.Email);
            if (!confirmResult.Success)
            {
                result.Message += "\n Warning: Email not confirmed\n";
                result.Errors.AddRange(confirmResult.Errors);
            }

            result.Success = true;
            result.Value = new RegistrationResponse
            {
                UserId = createdUser.Id,
                email = createdUser.Email
            };

            return result;
        }

        public async Task<Result<string>> sendConfirmEmailLink(string Email)
        {
            var result = new Result<string>();

            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                result.Success = false;
                result.Errors.Add($"User with given email ({Email}) not found!");
                result.Message = "Could not find user!";
                return result;
            }


            if (user.EmailConfirmed)
            {
                result.Success = false;
                result.Errors.Add($"User with given email ({Email}) has already confirmed their email!");
                result.Message = "User has already confirmed email!";
                return result;
            }



            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string connectionLink = _serverSettings.BaseApiUrl + $"Auth/Confirm/?email={HttpUtility.UrlEncode(Email)}&token={HttpUtility.UrlEncode(token)}";

            var message = new CineFlex.Application.Models.Email.Email
            {
                To = user.Email,
                Subject = "Email Confirmation",
                Body = $"Email Confirmation link: {connectionLink}\n token: {token}"
            };

            var emailResult = await _emailSender.sendEmail(message);
            if (!emailResult.Success)
            {
                result.Success = false;
                result.Errors.AddRange(emailResult.Errors);
                result.Message = "Could not send Email!";
                return result;
            }

            result.Success = true;
            result.Value = Email;
            result.Message = "Email Confirmation link successfully sent!";

            return result;
        }

        public async Task<Result<string>> ForgotPassword(string Email)
        {
            var result = new Result<string>();
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                result.Success = false;
                result.Errors.Add($"User with email ({Email}) not found");
                return result;
            }

            if (!user.EmailConfirmed)
            {
                result.Success = false;
                result.Errors.Add($"User has not confirmed the email ({Email})");
                return result;
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string resetLink = "# todo: A page where they reset password";

            var message = new CineFlex.Application.Models.Email.Email
            {
                To = Email,
                Subject = "Password Reset",
                Body = $"Password Reset link: {resetLink} \n token: {token}"
            };

            var emailResult = await _emailSender.sendEmail(message);
            if (!emailResult.Success)
            {
                result.Success = false;
                result.Errors.AddRange(emailResult.Errors);
                return result;
            }

            result.Success = true;
            result.Value = Email;
            return result;

        }

        public async Task<Result<string>> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            var result = new Result<string>();
            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
            {
                result.Success = false;
                result.Errors.Add($"User with email ({resetPasswordModel.Email}) not found");
                return result;
            }

            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPassResult.Succeeded)
            {
                result.Success = false;
                foreach (var Error in resetPassResult.Errors)
                {
                    result.Errors.Add(Error.Description);
                }
                return result;
            }

            result.Success = true;
            result.Value = resetPasswordModel.Email;
            return result;
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
}