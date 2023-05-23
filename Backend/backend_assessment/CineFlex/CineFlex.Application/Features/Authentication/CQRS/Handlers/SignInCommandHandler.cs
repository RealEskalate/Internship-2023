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
    public class SigninHandler : IRequestHandler<SigninCommand, BaseCommandResponse<SignInResponse>>
    {
        private readonly IAuthRepository _authenticationRepo;
        public SigninHandler(IAuthRepository authRepository)
        {
            _authenticationRepo = authRepository;
        }

        public async Task<BaseCommandResponse<SignInResponse>> Handle(SigninCommand request, CancellationToken cancellationToken)
        {
            var validator = new SignInFormDtoValidators();
            var response = new BaseCommandResponse<SignInResponse>();
            var validationResult = await validator.ValidateAsync(request.SigninFormDto);
            if (validationResult.IsValid == true)
            {
                try
                {
                    var signInResponse = await _authenticationRepo.SignInAsync(request.SigninFormDto);
                    response.Success = true;
                    response.Value = signInResponse;
                    response.Message = "User Signed In Successfully";
                }
                catch (Exception e)
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
