using AutoMapper;
using CineFlex.Identity.Models;
using Microsoft.AspNetCore.Identity;
using CineFlex.Application.Contracts.Identity;
using CineFlex.Domain.Models.Identity;
using System;

namespace CineFlex.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User?> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return null;

            return new User
            {
                Email = user.Email,
                AppUserId = user.Id,
                Name = user.Name,
                Roles = await _userManager.GetRolesAsync(user),
            };
        }


        public async Task<List<User>> GetUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync("User");
            if (users == null)
                return new List<User>();

            return users.Select(q => new User
            {
                AppUserId = q.Id,
                Email = q.Email,
                Name = q.Name,
            }).ToList();
        }
    }
}