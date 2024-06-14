using Application.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace Infrustructure.Services
{
    public class UserAccessor : IUserAccessor
    {
        public readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetUsername()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
