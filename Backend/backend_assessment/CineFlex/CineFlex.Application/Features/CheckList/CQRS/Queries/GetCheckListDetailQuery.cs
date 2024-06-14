using CineFlex.Application.Features.CheckList.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.CheckList.CQRS.Queries
{
    public class GetCheckListDetailQuery : IRequest<BaseCommandResponse<CheckListDto>>
    {
        public int Id { get; set; }
    }
}
