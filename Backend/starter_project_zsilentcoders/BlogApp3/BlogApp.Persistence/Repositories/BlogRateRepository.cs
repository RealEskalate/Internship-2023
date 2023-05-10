using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Persistence.Repositories
{
    public class BlogRateRepository : GenericRepository<BlogRate>,  IBlogRateRepository
    {
        private readonly BlogAppDbContext _dbContext;
        public BlogRateRepository(BlogAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BlogRate>> GetBlogRatesByBlog(int blogId)
        {
            var blogRates = await _dbContext.BlogRates.Where(br => br.BlogId == blogId).ToListAsync();
            return blogRates;
        }


    }
}
