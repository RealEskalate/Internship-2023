using BlogApp.Application.Features.Authentication.DTO;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Authentication.CQRS.Queries
{
    public class ConfirmEmailQuery : IRequest<BaseResponse<Unit>>
    {
        public ConfirmEmailDto ConfirmEmailDto { get; set; }
    }
}
