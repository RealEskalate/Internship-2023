using BlogApp.Domain;

namespace BlogApp.Application.Contracts.Persistence;

public interface IRatingRepository : IGenericRepository<Rating>
{
    Task<Rating> FindByBlogAndRater(int blogId, int raterId);
}