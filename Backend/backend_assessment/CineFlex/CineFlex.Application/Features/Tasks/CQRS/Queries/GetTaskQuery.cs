﻿using CineFlex.Application.Features.Cinema.Dtos;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Cinema.CQRS.Queries
{
    public class GetTaskQuery: IRequest<BaseCommandResponse<TaskDto>>
    {
        public int Id { get; set; }
    }
}
