using BlogApp.Application.Contracts.Identity;
using BlogApp.Application.Features.Authentication.CQRS.Queries;
using BlogApp.Application.Features.Authentication.DTO.Validators;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Authentication.CQRS.Handlers
{
    public class ConfirmEmailHandler : IRequestHandler<ConfirmEmailQuery, BaseResponse<Unit>>
    {
        private readonly IAuthRepository _authRepository;
        public ConfirmEmailHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        
        public async Task<BaseResponse<Unit>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var validator = new ConfirmEmailDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ConfirmEmailDto);
            var response = new BaseResponse<Unit>();
            if (validationResult.IsValid == true)
            {
                try
                {
                    var confirmationResponse = await _authRepository.ConfirmEmailAsync(request.ConfirmEmailDto);
                    response.Success = true;
                    response.Data = confirmationResponse;
                    response.Message = "Email confirmed Successfully";
                }
                catch (Exception e)
                {
                    response.Success = false;
                    response.Message = "Email confirmation failed";
                    response.Errors = new List<string>() { e.Message };
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Email confirmation failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }

            return response;
        }
    }
}
