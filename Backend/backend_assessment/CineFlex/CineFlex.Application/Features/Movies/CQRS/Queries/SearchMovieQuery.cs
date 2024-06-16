using CineFlex.Application.Features.Movies.DTOs;
using MediatR;

namespace CineFlex.Application.Features.Movies.CQRS.Queries;

public class SearchMovieQuery : IRequest<List<MovieDto>>
{
    public string Title { get; set; }
}