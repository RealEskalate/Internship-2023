using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        I_UserRepository _UserRepository { get; }
        I_IndexRepository _IndexRepository { get; }
        ITagRepository TagRepository {get;}

        IBlogRepository BlogRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IBlogRateRepository BlogRateRepository { get; }
      
        ICommentRepository _CommentRepository { get; }

        Task <int> Save();

    }
}
