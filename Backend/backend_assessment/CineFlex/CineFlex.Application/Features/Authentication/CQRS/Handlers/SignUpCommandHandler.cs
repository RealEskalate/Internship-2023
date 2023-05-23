using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Features.Authentication.CQRS.Commands;
using CineFlex.Application.Features.Authentication.DTOs;
using CineFlex.Application.Features.Authentication.DTOs.Validators;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Authentication.CQRS.Handlers
{
    public class SignupHandler : IRequestHandler<SignUpCommand, BaseCommandResponse<SignUpResponse>>
    {
        private readonly IAuthRepository _authRepository;
        public SignupHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<BaseCommandResponse<SignUpResponse>> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var validator = new SignUpFormValidator();
            var response = new BaseCommandResponse<SignUpResponse>();
            var validationResult = await validator.ValidateAsync(request.SignupFormDto);
            if (validationResult.IsValid == true)
            {
                try
                {
                    var signUpResponse = await _authRepository.SignUpAsync(request.SignupFormDto);
                    response.Success = true;
                    response.Value = signUpResponse;
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
