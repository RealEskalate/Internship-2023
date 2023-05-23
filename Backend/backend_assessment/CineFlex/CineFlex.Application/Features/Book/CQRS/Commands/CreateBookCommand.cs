﻿using CineFlex.Application.Features.Book.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Book.CQRS.Commands
{
    public class CreateBookCommand: IRequest<BaseCommandResponse<int>> 
    {
        public CreateBookDto bookingDto { get; set; }
    }
}
