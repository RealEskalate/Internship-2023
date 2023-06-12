using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.CQRS.Commands
{
    public class DeleteTaskCheckListCommand : IRequest<BaseCommandResponse<int>>
    {
        public int Id { get; set; }
    }
}
