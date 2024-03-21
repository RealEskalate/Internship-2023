using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
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
    }
}
