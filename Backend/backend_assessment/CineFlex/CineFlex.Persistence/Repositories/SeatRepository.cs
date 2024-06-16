using CineFlex.Domain;
using CineFlex.Application.Contracts.Persistence;


namespace CineFlex.Persistence.Repositories
{
    public class SeatRepository : GenericRepository<Seat>, ISeatRepository
    {
        private readonly CineFlexDbContex _dbContext;
        public SeatRepository(CineFlexDbContex dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}