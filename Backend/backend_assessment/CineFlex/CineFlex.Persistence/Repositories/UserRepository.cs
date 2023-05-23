using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

using System.Security.Claims;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Models;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Models.DTOs;

namespace CineFlex.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserRepository(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<ApplicationUser> CreateUserAsync(ApplicationUser user, string password, string roles)
        {

            
            var result = await _userManager.CreateAsync(user, password);
            Console.WriteLine(result.ToString());
            
            if (result.Succeeded)
            {

                var savedUser = await _userManager.FindByEmailAsync(user.Email);

                var addRoleResult = await _userManager.AddToRoleAsync(user, roles);

        if (!addRoleResult.Succeeded) throw new InvalidOperationException("User role assignment has failed");

              
                return user;
            }
            else
            {
                Console.WriteLine(result.ToString());
                throw new Exception("Failed to create user.");
            }
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<ApplicationUser> UpdateUserAsync(string userId, ApplicationUser user)
        {
            var existingUser = await _userManager.FindByIdAsync(userId);
            if (existingUser == null)
            {
                throw new Exception("User not found.");
            }

            existingUser.Email = user.Email;
            existingUser.FullName = user.FullName;

            var result = await _userManager.UpdateAsync(existingUser);
            if (result.Succeeded)
            {
                return existingUser;
            }
            else
            {
                throw new Exception("Failed to update user.");
            }
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to delete user.");
            }
        }

        public async Task<bool> CheckEmailExistence(string email, string? userId)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null && user.Id != userId;
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task ResetPassword(string userId, string password)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, password);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to reset password.");
            }
        }

        public async Task<LoginResponse> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("Invalid email or password.");
            }

            var validPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!validPassword)
            {
                throw new Exception("Invalid email or password.");
            }

            var token =  GenerateToken(user);
            return new LoginResponse(true, "Login successful", token, false);


            ;
        }

        public string GenerateToken(ApplicationUser user)
        {
              var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email ?? string.Empty),
            new(ClaimTypes.NameIdentifier, user.UserName),
            new(ClaimTypes.Name, user.UserName),
        };
         var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecurityKey"] ?? string.Empty);
        var secret = new SymmetricSecurityKey(key);
        var value= new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            var jwtOptions = new JwtSecurityToken(
            _configuration["JwtSettings:Issuer"],
            _configuration["JwtSettings:Audience"],
             claims, 
            
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:ExpirationTimeInMinutes"])),
            signingCredentials: value);

        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtOptions);
      

       

        return accessToken;
            
        }
    }
}
