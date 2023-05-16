using BlogApp.Application.Features.Authentication.DTO;
using BlogApp.Application.Responses;
using MediatR;


namespace BlogApp.Application.Features.Authentication.CQRS.Commands
{
    public class SignupCommand : IRequest<BaseResponse<SignUpResponse>>
    {
        
        public SignupFormDto SignupFormDto { get; set; }
    }
}
