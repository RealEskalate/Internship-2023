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
        private IBlogRepository _blogRepository;

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

        public IBlogRepository BlogRepository
        {
            get
            {
                if (_blogRepository == null)
                    _blogRepository = new BlogRepository(_context);
                return _blogRepository;
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
