using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
    public class CinemaRepository : GenericRepository<CinemaEntity>, ICinemaRepository
    {
        public CinemaRepository(CineFlexDbContext dbContext) : base(dbContext)
        {
        }
    }
}
