using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Movies.CQRS.Queries;

public class GetMovieListQuery : IRequest<BaseCommandResponse<List<MovieDto>>>
{
    public string? query { get; init; }
}