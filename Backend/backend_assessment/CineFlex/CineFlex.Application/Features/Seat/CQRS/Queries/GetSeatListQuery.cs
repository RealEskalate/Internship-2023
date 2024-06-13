using CineFlex.Application.Features.Seat.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seat.CQRS.Queries;

public class GetSeatListQuery : IRequest<BaseCommandResponse<List<SeatDto>>>
{
}
