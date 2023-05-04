using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using BlogApp.Persistence;
using BlogApp.Persistence.Repositories;

namespace BlogApp.Persistence.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(BlogAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<Blog>> GetReviewerBlogs(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Blog>> GetUserBlogs(int Id)
        {
            throw new NotImplementedException();
        }
    }
}