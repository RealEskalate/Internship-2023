
using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Features.Authentication.CQRS.Commands;
using CineFlex.Application.Features.Authentication.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Authentication.CQRS.Handlers;

public class SigninCommandHandler : IRequestHandler<SigninCommand, BaseCommandResponse<SigninResponse>>
{
    private readonly IAuthService _authService;

    public SigninCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }
    
    async Task<BaseCommandResponse<SigninResponse>> IRequestHandler<SigninCommand, BaseCommandResponse<SigninResponse>>.Handle(SigninCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse<SigninResponse>();

        var signinForm = request.SigninForm;

        try
        {
            var SigninResponse = await _authService.LoginUserAsync(signinForm);
            response.Success = true;
            response.Value = SigninResponse;
            response.Message = "Signin Successfull ";

            return response;
        }

        catch (Exception e)
        {
            response.Success = false;
            response.Message = "Signin Failed";
            response.Errors = new List<string>() { e.Message };

            return response;
        }
    }
}