using System;
using System.Collections.Generic;
using System.Linq;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;

namespace BlogApp.Persistence.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        private readonly BlogAppDbContext _dbContext;
        public TagRepository(BlogAppDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
            
        }
    }
}