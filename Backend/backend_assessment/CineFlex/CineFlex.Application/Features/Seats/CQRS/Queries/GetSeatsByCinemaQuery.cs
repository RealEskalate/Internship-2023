using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Queries;

public class GetSeatsByCinemaQuery : IRequest<BaseCommandResponse<List<SeatDto>>>
{
    public int CinemaId { get; set; }
}