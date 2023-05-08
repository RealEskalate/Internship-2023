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
    public class SigninHandler : IRequestHandler<SigninCommand, SignInResponse>
    {
        private readonly IAuthRepository _authenticationService;
        public SigninHandler(IAuthRepository authRepository)
        {
            _authenticationService = authRepository;
        }
        
        public async Task<SignInResponse> Handle(SigninCommand request, CancellationToken cancellationToken)
        {
            return await _authenticationService.SignInAsync(request.SigninFormDto);
        }
    }
}
