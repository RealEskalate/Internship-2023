using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using BlogApp.Persistence;
using BlogApp.Persistence.Repositories;

namespace BlogApp.Persistence.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        private readonly BlogAppDbContext _dbContext;

        public BlogRepository(BlogAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Blog>> GetPublishedBlogs()
        {
            return _dbContext.Blogs
                    .Where(blog => blog.Status == PublicationStatus.Published)
                    .ToList();
        }

        public async Task<IList<Blog>> GetUnPublishedBlogs()
        {
            return _dbContext.Blogs
                    .Where(blog => blog.Status == PublicationStatus.NotPublished)
                    .ToList();
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