using BlogApp.Domain;

namespace BlogApp.Application.Contracts.Persistence;

public interface IRatingRepository : IGenericRepository<Rating>
{
    Task<Rating> GetByBlogAndRater(int blogId, int raterId);
    IReadOnlyList<Rating> GetByBlog(int blogId);
}