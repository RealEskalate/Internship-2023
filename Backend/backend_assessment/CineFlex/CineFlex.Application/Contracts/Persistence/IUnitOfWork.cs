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
        ITaskCheckListRepository TaskCheckListRepository { get; }
        ITaskRepository TaskRepository  { get; }
        Task<int> Save();
        
    }
}
