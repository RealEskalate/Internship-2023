using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Requests.Queries;

public class GetAllSeatsQuery: IRequest<BaseCommandResponse<List<SeatDetailsDto>?>>
{
    public GetAllSeatsDto GetAllSeatsDto { get; set; }
}