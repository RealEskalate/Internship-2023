using BlogApp.Application.Features.Authentication.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Authentication.CQRS.Commands
{
    public class SigninCommand : IRequest<SignInResponse>
    {
        public SigninFormDto SigninFormDto { get; set; }
    }
}
