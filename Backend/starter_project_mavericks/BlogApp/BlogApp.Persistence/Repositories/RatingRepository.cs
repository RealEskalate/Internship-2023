using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Persistence.Repositories;
public class RatingRepository : GenericRepository<Rating>, IRatingRepository
{
    private readonly BlogAppDbContext _dbContext;

    public RatingRepository(BlogAppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IReadOnlyList<Rating> GetByBlog(int blogId)
    {
        var ratings = _dbContext.Ratings
            .Where(q => q.BlogId == blogId).ToList();

        return ratings;
    }

    public async Task<Rating> GetByBlogAndRater(int blogId, int raterId)
    {
        var rating = await _dbContext.Ratings
            .FirstOrDefaultAsync(q => q.BlogId == blogId && q.RaterId == raterId);

        return rating;
    }
}
