using CineFlex.Application.Features.Seats.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Application.Responses;

namespace CineFlex.Application.Features.Seats.CQRS.Queries
{
    public class GetSeatListQuery: IRequest<BaseCommandResponse<List<SeatDto>>>
    {
    }
}
