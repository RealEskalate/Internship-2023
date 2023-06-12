using CineFlex.Application.Contracts.Persistence;
using CineFlex.Persistence;
using CineFlex.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CineFlexDbContex _context;
        private ITaskCheckListRepository _TaskCheckListRepository;

        private ITaskRepository _TaskRepository;
        public UnitOfWork(CineFlexDbContex context)
        {
            _context = context;
        }

        public ITaskCheckListRepository TaskCheckListRepository
        {
            get
            {
                if (_TaskCheckListRepository == null)
                    _TaskCheckListRepository = new TaskCheckListRepository(_context);
                return _TaskCheckListRepository;
            }
        }
        public ITaskRepository TaskRepository
        {
            get
            {
                if (_TaskRepository == null)
                    _TaskRepository = new TaskRepository(_context);
                return _TaskRepository;
            }
        }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
