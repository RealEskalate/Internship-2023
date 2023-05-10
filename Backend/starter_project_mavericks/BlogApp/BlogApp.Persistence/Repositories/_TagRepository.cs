using BlogApp.Application.Contracts.Persistence;
using BlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Persistence.Repositories
{
    public class _TagRepository : GenericRepository<_Tag>, I_TagRepository
    {
        private readonly BlogAppDbContext _dbContext;
        public _TagRepository(BlogAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
