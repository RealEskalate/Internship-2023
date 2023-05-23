using CineFlex.Application.Models;
using MediatR;


namespace CineFlex.Application.Features.Auth.CQRS.Queries;

    public class GetUserQuery : IRequest<ApplicationUser>
    {
        public string UserId { get; set; }
    }

