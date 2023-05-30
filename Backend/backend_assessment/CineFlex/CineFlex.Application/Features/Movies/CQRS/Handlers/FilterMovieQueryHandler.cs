using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.CQRS.Queries;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.Movies.CQRS.Handlers;


public class MovieFilterByGenreQueryHandler : IRequestHandler<FilterMoviesByGenreQuery, List<Movie>>
{
    private readonly IUnitOfWork _unitOfWork;

    public MovieFilterByGenreQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    
    public async Task<List<Movie>> Handle(FilterMoviesByGenreQuery request, CancellationToken cancellationToken)
        {
        return await _unitOfWork.MovieRepository.FilterMoviesByGenre(request.Genre);
        }
}
