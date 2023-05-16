using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Authentication.CQRS.Commands;
using BlogApp.Application.Features.Authentication.DTO;
using BlogApp.Application.Features.Authentication.DTO.Validators;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Authentication.CQRS.Handlers
{
    public class SignupHandler : IRequestHandler<SignupCommand, BaseResponse<SignUpResponse>>
    {
        private readonly IAuthRepository _authRepository;
        public SignupHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        
        public async Task<BaseResponse<SignUpResponse>> Handle(SignupCommand request, CancellationToken cancellationToken)
        {
            var validator = new SignUpFormValidator();
            var response = new BaseResponse<SignUpResponse>();
            var validationResult = await validator.ValidateAsync(request.SignupFormDto);
            if (validationResult.IsValid == true)
            {
                try
                {
                    var signUpResponse = await _authRepository.SignUpAsync(request.SignupFormDto);
                    response.Success = true;
                    response.Data = signUpResponse;
                    response.Message = "User Registered Successfully";
                }
                catch (Exception e)
                {
                    response.Success = false;
                    response.Message = "User Registration Failed";
                    response.Errors = new List<string>() { e.Message };
                }
                
            }
            else
            {
                response.Success = false;
                response.Message = "User Registration Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }

            return response;
        }
    }
}
