using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Persistence.Repositories
{
    public class ReviewRepository: GenericRepository<Review>, IReviewRepository
    {
        private readonly BlogAppDbContext _dbContext;

        public ReviewRepository(BlogAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task ChangeApprovalStatus(Review review, bool? IsResolved)
        {
            review.IsResolved = IsResolved;
            _dbContext.Entry(review).State = EntityState.Modified;
        }

        public async Task<IReadOnlyList<Review>> GetAllByReviewerId(int id)
        {
            return await _dbContext.Set<Review>()
                .AsNoTracking()
                .Where(r => r.ReviewerId == id)
                .ToListAsync();
        }
    }
}