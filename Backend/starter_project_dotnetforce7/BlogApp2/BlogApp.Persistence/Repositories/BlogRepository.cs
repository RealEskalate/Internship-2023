using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using Microsoft.EntityFrameworkCore;
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


         public async Task<List<Blog>> GetBlogsWithRate()
        {
            return await _dbContext.Set<Blog>().Include(x => x.Rates).AsNoTracking().ToListAsync();
        }

         public async Task<Blog> Get(int id)
        {
            return await _dbContext.Set<Blog>().Include(x => x.Rates).FirstOrDefaultAsync(b => b.Id == id);
        }

    }
}
