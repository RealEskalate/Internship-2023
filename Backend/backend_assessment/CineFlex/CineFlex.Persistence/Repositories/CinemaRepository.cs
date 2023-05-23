using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;

namespace CineFlex.Persistence.Repositories;

public class CinemaRepository : GenericRepository<CinemaEntity>, ICinemaRepository
{
    public CinemaRepository(CineFlexDbContext dbContext) : base(dbContext)
    {
    }
}