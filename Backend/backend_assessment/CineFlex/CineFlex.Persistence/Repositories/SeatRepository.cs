using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CineFlex.Persistence.Repositories
{
    public class SeatRepository : GenericRepository<Seat>, ISeatRepository
    {
        private readonly CineFlexDbContex _context;
        public SeatRepository(CineFlexDbContex dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Seat>> GetSeats()
        {
            return await _context.Set<Seat>().Include(x => x.Cinema).AsNoTracking().ToListAsync();
        }
        public async Task<Seat> GetSeat()
        {
            return await _context.Set<Seat>().Include(x => x.Cinema).FirstOrDefaultAsync();
        }

    }
}
