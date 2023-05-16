using BlogApp.Application.Features.Authentication.DTO;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Authentication.CQRS.Commands
{
    public class SigninCommand : IRequest<BaseResponse<SignInResponse>>
    {
        public SigninFormDto SigninFormDto { get; set; }
    }
}
