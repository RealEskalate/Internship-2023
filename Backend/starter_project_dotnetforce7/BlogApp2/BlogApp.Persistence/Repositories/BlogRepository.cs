using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using Microsoft.EntityFrameworkCore;

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
            return await _dbContext.Set<Blog>().Include(x => x.Rates).Include(p => p.CoverImage).AsNoTracking().ToListAsync();
        }

         public async Task<Blog> Get(int id)
        {
            return await _dbContext.Set<Blog>().Include(x => x.Rates).Include(p => p.CoverImage).FirstOrDefaultAsync(b => b.Id == id);
        }

    }
}
