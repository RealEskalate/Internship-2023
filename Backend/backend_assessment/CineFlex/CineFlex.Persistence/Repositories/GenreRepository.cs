using System;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;

namespace CineFlex.Persistence.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly CineFlexDbContex _dbContext;

        public GenreRepository(CineFlexDbContex context) : base(context)
        {
            
            _dbContext = context;
        }

        
    }
}