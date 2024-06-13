using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;

namespace CineFlex.Persistence.Repositories;

public class BookingRepository: GenericRepository<Booking>, IBookingRepository
{
    public BookingRepository(CineFlexDbContex dbContext) : base(dbContext)
    {
    }
}