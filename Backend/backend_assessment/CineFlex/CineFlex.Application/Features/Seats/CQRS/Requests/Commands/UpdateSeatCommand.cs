using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Requests.Commands;

public class UpdateSeatCommand: IRequest<BaseCommandResponse<SeatDetailsDto?>>
{
    public UpdateSeatDto UpdateSeatDto { get; set; }
}