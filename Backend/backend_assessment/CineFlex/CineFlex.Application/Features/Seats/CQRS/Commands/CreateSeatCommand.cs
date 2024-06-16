using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineFlex.Application.Features.Seats.DTO;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Commands
{
    public class CreateSeatCommand : IRequest<BaseCommandResponse<int>>
    {
        public CreateSeatDto SeatDto {get; set; }
    }
} 