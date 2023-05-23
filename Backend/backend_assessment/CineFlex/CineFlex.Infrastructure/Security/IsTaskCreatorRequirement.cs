using CineFlex.Persistence;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CineFlex.Infrastructure.Security
{
    public class IsTaskCreatorRequirement : IAuthorizationRequirement
    {
    }
    public class IsTaskCreatorRequirementHandler : AuthorizationHandler<IsTaskCreatorRequirement>
    {
        private readonly CineFlexDbContex _dbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IsTaskCreatorRequirementHandler(CineFlexDbContex dbcontext, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbcontext = dbcontext;
        }

        protected override  Task HandleRequirementAsync(AuthorizationHandlerContext context, IsTaskCreatorRequirement requirement)
        {
        //     var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //     if (userId == null) return Task.CompletedTask;

        //    var routeData = _httpContextAccessor.HttpContext?.GetRouteData();
        //    var taskId = routeData?.Values.SingleOrDefault(x => x.Key == "id").Value;

        //     if(taskId == null) return Task.CompletedTask;

        //     var task =  _dbcontext.Tasks.AsNoTracking().SingleOrDefaultAsync(x => x.Id.ToString() == taskId.ToString()).Result;

        //     if (task == null) return Task.CompletedTask;

        //     if (task.CreatorId == userId) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}

