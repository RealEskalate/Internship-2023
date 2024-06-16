using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly CineFlexDbContex _context;
        public MovieRepository(CineFlexDbContex dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<Movie>> SearchMoviesAsync(string title)
        {
        return await _context.Movies
            .Where(m => m.Title.Contains(title))
            .ToListAsync();
        }
       public async Task<List<Movie>> FilterMoviesByGenre(string genre)
        {
            return await _context.Movies.Where(m => m.Genre == genre).ToListAsync();
        }

    }
}
