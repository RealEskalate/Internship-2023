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

        private I_IndexRepository _indexRepository;
        private IRateRepository _rateRepository;

        private IBlogRepository _BlogRepository;


        public UnitOfWork(BlogAppDbContext context)
        {
            _context = context;
        }

        public I_IndexRepository _IndexRepository { 
            get 
            {
                if (_indexRepository == null)
                    _indexRepository = new _IndexRepository(_context);
                return _indexRepository; 
            } 
         }

        public IRateRepository RateRepository
        {
            get
            {
                if (_rateRepository == null)
                    _rateRepository = new RateRepository(_context);
                return _rateRepository;
            }
        }
        public IBlogRepository BlogRepository { 
            get 
            {
                if (_BlogRepository == null)
                    _BlogRepository = new BlogRepository(_context);
                return _BlogRepository; 
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
