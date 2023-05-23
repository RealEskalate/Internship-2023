using CineFlex.Application.Features.Seat.DTOs;
using CineFlex.Application.Responses;
using MediatR;


namespace CineFlex.Application.Features.Seat.CQRS.Commands;



public class UpdateSeatCommand : IRequest<BaseCommandResponse<int>>
{
    public UpdateSeatDto updateSeatDto { get; set; }
}
