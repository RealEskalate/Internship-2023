using CineFlex.Application.Contracts.Identity;
using CineFlex.Application.Features.Authentication.CQRS.Commands;
using CineFlex.Application.Features.Authentication.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Authentication.CQRS.Handlers
{
    public class SignupCommandHandler : IRequestHandler<SignupCommand, BaseCommandResponse<SignupResponse>>
    {
        private readonly IAuthService _authService;

        public SignupCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<BaseCommandResponse<SignupResponse>> Handle(SignupCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<SignupResponse>();

            var signupForm = request.SignupForm;

            try
            {
                var SignupResponse = await _authService.RegisterUserAsync(signupForm);
                response.Success = true;
                response.Value = SignupResponse;
                response.Message = "Signup successful";

                return response;
            }

            catch (Exception e)
            {
                response.Success = false;
                response.Message = "Signup Failed";
                response.Errors = new List<string>() { e.Message };

                return response;
            }
        }
    }
}
