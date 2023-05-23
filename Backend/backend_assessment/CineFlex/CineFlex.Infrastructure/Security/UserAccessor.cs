

using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using CineFlex.Domain;
using Microsoft.AspNetCore.Identity;
using CineFlex.Application.Contracts.Persistence;

namespace CineFlex.Infrastructure.Security
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public UserAccessor(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public string GetUsername()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }

        public async Task<AppUser> GetCurrentUser()
        {
            var username = GetUsername();
            return await _userManager.FindByNameAsync(username);
        }
    }
}
