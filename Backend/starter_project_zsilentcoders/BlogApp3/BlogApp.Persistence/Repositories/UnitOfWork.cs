using BlogApp.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly BlogAppDbContext _context;

        private I_UserRepository _userRepository;

        public UnitOfWork(BlogAppDbContext context)
        {
            _context = context;
        }

        public I_UserRepository _UserRepository { 
            get 
            {
                if (_userRepository == null)
                    _userRepository = new _UserRepository(_context);
                return _userRepository; 
            } 
         }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
