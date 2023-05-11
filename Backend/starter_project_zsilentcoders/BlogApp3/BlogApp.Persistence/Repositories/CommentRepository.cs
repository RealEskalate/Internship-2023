using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;

namespace BlogApp.Persistence.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    private readonly BlogAppDbContext _dbContext;
    public CommentRepository(BlogAppDbContext context) : base(context)
    {
        _dbContext = context;
    }
}
