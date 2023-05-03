using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features._Indices.CQRS.Commands
{
    public class Create_UserCommand: IRequest<BaseCommandResponse>
    {
        public Create_UserDto _UserDto { get; set; }
    }
}
