using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.CQRS.Queries;
using CineFlex.Application.Features.Movies.DTOs;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Movies.CQRS.Handlers;

public class SearchMovieQueryHandler : IRequestHandler<SearchMovieQuery, List<MovieDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public SearchMovieQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }

    public async Task<List<MovieDto>> Handle(SearchMovieQuery request, CancellationToken cancellationToken)
    {
        var movies = await  _unitOfWork.MovieRepository.SearchMoviesAsync(request.Title);

        var movieDtos = movies.Select(m => new MovieDto
        {
            Id = m.Id,
            Title = m.Title,
            Genre = m.Genre
        }).ToList();

        return movieDtos;
    }
}
