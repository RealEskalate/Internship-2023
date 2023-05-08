using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Features.Authentication.CQRS.Commands;
using BlogApp.Application.Features.Authentication.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Authentication.CQRS.Handlers
{
    public class SignupHandler : IRequestHandler<SignupCommand, SignUpResponse>
    {
        private readonly IAuthRepository _authRepository;
        public SignupHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        
        public async Task<SignUpResponse> Handle(SignupCommand request, CancellationToken cancellationToken)
        {
            return await _authRepository.SignUpAsync(request.SignupFormDto);
        }
    }
}
