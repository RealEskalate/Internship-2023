using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.Movies.CQRS.Queries;

 public class FilterMoviesByGenreQuery : IRequest<List<Movie>>
    {
        public string Genre { get; set; }
    }
