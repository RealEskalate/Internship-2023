using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Persistence.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        private readonly BlogAppDbContext _dbContext;

        public BlogRepository(BlogAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
