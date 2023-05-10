using BlogApp.Application.Features.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Users.CQRS.Queries
{
    public class Get_UserDetailQuery : IRequest<_UserDto>
    {
        public int Id { get; set; }
    }
}
