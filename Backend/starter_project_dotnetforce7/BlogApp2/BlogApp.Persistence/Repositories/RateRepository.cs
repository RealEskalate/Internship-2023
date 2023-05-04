using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Persistence.Repositories
{
    public class RateRepository : GenericRepository<Rate>, IRateRepository
    {
        private readonly BlogAppDbContext _context;
        public RateRepository(BlogAppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
