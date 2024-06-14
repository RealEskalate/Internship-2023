using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineFlex.Domain;

namespace CineFlex.Application.Contracts.Persistence
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        
    }
}