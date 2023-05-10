using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Features.Authentication.CQRS.Commands;
using BlogApp.Application.Features.Authentication.DTO;
using BlogApp.Application.Responses;
using BlogApp.Application.Features.Authentication.DTO.Validators;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Authentication.CQRS.Handlers
{
    public class SigninHandler : IRequestHandler<SigninCommand, BaseResponse<SignInResponse>>
    {
        private readonly IAuthRepository _authenticationRepo;
        public SigninHandler(IAuthRepository authRepository)
        {
            _authenticationRepo = authRepository;
        }
        
        public async Task<BaseResponse<SignInResponse>> Handle(SigninCommand request, CancellationToken cancellationToken)
        {
            var validator = new SignInFormDtoValidators();
            var response = new BaseResponse<SignInResponse>();
            var validationResult = await validator.ValidateAsync(request.SigninFormDto);
            if (validationResult.IsValid == true)
            {
                try
                {
                    var signInResponse = await _authenticationRepo.SignInAsync(request.SigninFormDto);
                    response.Success = true;
                    response.Data = signInResponse;
                    response.Message = "User Signed In Successfully";
                }
                catch(Exception e)
                {
                    response.Success = false;
                    response.Message = "User Sign In Failed";
                    response.Errors = new List<string>() { e.Message };
                }
            }
            else
            {
                response.Success = false;
                response.Message = "User Sign In Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }

            return response;
        }
    }
}
