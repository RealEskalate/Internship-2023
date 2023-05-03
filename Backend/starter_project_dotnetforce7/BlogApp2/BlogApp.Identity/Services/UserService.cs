using AutoMapper;
using BlogApp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using BlogApp.Application.Contracts.Identity;
using BlogApp.Domain.Models.Identity;
using System;

namespace BlogApp.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetUser(string userId)
        {
            var User = await _userManager.FindByIdAsync(userId);
            return new User
            {
                Email = User.Email,
                Id = User.Id,
                Firstname = User.Firstname,
                Lastname = User.Lastname
            };
        }
        

        public async Task<List<User>> GetUsers()
        {
            var Users = await _userManager.GetUsersInRoleAsync("User");
            return Users.Select(q => new User { 
                Id = q.Id,
                Email = q.Email,
                Firstname = q.Firstname,
                Lastname = q.Lastname
            }).ToList();
        }
    }
}