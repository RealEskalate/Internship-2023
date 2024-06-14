using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.DTOs;
using CineFlex.Domain;
using Microsoft.EntityFrameworkCore;

namespace CineFlex.Persistence.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private readonly CineFlexDbContex _context;
        public BookingRepository(CineFlexDbContex dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Booking>> GetAllWithDetail()
        {
            return await _context.Bookings.Include(bk => bk.Cinema).Include(bk => bk.Movie).Include(bk => bk.Seats).ToListAsync();
        }

        public async Task<Booking> GetBookingDetail(int Id)
        {
            return await _context.Bookings.Include(bk => bk.Cinema).Include(bk=>bk.Movie).Include(bk=>bk.Seats).FirstOrDefaultAsync(tsk => tsk.Id == Id);
        }
    }
}
