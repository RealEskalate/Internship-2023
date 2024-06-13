using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Requests.Queries;

public class GetSeatDetailsQuery: IRequest<BaseCommandResponse<SeatDetailsDto?>>
{
       public int Id { get; set; }
}