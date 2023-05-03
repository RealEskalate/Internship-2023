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

        IBlogRepository BlogRepository { get; }
        Task Save();
    }
}
