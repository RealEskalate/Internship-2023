using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;
using Microsoft.EntityFrameworkCore;

namespace CineFlex.Persistence.Repositories;

public class SeatRepository : GenericRepository<Seat>, ISeatRepository
{
    private readonly CineFlexDbContext _dbContext;

    public SeatRepository(CineFlexDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Seat>> GetByCinemaId(int requestCinemaId)
    {
        return await _dbContext.Seats.Where(seat => seat.CinemaId == requestCinemaId).AsNoTracking().ToListAsync();
    }

    public async Task<IReadOnlyList<Seat>> GetSeatsWithId(IList<int> seatIds)
    {
        return await _dbContext.Seats.Where(seat => seatIds.Contains(seat.Id)).ToListAsync();
    }
}