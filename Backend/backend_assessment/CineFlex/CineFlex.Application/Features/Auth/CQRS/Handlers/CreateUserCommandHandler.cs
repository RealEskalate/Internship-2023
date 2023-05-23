using System.Threading;
using System.Threading.Tasks;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Auth.CQRS.Commands;
using CineFlex.Application.Models;
using MediatR;


namespace CineFlex.Application.Features.Auth.CQRS.Handler;

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApplicationUser>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUser> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                
                Email = request.userCreationDto.Email,
                     UserName=   request.userCreationDto.UserName,
                     GivenRole= request.userCreationDto.roles,
                     

                FullName = request.userCreationDto.FullName,
            };

            return await _userRepository.CreateUserAsync(user, request.userCreationDto.Password,request.userCreationDto.roles);
        }
    }

