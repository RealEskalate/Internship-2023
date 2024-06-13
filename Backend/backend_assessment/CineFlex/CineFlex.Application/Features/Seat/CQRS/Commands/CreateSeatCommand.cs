using CineFlex.Application.Features.Seat.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seat.CQRS.Commands;

public class CreateSeatCommand : IRequest<BaseCommandResponse<int>>
{
    public CreateSeatDto createSeatDto { get; set; }
}