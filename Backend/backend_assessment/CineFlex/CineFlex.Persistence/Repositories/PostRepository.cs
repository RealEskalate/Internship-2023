using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Persistence;

namespace CineFlex.Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(CineFlexDbContext dbContex) : base(dbContex)
        {

        }
    }
}
