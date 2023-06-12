﻿using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.CQRS.Commands
{
    public class CreateTaskCheckListCommand : IRequest<BaseCommandResponse<int>>
    {
        public CreateTaskCheckListDto TaskCheckListDto { get; set; }
    }
}
