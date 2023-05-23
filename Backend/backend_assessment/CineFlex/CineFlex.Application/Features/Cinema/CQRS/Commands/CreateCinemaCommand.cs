using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Cinema.CQRS.Commands;

public class CreateCinemaCommand : IRequest<BaseCommandResponse<int>>
{
    public CreateCinemaDto CinemaDto { get; set; }
}