using CineFlex.Application.Features.CheckList.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.CheckList.CQRS.Commands
{
    public class UpdateCheckListCommand : IRequest<BaseCommandResponse<Unit>>
    {
        public UpdateCheckListDto CheckListDto { get; set; }

    }
}
