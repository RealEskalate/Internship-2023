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

    }
}
