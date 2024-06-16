using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private readonly CineFlexDbContex _context;
        public BookingRepository(CineFlexDbContex dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<Booking> Get(int id)
        {
            return await _context.Set<Booking>().Include(x => x.Seats).FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
