using CineFlex.Application.Models;
using MediatR;
using CineFlex.Application.Models.DTOs;

namespace CineFlex.Application.Features.Auth.CQRS.Commands
{
    public class CreateUserCommand : IRequest<ApplicationUser>
    {
       public UserCreationDto userCreationDto { get; set; }  
    }
}
