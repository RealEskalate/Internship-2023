using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IRatingRepository RatingRepository { get; }
        I_IndexRepository _IndexRepository { get; }
        Task Save();
    }
}
