using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Persistence.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly BlogAppDbContext _dbContext;

        public CommentRepository(BlogAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public IReadOnlyList<Comment> GetByBlog(string blogId)
    {
        var comments = _dbContext.Comments
            .Where(q => q.BlogId == blogId).ToList();

        return comments;
    }
    }
}
