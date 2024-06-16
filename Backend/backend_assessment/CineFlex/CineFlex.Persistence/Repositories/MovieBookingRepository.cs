using CineFlex.Application.Contracts.Persistence;
using CineFlex.Domain;

namespace CineFlex.Persistence.Repositories;

public class MovieBookingRepository : GenericRepository<MovieBooking>, IMovieBookingRepository
{
    public MovieBookingRepository(CineFlexDbContext dbContext) : base(dbContext)
    {
    }
}