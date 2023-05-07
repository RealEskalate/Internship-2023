using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Domain;

namespace BlogApp.Application.Contracts.Persistence
{
    public interface IReviewRepository: IGenericRepository<_Review>
    {
        Task<IReadOnlyList<_Review>> GetAllByReviewerId(int id);
<<<<<<< HEAD
        Task ChangeApprovalStatus(_Review review, bool? IsResolved);
=======
>>>>>>> 0fef7f1 (fix(Samuel_Abatneh.review): fix review repository issue)
    }
}