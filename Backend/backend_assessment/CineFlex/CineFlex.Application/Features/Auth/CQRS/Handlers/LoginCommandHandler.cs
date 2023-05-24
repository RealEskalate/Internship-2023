using System.Threading;
using System.Threading.Tasks;
using CineFlex.Application.Features.Auth.CQRS.Commands;
using MediatR;
using CineFlex.Application.Models.DTOs;
using CineFlex.Application.Contracts.Persistence;
namespace CineFlex.Application.Features.Auth.CQRS.Handler;

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
   

        public LoginCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
          
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request.loginRequest.Email);
            var user = await _userRepository.FindByEmailAsync(request.loginRequest.Email);

           

            if (user == null)
            {
                // User not found
                return null;
            }

            var passwordValid = await _userRepository.CheckPasswordAsync(user, request.loginRequest.Password);
            Console.WriteLine(passwordValid);

            if (!passwordValid)
            {
                // Invalid password
                return null;
            }

            var loginResponse = await _userRepository.LoginAsync(request.loginRequest.Email,request.loginRequest.Password);
            Console.WriteLine(loginResponse);

            return loginResponse;
        }
    }

