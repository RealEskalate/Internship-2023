using CineFlex.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CineFlex.API.Authorizations.Requirements;

public class BookOwnerRequirement : IAuthorizationRequirement
{
}