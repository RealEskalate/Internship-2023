using CineFlex.Application.Features.Authentication.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Authentication.CQRS.Commands
{
    public class SignUpCommand : IRequest<BaseCommandResponse<SignUpResponse>>
    {
        public SignupFormDto SignupFormDto { get; set; }
    }
}
