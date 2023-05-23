using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Movies.CQRS.Commands;

public class UpdateMovieCommand : IRequest<BaseCommandResponse<Unit>>
{
    public UpdateMovieDto MovieDto { get; set; }
}