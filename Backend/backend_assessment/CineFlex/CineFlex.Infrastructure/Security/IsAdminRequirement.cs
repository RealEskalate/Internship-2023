using CineFlex.Persistence;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using CineFlex.Domain;

namespace CineFlex.Infrastructure.Security
{
    public class IsAdminRequirement : IAuthorizationRequirement
    {
    }
    public class IsAdminRequirementHandler : AuthorizationHandler<IsAdminRequirement>
    {
        private readonly CineFlexDbContex _dbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IsAdminRequirementHandler(CineFlexDbContex dbcontext, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbcontext = dbcontext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminRequirement requirement)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Task.CompletedTask;


            var user = _dbcontext.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Id == userId).Result;

            if (user == null) return Task.CompletedTask;

            if (user.Role == AppUser.UserRole.Admin) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}

