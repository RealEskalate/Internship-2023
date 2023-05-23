using System.Security.Claims;
using CineFlex.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CineFlex.API.Services
{
    public class UserService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public UserService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<AppUser> GetCurrentUser(ClaimsPrincipal userPrincipal)
        {
            var userEmail = userPrincipal.FindFirstValue(ClaimTypes.Email);
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
        }


    }
}
