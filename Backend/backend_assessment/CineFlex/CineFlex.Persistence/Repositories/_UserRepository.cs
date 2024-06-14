using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
    public class _UserRepository : GenericRepository<User>, I_UserRepository
    {
        private readonly CineFlexDbContex _dbContext;

        public _UserRepository(CineFlexDbContex dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
