﻿using BlogApp.Application.Contracts.Persistence;
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
        private ICommentRepository _commentRepository;

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
         public ICommentRepository _CommentRepository { 
            get 
            {
                if (_commentRepository== null)
                    _commentRepository = new CommentRepository(_context);
                return _commentRepository; 
            } 
         }

        public I_IndexRepository _IndexRepository { 
            get 
            {
                if (_indexRepository == null)
                    _indexRepository = new _IndexRepository(_context);
                return _indexRepository; 
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
