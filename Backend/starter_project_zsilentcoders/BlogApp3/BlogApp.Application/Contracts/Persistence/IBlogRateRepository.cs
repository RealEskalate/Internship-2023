using BlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Contracts.Persistence
{
    public interface IBlogRateRepository : IGenericRepository<BlogRate>
    {
        public Task<List<BlogRate>> GetBlogRatesByBlog(int id);
        public Task<BlogRate> GetBlogRateByBlogAndRater(int blogId , int raterId);
        public Task<bool> BlogExists(int blogId);    
        public Task<bool> RaterExists(int raterId);

    }
}
