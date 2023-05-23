using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers;

public class GetSeatsByCinemaQueryHandler : IRequestHandler<GetSeatsByCinemaQuery, BaseCommandResponse<List<SeatDto>>>
{
    public Task<BaseCommandResponse<List<SeatDto>>> Handle(GetSeatsByCinemaQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}