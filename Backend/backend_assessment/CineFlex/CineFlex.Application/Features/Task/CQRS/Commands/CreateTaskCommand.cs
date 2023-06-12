using CineFlex.Application.Features.Task.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Task.CQRS.Commands
{
    public class CreateTaskCommand:IRequest<BaseCommandResponse<int>>
    {
        public CreateTaskDto TaskDto { get; set; }
    }
}
