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
        private IBlogRepository _blogRepository;
        private IReviewRepository _reviewRepository;
        private ITagRepository _tagRepository;

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

        public IRatingRepository RatingRepository
        {
            get
            {
                if (_ratingRepository == null)
                    _ratingRepository = new RatingRepository(_context);
                return _ratingRepository;
            }
        }

        public IBlogRepository BlogRepository{
            get{
                if(_blogRepository == null)
                    _blogRepository = new BlogRepository(_context);
                return _blogRepository;
            }
        }
        public ITagRepository TagRepository

        {
            get
            {
                if (_tagRepository == null)
                    _tagRepository = new TagRepository(_context);
                return _tagRepository;
            }
        }

        public IReviewRepository ReviewRepository
        {
            get
            {
                return _reviewRepository ??= new ReviewRepository(_context);
                
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
