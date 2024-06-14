using CineFlex.Application.Features.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Users.CQRS.Queries
{
    public class Get_UserListQuery: IRequest<List<_UserDto>>
    {
    }
}
