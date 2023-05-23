using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
    public class SeatRepository : GenericRepository<Seat>, ISeatRepository
    {
        private readonly CineFlexDbContex _dbContext;
        public SeatRepository(CineFlexDbContex dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Seat>> GetSeatsByCinemaID(int CinemaID)
        {
            return _dbContext.Seats.Where(seat => seat.CinemaID == CinemaID).ToList();
        }
    }
}
