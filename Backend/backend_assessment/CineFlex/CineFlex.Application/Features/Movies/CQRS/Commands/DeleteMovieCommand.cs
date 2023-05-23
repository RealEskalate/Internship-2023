using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Movies.CQRS.Commands;

public class DeleteMovieCommand : IRequest<BaseCommandResponse<int>>
{
    public int Id { get; set; }
}