using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Commands
{
    public class UpdateSeatStatusCommand : IRequest<BaseCommandResponse<Unit>>
    {
        public UpdateSeatStatusDto SeatDto { get; set; }

    }
}
