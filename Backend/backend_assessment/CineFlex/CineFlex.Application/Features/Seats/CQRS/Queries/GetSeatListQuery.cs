using CineFlex.Application.Features.Seats.Dtos;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Queries
{
    public class GetSeatListQuery :IRequest<BaseCommandResponse<List<SeatDto>>>
    {

    }
}
