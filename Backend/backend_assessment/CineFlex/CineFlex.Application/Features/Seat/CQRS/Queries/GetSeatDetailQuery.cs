using CineFlex.Application.Features.Seat.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seat.CQRS.Queries
{
    public class GetSeatDetailQuery: IRequest<BaseCommandResponse<SeatDto>>
    {
        public int Id { get; set; }
    }
}
