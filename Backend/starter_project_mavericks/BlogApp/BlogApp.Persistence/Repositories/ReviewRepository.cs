using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Persistence.Repositories;

public class ReviewRepository : GenericRepository<Review>, IReviewRepository
{
    private readonly BlogAppDbContext _dbContext;
    public ReviewRepository(BlogAppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Review> GetReviewDetail(int Id)
    {
        var review = await _dbContext.Reviews.FirstOrDefaultAsync(r => r.Id==Id);
        return review;
    }

    public async Task<List<Review>> GetReviewsByBlogId(int BlogId)
    {
        var reviews = await _dbContext.Reviews.Where(r => r.BlogId == BlogId).ToListAsync();
        return reviews;
    }

    public async Task<List<Review>> GetReviewsByUserId(string ReviewerId)
    {
        var reviews = await _dbContext.Reviews.Where(r => r.ReviewerId == ReviewerId).ToListAsync();
        return reviews;
    }
}