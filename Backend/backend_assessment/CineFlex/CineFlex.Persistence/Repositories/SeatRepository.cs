using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;

namespace CineFlex.Persistence.Repositories;

public class SeatRepository : GenericRepository<Seat>, ISeatRepository
    {
        public SeatRepository(CineFlexDbContex dbContext) : base(dbContext)
        {
        }
    }

