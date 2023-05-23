
using System.Security.Claims;
using Application.Contracts.Identity;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Security
{


    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetUserName()
        {

            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);

        }
    }
}