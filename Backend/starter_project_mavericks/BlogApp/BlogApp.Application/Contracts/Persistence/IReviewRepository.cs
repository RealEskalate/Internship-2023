using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Domain;

namespace BlogApp.Application.Contracts.Persistence;

public interface IReviewRepository : IGenericRepository<Review>
{
    Task<Review> GetReviewDetail(int Id);
    Task<List<Review>> GetReviewsByBlogId(int BlogId);
    Task<List<Review>> GetReviewsByUserId(int ReviewerId);
}