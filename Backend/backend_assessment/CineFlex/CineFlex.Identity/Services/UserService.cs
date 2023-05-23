using Microsoft.AspNetCore.Identity;
using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Models.Identity;
using CineFlex.Identity.Models;

namespace CineFlex.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<CineFlexUser> _userManager;

    public UserService(UserManager<CineFlexUser> userManager)
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
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            FullName = user.FullName,
            Roles = await _userManager.GetRolesAsync(user),
        };
    }


    public async Task<bool> Exists(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return user != null;
    }

    public async Task<bool> IsAdmin(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return await _userManager.IsInRoleAsync(user, "Admin");
    }


    public async Task<List<User>> GetUsers()
    {
        var users = await _userManager.GetUsersInRoleAsync("User");
        if (users == null)
            return new List<User>();

        return users.Select(q => new User
        {
            Id = q.Id,
            Email = q.Email,
            FullName = q.FullName,

        }).ToList();
    }
}
