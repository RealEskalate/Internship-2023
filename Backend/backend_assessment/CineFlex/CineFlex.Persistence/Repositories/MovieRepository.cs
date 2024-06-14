using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly CineFlexDbContex _context;
        private readonly IMapper _mapper;

        public MovieRepository(CineFlexDbContex dbContext, IMapper mapper) : base(dbContext)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<MovieDto> AddMovieAsync(CreateMovieDto movieDto)
        {
            var movieEntity = _mapper.Map<Movie>(movieDto);
            await Add(movieEntity);
            var createdMovieDto = _mapper.Map<MovieDto>(movieEntity);
            return createdMovieDto;
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var movies = await GetAll();
            var movieDtos = _mapper.Map<IEnumerable<MovieDto>>(movies);
            return movieDtos;
        }

        public async Task<MovieDto> GetMovieByIdAsync(int movieId)
        {
            var movieEntity = await Get(movieId);
            if (movieEntity == null)
                return null;
            var movieDto = _mapper.Map<MovieDto>(movieEntity);
            return movieDto;
        }

        public async Task<MovieDto> UpdateMovieAsync(UpdateMovieDto movieDto)
        {
            var movieEntity = await Get(movieDto.Id);
            if (movieEntity == null)
                return null;

            _mapper.Map(movieDto, movieEntity);
            await Update(movieEntity);

            var updatedMovieDto = _mapper.Map<MovieDto>(movieEntity);
            return updatedMovieDto;
        }
    }
}
