using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;

namespace CineFlex.Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly CineFlexDbContex _context;
        public PostRepository(CineFlexDbContex dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
