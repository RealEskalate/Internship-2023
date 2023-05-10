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
        private ITagRepository _tagRepository;
        private IBlogRepository _blogRepository;
        private IReviewRepository _reviewRepository;
        private IBlogRateRepository _blogRateRepository;

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
          public ITagRepository TagRepository { 
            get 
            {
                if (_tagRepository == null)
                    _tagRepository = new TagRepository(_context);
                return _tagRepository; 
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
         public IReviewRepository ReviewRepository { 
            get 
            {
                if (_reviewRepository == null)
                    _reviewRepository = new ReviewRepository(_context);
                return _reviewRepository; 
            } 
         }



        public IBlogRateRepository BlogRateRepository
        {
            get
            {
                if (_blogRateRepository == null)
                    _blogRateRepository = new BlogRateRepository(_context);
                return _blogRateRepository;
            }
        }

        public void Dispose()
        {
            get
            {
                if (_blogRateRepository == null)
                    _blogRateRepository = new BlogRateRepository(_context);
                return _blogRateRepository;
            }
        }
        
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
