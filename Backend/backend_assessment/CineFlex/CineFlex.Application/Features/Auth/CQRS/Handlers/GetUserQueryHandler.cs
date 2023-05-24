using System.Threading;
using System.Threading.Tasks;
using MediatR;

using CineFlex.Application.Features.Auth.CQRS.Queries;
using CineFlex.Application.Models;
using CineFlex.Application.Contracts.Persistence;

namespace CineFlex.Application.Features.Auth.CQRS.Handler;

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ApplicationUser>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUser> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserById(request.UserId);
        }
    }

