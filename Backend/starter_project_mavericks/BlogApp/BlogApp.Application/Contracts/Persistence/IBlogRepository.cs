using BlogApp.Domain;

namespace BlogApp.Application.Contracts.Persistence
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Task<IList<Blog>> GetReviewerBlogs(int Id);
        Task<IList<Blog>> GetUserBlogs(int Id);
        Task<IList<Blog>> GetPublishedBlogs();
        Task<IList<Blog>> GetUnPublishedBlogs();
    }
}