using CineFlex.Application.Features.Seat.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace CineFlex.Application.Features.Seat.CQRS.Queries
{
    public class GetSeatListQuery : IRequest<BaseCommandResponse<List<SeatDto>>>
    {
    }
}
