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

    public async Task<Rating> FindByBlogAndRater(int blogId, int raterId)
    {
        var rating = await _dbContext.Ratings
            .FirstOrDefaultAsync(q => q.BlogId == blogId && q.RaterId == raterId);

        return rating;
    }
}
