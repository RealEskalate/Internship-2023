using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Cinema.CQRS.Commands;

public class DeleteCinemaCommand : IRequest<BaseCommandResponse<Unit>>
{
    public int Id { get; set; }
}