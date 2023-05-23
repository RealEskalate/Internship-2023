using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineFlex.Application.Features.Seats.DTO;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Queries
{
    public class GetSeatQuery : IRequest<BaseCommandResponse<SeatDto>>
    {
        public int Id { get; set; }
        
    }
}