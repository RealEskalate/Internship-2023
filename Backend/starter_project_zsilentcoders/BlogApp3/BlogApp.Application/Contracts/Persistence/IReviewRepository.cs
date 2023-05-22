using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Domain;

namespace BlogApp.Application.Contracts.Persistence
{
    public interface IReviewRepository: IGenericRepository<Review>
    {
        Task<IReadOnlyList<Review>> GetAllByReviewerId(int id);
        Task ChangeApprovalStatus(Review review, bool? IsResolved);
    }
}