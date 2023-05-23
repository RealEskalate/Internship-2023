using CineFlex.API.Authorizations.Requirements;
using CineFlex.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Authorization;

namespace CineFlex.API.Authorizations.Handlers;

public class BookOwnerHandler : AuthorizationHandler<BookOwnerRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUnitOfWork _unitOfWork;

    public BookOwnerHandler(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _unitOfWork = unitOfWork;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, BookOwnerRequirement requirement)
    {
        var userId = _httpContextAccessor.HttpContext.User.Claims
            .FirstOrDefault(q => q.Type == "uid")?.Value;

        object? id;
        
        _httpContextAccessor.HttpContext.Request.RouteValues.TryGetValue("id", out id);
        var task = await _unitOfWork.BookRepository.Get(Int32.Parse(id as string));
        if (userId == task.ApplicationUserId)
        {
            context.Succeed(requirement);
        }
    }
}
