using AutoMapper;
using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Models.Identity;
using CineFlex.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CineFlex.Identity.Services;

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
            Firstname = user.Firstname,
            Lastname = user.Lastname,
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
            Firstname = q.Firstname,
            Lastname = q.Lastname
        }).ToList();
    }
}
