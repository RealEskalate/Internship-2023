using BlogApp.Application.Features.Authentication.DTO;
using MediatR;


namespace BlogApp.Application.Features.Authentication.CQRS.Commands
{
    public class SignupCommand : IRequest<SignUpResponse>
    {
        
        public SignupFormDto SignupFormDto { get; set; }
    }
}
