using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;

namespace CineFlex.Persistence.Repositories;

public class SeatRepository: GenericRepository<Seat>, ISeatRepository
{
    private readonly CineFlexDbContex _dbContext;
    public SeatRepository(CineFlexDbContex dbContext) : base(dbContext)
    {
    }


    public List<string> GetBookedSeatNumbers()
    {
        List<string> bookedSeatNumbers = _dbContext.Seats
            .Where(s => s.Availability != null) // Assuming BookingId is the foreign key to represent a booked seat
            .Select(s => s.SeatNumber)
            .ToList();

        return bookedSeatNumbers;
    }
}