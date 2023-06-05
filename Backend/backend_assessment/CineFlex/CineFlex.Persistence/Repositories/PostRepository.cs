using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;

namespace CineFlex.Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>,IPostRepository
    {
        public PostRepository(CineFlexDbContex dbContex):base(dbContex){
            
        }
    }
}