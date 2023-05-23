using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;

namespace CineFlex.Persistence.Repositories;

public class BookingRepository: GenericRepository<Booking>, IBookingRepository
{
    private readonly CineFlexDbContex _context;
    public BookingRepository(CineFlexDbContex dbContext) : base(dbContext)
    {
        _context = dbContext;
    }
}
