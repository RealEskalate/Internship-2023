using CineFlex.Domain;
using CineFlex.Application.Features.Movies.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineFlex.Application.Contracts.Persistence
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
        Task<MovieDto> GetMovieByIdAsync(int movieId);
        Task<MovieDto> AddMovieAsync(CreateMovieDto movieDto);
        Task<MovieDto> UpdateMovieAsync(UpdateMovieDto movieDto);
    }
}
