using CineFlex.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }
        IMovieRepository MovieRepository { get; }
        ICinemaRepository CinemaRepository { get; }
        Task<int> Save();
        
    }
}
