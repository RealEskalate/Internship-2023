using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Cinema.CQRS.Commands;

public class UpdateCinemaCommand : IRequest<BaseCommandResponse<Unit>>
{
    public UpdateCinemaDto updateCinemaDto { get; set; }
}