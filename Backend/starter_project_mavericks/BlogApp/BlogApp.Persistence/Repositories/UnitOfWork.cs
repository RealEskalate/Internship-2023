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
        private IRatingRepository _ratingRepository;

        private ICommentRepository commentRepository;

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
         
         public ICommentRepository CommentRepository { 
            get 
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(_context);
                return commentRepository; 
            } 
         }

        public IRatingRepository RatingRepository
        {
            get
            {
                if (_ratingRepository == null)
                    _ratingRepository = new RatingRepository(_context);
                return _ratingRepository;
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
