using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CineFlex.Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly CineFlexDbContext _context;

        public MovieRepository(CineFlexDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<IReadOnlyList<Movie>> GetMoviesByTitle(string query)
        {
            return await _context.Movies.Where(movie => movie.Title.Contains(query)).ToListAsync();
        }
    }
}